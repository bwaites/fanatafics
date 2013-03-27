Imports DatabaseHelper
Public Class Story
    Inherits HeaderData
#Region " Private Members "
    Private _Title As String = String.Empty
    Private _Summary As String = String.Empty
    Private _MaturityID As Guid = Guid.Empty
    '
    'ADD PRIVATE MEMBERS FOR CHILDREN HERE
    '
    Private WithEvents _StoryChapter As StoryChapterList = Nothing

#End Region

#Region " Public Properties "
    Public Property Title As String
        Get
            Return _Title
        End Get
        Set(value As String)
            If value <> _Title Then
                _Title = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

    Public Property Summary As String
        Get
            Return _Summary
        End Get
        Set(value As String)
            If value <> _Summary Then
                _Summary = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

    Public Property MaturityID As Guid
        Get
            Return _MaturityID
        End Get
        Set(ByVal value As Guid)
            _MaturityID = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property


    '
    'ADD PUBLIC PROPERITES FOR CHILDREN HERE
    '

    

    Public ReadOnly Property Addresses As StoryChapterList
        Get
            If _StoryChapter Is Nothing Then
                _StoryChapter = New StoryChapterList
                _StoryChapter = _StoryChapter.GetByStoryID(MyBase.Id)
            End If
            Return _StoryChapter
        End Get
    End Property

#End Region

#Region " Private Methods "
    Private Function Insert(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStory_INSERT"
            'Add the header data parameters
            MyBase.Initialize(database, Guid.Empty)
            'Add the parameter
            database.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = _Title
            database.Command.Parameters.Add("@Summary", SqlDbType.VarChar).Value = _Summary
            database.Command.Parameters.Add("@MaturityID", SqlDbType.UniqueIdentifier).Value = _MaturityID

            'CHANGE EXECUTE NON QUERY TO EXECUTE NON QUERY WITH TRANSACTION
            database.ExecuteNonQueryWithTransaction()
            'Retrieve the header data values from the command object
            MyBase.Initialize(database.Command)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function Update(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStory_UPDATE"
            'Add the header data parameters
            MyBase.Initialize(database, MyBase.Id)
            'Add the parameter
            database.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = _Title
            database.Command.Parameters.Add("@Summary", SqlDbType.VarChar).Value = _Summary
            database.Command.Parameters.Add("@MaturityID", SqlDbType.UniqueIdentifier).Value = _MaturityID
            'Execute non query
            database.ExecuteNonQueryWithTransaction()
            '
            'CHANGE EXECUTE NON QUERY TO EXECUTE NON QUERY WITH TRANSACTION
            'Retrieve the header data values from the command object
            MyBase.Initialize(database.Command)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function Delete(database As DatabaseHelper.Database) As Boolean

        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStory_DELETE"
            MyBase.Initialize(database, MyBase.Id)
            database.ExecuteNonQueryWithTransaction()
            '
            'DON'T FORGET TO SOFT DELETE THE CHILDREN OF THE PARENT
            '

            MyBase.Initialize(database.Command)
            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function IsValid() As Boolean
        'THESE ARE THE BUSINESS RULES
        'ASSUME TRUE UNLESS A RULE IS BROKEN
        Dim result As Boolean = True

        If _Title = String.Empty Then
            result = False
        End If
        If _Title.Length > 100 Then
            result = False
        End If

        If _Summary = String.Empty Then
            result = False
        End If
        If _Summary.Length > 400 Then
            result = False
        End If

        Return result

    End Function
#End Region

#Region " Public Methods "
    Public Function Save() As Story
        Dim db As New Database(My.Settings.ConnectionName)
        db.BeginTransaction(My.Settings.ConnectionName)

        Dim result As Boolean = True

        If MyBase.IsNew = True AndAlso MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = Insert(db)
        ElseIf MyBase.Deleted = True AndAlso MyBase.IsDirty = True Then
            result = Delete(db)
        ElseIf MyBase.IsNew = False AndAlso MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = Update(db)
        End If

        If result = True Then
            MyBase.IsDirty = False
            MyBase.IsNew = False
        End If
        '
        '
        'Handle the children here'
        '

       

        If result = True AndAlso _StoryChapter.IsSavable = True Then
            result = _StoryChapter.Save(db, MyBase.Id)
        End If
        '
        'Handle the transaction here'
        '
        If result = True Then
            db.EndTransaction()
        Else
            db.RollbackTransaction()
        End If

        Return Me
    End Function
    Public Function IsSavable() As Boolean
        '
        'ADD CHECKS HERE FOR CHILDREN BEING SAVABLE
        '
        If MyBase.IsDirty = True AndAlso IsValid() = True OrElse _StoryChapter.IsSavable = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetById(id As Guid) As Story

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStory_getById"
        db.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()

        If ds.Tables(0).Rows.Count = 1 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            MyBase.Initialize(dr)
            InitializeBusinessData(dr)
            MyBase.IsNew = False
            MyBase.IsDirty = False

            Return Me
        Else
            If ds.Tables(0).Rows.Count = 0 Then
                Throw New Exception(String.Format("Story {0} was not found", id))
            Else
                Throw New Exception(String.Format("Story {0} found multiple records", id))
            End If
        End If

    End Function
    Public Sub InitializeBusinessData(dr As DataRow)
        _Title = dr("Title")
        _Summary = dr("Summary")
        _MaturityID = dr("MaturityID")
    End Sub
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

#End Region

#Region " Construction "

#End Region
End Class

Imports DatabaseHelper
Public Class Story
    Inherits HeaderData
#Region " Private Members "
    Private _Title As String = String.Empty
    Private _Summary As String = String.Empty
    Private _FandomID As Guid = Guid.Empty
    Private _GenreID1 As Guid = Guid.Empty
    Private _GenreID2 As Guid = Guid.Empty
    Private _MaturityID As Guid = Guid.Empty

    '
    'ADD PRIVATE MEMBERS FOR CHILDREN HERE
    '

    'Private WithEvents _storyGenres As StoryGenreList = Nothing
    'Private WithEvents _storyFandoms As StoryFandomList = Nothing
    'Private WithEvents _StorysUsers As UserStoryList = Nothing

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
    Public Property FandomID As Guid
        Get
            Return _FandomID
        End Get
        Set(ByVal value As Guid)
            _FandomID = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property
    Public Property GenreID1 As Guid
        Get
            Return _GenreID1
        End Get
        Set(ByVal value As Guid)
            _GenreID1 = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property
    Public Property GenreID2 As Guid
        Get
            Return _GenreID2
        End Get
        Set(ByVal value As Guid)
            _GenreID2 = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
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

    'Public ReadOnly Property StoryGenres As StoryGenreList
    '    Get
    '        If _storyGenres Is Nothing Then
    '            _storyGenres = New StoryGenreList
    '            _storyGenres = _storyGenres.GetByStoryID(MyBase.Id)
    '        End If
    '        Return _storyGenres
    '    End Get

    'End Property

    'Public ReadOnly Property StoryFandoms As StoryFandomList
    '    Get
    '        If _storyFandoms Is Nothing Then
    '            _storyFandoms = New StoryFandomList
    '            _storyFandoms = _storyFandoms.GetByStoryId(MyBase.Id)
    '        End If
    '        Return _storyFandoms
    '    End Get
    'End Property

    'Public ReadOnly Property StorysUsers As UserStoryList
    '    Get
    '        If _StorysUsers Is Nothing Then
    '            _StorysUsers = New UserStoryList
    '            _StorysUsers = _StorysUsers.GetByStoryID(MyBase.Id)
    '        End If
    '        Return _StorysUsers
    '    End Get
    'End Property


#End Region

#Region " Private Methods "
    Private Function Insert(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStory2_INSERT"
            'Add the header data parameters
            MyBase.Initialize(database, Guid.Empty)
            'Add the parameter
            database.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = _Title
            database.Command.Parameters.Add("@Summary", SqlDbType.VarChar).Value = _Summary
            database.Command.Parameters.Add("@FandomID", SqlDbType.UniqueIdentifier).Value = _FandomID
            database.Command.Parameters.Add("@GenreID1", SqlDbType.UniqueIdentifier).Value = _GenreID1
            database.Command.Parameters.Add("@GenreID2", SqlDbType.UniqueIdentifier).Value = _GenreID2
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
            database.Command.CommandText = "tblStory2_UPDATE"
            'Add the header data parameters
            MyBase.Initialize(database, MyBase.Id)
            'Add the parameter
            database.Command.Parameters.Add("@Title", SqlDbType.VarChar).Value = _Title
            database.Command.Parameters.Add("@Summary", SqlDbType.VarChar).Value = _Summary
            database.Command.Parameters.Add("@FandomID", SqlDbType.UniqueIdentifier).Value = _FandomID
            database.Command.Parameters.Add("@GenreID1", SqlDbType.UniqueIdentifier).Value = _GenreID1
            database.Command.Parameters.Add("@GenreID2", SqlDbType.UniqueIdentifier).Value = _GenreID2
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
            database.Command.CommandText = "tblStory2_DELETE"
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
        If _FandomID = Guid.Empty Then
            result = False
        End If
        If _GenreID1 = Guid.Empty Then
            result = False
        End If
        If _GenreID2 = Guid.Empty Then
            result = False
        End If
        If _MaturityID = Guid.Empty Then
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
        'If result = True AndAlso _storyGenres.IsSavable = True Then
        '    result = _storyGenres.Save(db, MyBase.Id)
        'End If

        'If result = True AndAlso _storyFandoms.IsSavable = True Then
        '    result = _storyFandoms.Save(db, MyBase.Id)
        'End If

        'If result = True AndAlso _StorysUsers.IsSavable = True Then
        '    result = _StorysUsers.Save(db, MyBase.Id)
        'End If
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
        If MyBase.IsDirty = True AndAlso IsValid() = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetById(id As Guid) As Story

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStory2_getById"
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
    Public Function GetAuthorById(id As Guid) As Story

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStory2_getById"
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
        _FandomID = dr("FandomID")
        _GenreID1 = dr("GenreID1")
        _GenreID2 = dr("GenreID2")
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

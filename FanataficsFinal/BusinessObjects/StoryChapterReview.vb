Imports DatabaseHelper
Public Class StoryChapterReview
    Inherits HeaderData

#Region " Private Members "
    Private _ChapterID As Guid = Guid.Empty
    Private _ReviewerName As String = String.Empty
    Private _UserID As Guid = Guid.Empty
    Private _ReviewContent As String = String.Empty


#End Region

#Region " Public Properties "
    Public Property ChapterID As Guid
        Get
            Return _ChapterID
        End Get
        Set(value As Guid)
            If value <> _ChapterID Then
                _ChapterID = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

    Public Property ReviewerName As String
        Get
            Return _ReviewerName
        End Get
        Set(value As String)
            If value <> _ReviewerName Then
                _ReviewerName = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

   Public Property UserID As Guid
        Get
            Return _UserID
        End Get
        Set(value As Guid)
            If value <> _UserID Then
                _UserID = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

    Public Property ReviewContent As String
        Get
            Return _ReviewContent
        End Get
        Set(value As String)
            If value <> _ReviewContent Then
                _ReviewContent = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property


 
#End Region

#Region " Private Methods "
    Private Function Insert(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblStoryChapterReview_INSERT"
            'Add the header data parameters
            MyBase.Initialize(database, Guid.Empty)
            'Add the parameter
            database.Command.Parameters.Add("@ChapterID", SqlDbType.UniqueIdentifier).Value = _ChapterID
            database.Command.Parameters.Add("@ReviewerName", SqlDbType.VarChar).Value = _ReviewerName
            database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID
            database.Command.Parameters.Add("@ReviewContent", SqlDbType.VarChar).Value = _ReviewContent



            'Execute non query
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
            database.Command.CommandText = "tblStoryChapterReview_UPDATE"
            'Add the header data parameters
            MyBase.Initialize(database, MyBase.Id)
            'Add the parameter
            database.Command.Parameters.Add("@ChapterID", SqlDbType.UniqueIdentifier).Value = _ChapterID
            database.Command.Parameters.Add("@ReviewerName", SqlDbType.VarChar).Value = _ReviewerName
            database.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = _UserID
            database.Command.Parameters.Add("@ReviewContent", SqlDbType.VarChar).Value = _ReviewContent


            'Execute non query
            database.ExecuteNonQueryWithTransaction()
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
            database.Command.CommandText = "tblStoryChapterReview_DELETE"
            MyBase.Initialize(database, MyBase.Id)
            database.ExecuteNonQueryWithTransaction()
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


        If _ReviewerName.Trim = String.Empty Then
            result = False
        End If
        If _ReviewerName.Length > 30 Then
            result = False
        End If

        

        If _ReviewContent.Trim = String.Empty Then
            result = False
        End If

        If _ReviewContent.Length > 12 Then
            result = False
        End If

        If _UserID = Guid.Empty AndAlso _ReviewerName.Trim = String.Empty Then
            result = False
        End If

        Return result

    End Function
#End Region

#Region " Public Methods "
    Public Function Save(database As Database, parentId As Guid) As StoryChapterReview

        _ChapterID = parentId

        Dim result As Boolean = True

        If MyBase.IsNew = True AndAlso MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = Insert(database)
        ElseIf MyBase.Deleted = True AndAlso MyBase.IsDirty = True Then
            result = Delete(database)
        ElseIf MyBase.IsNew = False AndAlso MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = Update(database)
        End If

        If result = True Then
            MyBase.IsDirty = False
            MyBase.IsNew = False
        End If

        Return Me
    End Function
    Public Function IsSavable() As Boolean
        If MyBase.IsDirty = True AndAlso IsValid() = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetById(id As Guid) As StoryChapterReview

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStoryChapterReview_getById"
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
                Throw New Exception(String.Format("Chapter Review {0} was not fount", id))
            Else
                Throw New Exception(String.Format("Chapter Review {0} found multiple records", id))
            End If
        End If

    End Function
    Public Sub InitializeBusinessData(dr As DataRow)
        _ChapterID = dr("ChapterID")
        _ReviewerName = dr("ReviewerName")
        _UserID = dr("UserID")
        _ReviewContent = dr("ReviewContent")


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

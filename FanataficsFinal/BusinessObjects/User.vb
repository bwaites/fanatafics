Imports DatabaseHelper
Public Class User
    Inherits HeaderData
#Region " Private Members "
    Private _UserName As String = String.Empty
    Private _Password As String = String.Empty
    Private _Email As String = String.Empty
    Private _SecurityQuestion As String = String.Empty
    Private _SecurityAnswer As String = String.Empty
    Private _StoryAmount As Integer = 0

    '
    'ADD PRIVATE MEMBERS FOR CHILDREN HERE
    '
    

#End Region

#Region " Public Properties "
    Public Property UserName As String
        Get
            Return _UserName
        End Get
        Set(value As String)
            If value <> _UserName Then
                _UserName = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

    Public Property Password As String
        Get
            Return _Password
        End Get
        Set(value As String)
            If value <> _Password Then
                _Password = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property

    Public Property Email As String
        Get
            Return _Email
        End Get
        Set(ByVal value As String)
            _Email = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property

    Public Property SecurityQuestion As String
        Get
            Return _SecurityQuestion
        End Get
        Set(ByVal value As String)
            _SecurityQuestion = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property

    Public Property SecurityAnswer As String
        Get
            Return _SecurityAnswer
        End Get
        Set(ByVal value As String)
            _SecurityAnswer = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property

    Public Property StoryAmount As Integer
        Get
            Return _StoryAmount
        End Get
        Set(ByVal value As Integer)
            _StoryAmount = value
            MyBase.IsDirty = True
            'Raise event if savable
            RaiseEvent evtIsSavable(IsSavable)
        End Set
    End Property
    '
    'ADD PUBLIC PROPERITES FOR CHILDREN HERE
    '


#End Region

#Region " Private Methods "
    Private Function Insert(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblUser_INSERT"
            'Add the header data parameters
            MyBase.Initialize(database, Guid.Empty)
            'Add the parameter
            database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _UserName
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password
            database.Command.Parameters.Add("@Email", SqlDbType.VarChar).Value = _Email
            database.Command.Parameters.Add("@SecurityQuestion", SqlDbType.VarChar).Value = _SecurityQuestion
            database.Command.Parameters.Add("@SecurityAnswer", SqlDbType.VarChar).Value = _SecurityAnswer
            database.Command.Parameters.Add("@StoryAmount", SqlDbType.Int).Value = _StoryAmount

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
            database.Command.CommandText = "tblUser_UPDATE"
            'Add the header data parameters
            MyBase.Initialize(database, MyBase.Id)
            'Add the parameter
            database.Command.Parameters.Add("@UserName", SqlDbType.VarChar).Value = _UserName
            database.Command.Parameters.Add("@Password", SqlDbType.VarChar).Value = _Password
            database.Command.Parameters.Add("@Email", SqlDbType.UniqueIdentifier).Value = _Email
            database.Command.Parameters.Add("@SecurityQuestion", SqlDbType.VarChar).Value = _SecurityQuestion
            database.Command.Parameters.Add("@SecurityAnswer", SqlDbType.VarChar).Value = _SecurityAnswer
            database.Command.Parameters.Add("@StoryAmount", SqlDbType.Int).Value = _StoryAmount
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
            database.Command.CommandText = "tblUser_DELETE"
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

        If _UserName.Trim = String.Empty Then
            result = False
        End If
        If _UserName.Length > 20 Then
            result = False
        End If

        If _Password.Trim = String.Empty Then
            result = False
        End If
        If _Password.Length > 15 Then
            result = False
        End If

        If _SecurityQuestion.Trim = String.Empty Then
            result = False
        End If

        If _SecurityQuestion.Length > 100 Then
            result = False
        End If

        If _SecurityAnswer.Trim = String.Empty Then
            result = False
        End If

        If _SecurityAnswer.Length > 100 Then
            result = False
        End If



        Return result

    End Function
#End Region

#Region " Public Methods "
    Public Function Save() As User
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
        If MyBase.IsDirty = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetById(id As String) As User

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
                Throw New Exception(String.Format("User {0} was not found", id))
            Else
                Throw New Exception(String.Format("User {0} found multiple records", id))
            End If
        End If

    End Function
    Public Sub InitializeBusinessData(dr As DataRow)
        _UserName = dr("UserName")
        _Password = dr("Password")
        _Email = dr("Email")
        _SecurityQuestion = dr("SecurityQuestion")
        _SecurityAnswer = dr("SecurityAnswer")
        _StoryAmount = dr("StoryAmount")
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

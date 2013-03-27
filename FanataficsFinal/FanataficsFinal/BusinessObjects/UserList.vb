Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper
Imports DataTypeHelper
Public Class UserList
#Region " Private Members "
    Private WithEvents _List As New BindingList(Of User)
    Private _Criteria As Criteria
#End Region

#Region " Public Properties "

    Public ReadOnly Property List As BindingList(Of User)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property UserName As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("UserName")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property Password As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("Password")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property Email As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("Email")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property SecurityQuestion As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("SecurityQuestion")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property SecurityAnswer As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("SecurityAnswer")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property StoryAmount As Integer
        Set(value As Integer)
            If value <> -1 Then
                _Criteria.Fields.Add("StoryAmount")
                _Criteria.Values.Add(value.ToString)
                _Criteria.Types.Add(Type.DataType.String_Contains)
            End If
        End Set
    End Property

#End Region



#Region " Private Methods "


#End Region

#Region " Public Methods "
    Public Function Save() As UserList
        Dim result As Boolean = True
        For Each u As User In _List
            If u.IsSavable = True Then
                u = u.Save
                If u.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        'DONT FORGET TO RETURN THE RESULT
        Return Me
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each u As User In _List
            If u.IsSavable = True Then
                result = True
                Exit For
            End If
        Next
        'DONT FORGET TO RETURN THE RESULT
        Return result
    End Function

    Public Function Search() As UserList
        'crease an instance of the databse class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim u As New User
            u.Initialize(dr)
            u.InitializeBusinessData(dr)
            u.IsNew = False
            u.IsDirty = False
            _List.Add(u)
            AddHandler u.evtIsSavable, AddressOf UserList_evtIsSavable
        Next
        Return Me
    End Function
#End Region

#Region " Public Events "
    Public Delegate Sub eIsSavable(ByVal savable As Boolean)
    Public Event evtIsSavable As eIsSavable
#End Region

#Region " Public Event Handlers "
    Private Sub UserList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New User
        AddHandler CType(e.NewObject, User).evtIsSavable, AddressOf UserList_evtIsSavable
    End Sub

#End Region

#Region " Construction "
    Public Sub New()
        _Criteria = New Criteria
        _Criteria.TableName = "tblUser"
    End Sub
#End Region
End Class

Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper

Public Class StoryList

#Region " Private Members "
    Private WithEvents _List As New BindingList(Of Story)
    Private _Criteria As Criteria
#End Region

#Region " Public Properties "

    Public ReadOnly Property List As BindingList(Of Story)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property Title As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("Title")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property Summary As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("Summary")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property MaturityID As Guid
        Set(value As Guid)
            If value <> Guid.Empty Then
                _Criteria.Fields.Add("MaturityLevel")
                _Criteria.Values.Add(value.ToString)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

#End Region

#Region " Private Methods "


#End Region

#Region " Public Methods "
    Public Function Save() As StoryList
        Dim result As Boolean = True
        For Each s As Story In _List
            If s.IsSavable = True Then
                s = s.Save
                If s.IsNew = True Then
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
        For Each s As Story In _List
            If s.IsSavable = True Then
                result = True
                Exit For
            End If
        Next
        'DONT FORGET TO RETURN THE RESULT
        Return result
    End Function

    Public Function Search() As StoryList
        'creates an instance of the database class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim s As New Story
            s.Initialize(dr)
            s.InitializeBusinessData(dr)
            s.IsNew = False
            s.IsDirty = False
            _List.Add(s)
            AddHandler s.evtIsSavable, AddressOf StoryList_evtIsSavable
        Next
        Return Me
    End Function

    Public Function GetByFandomID(id As Guid) As StoryList
        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStoryFandom_getByFandomID"
        db.Command.Parameters.Add("@FandomID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim s As New Story()
            s.Initialize(dr)
            s.InitializeBusinessData(dr)
            s.IsNew = False
            s.IsDirty = False

            AddHandler s.evtIsSavable, AddressOf StoryList_evtIsSavable

            _List.Add(s)
        Next

        Return Me
    End Function

    Public Function GetByUserID(id As Guid) As StoryList
        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStory_getByUserID"
        db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim s As New Story()
            s.Initialize(dr)
            s.InitializeBusinessData(dr)
            s.IsNew = False
            s.IsDirty = False

            AddHandler s.evtIsSavable, AddressOf StoryList_evtIsSavable

            _List.Add(s)
        Next

        Return Me
    End Function
#End Region

#Region " Public Events "
    Public Delegate Sub eIsSavable(ByVal savable As Boolean)
    Public Event evtIsSavable As eIsSavable
#End Region

#Region " Public Event Handlers "
    Private Sub StoryList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Story
        AddHandler CType(e.NewObject, Story).evtIsSavable, AddressOf StoryList_evtIsSavable
    End Sub

#End Region

#Region " Construction "
    Public Sub New()
        _Criteria = New Criteria
        _Criteria.TableName = "tblStory"
    End Sub
#End Region

End Class

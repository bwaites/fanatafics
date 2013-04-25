Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper
Public Class ChapterList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Chapter)
    Private _Criteria As Criteria
#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Chapter)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property StoryID As Guid
        Set(value As Guid)
            If value <> Guid.Empty Then
                _Criteria.Fields.Add("StoryID")
                _Criteria.Values.Add(value.ToString)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
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

    Public WriteOnly Property ChapterContent As String
        Set(value As String)
            If value <> String.Empty Then
                _Criteria.Fields.Add("ChapterContent")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property ChapterOrder As Integer
        Set(value As Integer)
            If value <> 0 Then
                _Criteria.Fields.Add("ChapterOrder")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByStoryID(id As Guid) As ChapterList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblChapter_getByStoryID"
        db.Command.Parameters.Add("@StoryID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sc As New Chapter()
            sc.Initialize(dr)
            sc.InitializeBusinessData(dr)
            sc.IsNew = False
            sc.IsDirty = False

            AddHandler sc.evtIsSavable, AddressOf ChapterList_evtIsSavable

            _List.Add(sc)
        Next

        Return Me

    End Function

    Public Function Save() As ChapterList
        Dim result As Boolean = True
        For Each sc As Chapter In _List
            If sc.IsSavable = True Then
                sc = sc.Save
                If sc.IsNew = True Then
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
        For Each sc As Chapter In _List
            If sc.IsSavable() = True Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function

    Public Function Search() As ChapterList
        'crease an instance of the database class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sc As New Chapter
            sc.Initialize(dr)
            sc.InitializeBusinessData(dr)
            sc.IsNew = False
            sc.IsDirty = False
            _List.Add(sc)
            AddHandler sc.evtIsSavable, AddressOf ChapterList_evtIsSavable
        Next
        Return Me
    End Function
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

    Private Sub ChapterList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Chapter
        AddHandler CType(e.NewObject, Chapter).evtIsSavable, AddressOf ChapterList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

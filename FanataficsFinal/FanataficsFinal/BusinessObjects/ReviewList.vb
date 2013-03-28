Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper
Public Class ReviewList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Review)
    Private _Criteria As Criteria
#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Review)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property ChapterID As Guid
        Set(value As Guid)
            If value <> Guid.Empty Then
                _Criteria.Fields.Add("ChapterID")
                _Criteria.Values.Add(value.ToString)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property ReviewerName As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("ReviewerName")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property UserID As Guid
        Set(value As Guid)
            If value <> Guid.Empty Then
                _Criteria.Fields.Add("UserID")
                _Criteria.Values.Add(value.ToString)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)

            End If
        End Set
    End Property

    Public WriteOnly Property ReviewContent As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("ReviewContent")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByChapterID(id As Guid) As ReviewList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblReview_getByChapterID"
        db.Command.Parameters.Add("@ChapterID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim scr As New Review()
            scr.Initialize(dr)
            scr.InitializeBusinessData(dr)
            scr.IsNew = False
            scr.IsDirty = False

            AddHandler scr.evtIsSavable, AddressOf ReviewList_evtIsSavable

            _List.Add(scr)
        Next

        Return Me

    End Function

    Public Function Save() As ReviewList
        Dim result As Boolean = True
        For Each scr As Review In _List
            If scr.IsSavable = True Then
                scr = scr.Save
                If scr.IsNew = True Then
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
        For Each scr As Review In _List
            If scr.IsSavable() = True Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function

    Public Function Search() As ReviewList
        'crease an instance of the databse class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim scr As New Review
            scr.Initialize(dr)
            scr.InitializeBusinessData(dr)
            scr.IsNew = False
            scr.IsDirty = False
            _List.Add(scr)
            AddHandler scr.evtIsSavable, AddressOf ReviewList_evtIsSavable
        Next
        Return Me
    End Function
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

    Private Sub ReviewList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Review
        AddHandler CType(e.NewObject, Review).evtIsSavable, AddressOf ReviewList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

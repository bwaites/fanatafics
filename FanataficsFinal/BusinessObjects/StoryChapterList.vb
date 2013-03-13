Imports System.ComponentModel
Imports DatabaseHelper
Public Class StoryChapterList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of StoryChapter)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of StoryChapter)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByStoryID(id As Guid) As StoryChapterList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStoryChapter_getByStoryID"
        db.Command.Parameters.Add("@StoryID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sc As New StoryChapter()
            sc.Initialize(dr)
            sc.InitializeBusinessData(dr)
            sc.IsNew = False
            sc.IsDirty = False

            AddHandler sc.evtIsSavable, AddressOf StoryChapterList_evtIsSavable

            _List.Add(sc)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each sc As StoryChapter In _List
            If sc.IsSavable = True Then
                sc = sc.Save(database, parentId)
                If sc.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each sc As StoryChapter In _List
            If sc.IsSavable() = True Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

    Private Sub StoryChapterList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StoryChapter
        AddHandler CType(e.NewObject, StoryChapter).evtIsSavable, AddressOf StoryChapterList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

Imports System.ComponentModel
Imports DatabaseHelper
Public Class StoryChapterReviewList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of StoryChapterReview)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of StoryChapterReview)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByChapterID(id As Guid) As StoryChapterReviewList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStoryChapterReview_getByChapterID"
        db.Command.Parameters.Add("@ChapterID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim scr As New StoryChapterReview()
            scr.Initialize(dr)
            scr.InitializeBusinessData(dr)
            scr.IsNew = False
            scr.IsDirty = False

            AddHandler scr.evtIsSavable, AddressOf StoryChapterReviewList_evtIsSavable

            _List.Add(scr)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each scr As StoryChapterReview In _List
            If scr.IsSavable = True Then
                scr = scr.Save(database, parentId)
                If scr.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each scr As StoryChapterReview In _List
            If scr.IsSavable() = True Then
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

    Private Sub StoryChapterReviewList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StoryChapterReview
        AddHandler CType(e.NewObject, StoryChapterReview).evtIsSavable, AddressOf StoryChapterReviewList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

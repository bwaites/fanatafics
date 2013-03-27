Imports System.ComponentModel
Imports DatabaseHelper
Public Class UserFavStoryList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of UserFavStory)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of UserFavStory)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByUserID(id As Guid) As UserFavStoryList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblUserFavStory_getByUserID"
        db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim ufs As New UserFavStory()
            ufs.Initialize(dr)
            ufs.InitializeBusinessData(dr)
            ufs.IsNew = False
            ufs.IsDirty = False

            AddHandler ufs.evtIsSavable, AddressOf UserFavStoryList_evtIsSavable

            _List.Add(ufs)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each ufs As UserFavStory In _List
            If ufs.IsSavable = True Then
                ufs = ufs.Save(database, parentId)
                If ufs.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each ufs As UserFavStory In _List
            If ufs.IsSavable() = True Then
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

    Private Sub UserFavStoryList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New UserFavStory
        AddHandler CType(e.NewObject, UserFavStory).evtIsSavable, AddressOf UserFavStoryList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

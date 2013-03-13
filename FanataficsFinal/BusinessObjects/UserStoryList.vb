Imports System.ComponentModel
Imports DatabaseHelper
Public Class UserStoryList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of UserStory)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of UserStory)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByUserID(id As Guid) As UserStoryList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblUserStory_getByUserID"
        db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim us As New UserStory()
            us.Initialize(dr)
            us.InitializeBusinessData(dr)
            us.IsNew = False
            us.IsDirty = False

            AddHandler us.evtIsSavable, AddressOf UserStoryList_evtIsSavable

            _List.Add(us)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each us As UserStory In _List
            If us.IsSavable = True Then
                us = us.Save(database, parentId)
                If us.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each us As UserStory In _List
            If us.IsSavable() = True Then
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

    Private Sub UserStoryList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New UserStory
        AddHandler CType(e.NewObject, UserStory).evtIsSavable, AddressOf UserStoryList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

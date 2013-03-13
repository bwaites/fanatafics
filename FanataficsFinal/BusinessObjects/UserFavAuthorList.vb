Imports System.ComponentModel
Imports DatabaseHelper
Public Class UserFavAuthorList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of UserFavAuthor)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of UserFavAuthor)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByUserID(id As Guid) As UserFavAuthorList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblUserFavAuthor_getByUserID"
        db.Command.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim ufa As New UserFavAuthor()
            ufa.Initialize(dr)
            ufa.InitializeBusinessData(dr)
            ufa.IsNew = False
            ufa.IsDirty = False

            AddHandler ufa.evtIsSavable, AddressOf UserFavAuthorList_evtIsSavable

            _List.Add(ufa)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each ufa As UserFavAuthor In _List
            If ufa.IsSavable = True Then
                ufa = ufa.Save(database, parentId)
                If ufa.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each ufa As UserFavAuthor In _List
            If ufa.IsSavable() = True Then
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

    Private Sub UserFavAuthorList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New UserFavAuthor
        AddHandler CType(e.NewObject, UserFavAuthor).evtIsSavable, AddressOf UserFavAuthorList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

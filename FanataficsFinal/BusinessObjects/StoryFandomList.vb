Imports System.ComponentModel
Imports DatabaseHelper
Public Class StoryFandomList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of StoryFandom)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of StoryFandom)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByFandomID(id As Guid) As StoryFandomList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStoryFandom_getByFandomID"
        db.Command.Parameters.Add("@FandomID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sf As New StoryFandom()
            sf.Initialize(dr)
            sf.InitializeBusinessData(dr)
            sf.IsNew = False
            sf.IsDirty = False

            AddHandler sf.evtIsSavable, AddressOf StoryFandomList_evtIsSavable

            _List.Add(sf)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each sf As StoryFandom In _List
            If sf.IsSavable = True Then
                sf = sf.Save(database, parentId)
                If sf.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each sf As StoryFandom In _List
            If sf.IsSavable() = True Then
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

    Private Sub StoryFandomList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StoryFandom
        AddHandler CType(e.NewObject, StoryFandom).evtIsSavable, AddressOf StoryFandomList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

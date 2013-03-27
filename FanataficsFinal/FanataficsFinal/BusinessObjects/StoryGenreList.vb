Imports System.ComponentModel
Imports DatabaseHelper
Public Class StoryGenreList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of StoryGenre)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of StoryGenre)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByGenreID(id As Guid) As StoryGenreList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblStoryGenre_getByGenreID"
        db.Command.Parameters.Add("@GenreID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sg As New StoryGenre()
            sg.Initialize(dr)
            sg.InitializeBusinessData(dr)
            sg.IsNew = False
            sg.IsDirty = False

            AddHandler sg.evtIsSavable, AddressOf StoryGenreList_evtIsSavable

            _List.Add(sg)
        Next

        Return Me

    End Function

    Public Function Save(database As Database, parentId As Guid) As Boolean
        Dim result As Boolean = True
        For Each sg As StoryGenre In _List
            If sg.IsSavable = True Then
                sg = sg.Save(database, parentId)
                If sg.IsNew = True Then
                    result = False
                    Exit For
                End If
            End If
        Next
        Return result
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each sg As StoryGenre In _List
            If sg.IsSavable() = True Then
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

    Private Sub StoryGenreList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New StoryGenre
        AddHandler CType(e.NewObject, StoryGenre).evtIsSavable, AddressOf StoryGenreList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

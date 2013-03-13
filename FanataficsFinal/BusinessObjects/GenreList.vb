Imports System.ComponentModel
Imports DatabaseHelper
Public Class GenreList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Genre)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Genre)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetAll() As GenreList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblGenre_getAll"
        ds = db.ExecuteQuery()

        Dim blank As New Genre
        blank.Id = Guid.Empty
        blank.GenreType = String.Empty

        _List.Add(blank)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim g As New Genre()
            g.Initialize(dr)
            g.InitializeBusinessData(dr)
            g.IsNew = False
            g.IsDirty = False

            AddHandler g.evtIsSavable, AddressOf GenreList_evtIsSavable

            _List.Add(g)
        Next

        Return Me

    End Function

    Public Function Save() As GenreList
        For Each g As Genre In _List
            If g.IsSavable = True Then
                g = g.Save()
                If g.IsDirty = False Then
                    g = g.Save()
                End If
            End If
        Next
        Return Me
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each g As Genre In _List
            If g.IsSavable() = True Then
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

    Private Sub GenreList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Genre
        AddHandler CType(e.NewObject, Genre).evtIsSavable, AddressOf GenreList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

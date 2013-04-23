Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper

Public Class GenreList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Genre)
    Private _Criteria As Criteria

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Genre)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property GenreType As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("GenreType")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
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
        Dim result As Boolean = True
        For Each g As Genre In _List
            If g.IsSavable = True Then
                g = g.Save
                If g.IsNew = True Then
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
        For Each g As Genre In _List
            If g.IsSavable() = True Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function
    Public Function Search() As GenreList
        'crease an instance of the databse class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim g As New Genre
            g.Initialize(dr)
            g.InitializeBusinessData(dr)
            g.IsNew = False
            g.IsDirty = False
            _List.Add(g)
            AddHandler g.evtIsSavable, AddressOf GenreList_evtIsSavable
        Next
        Return Me
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

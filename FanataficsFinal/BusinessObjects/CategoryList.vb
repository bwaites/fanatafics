Imports System.ComponentModel
Imports DatabaseHelper
Public Class CategoryList

#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Category)

#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Category)
        Get
            Return _List
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetAll() As CategoryList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblCategory_getAll"
        ds = db.ExecuteQuery()

        Dim blank As New Category
        blank.Id = Guid.Empty
        blank.Type = String.Empty

        _List.Add(blank)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim c As New Category()
            c.Initialize(dr)
            c.InitializeBusinessData(dr)
            c.IsNew = False
            c.IsDirty = False

            AddHandler c.evtIsSavable, AddressOf CategoryList_evtIsSavable

            _List.Add(c)
        Next

        Return Me

    End Function

    Public Function Save() As CategoryList
        For Each c As Category In _List
            If c.IsSavable = True Then
                c = c.Save()
                If c.IsDirty = False Then
                    c = c.Save()
                End If
            End If
        Next
        Return Me
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each c As Category In _List
            If c.IsSavable() = True Then
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

    Private Sub CategoryList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Category
        AddHandler CType(e.NewObject, Category).evtIsSavable, AddressOf CategoryList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

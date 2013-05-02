Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper

Public Class MaturityList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Maturity)
    Private _Criteria As New Criteria
#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Maturity)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property MaturityLevel As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("MaturityLevel")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property
#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetAll() As MaturityList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblMaturity_getAll"
        ds = db.ExecuteQuery()

        Dim blank As New Maturity
        blank.Id = Guid.Empty
        blank.MaturityLevel = String.Empty

        _List.Add(blank)

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim m As New Maturity()
            m.Initialize(dr)
            m.InitializeBusinessData(dr)
            m.IsNew = False
            m.IsDirty = False

            AddHandler m.evtIsSavable, AddressOf MaturityList_evtIsSavable

            _List.Add(m)
        Next

        Return Me

    End Function

    Public Function Save() As MaturityList
        For Each m As Maturity In _List
            If m.IsSavable = True Then
                m = m.Save()
                If m.IsDirty = False Then
                    m = m.Save()
                End If
            End If
        Next
        Return Me
    End Function

    Public Function IsSavable() As Boolean
        Dim result As Boolean = False
        For Each m As Maturity In _List
            If m.IsSavable() = True Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function

    Public Function Search() As MaturityList
        'crease an instance of the databse class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim m As New Maturity
            m.Initialize(dr)
            m.InitializeBusinessData(dr)
            m.IsNew = False
            m.IsDirty = False
            _List.Add(m)
            AddHandler m.evtIsSavable, AddressOf MaturityList_evtIsSavable
        Next
        Return Me
    End Function
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

    Private Sub MaturityList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Maturity
        AddHandler CType(e.NewObject, Maturity).evtIsSavable, AddressOf MaturityList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

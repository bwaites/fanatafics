Imports System.ComponentModel
Imports DatabaseHelper
Imports SQLHelper
Public Class FandomList
#Region " Private Members "

    Private WithEvents _List As New BindingList(Of Fandom)
    Private _Criteria As Criteria
#End Region

#Region " Public Properties "

    Public ReadOnly Property List() As BindingList(Of Fandom)
        Get
            Return _List
        End Get
    End Property

    Public WriteOnly Property FandomName As String
        Set(value As String)
            If value.Trim <> String.Empty Then
                _Criteria.Fields.Add("FandomName")
                _Criteria.Values.Add(value)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

    Public WriteOnly Property CategoryID As Guid
        Set(value As Guid)
            If value <> Guid.Empty Then
                _Criteria.Fields.Add("CategoryID")
                _Criteria.Values.Add(value.ToString)
                _Criteria.Types.Add(DataTypeHelper.Type.DataType.String_Contains)
            End If
        End Set
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "



    Public Function GetByFandomID(id As Guid) As FandomList

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblFandom_getByFandomID"
        db.Command.Parameters.Add("@FandomID", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()


        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sf As New Fandom()
            sf.Initialize(dr)
            sf.InitializeBusinessData(dr)
            sf.IsNew = False
            sf.IsDirty = False

            AddHandler sf.evtIsSavable, AddressOf FandomList_evtIsSavable

            _List.Add(sf)
        Next

        Return Me

    End Function

    Public Function Save() As FandomList
        Dim result As Boolean = True
        For Each sf As Fandom In _List
            If sf.IsSavable = True Then
                sf = sf.Save
                If sf.IsNew = True Then
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
        For Each sf As Fandom In _List
            If sf.IsSavable() = True Then
                result = True
                Exit For
            End If
        Next
        Return result
    End Function

    Public Function Search() As FandomList
        'crease an instance of the databse class
        Dim database As New Database(My.Settings.ConnectionName)
        Dim ds As New DataSet

        database.ConnectionName = My.Settings.ConnectionName
        database.Command.CommandType = CommandType.Text
        database.Command.CommandText = SQLHelper.Builder.Build(_Criteria)

        ds = database.ExecuteQuery

        For Each dr As DataRow In ds.Tables(0).Rows
            Dim sf As New Fandom
            sf.Initialize(dr)
            sf.InitializeBusinessData(dr)
            sf.IsNew = False
            sf.IsDirty = False
            _List.Add(sf)
            AddHandler sf.evtIsSavable, AddressOf FandomList_evtIsSavable
        Next
        Return Me
    End Function
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

    Private Sub FandomList_evtIsSavable(savable As Boolean)
        RaiseEvent evtIsSavable(savable)
    End Sub

    Private Sub _List_AddingNew(sender As Object, e As System.ComponentModel.AddingNewEventArgs) Handles _List.AddingNew
        e.NewObject = New Fandom
        AddHandler CType(e.NewObject, Fandom).evtIsSavable, AddressOf FandomList_evtIsSavable
    End Sub

#End Region

#Region " Construction "

#End Region
End Class

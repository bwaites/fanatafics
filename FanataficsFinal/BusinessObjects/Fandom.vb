﻿Imports DatabaseHelper
Public Class Fandom
    Inherits HeaderData

#Region " Private Members "
    Private _FandomName As String = String.Empty
    Private _CategoryID As Guid = Guid.Empty

#End Region

#Region " Public Properties "
    Public Property FandomName As String
        Get
            Return _FandomName
        End Get
        Set(value As String)
            If value <> _FandomName Then
                _FandomName = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property



    Public Property CategoryID As Guid
        Get
            Return _CategoryID
        End Get
        Set(value As Guid)
            If value <> _CategoryID Then
                _CategoryID = value
                MyBase.IsDirty = True
                'Raise an Event here to notify
                'if the object is savable
                RaiseEvent evtIsSavable(IsSavable)
            End If
        End Set
    End Property
#End Region

#Region " Private Methods "
    Private Function Insert(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblFandom_INSERT"
            'Add the header data parameters
            MyBase.Initialize(database, Guid.Empty)
            'Add the parameter
            database.Command.Parameters.Add("@FandomName", SqlDbType.VarChar).Value = _FandomName

            database.Command.Parameters.Add("@StoryID", SqlDbType.UniqueIdentifier).Value = _CategoryID


            'Execute non query
            database.ExecuteNonQueryWithTransaction()
            'Retrieve the header data values from the command object
            MyBase.Initialize(database.Command)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function Update(database As DatabaseHelper.Database) As Boolean

        Try
            'Setting up the Command object
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblFandom_UPDATE"
            'Add the header data parameters
            MyBase.Initialize(database, MyBase.Id)
            'Add the parameter
            database.Command.Parameters.Add("@FandomName", SqlDbType.VarChar).Value = _FandomName

            database.Command.Parameters.Add("@StoryID", SqlDbType.UniqueIdentifier).Value = _CategoryID

            'Execute non query
            database.ExecuteNonQueryWithTransaction()
            'Retrieve the header data values from the command object
            MyBase.Initialize(database.Command)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function Delete(database As DatabaseHelper.Database) As Boolean

        Try
            database.Command.Parameters.Clear()
            database.Command.CommandType = CommandType.StoredProcedure
            database.Command.CommandText = "tblFandom_DELETE"
            MyBase.Initialize(database, MyBase.Id)
            database.ExecuteNonQueryWithTransaction()
            MyBase.Initialize(database.Command)

            Return True
        Catch ex As Exception
            Return False
        End Try

    End Function
    Private Function IsValid() As Boolean
        'THESE ARE THE BUSINESS RULES
        'ASSUME TRUE UNLESS A RULE IS BROKEN
        Dim result As Boolean = True


        If _FandomName = String.Empty Then
            result = False
        End If
        If _CategoryID = Guid.Empty Then
            result = False
        End If

        Return result

    End Function
#End Region

#Region " Public Methods "
    Public Function Save() As Fandom
        Dim db As New Database(My.Settings.ConnectionName)
        db.BeginTransaction(My.Settings.ConnectionName)

        Dim result As Boolean = True

        If MyBase.IsNew = True AndAlso MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = Insert(db)
        ElseIf MyBase.Deleted = True AndAlso MyBase.IsDirty = True Then
            result = Delete(db)
        ElseIf MyBase.IsNew = False AndAlso MyBase.IsDirty = True AndAlso IsValid() = True Then
            result = Update(db)
        End If

        If result = True Then
            MyBase.IsDirty = False
            MyBase.IsNew = False
        End If
        '
        '
        'Handle the children here'
        '




        '
        'Handle the transaction here'
        '
        If result = True Then
            db.EndTransaction()
        Else
            db.RollbackTransaction()
        End If

        Return Me
    End Function
    Public Function IsSavable() As Boolean
        If MyBase.IsDirty = True AndAlso IsValid() = True Then
            Return True
        Else
            Return False
        End If
    End Function
    Public Function GetById(id As Guid) As Fandom

        Dim db As New Database(My.Settings.ConnectionName)
        Dim ds As DataSet = Nothing
        db.Command.CommandType = CommandType.StoredProcedure
        db.Command.CommandText = "tblFandom_getById"
        db.Command.Parameters.Add("@Id", SqlDbType.UniqueIdentifier).Value = id
        ds = db.ExecuteQuery()

        If ds.Tables(0).Rows.Count = 1 Then
            Dim dr As DataRow = ds.Tables(0).Rows(0)
            MyBase.Initialize(dr)
            InitializeBusinessData(dr)
            MyBase.IsNew = False
            MyBase.IsDirty = False

            Return Me
        Else
            If ds.Tables(0).Rows.Count = 0 Then
                Throw New Exception(String.Format("Story Fandom {0} was not found", id))
            Else
                Throw New Exception(String.Format("Story Fandom {0} found multiple records", id))
            End If
        End If

    End Function
    Public Sub InitializeBusinessData(dr As DataRow)
        _FandomName = dr("FandomName")

        _CategoryID = dr("CategoryID")

    End Sub
#End Region

#Region " Public Events "

    Public Delegate Sub IsSavableArgs(savable As Boolean)
    Public Event evtIsSavable As IsSavableArgs

#End Region

#Region " Public Event Handlers "

#End Region

#Region " Construction "

#End Region
End Class

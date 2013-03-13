Imports System.Data.SqlClient
Imports ConfigurationHelper

Public Class Database
#Region " Private Members "
    Private _cn As SqlConnection
    Private _cmd As SqlCommand
    Private _da As SqlDataAdapter
    Private _ds As DataSet
    Private _transaction As SqlTransaction

    Private _ConnectionName As String = String.Empty
#End Region

#Region " Public Properties "

    Public Property ConnectionName() As String
        Get
            Return _ConnectionName
        End Get
        Set(ByVal value As String)
            _ConnectionName = value
        End Set
    End Property


    Public ReadOnly Property Command() As SqlCommand
        Get
            Return _cmd
        End Get
    End Property

#End Region

#Region " Private Methods "

#End Region

#Region " Public Methods "
    ''' <summary>
    ''' Allows you to add or update the database
    ''' </summary>
    ''' <returns>An SQLCommand object which holds the header data values</returns>
    ''' <remarks>Your mom</remarks>
    Public Function ExecuteNonQuery() As SqlCommand

        'Go get the connection string from the configuration file
        _cn.ConnectionString = ConfigurationHelper.vb.Configuration.GetConnectionString(_ConnectionName)

        _cn.Open()
        'Tell the command object about the connection
        _cmd.Connection = _cn
        'Execute the command object
        'This assumes that the command text and parameters have been set up

        _cmd.ExecuteNonQuery()

        'Close the connection
        _cn.Close()

        'return the command object which will have values output from the stored procedure (ie. header data values)
        Return _cmd
    End Function


    ''' <summary>
    ''' Retrieves data from a database
    ''' 
    ''' </summary>
    ''' <returns>stores data from a dataset</returns>
    ''' <remarks></remarks>
    Public Function ExecuteQuery() As DataSet

        'Get the connection string from the configuration file
        _cn.ConnectionString = ConfigurationHelper.vb.Configuration.GetConnectionString(_ConnectionName)
        'Open up the connection
        _cn.Open()
        'Tell the command object about the connection
        _cmd.Connection = _cn
        'Tell the data adapter about the command object
        _da.SelectCommand = _cmd
        'full up dataset with the data adapter
        _da.Fill(_ds)
        'close the connection
        _cn.Close()
        'return the dataset to the caller
        Return _ds
    End Function
    Public Sub BeginTransaction(connectioName As String)
        'SETUP THE CONNECTION STRING
        _cn.ConnectionString = ConfigurationHelper.vb.Configuration.GetConnectionString(connectioName)
        'OPEN THE CONNECTION
        _cn.Open()

        'BEGIN THE TRANSACTION
        _transaction = _cn.BeginTransaction
    End Sub

    Public Sub EndTransaction()
        'COMMIT THE TRANSACTION
        _transaction = _cn.BeginTransaction
        'CLOSE THE CONNECTION
        _cn.Close()
    End Sub

    Public Sub RollbackTransaction()
        'ROLL BACK THE TRANSACTION
        _transaction.Rollback()
        'CLOSE THE CONNECTION
        _cn.Close()
    End Sub

    Public Function ExecuteNonQueryWithTransaction() As SqlCommand
        'ASSUME THE CONNECTION HAS BEEN OPENED
        'SETUP THE COMMAND OBJECT
        _cmd.Connection = _cn
        'CALL THE EXECUTENONQUERY MTHOD OF THE COMMAND OBJECT
        _cmd.ExecuteNonQuery()
        'RETURN THE COMMAND OBJECT TO THE CALLER
        Return _cmd


    End Function

#End Region

#Region " Public Events "

#End Region

#Region " Public Event Handlers "

#End Region

#Region " Construction "
    Public Sub New(name As String)
        _cn = New SqlConnection
        _cmd = New SqlCommand
        _da = New SqlDataAdapter
        _ds = New DataSet
        _ConnectionName = name
    End Sub

#End Region
End Class

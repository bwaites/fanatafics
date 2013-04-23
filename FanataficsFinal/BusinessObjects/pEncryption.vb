Imports System.Text

Public Class pEncryption
    Public Function EncryptQueryString(ByVal queryString As String) As String
        Dim _bitEncrypt As Byte()
        _bitEncrypt = ASCIIEncoding.ASCII.GetBytes(queryString)
        Dim encryptedQueryString As String = Convert.ToBase64String(_bitEncrypt)
        Return encryptedQueryString
    End Function

    Public Function DecryptQueryString(ByVal queryString As String) As String
        Dim _bitDecrypt As Byte()
        _bitDecrypt = Convert.FromBase64String(queryString)
        Dim decryptedQueryString = ASCIIEncoding.ASCII.GetString(_bitDecrypt)
        Return decryptedQueryString
    End Function
End Class

<%@ Page Title="Upload & Edit" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="UploadnEdit.aspx.cs" Inherits="fanataficsWebApplication.WebForm2" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        }
        
</style>
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
   
    <script src="Scripts/jquery-1.9.1.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <table class="style1">
    <tr>
        <td class="style2">

            <asp:Label ID="lblUpload" runat="server" Text="Pick what file to upload "></asp:Label>
        </td>
        <td>
            <asp:FileUpload ID="FileUpload1" runat="server" />

        </td>
    </tr>
    </table>
    

    <textarea id="ckeditor">
            
    </textarea>
    <script>
        CKEDITOR.replace('ckeditor');
        </script>
</asp:Content>

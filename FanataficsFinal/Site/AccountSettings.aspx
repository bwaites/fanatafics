<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AccountSettings.aspx.cs" Inherits="Site.AccountSettings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <style type="text/css">
    .style1
    {
        width: 100%;
    }
    .style2
    {
        height: 56px;
    }
    .style3
    {
        height: 40px;
    }
</style>

</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="span5 well">
    <table cellpadding="3" class="style1">
    <tr>
        <td class="style2">
            <asp:Label ID="Label1" runat="server" Text="User Name"></asp:Label>
        </td>
        <td class="style2">
            <asp:Label ID="lblUserName" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style2">
            <asp:TextBox ID="txtUserName" runat="server"></asp:TextBox>
        </td>
        <td class="style2">
            <asp:Button ID="btnEditUsrName" runat="server" onclick="btnEditUsrName_Click" 
                Text="Edit" />
        </td>
    </tr>
    <tr>
        <td class="style3">
            <asp:Label ID="Label2" runat="server" Text="Password"></asp:Label>
        </td>
        <td class="style3">
            <asp:Label ID="lblPassword" runat="server" Text="Label"></asp:Label>
        </td>
        <td class="style3">
            <asp:TextBox ID="txtPassword" runat="server"></asp:TextBox>
        </td>
        <td class="style3">
            <asp:Button ID="btnEditPassword" runat="server" onclick="btnEditPassword_Click" 
                Text="Edit" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label7" runat="server" Text="Email"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblEmail" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            <asp:TextBox ID="txtEmail" runat="server"></asp:TextBox>
        </td>
        <td>
            <asp:Button ID="btnEditEmail" runat="server" onclick="btnEditEmail_Click" 
                Text="Edit" />
        </td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label3" runat="server" Text="Security Question"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblSecQuest" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            <asp:Label ID="Label4" runat="server" Text="Security Answer"></asp:Label>
        </td>
        <td>
            <asp:Label ID="lblSecAns" runat="server" Text="Label"></asp:Label>
        </td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
    <tr>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
        <td>
            &nbsp;</td>
    </tr>
</table>
</div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditAccount.aspx.cs" Inherits="Site.EditAccount" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

    <asp:LoginView ID="loginView" runat="server">
        <LoggedInTemplate>
            <div class="span6" id="dvAccountDetails" runat="server"></div>
            
        </LoggedInTemplate>
    </asp:LoginView>

</asp:Content>

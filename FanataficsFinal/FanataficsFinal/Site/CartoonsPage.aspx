<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="CartoonsPage.aspx.cs" Inherits="Site.CartoonsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Repeater ID="rptCartoons" runat="server">
        <HeaderTemplate>
            <table border="1" cellpadding="5" width="100%" style="font: 8pt verdana">
            <tr align="center">
                <td>Title </td>
                <td>Summary</td>
            </tr>
        </HeaderTemplate>
        <ItemTemplate>
            <tr>
                
                <td>
                     <%# DataBinder.Eval(Container.DataItem, "Title") %>
                </td>
                <td>
                     <%# DataBinder.Eval(Container.DataItem, "Summary") %>
                </td>
                
            </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>
        </FooterTemplate>
    </asp:Repeater>
</asp:Content>

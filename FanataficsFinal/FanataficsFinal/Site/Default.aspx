<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Site.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span5">
            <asp:Repeater ID="rptCategories" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr align="center">
                                <td>
                                    Fanatical Categories
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='FandomPage.aspx?CategoryID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                                <%# DataBinder.Eval(Container.DataItem,"Type") %></a>
                        </td>
                    </tr>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

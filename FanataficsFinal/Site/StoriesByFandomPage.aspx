<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="StoriesByFandomPage.aspx.cs" Inherits="Site.BatmanFandom" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span5">
            <asp:Repeater ID="rptStories" runat="server">
                <HeaderTemplate>
                    <table>
                    <thead> <tr align="center">
                        <td>Stories</td>
                    </tr></thead>
                    <tbody>   
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>                    
                        <td><a href='StoryPage.aspx?StoryID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'><%# DataBinder.Eval(Container.DataItem,"Title") %></a>  </td>
                        <td><%# DataBinder.Eval(Container.DataItem,"Summary") %>  </td>

                    </tr>
                </ItemTemplate>
                <SeparatorTemplate><br /></SeparatorTemplate>
                <FooterTemplate>
                    </tbody>
                    </table>
                </FooterTemplate>
            </asp:Repeater>
            
        </div>
    </div>
</asp:Content>

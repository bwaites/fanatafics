<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="FandomPage.aspx.cs" Inherits="Site.FandomPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
  <div class="container-fluid">
        <div class="span5">
            
            <asp:Repeater ID="rptFandoms" runat="server">
                <HeaderTemplate>
                    <table>
                        <thead><tr align="center"><td>Fandoms</td>
                    </tr></thead>
                    <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='StoryByFandomPage.aspx?FandomID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                                <%# DataBinder.Eval(Container.DataItem,"FandomName") %></a>
                         
                        </td>
                      
                   
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

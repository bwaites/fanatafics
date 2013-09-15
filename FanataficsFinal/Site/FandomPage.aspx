<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="FandomPage.aspx.cs" Inherits="Site.FandomPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span4 well">
            <asp:Repeater ID="rptFandoms" runat="server">
                <HeaderTemplate>
                    <div id="sidebar">
                        <h1>Fandoms</h1>
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <h3><a href='StoriesByFandomPage.aspx?FandomID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                            <%# DataBinder.Eval(Container.DataItem,"FandomName") %></a></h3>
                    </li>
                </ItemTemplate>
                <FooterTemplate>
                    </ul> </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

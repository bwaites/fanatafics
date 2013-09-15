<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="Site.Default1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span3 well">
            <asp:Repeater ID="rptCategories" runat="server">
                <HeaderTemplate>
                    <div id="sidebar">
                        <h1>
                            Fanatical Categories</h1>
                        <ul>
                </HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <h3>
                            <a href='FandomPage.aspx?CategoryID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                                <%# DataBinder.Eval(Container.DataItem,"Type") %></a></h3>
                    </li>
                </ItemTemplate>
                <SeparatorTemplate>
                </SeparatorTemplate>
                <FooterTemplate>
                    </ul></div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

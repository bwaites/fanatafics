<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="UserPage.aspx.cs" Inherits="Site.UserPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span9" id="usrBio" runat="server">
        </div>
        <div class="span9" id="usrStories">
            <asp:Repeater ID="rptUsrStories" runat="server" OnItemDataBound="rptUsrStories_ItemDataBound">
                <HeaderTemplate>
                    <div class="post">
                        <h2>
                            This Fanatic has created the following:</h2>
                </HeaderTemplate>
                <ItemTemplate>
                    <h3>
                        <a href='StoryPage.aspx?StoryID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                            <%# DataBinder.Eval(Container.DataItem,"Title") %></a>
                        <asp:HiddenField ID="hidnID" Value='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                            runat="server" />
                    </h3>
                    <span class="posted">
                        <asp:HyperLink ID="hlReviews" Text="Reviews" runat="server"></asp:HyperLink></span>
                    <div class="entry">
                        <%# DataBinder.Eval(Container.DataItem,"Summary") %>
                    </div>
                </ItemTemplate>
                <SeparatorTemplate>
                </SeparatorTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

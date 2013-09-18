<%@ Page Title="Stories in Fandom" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoriesInFandomPage.aspx.cs" Inherits="Site.StoriesInFandom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span8 well" id="content">
            <asp:Repeater ID="rptStories" runat="server" OnItemDataBound="rptStories_ItemDataBound">
                <HeaderTemplate>
                    <div class="post">
                </HeaderTemplate>
                <ItemTemplate>
                    <h1>
                        <a href='StoryPage.aspx?StoryID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                            <%# DataBinder.Eval(Container.DataItem,"Title") %></a>
                        <asp:HiddenField ID="hidnID" Value='<%# DataBinder.Eval(Container.DataItem, "Id") %>'
                            runat="server" />
                    </h1>
                    <span class="posted">Scribbler:&nbsp;
                        <asp:HyperLink ID="hlAuthor" runat="server" NavigateUrl="~/UserPage.aspx">HyperLink</asp:HyperLink>
                    </span>
                    <div class="pull-right">
                        <asp:HyperLink ID="hlReviews" runat="server" NavigateUrl="">Reviews</asp:HyperLink>
                    </div>
                    <div class="entry">
                        <%# DataBinder.Eval(Container.DataItem,"Summary") %>
                    </div>
                </ItemTemplate>
                <FooterTemplate>
                    </div>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

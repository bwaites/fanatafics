<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReviewsPage.aspx.cs" Inherits="Site.ReviewsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span7 well">
        <h3>
            Reviews for&nbsp;<asp:Label ID="lblStoryTitle" runat="server" Text="StoryTitleGoesHere"></asp:Label>
        </h3>
        <div class="pull-right">
            <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID"
                OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True" Text="Chapters"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Repeater ID="rptReviews" runat="server">
            <HeaderTemplate>
                <div class="post">
            </HeaderTemplate>
            <ItemTemplate>
                <p>
                    <asp:Label ID="Label1" runat="server">Name: </asp:Label>
                    <%# DataBinder.Eval(Container.DataItem,"ReviewerName" )%>
                </p>
                <p>
                    <%#DataBinder.Eval(Container.DataItem,"ReviewContent") %>
                </p>
            </ItemTemplate>
            <SeparatorTemplate>
            </SeparatorTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

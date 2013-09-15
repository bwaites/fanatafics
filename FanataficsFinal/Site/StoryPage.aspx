<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoryPage.aspx.cs" Inherits="Site.StoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span8">
        <div class="post">
            <h3 class="title">
                <asp:Label ID="lblStoryTitle" runat="server" Text="StoryTitleGoesHere"></asp:Label></h3>
            <p>
                <span class="posted">Written By:
                    <asp:HyperLink ID="hlAuthor" runat="server" Text="Author Name"></asp:HyperLink>
                    <asp:HyperLink ID="hlReviews" runat="server">Reviews</asp:HyperLink></span></p>
            <div class="entry" id="dvChapContent" runat="server">
            </div>
            <p>
                <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID"
                    OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true"
                    OnDataBound="ddlChapterList_DataBound" OnClientLoad="updateContent()">
                    <asp:ListItem Selected="True" Text="Chapter List"></asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
    </div>
    <div class="span5 offset4">
        <div class="post">
            <p>
                <asp:Label ID="lblReviewerName" runat="server" Text="Name of Reviewer "></asp:Label>
                <asp:TextBox ID="txtGuestReviewer" runat="server" Width="141px"></asp:TextBox></p>
            <p>
                &nbsp;</p>
            <p>
                <asp:TextBox ID="txtReview" runat="server" TextMode="MultiLine" Width="320px" Height="200px"
                    Style="resize: none;"></asp:TextBox></p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" OnClick="btnSubmit_Click" Text="Submit" /></p>
        </div>
    </div>
</asp:Content>

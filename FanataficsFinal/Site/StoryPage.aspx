<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoryPage.aspx.cs" Inherits="Site.StoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span12">
        <div class="post">
            <h1>
                <asp:Label ID="lblStoryTitle" runat="server" Text="StoryTitleGoesHere"></asp:Label></h1>
            <p>
                <span class="posted">Scribbled By:
                    <asp:HyperLink ID="hlAuthor" runat="server" Text="Author Name"></asp:HyperLink>
                    <asp:HyperLink ID="hlReviews" runat="server">Reviews</asp:HyperLink>
                </span>
            </p>
            <div class="entry" id="dvChapContent" runat="server">
            </div>
            <p>
                <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID"
                    OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true"
                    OnClientLoad="updateContent()">
                    <asp:ListItem Selected="True" Text="Chapter List"></asp:ListItem>
                </asp:DropDownList>
            </p>
        </div>
    </div>
    <div class="span5 offset4">
        <div class="post">
            <h3>
                <asp:Label ID="Label1" runat="server" Text="Name:"></asp:Label>&nbsp;&nbsp;
                <asp:Label ID="lblReviewerName" runat="server" Text="ReviewerNameGoesHere"></asp:Label>
            </h3>
            <asp:TextBox ID="txtGuestReviewer" runat="server" class="span3">Type your name here</asp:TextBox>
            
            <p>
                <asp:TextBox ID="txtReview" runat="server" placeholder="Type your review here!" TextMode="MultiLine" class="span4" Height="200px"
                    Style="resize: none;"></asp:TextBox>
            </p>
            <p>
                <asp:Button ID="btnSubmit" runat="server" class="span4 btn-large btn-primary" OnClick="btnSubmit_Click"
                    Text="Submit" />
            </p>
        </div>
    </div>
</asp:Content>

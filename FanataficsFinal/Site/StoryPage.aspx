<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoryPage.aspx.cs" Inherits="Site.StoryPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
               &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblStoryTitle" runat="server" Text="StoryTitleGoesHere"></asp:Label>
            </td>
            <td>
                <asp:HyperLink ID="hlAuthor" runat="server" Text="Author Name"></asp:HyperLink>
            </td>
            <td>
                &nbsp;
                <asp:HyperLink ID="hlReviews" runat="server">Reviews</asp:HyperLink>
            </td>
        </tr>
        <tr>
            <td>
                <div id="dvChapterContent" runat="server">
                </div>
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;
            </td>
            <td>
                &nbsp;
            </td>
            <td>
                <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID"
                    OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" 
                    AutoPostBack="true" ondatabound="ddlChapterList_DataBound">
                <asp:ListItem Selected="True" Text="Chapter List"></asp:ListItem>
                </asp:DropDownList>

            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Label ID="lblReview" runat="server" Text="Review"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblReviewerName" runat="server" Text="ReviewerName"></asp:Label>
            </td>
            <td>
                <asp:TextBox ID="txtGuestReviewer" runat="server"></asp:TextBox>
            </td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <textarea id="txtaReview" cols="20" name="S1" rows="5" runat="server"></textarea></td>
            <td>
                &nbsp;</td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
            <td>
                <asp:Button ID="btnSubmit" runat="server" onclick="btnSubmit_Click" 
                    Text="Submit" />
            </td>
            <td>
                &nbsp;</td>
        </tr>
    </table>
</asp:Content>

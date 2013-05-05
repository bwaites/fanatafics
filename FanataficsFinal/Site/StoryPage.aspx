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
                <asp:Label ID="lblAuthor" runat="server" Text="Author Name"></asp:Label>
            </td>
            <td>
                &nbsp;
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
                    OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:ListItem Selected="True">
                </asp:ListItem>
               
            </td>
        </tr>
    </table>
</asp:Content>

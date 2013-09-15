<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="testStoryPage.aspx.cs" Inherits="Site.testStoryPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
      
    <table style="width: 100%;">
        <tr>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblAuthor" runat="server" Text="Author Name"></asp:Label>
            </td>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <textarea id="txtaStoryContent" cols="20" name="S1" rows="2"></textarea></td>
                <div id="dvChapterContent" runat="server">
                </div>
            </td>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
        </tr>
        <tr>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
            <td>
                &nbsp;</td>
                &nbsp;
            </td>
            <td>
                <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="Title">
                <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID" OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true">
                </asp:DropDownList>
                <asp:ListItem Selected="True">
                </asp:ListItem>
                </asp:DropDownList>
            </td>
        </tr>
    </table>
    
</asp:Content>

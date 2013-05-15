<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReviewsPage.aspx.cs" Inherits="Site.ReviewsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style type="text/css">
        .style1
        {
            width: 100%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span7 well">
        <table class="style1">
            <tr>
                <td>
                    &nbsp;
                </td>
                <td>
                    <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID"
                        OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true"
                        OnDataBound="ddlChapterList_DataBound">
                        <asp:ListItem Selected="True" Text="Chapters"></asp:ListItem>
                    </asp:DropDownList>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Repeater ID="rptReviews" runat="server">
                        <HeaderTemplate>
                            <table>
                                <thead>
                                    <tr align="center">
                                        <td>
                                            Reviews
                                        </td>
                                    </tr>
                                </thead>
                                <tbody>
                        </HeaderTemplate>
                        <ItemTemplate>
                            <tr>
                                <td>
                                    <asp:Label runat="server">Reviewer Name: </asp:Label>
                                </td>
                                <td>
                                    <%# DataBinder.Eval(Container.DataItem,"ReviewerName" )%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label runat="server">Review:</asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <%#DataBinder.Eval(Container.DataItem,"ReviewContent") %>
                                </td>
                            </tr>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <p>
                                ******************</p>
                        </SeparatorTemplate>
                        <FooterTemplate>
                            </tbody></table></FooterTemplate>
                    </asp:Repeater>
                </td>
                <td>
                    &nbsp;
                </td>
            </tr>
        </table>
    </div>
</asp:Content>

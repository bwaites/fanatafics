<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ReviewsPage.aspx.cs" Inherits="Site.ReviewsPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="span7 well">
        <div class="pull-right">
            <asp:DropDownList ID="ddlChapterList" runat="server" DataTextField="Title" DataValueField="ID"
                OnSelectedIndexChanged="ddlChapterList_SelectedIndexChanged" AutoPostBack="true">
                <asp:ListItem Selected="True" Text="Chapters"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <asp:Repeater ID="rptReviews" runat="server">
            <HeaderTemplate>
                <div class="post">
                    <h3>
                        Reviews
                    </h3>
            </HeaderTemplate>
            <ItemTemplate>
                <span>
                    <asp:Label ID="Label1" runat="server">Reviewer Name: </asp:Label>
                    <%# DataBinder.Eval(Container.DataItem,"ReviewerName" )%>
                </span><span>
                    <asp:Label ID="Label2" runat="server">Review:</asp:Label>
                    <%#DataBinder.Eval(Container.DataItem,"ReviewContent") %>
                </span>
            </ItemTemplate>
            <SeparatorTemplate>
            </SeparatorTemplate>
            <FooterTemplate>
                </div>
            </FooterTemplate>
        </asp:Repeater>
    </div>
</asp:Content>

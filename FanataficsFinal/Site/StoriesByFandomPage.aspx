<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="StoriesByFandomPage.aspx.cs" Inherits="Site.BatmanFandom" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="span5">
            <asp:Repeater ID="rptStories" runat="server" 
                OnItemDataBound="rptStories_ItemDataBound" 
                ondatabinding="rptStories_DataBinding">
                <HeaderTemplate>
                    <table>
                        <thead>
                            <tr align="center">
                                <td>
                                    Stories
                                </td>
                            </tr>
                        </thead>
                        <tbody>
                </HeaderTemplate>
                <ItemTemplate>
                    <tr>
                        <td>
                            <a href='StoryPage.aspx?StoryID=<%# DataBinder.Eval(Container.DataItem,"Id") %>'>
                                <%# DataBinder.Eval(Container.DataItem,"Title") %></a>
                                <asp:HiddenField ID="hidnID" Value='<%# DataBinder.Eval(Container.DataItem, "Id") %>' runat="server"/>
                                <asp:Label ID="lblAuthor" runat="server" Text="Author Name"></asp:Label>
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <%# DataBinder.Eval(Container.DataItem,"Summary") %>
                        </td>
                    </tr>
                </ItemTemplate>
                <SeparatorTemplate>
                    <br />
                </SeparatorTemplate>
                <FooterTemplate>
                    </tbody> </table>
                </FooterTemplate>
            </asp:Repeater>
        </div>
    </div>
</asp:Content>

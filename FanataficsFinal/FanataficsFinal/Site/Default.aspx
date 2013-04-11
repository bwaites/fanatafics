<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Site.Default1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
   

    <div class="container-fluid">
        <div class="span5">
            <asp:GridView ID="gvCategories" runat="server">
            </asp:GridView>
            <asp:HyperLink ID="hlCartoons" runat="server" 
                NavigateUrl="CartoonsPage.aspx?CategoryID=b91238f2-d4db-4596-8b47-33179a49ef20">Cartoons</asp:HyperLink>
        </div>
    </div>
</asp:Content>

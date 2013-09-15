<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="RPSLSPage.aspx.cs" Inherits="CornerOfCreation.RPSLSPage" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <asp:Label ID="lblBatAI" runat="server" Text="Your turn, ___"></asp:Label> <br />
    <asp:Label ID="lblPlayer" runat="server" Text="Label"></asp:Label><br />
    <asp:Label ID="lblWords" runat="server" Text="Choose an Option"></asp:Label><br />
    <asp:Button ID="btnRock" runat="server" Text="Rock" onclick="btnRock_Click" /><br />
    <asp:Button ID="btnPaper" runat="server" Text="Paper" 
        onclick="btnPaper_Click" /><br />
    <asp:Button ID="btnScissors" runat="server" Text="Scissors" 
        onclick="btnScissors_Click" /><br />
    <asp:Button ID="btnLizard" runat="server" Text="Lizard" 
        onclick="btnLizard_Click" /><br />
    <asp:Button ID="btnSpock" runat="server" Text="Spock" 
        onclick="btnSpock_Click" /><br />

</asp:Content>

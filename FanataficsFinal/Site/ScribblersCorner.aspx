<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ScribblersCorner.aspx.cs" Inherits="Site.ScribblersCorner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span3 well">
                <div id="sidebar">
                    <h1>Fanatical Editing Section</h1>
                    <ul>
                        <li class="active"><h3><a href="NewStory.aspx">Make a New Story</a></h3></li>
                        <li><h3><a href="EditStory.aspx">Edit Story Details</a></h3></li>
                        <li><h3><a href="AddChapter.aspx">Add a New Chapter(s)</a></h3></li>
                        <li><h3><a href="EditChapters.aspx">Edit Old Chapters</a></h3></li>
                    </ul>            
                </div>
                <!--/sidebar -->
            </div>
            <!--/span-->
        </div>
            <!--/row-->
    </div>
        <!--/container-->
</asp:Content>

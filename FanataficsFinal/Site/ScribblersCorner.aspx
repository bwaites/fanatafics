<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="ScribblersCorner.aspx.cs" Inherits="Site.ScribblersCorner" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container-fluid">
        <div class="row-fluid">
            <div class="span3">
                <div class="well sidebar-nav">
                    <ul class="nav">
                        <li class="active"><a href="NewStory.aspx">Make a New Story</a></li>
                        <li><a href="EditStory.aspx">Edit Story Details</a></li>
                        <li><a href="AddChapter.aspx">Add a New Chapter(s)</a></li>
                        <li><a href="EditChapters.aspx">Edit Old Chapters</a></li>
                    </ul>            
                </div>
                <!--/.well -->
            </div>
            <!--/span-->
        </div>
            <!--/row-->
    </div>
        <!--/container-->
</asp:Content>

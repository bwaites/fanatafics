<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Fanaticals.aspx.cs" Inherits="fanataficsWebApplication.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <!--fanatical span start-->
            <div class="span3" id="fanaticalSpan">
		        <div class="well sidebar-nav">
                    <center>
                        <ul class="nav nav-list">
				            <li class="nav-header"><h3>Fanatical Options </h3></li>
				            <li class="active">
					        <a href="~/UploadnEdit.aspx">Upload & Edit</a>
					        </li>
                            <li>
					        <a href="~/ManageStories.aspx">Manage Stories</a>
					        </li>
                            <li>
					        <a href="~/CreateNew.aspx">Create New</a>
					        </li>
                            <li>
					        <a href="~/ManageAccount.aspx">Manage Account</a>
					        </li>
                        </ul>
                    </center>
			    </div>
	        </div> <!--end of Fanatical span -->
</asp:Content>

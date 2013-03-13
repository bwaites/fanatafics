<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.master" AutoEventWireup="true"
    CodeBehind="Default.aspx.cs" Inherits="fanataficsWebApplication._Default" %>

<asp:Content ID="HeaderContent" runat="server" ContentPlaceHolderID="HeadContent">
</asp:Content>
<asp:Content ID="BodyContent" runat="server" ContentPlaceHolderID="MainContent">
           
            


            <!--fanatical span start-->
            <div class="span3" id="fanaticalSpan">
		        <div class="well sidebar-nav">
                    <center>
                        <ul class="nav nav-list">
				            <li class="nav-header"><h3>Fanatical Options </h3>
                                <asp:LoginView ID="LoginView1" runat="server">
                                    <AnonymousTemplate>
                                        <p> Please Log-In or Sign-Up to see these options</p>
                                    </AnonymousTemplate>
                                    <LoggedInTemplate>
                                        <li class="active">
					                    <a href="UploadnEdit.aspx">Upload & Edit</a>
					                    </li>
                                        <li>
					                    <a href="ManageStories.aspx">Manage Stories</a>
					                    </li>
                                        <li>
					                    <a href="CreateNew.aspx">Create New</a>
					                    </li>
                                        <li>
					                    <a href="ManageAccount.aspx">Manage Account</a>
					                    </li>
                                    </LoggedInTemplate>
                                </asp:LoginView>
                                </li>
				            
                        </ul>
                    </center>
			    </div>
	        </div> 
            <!--end of fanatical span -->

            <!--Category span start-->
            <div class="span3" id="categorySpan">
		        <div class="well sidebar-nav">
                    <center>
                        <ul class="nav nav-list">
				            <li class="nav-header"><h3>FanFiction Categories </h3></li>
				            <li class="active">
					        <a href="#">Anime</a>
					        </li>
                            <li>
					        <a href="#">Cartoons</a>
					        </li>
                            <li>
					        <a href="#">Comics</a>
					        </li>
                            <li>
					        <a href="#">Manga</a>
					        </li>
                            <li>
					        <a href="#">Movies</a>
					        </li>
                            <li>
					        <a href="#">Television</a>
					        </li>
                        </ul>
                    </center>
			    </div>
	        </div> <!--end of Category span -->
            <div class="well span4">
                <h3>Top Rated Stories</h3>
            </div>


            <div class="well span4">
                <h3>News & Updates</h3>
            </div>
    
</asp:Content>

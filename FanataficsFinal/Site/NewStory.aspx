<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="NewStory.aspx.cs" Inherits="Site.NewStory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <!-- Form Name -->
        <div class="span6 offset3">
            <h2 class="title">
                Fanatical Editor&nbsp; - &nbsp;Make a New Story</h2>
        </div>
        <div class="span8 offset2 well">
            <div class="post" id="dvCategories">
                <!-- Drop down list for Categories-->
                <span>Choose a Category</span>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlCategory" class="input-xlarge" runat="server" 
                            AutoPostBack="True" onselectedindexchanged="ddlCategory_SelectedIndexChanged">
                            <asp:ListItem Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                    ErrorMessage="Must pick a Category" SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </div>
            <div class="post" id="dvFandoms">
                <!-- Select Basic -->
                <span>Choose a Fandom</span>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlFandom" class="input-xlarge" runat="server" DataTextField="FandomName"
                            DataValueField="ID" 
                            onselectedindexchanged="ddlFandom_SelectedIndexChanged">
                            <asp:ListItem Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="rfvFandom" runat="server" ControlToValidate="ddlFandom"
                    ErrorMessage="Must choose a Fandom" SetFocusOnError="true">*</asp:RequiredFieldValidator>
            </div>
            <div class="post" id="dvStoryTitle">
                <!-- Text input-->
                <span>Title of Story</span>
                <div class="control-group">
                    <div class="controls">
                        <input id="txtTitle" name="txtTitle" type="text" text="(100 Characters MAX)" class="input-xlarge"
                            required="true" runat="server" />
                        <p class="help-block">
                        </p>
                    </div>
                </div>
                <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                    ErrorMessage="Title can't be left blank" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                <!-- Text Area -->
            </div>
            <div class="post" id="dvStorySummary">
                <span>Summary of Story</span>
                <div class="control-group">
                    <div class="controls">
                        <textarea rows="5" cols="50" id="txtSummary" class="span5" style="resize: none;" runat="server">(500 MAX)</textarea>
                    </div>
                </div>
            </div>
            <div class="post" id="dvGenres">
                <!-- Select Multiple -->
                <span>Choose two Genres</span>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlGenre1" class="input-xlarge" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGenre1" runat="server" ControlToValidate="ddlGenre1"
                            ErrorMessage="Must choose at least one Genre" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                        <asp:DropDownList ID="ddlGenre2" class="input-xlarge" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvGenre2" runat="server" ControlToValidate="ddlGenre2"
                            ErrorMessage="Must choose at least one Genre" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="post" id="dvMaturity">
                <!-- Select Basic -->
                <span>Choose a Maturity Rating</span>
                <div class="control-group">
                    <div class="controls">
                        <asp:DropDownList ID="ddlMaturity" class="input-xlarge" runat="server" AutoPostBack="True">
                            <asp:ListItem Selected="True"></asp:ListItem>
                        </asp:DropDownList>
                        <asp:RequiredFieldValidator ID="rfvMaturity" runat="server" ControlToValidate="ddlMaturity"
                            ErrorMessage="Must choose a Maturity" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    </div>
                </div>
            </div>
            <div class="post" id="dvButtons">
                <!-- Button -->
                <span></span>
                <div class="control-group">
                    <div class="controls">
                        <asp:Button runat="server" ID="btnAddStory" class="btn btn-primary" Text="Add Story"
                            OnClick="btnAddStory_Click" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

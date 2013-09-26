<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditStory.aspx.cs" Inherits="Site.EditStory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <!-- Form Name -->
        <div class="span6 offset3">
            <h2 class="title">
                Fanatical Editor&nbsp; - &nbsp;Story Details</h2>
        </div>
        <!-- Drop down list for Stories -->
        <div class="span8 offset2 well">
            <div class="post" id="dvStorySelection">
                <span>Choose a Story</span>
                <div class="controls">
                    <asp:DropDownList ID="ddlStory" class="input-xlarge" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlStory_SelectedIndexChanged" OnDataBound="ddlStory_DataBound">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvStory" runat="server" ControlToValidate="ddlStory"
                        ErrorMessage="Must pick a Story" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="post" id="dvCategorySelection">
                <!-- Drop down list for Categories -->
                <span>Choose a Category</span>
                <div class="controls">
                    <asp:DropDownList ID="ddlCategory" class="input-xlarge" runat="server" AutoPostBack="True">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
                        ErrorMessage="Must pick a Category" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="post" id="dvFandomSelection">
                <!-- Drop down list for Fandoms -->
                <span>Choose a Fandom</span>
                <div class="controls">
                    <asp:DropDownList ID="ddlFandom" class="input-xlarge" runat="server" AutoPostBack="false"
                        OnSelectedIndexChanged="ddlFandom_SelectedIndexChanged">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvFandom" runat="server" ControlToValidate="ddlFandom"
                        ErrorMessage="Must choose a Fandom" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="post" id="dvStoryTitle">
                <!-- Text input-->
                <span>Title of Story</span>
                <div class="controls">
                    <input id="txtTitle" name="txtTitle" type="text" text="(100 Characters MAX)" class="input-xlarge"
                        required="true" runat="server" />
                    <p class="help-block">
                    </p>
                    <asp:RequiredFieldValidator ID="rfvTitle" runat="server" ControlToValidate="txtTitle"
                        ErrorMessage="Title can't be left blank" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="post" id="dvStorySummary">
                <!-- Text Area -->
                <span>Story Summary</span>
                <div class="controls">
                    <textarea rows="4" cols="50" id="txtSummary" class="span5" runat="server" width="528px"
                        style="resize: none;">(500 MAX)</textarea>
                </div>
            </div>
            <div class="post" id="dvGenreSelections">
                <!-- Drop Down List for Genres -->
                <span>Choose two genres</span>
                <div class="controls">
                    <asp:DropDownList ID="ddlGenre1" class="input-xlarge" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlGenre1_SelectedIndexChanged">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGenre1" runat="server" ControlToValidate="ddlGenre1"
                        ErrorMessage="Must choose at least two Genres" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                    <asp:DropDownList ID="ddlGenre2" class="input-xlarge" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlGenre2_SelectedIndexChanged">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvGenre2" runat="server" ControlToValidate="ddlGenre2"
                        ErrorMessage="Must choose at least two Genres" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="post" id="dvMaturity">
                <!-- Drop Down List for Maturity -->
                <span>Choose a Maturity Rating</span>
                <div class="controls">
                    <asp:DropDownList ID="ddlMaturity" class="input-xlarge" runat="server" AutoPostBack="True"
                        OnSelectedIndexChanged="ddlMaturity_SelectedIndexChanged">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
                    <asp:RequiredFieldValidator ID="rfvMaturity" runat="server" ControlToValidate="ddlMaturity"
                        ErrorMessage="Must choose a Maturity" SetFocusOnError="true">*</asp:RequiredFieldValidator>
                </div>
            </div>
            <div class="post" id="dvButtons">
                <div class="controls">
                    <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes To Story" OnClick="btnSaveChanges_Click" />
                    <asp:Button ID="btnDeleteStory" runat="server" Text="Delete Story" OnClick="btnDeleteStory_Click" />
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditStory.aspx.cs" Inherits="Site.EditStory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <!-- Form Name -->
        <h2>
            Edit a Scribble!</h2>
        <!-- Drop down list for Stories -->
        <div class="control-group">
            <label class="control-label">
                Choose a Scribble</label>
            <div class="controls">
                <asp:DropDownList ID="ddlStory" class="input-xlarge" runat="server" 
                    AutoPostBack="True" onselectedindexchanged="ddlStory_SelectedIndexChanged" 
                    ondatabound="ddlStory_DataBound" 
                    >
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:RequiredFieldValidator ID="rfvStory" runat="server" ControlToValidate="ddlStory"
            ErrorMessage="Must pick a Story" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        
                <!-- Drop down list for Categories -->
        <div class="control-group">
            <label class="control-label">
                Choose a Category</label>
            <div class="controls">
                <asp:DropDownList ID="ddlCategory" class="input-xlarge" runat="server" 
                    AutoPostBack="True">
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:RequiredFieldValidator ID="rfvCategory" runat="server" ControlToValidate="ddlCategory"
            ErrorMessage="Must pick a Story" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        
        <!-- Drop down list for Fandoms -->
        <div class="control-group">
            <label class="control-label">
                Fandom</label>
            <div class="controls">
                <asp:DropDownList ID="ddlFandom" class="input-xlarge" runat="server" 
                    AutoPostBack = "false" onselectedindexchanged="ddlFandom_SelectedIndexChanged" >                    
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:RequiredFieldValidator ID="rfvFandom" runat="server" ControlToValidate="ddlFandom"
            ErrorMessage="Must choose a Fandom" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        <!-- Text input-->
        <div class="control-group">
            <label class="control-label">
                Title</label>
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
        <div class="control-group">
            <label class="control-label">
                Summary</label>
            <div class="controls">
                <div id="Summary" class="textarea">
                    <textarea rows="5" cols="50" id="txtSummary" runat="server">(500 MAX)</textarea>
                </div>
            </div>
        </div>


               <!-- Drop Down List for Genres -->
        <div class="control-group">
            <label class="control-label">
                Choose two genres</label>
            <div class="controls">
                <asp:DropDownList ID="ddlGenre1" class="input-xlarge" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlGenre1_SelectedIndexChanged" >
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:RequiredFieldValidator ID="rfvGenre1" runat="server" ControlToValidate="ddlGenre1"
            ErrorMessage="Must choose at least one Genre" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        <div class="control-group">
            <div class="controls">
                <asp:DropDownList ID="ddlGenre2" class="input-xlarge" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlGenre2_SelectedIndexChanged" >
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:RequiredFieldValidator ID="rfvGenre2" runat="server" ControlToValidate="ddlGenre2"
            ErrorMessage="Must choose at least one Genre" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        <!-- Drop Down List for Maturity -->
        <div class="control-group">
            <label class="control-label">
                Choose a Maturity Rating</label>
            <div class="controls">
                <asp:DropDownList ID="ddlMaturity" class="input-xlarge" runat="server" 
                    AutoPostBack="True" 
                    onselectedindexchanged="ddlMaturity_SelectedIndexChanged" >
                    <asp:ListItem Selected="True"></asp:ListItem>
                </asp:DropDownList>
            </div>
        </div>
        <asp:RequiredFieldValidator ID="rfvMaturity" runat="server" ControlToValidate="ddlMaturity"
            ErrorMessage="Must choose a Maturity" SetFocusOnError="true">*</asp:RequiredFieldValidator>
        <!-- Button -->
        <div class="control-group">
            <label class="control-label">
            </label>
            <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes To Story" 
                onclick="btnSaveChanges_Click" />
   
            <asp:Button ID="btnDeleteStory" runat="server" Text="Delete Story" 
                onclick="btnDeleteStory_Click" />
   
        </div>
    </div>
</asp:Content>

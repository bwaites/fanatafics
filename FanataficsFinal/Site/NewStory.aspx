﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewStory.aspx.cs" Inherits="Site.NewStory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-horizontal">


<!-- Form Name -->
<h2>Add A Story</h2>

<!-- Drop down list -->
<div class="control-group">
  <label class="control-label">Category</label>
  <div class="controls">
      <asp:DropDownList ID="ddlCategory" class="input-xlarge"  
          runat="server" AutoPostBack="True">
        <asp:ListItem Selected="True"></asp:ListItem>
      </asp:DropDownList> 
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvCategory"
  runat="server"
  ControlToValidate="ddlCategory" 
  ErrorMessage="Must pick a Category"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Select Basic -->
<div class="control-group">
  <label class="control-label">Fandom</label>
  <div class="controls">
     <asp:DropDownList ID="ddlFandom" class="input-xlarge"  
          runat="server" DataTextField="FandomName" DataValueField="ID">
        <asp:ListItem Selected="True"></asp:ListItem>
      </asp:DropDownList> 
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvFandom"
  runat="server"
  ControlToValidate="ddlFandom" 
  ErrorMessage="Must choose a Fandom"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Title</label>
  <div class="controls">
    <input id="txtTitle" name="txtTitle" type="text" text="(100 Characters MAX)" class="input-xlarge" required="true" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvTitle"
  runat="server"
  ControlToValidate="txtTitle" 
  ErrorMessage="Title can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Textarea -->
<div class="control-group">
  <label class="control-label">Summary</label>
  <div class="controls">                     
    <div id="Summary"  class="textarea">
      <textarea rows="5" cols="50" id="txtSummary" runat="server">(500 MAX)</textarea>
    </div>
  </div>
</div>



<!-- Select Multiple -->
<div class="control-group">
  <label class="control-label">Genre</label>
  <div class="controls">
    <asp:DropDownList ID="ddlGenre" class="input-xlarge"  
          runat="server" AutoPostBack="True">
        <asp:ListItem Selected="True"></asp:ListItem>
      </asp:DropDownList> 
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvGenre"
  runat="server"
  ControlToValidate="ddlGenre" 
  ErrorMessage="Must choose at least one Genre"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Select Basic -->
<div class="control-group">
  <label class="control-label">Maturity Rating</label>
  <div class="controls">
    <asp:DropDownList ID="ddlMaturity" class="input-xlarge"  
          runat="server" AutoPostBack="True">
        <asp:ListItem Selected="True"></asp:ListItem>
      </asp:DropDownList> 
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvMaturity"
  runat="server"
  ControlToValidate="ddlMaturity" 
  ErrorMessage="Must choose a Maturity"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Button -->
<div class="control-group">
  <label class="control-label"></label>
  <div class="controls">
    <asp:Button runat="server" ID="btnAddStory" class="btn btn-primary" 
          Text="Add Story" onclick="btnAddStory_Click" />
  </div>
</div>
</div>
</asp:Content>
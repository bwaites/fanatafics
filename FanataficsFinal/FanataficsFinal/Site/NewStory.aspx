<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="NewStory.aspx.cs" Inherits="Site.NewStory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-horizontal">


<!-- Form Name -->
<h2>Add A Story</h2>

<!-- Select Basic -->
<div class="control-group">
  <label class="control-label">Category</label>
  <div class="controls">
    <select id="sbCategory" name="sbCategory" class="input-xlarge">
    </select>
  </div>
</div>

<!-- Select Basic -->
<div class="control-group">
  <label class="control-label">Fandom</label>
  <div class="controls">
    <select id="sbFandom" name="sbFandom" class="input-xlarge">
    </select>
  </div>
</div>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Title</label>
  <div class="controls">
    <input id="txtTitle" name="txtTitle" type="text" placeholder="(100 MAX)" class="input-xlarge" required="">
    <p class="help-block"></p>
  </div>
</div>

<!-- Textarea -->
<div class="control-group">
  <label class="control-label">Summary</label>
  <div class="controls">                     
    <div id="txtSummary" name="txtSummary" class="textarea">
      <textarea>(500 MAX)</textarea>
    </div>
  </div>
</div>

<!-- Select Multiple -->
<div class="control-group">
  <label class="control-label">Genre</label>
  <div class="controls">
    <select id="smGenre" name="smGenre" class="input-xlarge" multiple="multiple">
    </select>
  </div>
</div>

<!-- Select Basic -->
<div class="control-group">
  <label class="control-label">Maturity Rating</label>
  <div class="controls">
    <select id="sbMaturity" name="sbMaturity" class="input-xlarge">
    </select>
  </div>
</div>

<!-- Button -->
<div class="control-group">
  <label class="control-label"></label>
  <div class="controls">
    <button id="btnAddStory" name="btnAddStory" class="btn btn-primary">Add Story</button>
  </div>
</div>


</div>
</asp:Content>

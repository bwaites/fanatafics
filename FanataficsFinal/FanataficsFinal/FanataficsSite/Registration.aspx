<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Fanatafics.Master" CodeBehind="Registration.aspx.vb" Inherits="FanataficsSite.Registration" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-horizontal">


<!-- Form Name -->
<h2>Become a Fanatic!</h2>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">User Name</label>
  <div class="controls">
    <input id="userName" name="userName" type="text" placeholder="" class="input-xlarge" required="">
    <p class="help-block"></p>
  </div>
</div>

<!-- Password input-->
<div class="control-group">
  <label class="control-label">Password</label>
  <div class="controls">
    <input id="password" name="password" type="password" placeholder="" class="input-xlarge" required="">
    <p class="help-block"></p>
  </div>
</div>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Email</label>
  <div class="controls">
    <input id="email" name="email" type="text" placeholder="" class="input-xlarge" required="">
    <p class="help-block"></p>
  </div>
</div>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Security Question</label>
  <div class="controls">
    <input id="securityQuestion" name="securityQuestion" type="text" placeholder="pick a question only you know " class="input-xlarge" required="">
    <p class="help-block"></p>
  </div>
</div>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Security Answer</label>
  <div class="controls">
    <input id="securityAnswer" name="securityAnswer" type="text" placeholder="answer the question" class="input-xlarge" required="">
    <p class="help-block"></p>
  </div>
</div>

<!-- Button -->
<div class="control-group">
  <label class="control-label"></label>
  <div class="controls">
    <button id="btnRegister" name="btnRegister" class="btn btn-primary">Register</button>
  </div>
</div>


</div>

</asp:Content>

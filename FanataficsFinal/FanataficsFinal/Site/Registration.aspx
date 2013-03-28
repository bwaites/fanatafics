<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Registration.aspx.cs" Inherits="Site.Registration" %>
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
    <input id="userName" name="userName" type="text" placeholder="" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
  <asp:RequiredFieldValidator ID="rfvUserName"
  runat="server"
  ControlToValidate="userName" 
  ErrorMessage="User Name can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>
</div>

<!-- Password input-->
<div class="control-group">
  <label class="control-label">Password</label>
  <div class="controls">
    <input id="password" name="password" type="password" placeholder="" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvPassword"
  runat="server"
  ControlToValidate="password" 
  ErrorMessage="Password can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Compare Password input-->
<div class="control-group">
  <label class="control-label">Compare Passwords</label>
  <div class="controls">
    <input id="password2" name="password2" type="password" placeholder="" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:CompareValidator ID="cvPassword"
runat="server"
ControlToCompare="password"
ControlToValidate="password2"
Operator="Equal"
ErrorMessage="Passwords must match"
SetFocusOnError="true"></asp:CompareValidator>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Email</label>
  <div class="controls">
    <input id="email" name="email" type="text" placeholder="" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvEmail"
  runat="server"
  ControlToValidate="email" 
  ErrorMessage="Email can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Security Question</label>
  <div class="controls">
    <input id="securityQuestion" name="securityQuestion" type="text" placeholder="pick a question only you know " class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvSecurityQuestion"
  runat="server"
  ControlToValidate="securityQuestion" 
  ErrorMessage="Question can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>
<!-- Text input-->
<div class="control-group">
  <label class="control-label">Security Answer</label>
  <div class="controls">
    <input id="securityAnswer" name="securityAnswer" type="text" placeholder="answer the question" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvSecurityAnswer"
  runat="server"
  ControlToValidate="securityAnswer" 
  ErrorMessage="answer can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!--Validation Summary -->
<asp:ValidationSummary ID="ValidationSummary"
runat="server" ShowMessageBox="true"
ShowSummary="false" />

<!-- Button -->
<div class="control-group">
  <label class="control-label"></label>
  <div class="controls">
    <asp:Button runat="server" ID="btnRegister" class="btn btn-primary" Text="Register" />
   
  </div>
</div>


</div>
</asp:Content>

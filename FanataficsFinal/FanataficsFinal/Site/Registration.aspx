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
    <input id="txtUserName" name="userName" type="text" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
  <asp:RequiredFieldValidator ID="rfvUserName"
  runat="server"
  ControlToValidate="txtUserName" 
  ErrorMessage="User Name can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>
</div>

<!-- Password input-->
<div class="control-group">
  <label class="control-label">Password</label>
  <div class="controls">
    <input id="txtPassword" name="password" type="password" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvPassword"
  runat="server"
  ControlToValidate="txtPassword" 
  ErrorMessage="Password can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Compare Password input-->
<div class="control-group">
  <label class="control-label">Compare Passwords</label>
  <div class="controls">
    <input id="txtPassword2" name="password2" type="password" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
    
</div>
<asp:CompareValidator ID="cvPassword"
runat="server"
ControlToCompare="txtPassword"
ControlToValidate="txtPassword2"
Operator="Equal"
ErrorMessage="Passwords must match"
SetFocusOnError="true"></asp:CompareValidator>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Email</label>
  <div class="controls">
    <input id="txtEmail" name="email" type="text" class="input-xlarge" required="" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvEmail"
  runat="server"
  ControlToValidate="txtEmail" 
  ErrorMessage="Email can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>

<!-- Text input-->
<div class="control-group">
  <label class="control-label">Security Question</label>
  <div class="controls">
    <input id="txtSecurityQuestion" name="securityQuestion" type="text" text="pick a question only you know " class="input-xlarge" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvSecurityQuestion"
  runat="server"
  ControlToValidate="txtSecurityQuestion" 
  ErrorMessage="Question can't be left blank"
  SetFocusOnError="true">*</asp:RequiredFieldValidator>
<!-- Text input-->
<div class="control-group">
  <label class="control-label">Security Answer</label>
  <div class="controls">
    <input id="txtSecurityAnswer" name="securityAnswer" type="text" text="answer the question" class="input-xlarge" runat="server" />
    <p class="help-block"></p>
  </div>
</div>
<asp:RequiredFieldValidator ID="rfvSecurityAnswer"
  runat="server"
  ControlToValidate="txtSecurityAnswer" 
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

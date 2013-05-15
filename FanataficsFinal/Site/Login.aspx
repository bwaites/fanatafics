<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Site.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal span6 well">

<!-- Form Name -->
<h2>Login</h2>
    <div class="control-group">
      <!-- Username -->
      <label class="control-label"  for="username">Username</label>
      <div class="controls">
        <input type="text" id="txtUsername" name="username" class="input-xlarge" runat="server" />
      </div>
    </div>
 
    <div class="control-group">
      <!-- Password-->
      <label class="control-label" for="password">Password</label>
      <div class="controls">
        <input type="password" id="txtPassword" name="password" class="input-xlarge" runat="server" />
      </div>
    </div>
 
    <div class="control-group">
      <!-- Button -->
      <div class="controls">
        <asp:Button runat="server" ID="btnLogin" class="btn btn-primary" Text="Login" />
    </div>
    </div>

</div>
</asp:Content>

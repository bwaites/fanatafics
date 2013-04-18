<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddChapter.aspx.cs" Inherits="Site.AddChapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">

    <script src="Assets/js/nicEdit.js" type="text/javascript"></script>
</asp:Content>

    

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">

<div class="form-horizontal">
        <!-- Form Name -->
        <h2>
            Add Chapter</h2>
        <!-- Select Basic -->
        <div class="control-group">
            <label class="control-label">
                Choose Story</label>
            <div class="controls">
            
                <asp:DropDownList ID="ddlStoryList" runat="server" DataTextField="Title" 
                    DataValueField="StoryID">
                </asp:DropDownList>
            </div>
        </div>
        <!-- Text input-->
        <div class="control-group">
            <label class="control-label">
                Chapter Title</label>
            <div class="controls">
                <input id="txtChapTitle" name="txtChapTitle" type="text" placeholder="" class="input-xlarge"
                    required="">
                <p class="help-block">
                </p>
            </div>
        </div>
<%--        <!-- Select Basic -->
        <div class="control-group">
            <label class="control-label">
                Placement</label>
            <div class="controls">
                <select id="sbChapPlace" name="sbChapPlace" class="input-xlarge">
                </select>
            </div>
        </div>--%>
      <script type="text/javascript">bkLib.onDomLoaded(nicEditors.allTextAreas);</script>
      <textarea class="span8" rows="50"></textarea>
    </div>
</asp:Content>


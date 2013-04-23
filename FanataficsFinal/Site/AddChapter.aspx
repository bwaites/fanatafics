<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddChapter.aspx.cs" Inherits="Site.AddChapter" %>
<%@ Register Assembly="CKEditor.NET" Namespace="CKEditor.NET" TagPrefix="CKEditor" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    
    
<%--    <link href="Assets/css/wysiwyg-color.css" rel="stylesheet" type="text/css" />


    <script src="Assets/js/prettify.js" type="text/javascript"></script>
    
    <%--<script src="Assets/js/wysihtml5-0.3.0.min.js" type="text/javascript"></script>--%>
    <script type="text/javascript" src="Assets/js/jquery-1.7.2.min.js"></script>
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
                <select id="sbStory" name="sbStory" class="input-xlarge">
                </select>
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
        <!-- Select Basic -->
        <div class="control-group">
            <label class="control-label">
                Placement</label>
            <div class="controls">
                <select id="sbChapPlace" name="sbChapPlace" class="input-xlarge">
                </select>
            </div>
        </div>

        <textarea class="textarea" id="txtarea" style="width: 810px; height: 200px;" placeholder="Enter text ..."></textarea>
       
            <script type="text/javascript" charset="utf-8">
                new nicEditor({ fullPanel: true, icononSave: function (content, id, instance) {
                    alert('save button clicked for element ' + id + ' = ' + content);
                } 
                }).panelInstance('txtarea');</script>
    </div>
</asp:Content>


<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddChapter.aspx.cs" Inherits="Site.AddChapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
 <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
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
                
                    <asp:DropDownList ID="ddlStory" runat="server" class="input-xlarge">
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

        <div id="textArea">
            <textarea id="editor1" name="editor1"></textarea>
            <script type="text/javascript">
                CKEDITOR.replace('editor1');
            </script>
            <asp:Button ID="btnAddChapter" runat="server" Text="Add Chapter" 
                class="input-large" onclick="btnAddChapter_Click"/>
        </div>
    </div>
</asp:Content>

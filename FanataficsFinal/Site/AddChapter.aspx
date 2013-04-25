<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddChapter.aspx.cs" Inherits="Site.AddChapter" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="Assets/js/jquery-1.7.2.min.js" type="text/javascript"></script>
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
                    <asp:DropDownList ID="ddlStory" class="input-xlarge" 
                        DataTextField="Title" DataValueField="ID" runat="server">
                        <asp:ListItem Selected="True"></asp:ListItem>
                    </asp:DropDownList>
            </div>
        </div>
        <!-- Text input-->
        <div class="control-group">
            <label class="control-label">
                Chapter Title</label>
            <div class="controls">
                <asp:TextBox ID="txtChapTitle" runat="server" class="input-large"></asp:TextBox>
                
                <p class="help-block">
                </p>
            </div>
        </div>

        
        <div id="textArea">
            <textarea id="editor1" name="editor1" ></textarea>
            <asp:HiddenField ID="hidnEdit" runat="server" />
            <script type="text/javascript">
                CKEDITOR.replace('editor1');


                //instance
                function getText() {
                    var editorText = CKEDITOR.instances.editor1.getData();
                    document.getElementById('<%= hidnEdit.ClientID %>').value = editorText;
                }

            </script>
            <asp:Button ID="btnAddChapter" runat="server" Text="Add Chapter" 
                class="input-large" onClientClick="getText()" onclick="btnAddChapter_Click" />
        </div>
    </div>
</asp:Content>

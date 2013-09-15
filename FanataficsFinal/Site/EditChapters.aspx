<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="EditChapters.aspx.cs" Inherits="Site.EditChapters" ValidateRequest="false"%>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="Assets/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
<div class="form-horizontal">
        <!-- Form Name -->
        <h2>
            Scribbler&#39;s Corner</h2>
        <p>

        </p>
  
        <%--        Div for all the editing stuff (ddlChapter, txtChapTitle, the editor and save buttons)--%>
        <div id="dvEdits" runat="server">
            <!-- Select Basic -->
            <div class="control-group">
                <asp:Label ID="lblChooseStory" runat="server" Text="Choose a Story"></asp:Label>
                <br />
                <br />
                <div class="controls">
                    <asp:DropDownList ID="ddlStory" class="input-xlarge" DataTextField="Title" DataValueField="ID"
                        runat="server" OnSelectedIndexChanged="ddlStory_SelectedIndexChanged" 
                        AutoPostBack="true" ondatabound="ddlStory_DataBound">
                        <asp:ListItem Selected="True" Text="Choose a Story"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Select Basic -->
            <div class="control-group">
                <label id="lblChooseChap" runat="server" class="control-label" visible="false">
                    Choose Chapter</label>
                <div class="controls">
                    <asp:DropDownList ID="ddlChapters" runat="server" DataTextField="Title" DataValueField="ID"
                        OnSelectedIndexChanged="ddlChapters_SelectedIndexChanged" AutoPostBack="true" ondatabound="ddlChapters_DataBound" Enabled="false">
                        <asp:ListItem Selected="True" Text="Choose a Story"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Text input-->
            <div class="control-group">
                <label class="control-label" id="lblChapterTitle" runat="server" visible="false">
                    Chapter Title</label>
                <div class="controls">
                    <asp:TextBox ID="txtChapTitle" runat="server" class="input-large"></asp:TextBox>
                    <p class="help-block">
                    </p>
                </div>
            </div>
            <div id="textArea">
                <textarea id="editor1" name="editor1"></textarea>
                <asp:HiddenField ID="hidnExisting" runat="server" />
                <%--                Javascript for getting and setting the text of the editor--%>
                <script type="text/javascript">
                    CKEDITOR.replace('editor1');


                    //instance
                    function getText() {
                        var editorText = CKEDITOR.instances.editor1.getData();
                        document.getElementById('<%= hidnExisting.ClientID %>').value = editorText;
                    }

                    function setText() {
                        var editorText = document.getElementById('<%= hidnExisting.ClientID %>').value
                        CKEDITOR.instances.editor1.setData(editorText);
                    }

                    function insertBreaks() {
                        var content = document.getElementById('<%= hidnExisting.ClientID %>').value
                        $data = str_replace("\n", "<br/>", $data);
                    }

                </script>
                <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" class="input-large"
                    OnClientClick="getText()" OnClick="btnSaveChanges_Click" />
            </div>
        </div>
    </div>
</asp:Content>

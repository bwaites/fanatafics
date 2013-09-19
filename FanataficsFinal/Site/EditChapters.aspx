<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="EditChapters.aspx.cs" Inherits="Site.EditChapters" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="Assets/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <div class="span6 offset3">
            <h2 class="title">
                Fanatical Editor&nbsp; - &nbsp;Chapter Editing</h2>
        </div>
        <!-- Form Name -->
        <%--        Div for all the editing stuff (ddlChapter, txtChapTitle, the editor and save buttons)--%>
        <div class="span8 offset2 well">
            <div class="post">
                <asp:Label ID="lblChooseStory" runat="server" Text="Choose a Story"></asp:Label>
                <asp:DropDownList ID="ddlStory" class="input-xlarge" DataTextField="Title" DataValueField="ID"
                    runat="server" OnSelectedIndexChanged="ddlStory_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="Choose a Story"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <div class="post">
                <asp:Label ID="Label1" runat="server" Text="Choose a Chapter"></asp:Label>
                <asp:DropDownList ID="ddlChapters" runat="server" DataTextField="Title" DataValueField="ID"
                    OnSelectedIndexChanged="ddlChapters_SelectedIndexChanged" AutoPostBack="true"
                    OnDataBound="ddlChapters_DataBound" Enabled="false" Visible="false">
                    <asp:ListItem Selected="True" Text="Choose a Story"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <!-- Text input-->
            <div class="post">
                <asp:Label ID="Label2" runat="server" Text="Title of Chapter"></asp:Label>
                <asp:TextBox ID="txtChapTitle" runat="server" class="input-large"></asp:TextBox>
            </div>
            <div class="post">
                <textarea id="editor1" name="editor1"></textarea>
                <asp:HiddenField ID="hidnExisting" runat="server" />
                <asp:Button ID="btnSaveChanges" runat="server" Text="Save Changes" class="input-large"
                    OnClientClick="getText()" OnClick="btnSaveChanges_Click" />
            </div>
        </div>
    </div>
    <%--                Javascript for getting and setting the text of the editor--%>
    <script type="text/javascript">
        CKEDITOR.replace('editor1');
        function getText() {
            var editorText = CKEDITOR.instances.editor1.getData();
            document.getElementById('<%= hidnExisting.ClientID %>').value = editorText;
        }
        function setText() {
            var editorText = document.getElementById('<%= hidnExisting.ClientID %>').value
            CKEDITOR.instances.editor1.setData(editorText);
        }
    </script>
</asp:Content>

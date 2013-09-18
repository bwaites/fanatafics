<%@ Page Title="Add a Chapter" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddChapter.aspx.cs" Inherits="Site.AddChapter" ValidateRequest="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <script src="ckeditor/ckeditor.js" type="text/javascript"></script>
    <script src="Assets/js/jquery-1.7.2.min.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="form-horizontal">
        <!-- Form Name -->
        <div class="span6 offset3">
            <h2 class="title">
                Fanatical Editor&nbsp; - &nbsp;Chapter Adding</h2>
        </div>
        <%--        Div for all the editing stuff (ddlChapter, txtChapTitle, the editor and save buttons)--%>
        <div class="span8 offset2 well">
            <!-- Select Basic -->
            <div class="post">
                <asp:Label ID="lblChooseStory" runat="server" Text="Choose a Story   "></asp:Label>
                <asp:DropDownList ID="ddlStory" class="input-xlarge" DataTextField="Title" DataValueField="ID"
                    runat="server" OnSelectedIndexChanged="ddlStory_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Selected="True" Text="Choose a Story"></asp:ListItem>
                </asp:DropDownList>
            </div>
            <!-- Text input-->
            <div class="post">
                <asp:Label ID="Label1" runat="server" Text="Title of Chapter   "></asp:Label>
                <asp:TextBox ID="txtChapTitle" runat="server" class="input-large"></asp:TextBox>
            </div>
            <div class="post">
                <textarea id="editor1" name="editor1"></textarea>
                <asp:HiddenField ID="hidnEdit" runat="server" />
                <div class="span1 offset3">
                    <asp:Button ID="btnAddChapter" runat="server" Text="Add Chapter" class="input-large"
                        OnClientClick="getText()" OnClick="btnAddChapter_Click" Visible="False" />
                </div>
            </div>
        </div>
    </div>
    <script type="text/javascript">
        CKEDITOR.replace('editor1');

        function getText() {
            var editorText = CKEDITOR.instances.editor1.getData();
            document.getElementById('<%= hidnEdit.ClientID %>').value = editorText;
        }
    </script>
</asp:Content>

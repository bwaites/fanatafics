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
        </h2>
        <%--        Div for all the editing stuff (ddlChapter, txtChapTitle, the editor and save buttons)--%>
        <div class="span8 offset3 well" runat="server">
            <!-- Select Basic -->
            <div class="control-group">
                <div class="controls">
                    <asp:Label ID="lblChooseStory" runat="server" Text="Choose a Story   "></asp:Label>
                    <asp:DropDownList ID="ddlStory" class="input-xlarge" DataTextField="Title" DataValueField="ID"
                        runat="server" OnSelectedIndexChanged="ddlStory_SelectedIndexChanged" AutoPostBack="true">
                        <asp:ListItem Selected="True" Text="Choose a Story"></asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <!-- Text input-->
            <div class="control-group">
                <div class="controls">
                    
                    <asp:Label ID="Label1" runat="server" Text="Title of Chapter   "></asp:Label>
                    
                    <asp:TextBox ID="txtChapTitle" runat="server" class="input-large"></asp:TextBox>                    
                    
                </div>
            </div>
            <div id="textArea">
                <textarea id="editor1" name="editor1"></textarea>
                <asp:HiddenField ID="hidnEdit" runat="server" />
                <%--                Javascript for getting and setting the text of the editor--%>
                <asp:Button ID="btnAddChapter" runat="server" Text="Add Chapter" class="input-large"
                    OnClientClick="getText()" OnClick="btnAddChapter_Click" />
            </div>
        </div>
    </div>
    <script type="text/javascript">
        CKEDITOR.replace('editor1');


        //instance
        function getText() {
            var editorText = CKEDITOR.instances.editor1.getData();
            document.getElementById('<%= hidnEdit.ClientID %>').value = editorText;
        }

        function setText() {
            var editorText = document.getElementById('<%= hidnEdit.ClientID %>').value;
            CKEDITOR.instances.editor1.setData(editorText);
        }

    </script>
</asp:Content>

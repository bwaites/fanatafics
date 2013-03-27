<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/Fanatafics.Master"
    CodeBehind="AddChapter.aspx.vb" Inherits="FanataficsSite.AddChapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
        <!-- Text Editor toolbar-->
      <%--  <div class="btn-toolbar">
            <div class="btn-group">
                <button class="btn" data-original-title="Bold - Ctrl+B">
                    <i class="icon-bold"></i>
                </button>
                <button class="btn" data-original-title="Italic - Ctrl+I">
                    <i class="icon-italic"></i>
                </button>
                <button class="btn" data-original-title="List">
                    <i class="icon-list"></i>
                </button>
                <button class="btn" data-original-title="Img">
                    <i class="icon-picture"></i>
                </button>
                <button class="btn" data-original-title="URL">
                    <i class="icon-arrow-right"></i>
                </button>
            </div>
            <div class="btn-group">
                <button class="btn" data-original-title="Align Right">
                    <i class="icon-align-right"></i>
                </button>
                <button class="btn" data-original-title="Align Center">
                    <i class="icon-align-center"></i>
                </button>
                <button class="btn" data-original-title="Align Left">
                    <i class="icon-align-left"></i>
                </button>
            </div>
            <div class="btn-group">
                <button class="btn" data-original-title="Preview">
                    <i class="icon-eye-open"></i>
                </button>
                <button class="btn" data-original-title="Save">
                    <i class="icon-ok"></i>
                </button>
                <button class="btn" data-original-title="Cancel">
                    <i class="icon-trash"></i>
                </button>
            </div>

        </div>--%>
    </div>
</asp:Content>

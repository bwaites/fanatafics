<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true"
    CodeBehind="AddChapter.aspx.cs" Inherits="Site.AddChapter" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link href="Assets/css/prettify.css" rel="stylesheet" type="text/css" />
<%--    <link href="Assets/css/wysiwyg-color.css" rel="stylesheet" type="text/css" />


    <script src="Assets/js/prettify.js" type="text/javascript"></script>
    
    <%--<script src="Assets/js/wysihtml5-0.3.0.min.js" type="text/javascript"></script>--%>
    <script src="Assets/js/bootstrap-wysihtml5.js" type="text/javascript"></script>
    <link href="Assets/css/bootstrap-wysihtml5.css" rel="stylesheet" type="text/css" />
    <script src="Assets/js/bootstrap-button.js" type="text/javascript"></script>
    <script src="Assets/js/bootstrap-wysiwyg.js" type="text/javascript"></script>
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
        <ul class="wysihtml5-toolbar" style="">
            <li class="dropdown"><a class="btn dropdown-toggle" data-toggle="dropdown" href="#">
                <i class="icon-font"></i>&nbsp;<span class="current-font">Normal text</span>&nbsp;<b
                    class="caret"></b></a><ul class="dropdown-menu">
                        <li><a data-wysihtml5-command="formatBlock" data-wysihtml5-command-value="div" href="javascript:;"
                            unselectable="on">Normal text</a></li><li><a data-wysihtml5-command="formatBlock"
                                data-wysihtml5-command-value="h1" href="javascript:;" unselectable="on">Heading
                                1</a></li><li><a data-wysihtml5-command="formatBlock" data-wysihtml5-command-value="h2"
                                    href="javascript:;" unselectable="on">Heading 2</a></li></ul>
            </li>
            <li>
                <div class="btn-group">
                    <a class="btn" data-wysihtml5-command="bold" title="CTRL+B" href="javascript:;" unselectable="on">
                        Bold</a><a class="btn" data-wysihtml5-command="italic" title="CTRL+I" href="javascript:;"
                            unselectable="on">Italic</a><a class="btn" data-wysihtml5-command="underline" title="CTRL+U"
                                href="javascript:;" unselectable="on">Underline</a></div>
            </li>
            <li>
                <div class="btn-group">
                    <a class="btn" data-wysihtml5-command="insertUnorderedList" title="Unordered List"
                        href="javascript:;" unselectable="on"><i class="icon-list"></i></a><a class="btn"
                            data-wysihtml5-command="insertOrderedList" title="Ordered List" href="javascript:;"
                            unselectable="on"><i class="icon-th-list"></i></a><a class="btn" data-wysihtml5-command="Outdent"
                                title="Outdent" href="javascript:;" unselectable="on"><i class="icon-indent-right">
                                </i></a><a class="btn" data-wysihtml5-command="Indent" title="Indent" href="javascript:;"
                                    unselectable="on"><i class="icon-indent-left"></i></a>
                </div>
            </li>
            <li>
                <div class="bootstrap-wysihtml5-insert-link-modal modal hide fade">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a><h3>
                            Insert Link</h3>
                    </div>
                    <div class="modal-body">
                        <input value="http://" class="bootstrap-wysihtml5-insert-link-url input-xlarge"></div>
                    <div class="modal-footer">
                        <a href="#" class="btn" data-dismiss="modal">Cancel</a><a href="#" class="btn btn-primary"
                            data-dismiss="modal">Insert link</a></div>
                </div>
                <a class="btn" data-wysihtml5-command="createLink" title="Link" href="javascript:;"
                    unselectable="on"><i class="icon-share"></i></a></li>
            <li>
                <div class="bootstrap-wysihtml5-insert-image-modal modal hide fade">
                    <div class="modal-header">
                        <a class="close" data-dismiss="modal">×</a><h3>
                            Insert Image</h3>
                    </div>
                    <div class="modal-body">
                        <input value="http://" class="bootstrap-wysihtml5-insert-image-url input-xlarge"></div>
                    <div class="modal-footer">
                        <a href="#" class="btn" data-dismiss="modal">Cancel</a><a href="#" class="btn btn-primary"
                            data-dismiss="modal">Insert image</a></div>
                </div>
                <a class="btn" data-wysihtml5-command="insertImage" title="Insert image" href="javascript:;"
                    unselectable="on"><i class="icon-picture"></i></a></li>
        </ul>
        <textarea class="textarea" style="width: 810px; height: 200px; display: none;" placeholder="Enter text ..."></textarea>
        <input type="hidden" name="_wysihtml5_mode" value="1">
        <iframe class="wysihtml5-sandbox" security="restricted" allowtransparency="true"
            frameborder="0" width="0" height="0" marginwidth="0" marginheight="0" style="background-color: rgb(255, 255, 255);
            border-collapse: separate; border: 1px solid rgb(204, 204, 204); clear: none;
            display: inline-block; float: none; margin: 0px 0px 9px; outline: rgb(85, 85, 85) none 0px;
            outline-offset: 0px; padding: 4px; position: static; top: auto; left: auto; right: auto;
            bottom: auto; z-index: auto; vertical-align: top; text-align: start; box-sizing: content-box;
            -webkit-box-shadow: rgba(0, 0, 0, 0.0745098) 0px 1px 1px 0px inset; box-shadow: rgba(0, 0, 0, 0.0745098) 0px 1px 1px 0px inset;
            border-top-right-radius: 3px; border-bottom-right-radius: 3px; border-bottom-left-radius: 3px;
            border-top-left-radius: 3px; width: 810px; height: 200px;"></iframe>

            <script type="text/javascript" charset="utf-8">
                $(prettyPrint);
</script>
    </div>
</asp:Content>


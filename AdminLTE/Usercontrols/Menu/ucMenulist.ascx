<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenulist.ascx.cs" Inherits="AdminLTE.Usercontrols.Menu.ucMenulist" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Language", null, { path: '/' });
        $.cookie("txtCode", null, { path: '/' });
        $.cookie("txtTitle", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("txtUrl", null, { path: '/' });
        $.cookie("MenuPosition", null, { path: '/' });
        $.cookie("ParentMenuID", null, { path: '/' });
        $.cookie("ObjectType", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Menu/viewMenu.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

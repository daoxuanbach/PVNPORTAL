<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucFunctionList.ascx.cs" Inherits="AdminLTE.Usercontrols.FunctionList.ucFunctionList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Search", null, { path: '/' });
        $.cookie("Language", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("ParentFunctionID", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/FunctionList/viewFunctionList.aspx");

    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

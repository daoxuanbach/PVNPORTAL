<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSysUser.ascx.cs" Inherits="AdminLTE.Usercontrols.SysUser.ucSysUser" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("Language", null, { path: '/' });
        postData(1, "/UserControls/SysUser/viewSysUser.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

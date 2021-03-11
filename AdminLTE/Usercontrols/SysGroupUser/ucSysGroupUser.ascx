<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSysGroupUser.ascx.cs" Inherits="AdminLTE.Usercontrols.SysGroupUser.ucSysGroupUser" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("Language", null, { path: '/' });
        postData(1, "/UserControls/SysGroupUser/viewSysGroupUser.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRolePermissionForUserList.ascx.cs" Inherits="AdminLTE.Usercontrols.SysUser.ucRolePermissionForUserList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("Language", null, { path: '/' });
        postData(1, "/UserControls/SysUser/viewRolePermissionForUserList.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 
</div>
<!-- /.content-wrapper -->

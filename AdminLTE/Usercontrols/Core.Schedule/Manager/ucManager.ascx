<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucManager.ascx.cs" Inherits="AdminLTE.Usercontrols.Manager.ucManager" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Name", null, { path: '/' });
        $.cookie("ShortName", null, { path: '/' });
        $.cookie("ManagerType", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Core.Schedule/Manager/viewManager.aspx");
    })
</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

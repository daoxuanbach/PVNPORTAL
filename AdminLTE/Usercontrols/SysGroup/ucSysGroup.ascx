<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSysGroup.ascx.cs" Inherits="AdminLTE.Usercontrols.SysGroup.ucSysGroup" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("Language", null, { path: '/' });
        postData(1, "/UserControls/SysGroup/viewSysGroup.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

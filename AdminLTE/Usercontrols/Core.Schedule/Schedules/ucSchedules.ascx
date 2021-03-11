<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSchedules.ascx.cs" Inherits="AdminLTE.Usercontrols.Schedules.ucSchedules" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtSearch", null, { path: '/' });
        $.cookie("Description", null, { path: '/' });
        $.cookie("FromAddress", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Core.Schedule/Schedules/viewSchedules.aspx");
    })
</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

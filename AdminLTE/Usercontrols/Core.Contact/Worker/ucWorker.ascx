<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucWorker.ascx.cs" Inherits="AdminLTE.Usercontrols.Worker.ucWorker" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("FirstName", null, { path: '/' });
        $.cookie("LastName", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CompanyID", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Core.Contact/Worker/viewWorker.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCompanyChart.ascx.cs" Inherits="AdminLTE.Usercontrols.CompanyChart.ucCompanyChart" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Name", null, { path: '/' });
        $.cookie("CompanyType", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/CompanyChart/viewCompanyChart.aspx");
    })
</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

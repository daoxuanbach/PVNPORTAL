<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCompany.ascx.cs" Inherits="AdminLTE.Usercontrols.Company.ucCompany" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("CompanyName", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        $.cookie("ParentCompany", null, { path: '/' });
        postData(1, "/UserControls/Core.Contact/Company/viewCompany.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

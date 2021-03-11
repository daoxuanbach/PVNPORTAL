<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDonViBanHanh.ascx.cs" Inherits="AdminLTE.Usercontrols.DonViBanHanh.ucDonViBanHanh" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtMa", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("txtTen", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/CoreDoc/DonViBanHanh/viewDonViBanHanh.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

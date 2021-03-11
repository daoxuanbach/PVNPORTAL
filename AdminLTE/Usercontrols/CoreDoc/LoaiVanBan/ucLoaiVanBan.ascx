<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiVanBan.ascx.cs" Inherits="AdminLTE.Usercontrols.LoaiVanBan.ucLoaiVanBan" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtMa", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("txtTen", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("LoaiVanBanID", null, { path: '/' });
        postData(1, "/UserControls/CoreDoc/LoaiVanBan/viewLoaiVanBan.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

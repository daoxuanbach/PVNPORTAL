<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVanBanPheDuyet.ascx.cs" Inherits="AdminLTE.Usercontrols.VanBan.ucVanBanPheDuyet" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtSoVanBan", null, { path: '/' });
        $.cookie("txtTieuDe", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        $.cookie("LoaiVanBanID", null, { path: '/' });
        postData(1, "/UserControls/CoreDoc/VanBan/viewVanBanPheDuyet.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

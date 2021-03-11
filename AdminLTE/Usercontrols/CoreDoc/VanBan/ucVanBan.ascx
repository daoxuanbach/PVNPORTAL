<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVanBan.ascx.cs" Inherits="AdminLTE.Usercontrols.VanBan.ucVanBan" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtSoVanBan", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("txtTieuDe", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        $.cookie("LoaiVanBanID", null, { path: '/' });
        postData(1, "/UserControls/CoreDoc/VanBan/viewVanBan.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

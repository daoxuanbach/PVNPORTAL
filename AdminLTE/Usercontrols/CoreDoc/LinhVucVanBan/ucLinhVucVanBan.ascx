<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLinhVucVanBan.ascx.cs" Inherits="AdminLTE.Usercontrols.LinhVucVanBan.ucLinhVucVanBan" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtMa", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("txtTen", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });

        postData(1, "/UserControls/CoreDoc/LinhVucVanBan/viewLinhVucVanBan.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

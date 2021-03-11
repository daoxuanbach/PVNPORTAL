<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLoaiLienHe.ascx.cs" Inherits="AdminLTE.Usercontrols.LoaiLienHe.ucLoaiLienHe" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("ContactType", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Core.Contact/LoaiLienHe/viewLoaiLienHe.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

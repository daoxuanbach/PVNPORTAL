<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucJobTitle.ascx.cs" Inherits="AdminLTE.Usercontrols.QLChucDanh.ucJobTitle" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("ContactType", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' }); 
        postData(1, "/UserControls/Core.Contact/QLChucDanh/viewJobTitle.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

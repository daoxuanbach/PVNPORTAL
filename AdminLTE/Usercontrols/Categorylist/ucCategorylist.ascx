<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucCategorylist.ascx.cs" Inherits="AdminLTE.Usercontrols.Categorylist.ucCategorylist" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Language", null, { path: '/' });
        postData(1, "/UserControls/Categorylist/viewCategorylist.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

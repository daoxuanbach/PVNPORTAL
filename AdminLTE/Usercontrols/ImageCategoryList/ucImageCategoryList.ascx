<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucImageCategoryList.ascx.cs" Inherits="AdminLTE.Usercontrols.ImageCategoryList.ucImageCategoryList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("UsedState", null, { path: '/' });
        postData(1, "/UserControls/ImageCategoryList/viewImageCategoryList.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

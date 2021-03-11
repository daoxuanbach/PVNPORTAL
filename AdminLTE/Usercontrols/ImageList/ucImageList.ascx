<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucImageList.ascx.cs" Inherits="AdminLTE.Usercontrols.ImageList.ucImageList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Language", null, { path: '/' });
        $.cookie("txtDesscription", null, { path: '/' });
        $.cookie("ImageCategoryID", null, { path: '/' });
        $.cookie("txtSearch", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        $.cookie("PublishedState", null, { path: '/' });

        postData(1, "/UserControls/ImageList/viewImageList.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

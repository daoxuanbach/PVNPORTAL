<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVideoList.ascx.cs" Inherits="AdminLTE.Usercontrols.VideoList.ucVideoList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Language", null, { path: '/' });
        $.cookie("txtDesscription", null, { path: '/' });
        $.cookie("VideoCategoryID", null, { path: '/' });
        $.cookie("txtSearch", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        $.cookie("PublishedState", null, { path: '/' });
        postData(1, "/UserControls/VideoList/viewVideoList.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

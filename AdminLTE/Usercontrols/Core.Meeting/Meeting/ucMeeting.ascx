<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMeeting.ascx.cs" Inherits="AdminLTE.Usercontrols.Meeting.ucMeeting" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Title", null, { path: '/' });
        $.cookie("RoomName", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Core.Meeting/Meeting/viewMeeting.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucRoom.ascx.cs" Inherits="AdminLTE.Usercontrols.Room.ucRoom" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("RoomName", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/Core.Meeting/Room/viewRoom.aspx");
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

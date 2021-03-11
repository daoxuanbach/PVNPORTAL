<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucEventList.ascx.cs" Inherits="AdminLTE.Usercontrols.EventList.ucEventList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("EventName",null, { path: '/' });
        $.cookie("EventType", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("Estiomae", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        getPage("/UserControls/EventList/viewEventList.aspx?action=add");
       
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
    

</div>  
<!-- /.content-wrapper -->

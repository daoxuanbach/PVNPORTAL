<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSysPage.ascx.cs" Inherits="AdminLTE.Usercontrols.SysPage.ucSysPage" %>

<script type="text/javascript">
    $(document).ready(function () {
        postData(1, "/UserControls/SysPage/viewSysPage.aspx");
    })
  
</script>
<input type="hidden" value="1" id="FunctionID" />
<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

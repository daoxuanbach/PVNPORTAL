<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSysRole.ascx.cs" Inherits="AdminLTE.Usercontrols.SysRole.ucSysRole" %>

<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("txtSearch", null, { path: '/' });
        $.cookie("FunctionID", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        postData(1, "/UserControls/SysRole/viewSysRole.aspx");
      
    })
  
</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
 

</div>
<!-- /.content-wrapper -->

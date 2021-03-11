<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsList.ascx.cs" Inherits="AdminLTE.Usercontrols.NewsList.ucNewsList" %>
<script type="text/javascript">
    $(document).ready(function () {
        $.cookie("Language", null, { path: '/' });
        $.cookie("txtSummary", null, { path: '/' });
        $.cookie("CategoryID", null, { path: '/' });
        $.cookie("txtSearch", null, { path: '/' });
        $.cookie("UsedState", null, { path: '/' });
        $.cookie("FromDate", null, { path: '/' });
        $.cookie("ToDate", null, { path: '/' });
        $.cookie("CurPage", null, { path: '/' });
        getPage("/UserControls/NewsList/viewNewsList.aspx?action=add");
       
    })

</script>

<!-- Content Wrapper. Contains page content -->
<div id="data-content" class="content-wrapper">
    

</div>  
<!-- /.content-wrapper -->

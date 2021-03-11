<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="uc_Side_menu.ascx.cs" Inherits="AdminLTE.Usercontrols.uc_Side_menu" %>
<%@ Register Src="~/Usercontrols/ucSearchSidebar.ascx" TagPrefix="uc1" TagName="ucSearchSidebar" %>
<!-- Left side column. contains the logo and sidebar -->
<aside class="main-sidebar">
    <!-- sidebar: style can be found in sidebar.less -->
    <section class="sidebar">
        
        <!-- search form -->
        <uc1:ucSearchSidebar runat="server" ID="ucSearchSidebar" />
        <!-- /.search form -->
        <!-- sidebar menu: : style can be found in sidebar.less -->


        <asp:Literal ID="ShowMenu" runat="server"></asp:Literal>
        

         
    </section>
    <!-- /.sidebar -->
</aside>

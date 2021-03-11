<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="BanHanhVanBanList.aspx.cs" Inherits="AdminLTE.Manage.pages.BanHanhVanBanList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/VanBan/ucVanBanBanHanh.ascx" TagPrefix="uc1" TagName="ucVanBanBanHanh" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVanBanBanHanh runat="server" ID="ucVanBanBanHanh" />
</asp:Content>

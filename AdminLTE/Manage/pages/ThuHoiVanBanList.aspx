<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="ThuHoiVanBanList.aspx.cs" Inherits="AdminLTE.Manage.pages.ThuHoiVanBanList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/VanBan/ucVanBanThuHoi.ascx" TagPrefix="uc1" TagName="ucVanBanThuHoi" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVanBanThuHoi runat="server" id="ucVanBanThuHoi" />
</asp:Content>

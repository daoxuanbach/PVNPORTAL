<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin.Master" CodeBehind="LoaiVanBanList.aspx.cs" Inherits="AdminLTE.Manage.pages.LoaiVanBanList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/LoaiVanBan/ucLoaiVanBan.ascx" TagPrefix="uc1" TagName="ucLoaiVanBan" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucLoaiVanBan runat="server" ID="ucLoaiVanBan" />
</asp:Content>


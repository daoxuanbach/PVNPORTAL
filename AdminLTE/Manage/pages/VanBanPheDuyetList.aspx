<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="VanBanPheDuyetList.aspx.cs" Inherits="AdminLTE.Manage.pages.VanBanPheDuyetList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/VanBan/ucVanBanPheDuyet.ascx" TagPrefix="uc1" TagName="ucVanBanPheDuyet" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVanBanPheDuyet runat="server" ID="ucVanBanPheDuyet" />
</asp:Content>

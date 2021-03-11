<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="VanBanList.aspx.cs" Inherits="AdminLTE.Manage.pages.VanBanList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/VanBan/ucVanBan.ascx" TagPrefix="uc1" TagName="ucVanBan" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVanBan runat="server" ID="ucVanBan" />
</asp:Content>

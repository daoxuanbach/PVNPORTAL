<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin.Master" CodeBehind="LinhVucList.aspx.cs" Inherits="AdminLTE.Manage.pages.LinhVucList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/LinhVucVanBan/ucLinhVucVanBan.ascx" TagPrefix="uc1" TagName="ucLinhVucVanBan" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucLinhVucVanBan runat="server" ID="ucLinhVucVanBan" />
</asp:Content>

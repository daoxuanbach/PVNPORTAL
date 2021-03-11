<%@ Page Language="C#"  MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ContactTypeList.aspx.cs" Inherits="AdminLTE.Manage.pages.ContactTypeList" %>

<%@ Register Src="~/Usercontrols/Core.Contact/LoaiLienHe/ucLoaiLienHe.ascx" TagPrefix="uc1" TagName="ucLoaiLienHe" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucLoaiLienHe runat="server" ID="ucLoaiLienHe" />
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="PageList.aspx.cs" Inherits="AdminLTE.Manage.pages.PageList" %>

<%@ Register Src="~/Usercontrols/SysPage/ucSysPage.ascx" TagPrefix="uc1" TagName="ucSysPage" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSysPage runat="server" id="ucSysPage" />
</asp:Content>

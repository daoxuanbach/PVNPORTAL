<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="GroupUserEdit.aspx.cs" Inherits="AdminLTE.Manage.pages.GroupUserEdit" %>

<%@ Register Src="~/Usercontrols/SysGroupUser/ucSysGroupUser.ascx" TagPrefix="uc1" TagName="ucSysGroupUser" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSysGroupUser runat="server" id="ucSysGroupUser" />
</asp:Content>

<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="UserList.aspx.cs" Inherits="AdminLTE.Manage.pages.UserList" %>

<%@ Register Src="~/Usercontrols/SysUser/ucSysUser.ascx" TagPrefix="uc1" TagName="ucSysUser" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSysUser runat="server" id="ucSysUser" />
</asp:Content>

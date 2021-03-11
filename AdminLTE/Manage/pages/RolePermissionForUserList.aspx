<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RolePermissionForUserList.aspx.cs" Inherits="AdminLTE.Manage.pages.RolePermissionForUserList" %>
<%@ Register Src="~/Usercontrols/SysUser/ucRolePermissionForUserList.ascx" TagPrefix="uc1" TagName="ucRolePermissionForUserList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
 
    <uc1:ucRolePermissionForUserList runat="server" ID="ucRolePermissionForUserList" />
</asp:Content>

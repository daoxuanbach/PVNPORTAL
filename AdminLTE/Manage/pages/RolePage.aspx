<%@ Page Language="C#" MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="RolePage.aspx.cs" Inherits="AdminLTE.Manage.pages.RolePage" %>

<%@ Register Src="~/Usercontrols/SysRole/ucSysRole.ascx" TagPrefix="uc1" TagName="ucSysRole" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSysRole runat="server" ID="ucSysRole" />
</asp:Content>

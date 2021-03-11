<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="UnitList.aspx.cs" Inherits="AdminLTE.Manage.pages.UnitList" %>

<%@ Register Src="~/Usercontrols/SysUnit/ucSysUnit.ascx" TagPrefix="uc1" TagName="ucSysUnit" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSysUnit runat="server" ID="ucSysUnit" />
</asp:Content>

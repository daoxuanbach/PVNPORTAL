<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="GroupList.aspx.cs" Inherits="AdminLTE.Manage.pages.GroupList" %>

<%@ Register Src="~/Usercontrols/SysGroup/ucSysGroup.ascx" TagPrefix="uc1" TagName="ucSysGroup" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSysGroup runat="server" id="ucSysGroup" />
</asp:Content>

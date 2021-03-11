<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ManagerList.aspx.cs" Inherits="AdminLTE.Manage.pages.ManagerList" %>

<%@ Register Src="~/Usercontrols/Core.Schedule/Manager/ucManager.ascx" TagPrefix="uc1" TagName="ucManager" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucManager runat="server" ID="ucManager" />
</asp:Content>


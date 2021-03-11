<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="JobTitleList.aspx.cs" Inherits="AdminLTE.Manage.pages.JobTitleList" %>
<%@ Register Src="~/Usercontrols/Core.Contact/QLChucDanh/ucJobTitle.ascx" TagPrefix="uc1" TagName="ucJobTitle" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucJobTitle runat="server" ID="ucJobTitle" />
</asp:Content>

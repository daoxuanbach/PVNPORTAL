<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="categorylist.aspx.cs" Inherits="AdminLTE.Manage.pages.categorylist" %>

<%@ Register Src="~/Usercontrols/Categorylist/ucCategorylist.ascx" TagPrefix="uc1" TagName="ucCategorylist" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucCategorylist runat="server" id="ucCategorylist" />
</asp:Content>
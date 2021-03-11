<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="FunctionList.aspx.cs" Inherits="AdminLTE.Manage.pages.FunctionList" %>

<%@ Register Src="~/Usercontrols/FunctionList/ucFunctionList.ascx" TagPrefix="uc1" TagName="ucFunctionList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucFunctionList runat="server" id="ucFunctionList" />
</asp:Content>
<%@ Page Language="C#"  MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="CompanyList.aspx.cs" Inherits="AdminLTE.Manage.pages.CompanyList" %>
<%@ Register Src="~/Usercontrols/Core.Contact/Company/ucCompany.ascx" TagPrefix="uc1" TagName="ucCompany" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucCompany runat="server" ID="ucCompany" />
</asp:Content>

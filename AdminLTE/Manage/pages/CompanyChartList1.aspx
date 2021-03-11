<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="CompanyChartList1.aspx.cs" Inherits="AdminLTE.Manage.pages.CompanyChartList1" %>

<%@ Register Src="~/Usercontrols/CompanyChart/ucCompanyChart.ascx" TagPrefix="uc1" TagName="ucCompanyChart" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucCompanyChart runat="server" ID="ucCompanyChart" />
</asp:Content>


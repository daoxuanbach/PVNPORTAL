<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detailv1.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.detailv1" %>

<%@ Register Src="~/Usercontrols_EN/ucNewsBreadCumb.ascx" TagPrefix="uc1" TagName="ucNewsBreadCumb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucNewsBreadCumb runat="server" ID="ucNewsBreadCumb" />
</asp:Content>

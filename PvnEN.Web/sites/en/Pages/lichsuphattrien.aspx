<%@ Page Title="" Language="C#" MasterPageFile="~/PVN_EN.Master" AutoEventWireup="true" CodeBehind="lichsuphattrien.aspx.cs" Inherits="PvnEN.Web.sites.en.Pages.lichsuphattrien" %>

<%@ Register Src="~/Usercontrols_EN/ucHistory.ascx" TagPrefix="uc1" TagName="ucHistory" %>
<%@ Register Src="~/Usercontrols_EN/ucBreadcumb.ascx" TagPrefix="uc1" TagName="ucBreadcumb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucHistory runat="server" UrlDetail="/sites/en/pages/lichsuphattrien.aspx" Title="Video" ID="ucHistory" />
</asp:Content>

<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="lichsuphattrien.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.lichsuphattrien" %>

<%@ Register Src="~/Usercontrols_EN/ucHistory.ascx" TagPrefix="uc1" TagName="ucHistory" %>



<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucHistory runat="server" UrlDetail="/sites/en/pages/lichsuphattrien.aspx" Title="Video" ID="ucHistory" />
</asp:Content>

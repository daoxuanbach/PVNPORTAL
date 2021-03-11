<%@ Page Title="" Language="C#" MasterPageFile="~/PVN_EN.Master" AutoEventWireup="true" CodeBehind="banlanhdao.aspx.cs" Inherits="PvnEN.Web.sites.en.Pages.banlanhdao" %>

<%@ Register Src="~/Usercontrols_EN/ucbanlanhdao.ascx" TagPrefix="uc1" TagName="ucbanlanhdao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucbanlanhdao runat="server" id="ucbanlanhdao" />
</asp:Content>

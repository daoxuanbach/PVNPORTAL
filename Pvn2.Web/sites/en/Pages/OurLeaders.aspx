<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="OurLeaders.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.OurLeaders" %>

<%@ Register Src="~/Usercontrols_EN/ucbanlanhdao.ascx" TagPrefix="uc1" TagName="ucbanlanhdao" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucbanlanhdao runat="server" ID="ucbanlanhdao" />
</asp:Content>

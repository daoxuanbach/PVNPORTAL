<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pvn2.Web._Default" %>

<%@ Register Src="~/Usercontrols_EN/ucAboutMain.ascx" TagPrefix="uc1" TagName="ucAboutMain" %>
<%@ Register Src="~/Usercontrols_EN/ucProductMain.ascx" TagPrefix="uc1" TagName="ucProductMain" %>
<%@ Register Src="~/Usercontrols_EN/ucNewsListMain.ascx" TagPrefix="uc1" TagName="ucNewsListMain" %>









<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucAboutMain runat="server" ID="ucAboutMain" />
    <uc1:ucProductMain runat="server" ID="ucProductMain" />
    <uc1:ucNewsListMain runat="server" CategoryID="6698f31a-ba84-4225-9bd9-2acaca638a39" CurrentLanguage="en-US" NewsPriority="2" ID="ucNewsListMain" />
   </asp:Content>
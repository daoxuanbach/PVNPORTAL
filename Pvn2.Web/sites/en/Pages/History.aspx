<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Site.Master"  CodeBehind="History.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.History" %>

<%@ Register Src="~/Usercontrols_EN/ucHistory.ascx" TagPrefix="uc1" TagName="ucHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucHistory runat="server"  ID="ucHistory" />
</asp:Content>



<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="video.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.video" %>

<%@ Register Src="~/Usercontrols_EN/ucVideo.ascx" TagPrefix="uc1" TagName="ucVideo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucVideo runat="server" id="ucVideo" />
</asp:Content>

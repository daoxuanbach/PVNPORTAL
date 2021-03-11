<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="photo.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.photo" %>

<%@ Register Src="~/Usercontrols_EN/ucPhoto.ascx" TagPrefix="uc1" TagName="ucPhoto" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucPhoto runat="server" id="ucPhoto" TotalItems="20" CurrentLanguage="vi-VN" MaxLengthTitle="50" OtherImageSize ="C130X80" />
</asp:Content>

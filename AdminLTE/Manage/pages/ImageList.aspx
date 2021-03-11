<%@ Page Language="C#" MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="ImageList.aspx.cs" Inherits="AdminLTE.Manage.pages.ImageList" %>

<%@ Register Src="~/Usercontrols/ImageList/ucImageList.ascx" TagPrefix="uc1" TagName="ucImageList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucImageList runat="server" id="ucImageList" />
</asp:Content>
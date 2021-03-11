<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="ImageCategoryList.aspx.cs" Inherits="AdminLTE.Manage.pages.ImageCategoryList" %>

<%@ Register Src="~/Usercontrols/ImageCategoryList/ucImageCategoryList.ascx" TagPrefix="uc1" TagName="ucImageCategoryList" %>



<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucImageCategoryList runat="server" ID="ucImageCategoryList" />
</asp:Content>

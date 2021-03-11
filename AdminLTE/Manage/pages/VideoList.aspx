<%@ Page Language="C#" MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="VideoList.aspx.cs" Inherits="AdminLTE.Manage.pages.VideoList" %>

<%@ Register Src="~/Usercontrols/VideoList/ucVideoList.ascx" TagPrefix="uc1" TagName="ucVideoList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVideoList runat="server" ID="ucVideoList" />
</asp:Content>
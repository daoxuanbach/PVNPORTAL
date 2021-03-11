<%@ Page Language="C#"  MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="VideoCategoryList.aspx.cs" Inherits="AdminLTE.Manage.pages.VideoCategoryList" %>

<%@ Register Src="~/Usercontrols/VideoCategoryList/ucVideoCategoryList.ascx" TagPrefix="uc1" TagName="ucVideoCategoryList" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucVideoCategoryList runat="server" id="ucVideoCategoryList" />
</asp:Content>

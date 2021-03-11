<%@ Page Title="" Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="newslist.aspx.cs" Inherits="AdminLTE.Manage.pages.newslist" %>

<%@ Register Src="~/Usercontrols/NewsList/ucNewsList.ascx" TagPrefix="uc1" TagName="ucNewsList" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucNewsList runat="server" id="ucNewsList" />
</asp:Content>

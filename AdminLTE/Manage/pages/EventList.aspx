<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/Admin.Master" CodeBehind="EventList.aspx.cs" Inherits="AdminLTE.Manage.pages.EventList" %>

<%@ Register Src="~/Usercontrols/EventList/ucEventList.ascx" TagPrefix="uc1" TagName="ucEventList" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucEventList runat="server" id="ucEventList" />
</asp:Content>

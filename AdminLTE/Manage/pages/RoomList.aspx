<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="RoomList.aspx.cs" Inherits="AdminLTE.Manage.pages.RoomList" %>

<%@ Register Src="~/Usercontrols/Core.Meeting/Room/ucRoom.ascx" TagPrefix="uc1" TagName="ucRoom" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucRoom runat="server" id="ucRoom" />
</asp:Content>


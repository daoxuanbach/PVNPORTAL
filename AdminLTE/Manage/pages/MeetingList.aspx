<%@ Page Language="C#"  MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="MeetingList.aspx.cs" Inherits="AdminLTE.Manage.pages.MeetingList" %>

<%@ Register Src="~/Usercontrols/Core.Meeting/Meeting/ucMeeting.ascx" TagPrefix="uc1" TagName="ucMeeting" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucMeeting runat="server" id="ucMeeting" />
</asp:Content>


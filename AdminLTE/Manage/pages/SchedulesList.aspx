<%@ Page Language="C#" MasterPageFile="~/Admin.Master" AutoEventWireup="true" CodeBehind="SchedulesList.aspx.cs" Inherits="AdminLTE.Manage.pages.SchedulesList" %>

<%@ Register Src="~/Usercontrols/Core.Schedule/Schedules/ucSchedules.ascx" TagPrefix="uc1" TagName="ucSchedules" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucSchedules runat="server" id="ucSchedules" />
</asp:Content>


<%@ Page Language="C#" MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="WorkerList.aspx.cs" Inherits="AdminLTE.Manage.pages.WorkerList" %>

<%@ Register Src="~/Usercontrols/Core.Contact/Worker/ucWorker.ascx" TagPrefix="uc1" TagName="ucWorker" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucWorker runat="server" id="ucWorker" />
</asp:Content>
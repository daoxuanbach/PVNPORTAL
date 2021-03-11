<%@ Page Language="C#" AutoEventWireup="true"  MasterPageFile="~/Admin.Master" CodeBehind="DonViBanHanhList.aspx.cs" Inherits="AdminLTE.Manage.pages.DonViBanHanhList" %>

<%@ Register Src="~/Usercontrols/CoreDoc/DonViBanHanh/ucDonViBanHanh.ascx" TagPrefix="uc1" TagName="ucDonViBanHanh" %>


<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucDonViBanHanh runat="server" ID="ucDonViBanHanh" />
</asp:Content>

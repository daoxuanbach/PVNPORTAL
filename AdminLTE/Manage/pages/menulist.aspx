<%@ Page Language="C#" MasterPageFile="~/Admin.Master"  AutoEventWireup="true" CodeBehind="menulist.aspx.cs" Inherits="AdminLTE.Manage.pages.menulist" %>

<%@ Register Src="~/Usercontrols/Menu/ucMenulist.ascx" TagPrefix="uc1" TagName="ucMenulist" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <uc1:ucMenulist runat="server" id="ucMenulist" />
</asp:Content>


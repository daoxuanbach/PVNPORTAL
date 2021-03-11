<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.list" %>

<%@ Register Src="~/Usercontrols_EN/ucNewsList.ascx" TagPrefix="uc1" TagName="ucNewsList" %>
<%@ Register Src="~/Usercontrols_EN/ucNewsBreadCumb.ascx" TagPrefix="uc1" TagName="ucNewsBreadCumb" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucNewsBreadCumb runat="server" ID="ucNewsBreadCumb" />
     <div class="row">
    <div class="col-md-12 no-padding">
        <uc1:ucNewsList runat="server" id="ucNewsList"  />
        <%--E81F5A22-690E-4FC2-B489-1327D6C42BBC--%>
    </div>
</div>
</asp:Content>

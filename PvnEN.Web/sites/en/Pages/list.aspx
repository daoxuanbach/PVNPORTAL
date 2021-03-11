<%@ Page Title="" Language="C#" MasterPageFile="~/PVN_EN.Master" AutoEventWireup="true" CodeBehind="list.aspx.cs" Inherits="PvnEN.Web.sites.en.Pages.list" %>

<%@ Register Src="~/Usercontrols_EN/ucNewsList.ascx" TagPrefix="uc1" TagName="ucNewsList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div class="row">
    <div class="col-md-9 no-padding">
        <uc1:ucNewsList runat="server" id="ucNewsList" />
        <%--E81F5A22-690E-4FC2-B489-1327D6C42BBC--%>
    </div>
    <div class="col-md-3">
         <div class="row">
            <div class="col-xs-12 no-padding">
              123
            </div>
        </div>
    </div>
</div>
</asp:Content>

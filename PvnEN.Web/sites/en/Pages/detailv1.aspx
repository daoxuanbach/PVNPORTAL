<%@ Page Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detailv1.aspx.cs" Inherits="PvnEN.Web.sites.en.Pages.detailv1" %>

<%@ Register Src="~/Usercontrols_EN/ucNewsBreadCumb.ascx" TagPrefix="uc1" TagName="ucNewsBreadCumb" %>
<%@ Register Src="~/Usercontrols_EN/ucNewsDetail2.ascx" TagPrefix="uc1" TagName="ucNewsDetail2" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <uc1:ucNewsBreadCumb runat="server" ID="ucNewsBreadCumb" />
    <div class="container-fluid">
        <div class="content col-xs-12">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-9">
                        <uc1:ucNewsDetail2 runat="server" ID="ucNewsDetail2" />
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

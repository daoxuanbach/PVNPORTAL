<%@ Page Title="" Language="C#" MasterPageFile="~/PVN_EN.Master" AutoEventWireup="true" CodeBehind="detail.aspx.cs" Inherits="PvnEN.Web.sites.en.Pages.detail" %>

<%@ Register Src="~/Usercontrols_EN/ucMenuSideEN.ascx" TagPrefix="uc1" TagName="ucMenuSideEN" %>
<%@ Register Src="~/Usercontrols_EN/ucNewsRelated.ascx" TagPrefix="uc1" TagName="ucNewsRelated" %>
<%@ Register Src="~/Usercontrols_EN/ucBreadcumb.ascx" TagPrefix="uc1" TagName="ucBreadcumb" %>
<%@ Register Src="~/Usercontrols_EN/ucNewsDetail.ascx" TagPrefix="uc1" TagName="ucNewsDetail" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="breachcrum_bg">
        <img src="/wp-includes/img/br_1.png" class="custom-logo" alt="">
    </div>
    <div class="navigator_bar">
        <div class="container">
            <ul>
            </ul>
        </div>
    </div>

    <div class="container-fluid">
        <div class="content col-xs-12">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12 col-sm-6 col-md-9">
                        <div class="post-content">
                            <uc1:ucNewsDetail runat="server" ID="ucNewsDetail" />
                        </div>
                    </div>
                    <div class="col-xs-12 col-sm-6 col-md-3">
                        <div class="widget_left">
                            <uc1:ucMenuSideEN TieuDeMenu="CATEGORIES" MenuPosition="1" ParentMenuID="4F848559-0698-4E7B-95FE-3341549E1DAD" runat="server" ID="ucMenuSideEN" />
                            <h5 class="widget-title">PRODUCT</h5>
                            <img style="padding-top: 5px;" src="/wp-includes/img/product_img.png">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

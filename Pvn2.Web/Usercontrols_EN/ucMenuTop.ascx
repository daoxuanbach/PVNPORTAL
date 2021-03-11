<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuTop.ascx.cs" Inherits="Pvn2.Web.Usercontrols_EN.ucMenuTop" %>
<%@ Register Src="~/Usercontrols_EN/ucTopBar_KH.ascx" TagPrefix="uc1" TagName="ucTopBar_KH" %>
<uc1:ucTopBar_KH runat="server" ID="ucTopBar_KH1" />
<div class="navbar_css">
<nav id="page-hd" class="navbar navbar-fixed-top">
        <div class="container">
            <div class="navbar-header">
                <button class="menu-trigger collapse collapsed" data-toggle="collapse" data-target="#hd-nav" aria-expanded="false" aria-controls="navbar">
                    <span>Menu</span>
                </button>
                <div class="menu-brand_css">
                    <a class="logo" href="#">
                       <img width="380" height="71" src="/wp-includes/img/banner.png" alt="Logo">
                    </a>
                </div>
            </div>
            <div id="hd-nav" class="navbar-main navbar-collapse collapse">
                <div class="navbar-mobile-search"></div>
                <ul id="primary-nav" class="nav navbar-nav">
                    <asp:Literal ID="ltrMenu" runat="server"></asp:Literal>
                </ul>
                <ul id="sec-nav2" class="nav navbar-nav">
                    <li class="header-search">
                        <form id="formSearch" action="#" class="search-form" method="get">
                            <i class="fa fa-search" aria-hidden="true"></i>
                            <input type="hidden" name="pageSize" value="21">
                            <input type="hidden" name="loai" value="0">
                            <input type="hidden" name="cateUrl" value="">
                            <input type="text" name="searchKey" id="searchKey" placeholder="Tìm kiếm..">
                        </form>
                        <script>
                            function search() {
                                if ($("#searchKey").val().trim() == "") {
                                    return false;
                                }
                                return true;
                            }
                    </script>
                    </li>
                </ul>
            </div>
        </div>
    </nav>
    </div>

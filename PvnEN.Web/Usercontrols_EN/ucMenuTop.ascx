<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuTop.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucMenuTop" %>
<%@ Register Src="~/Usercontrols_EN/ucTopBar_KH.ascx" TagPrefix="uc1" TagName="ucTopBar_KH" %>
<div class="top-heading ">
    <uc1:ucTopBar_KH runat="server" id="ucTopBar_KH" />
        <div class="middle-section-header hidden-mobile">
            <div class="container">
                <div class="middle-section-inner">
                    <div class="middle-bar-module heading-module logo">
                        <div class="logo-image">
                            <a href="/sites/en/" class="custom-logo-link" rel="home">
                                <img width="380" height="71" src="/wp-content/uploads/2017/06/banner.png"  alt="" /></a>
                        </div>
                    </div>
                    <div class="middle-bar-module heading-module">
                        <div class="module-main-menu">
                            <ul id="menu-main-menu" class="main-menu navbar-collapse collapse">
                                  <asp:Literal ID="ltrMenu" runat="server"></asp:Literal>
                            </ul>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <div class="navigation-bar sticky">
        <div class="container">
            <div class="navigation-bar-inner">
                <a href="/sites/en/" class="regular-logo custom-logo-link" rel="home">
                    <img width="197" height="71" src="/wp-content/uploads/2017/06/banner.png" class="" alt="" /></a><a href="#" class="sticky-logo custom-logo-link" rel="home"><img width="380" height="50" src="/wp-content/uploads/2017/06/banner.png" class="" alt="" /></a>
                    <button class="navbar-toggle toggle-main-menu" type="button" onclick="javascript:;" data-toggle="collapse" data-target=".navigation-bar-mobile">
                        <span class="menu-bar">
                            <span></span>
                            <span></span>
                            <span></span>
                        </span>
                    </button>
                <div class="heading-module">
                    <div class="module-main-menu">
                        <ul id="menu-main-menu-1" class="main-menu navbar-collapse collapse">
                             <asp:Literal ID="ltrmenuMobile" runat="server"></asp:Literal>
                        </ul>
                    </div>
                </div>
            </div>
            <div class="navigation-bar-mobile collapse"></div>
        </div>
    </div>

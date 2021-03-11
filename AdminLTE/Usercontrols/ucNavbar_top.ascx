<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNavbar_top.ascx.cs" Inherits="AdminLTE.Manage.Usercontrols.ucNavbar_top" %>


<header class="main-header">
    <!-- Logo -->
    <a href="/Manage/pages/default.aspx" class="logo">
        <!-- mini logo for sidebar mini 50x50 pixels -->
        <span class="logo-mini"><b>P</b>OC</span>
        <!-- logo for regular state and mobile devices -->
        <span class="logo-lg"><b>PHU QUOC POC</b></span>
    </a>
    <!-- Header Navbar: style can be found in header.less -->
    <nav class="navbar navbar-static-top" role="navigation">
        <!-- Sidebar toggle button-->
        <a href="#" class="sidebar-toggle" data-toggle="offcanvas" role="button">
            <span class="sr-only">Toggle navigation</span>
        </a>
        <div class="navbar-custom-menu">
            <ul class="nav navbar-nav">
                <li >
                    <a href="/" >
                        <i class="fa fa-home  text-yellow"></i> Trang chủ
                    </a>
                </li>
                <!-- User Account: style can be found in dropdown.less -->
                <li class="dropdown user user-menu">
                    <a href="#" class="dropdown-toggle" data-toggle="dropdown">
                        <img src="<%=USERAVATAR %>" class="user-image" alt="User Image">
                        <span class="hidden-xs"><%=LOGINNAME %></span>
                    </a>
                    <ul class="dropdown-menu">
                        <!-- User image -->
                        <li class="user-header">
                              
							  <div class="dw-user-box">
                                    <div class="u-img"><img src="<%=USERAVATAR %>" alt="User Image" /></div>
                                    <div class="u-text">
                                        <h4><span class="hidden-xs"><%=LOGINNAME %></span></h4>
                                        <asp:HyperLink CssClass="btn btn-rounded btn-danger btn-sm" runat="server" ID="HyperLink1" NavigateUrl="~/Manage/Pages/UserInfo.aspx" Text="Thông tin tài khoản"></asp:HyperLink></div>
                                </div>
                        </li>
                        <!-- Menu Body -->
						<li class="user-header1"><a class="fa " href="/Manage/Pages/UserInfo.aspx"><i class="fa fa-cogs" aria-hidden="true"></i>Cài đặt</a></li>
						<li class="user-header1"><asp:HyperLink runat="server" CssClass="fa fa-power-off" ID="lnkForgotPassword" NavigateUrl="~/_layouts/15/closeConnection.aspx?loginasanotheruser=true" Text="Đăng xuất"></asp:HyperLink>
                       
                    </ul>
                </li>
                <!-- Control Sidebar Toggle Button -->
                <%--<li>
                            <a href="#" data-toggle="control-sidebar"><i class="fa fa-gears"></i></a>
                        </li>--%>
            </ul>
        </div>
    </nav>
</header>

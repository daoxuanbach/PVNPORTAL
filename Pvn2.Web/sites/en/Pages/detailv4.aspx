<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="detailv4.aspx.cs" Inherits="Pvn2.Web.sites.en.Pages.detailv4" %>

<%@ Register Src="~/Usercontrols_EN/ucNewsBreadCumb.ascx" TagPrefix="uc1" TagName="ucNewsBreadCumb" %>
<%@ Register Src="~/Usercontrols_EN/ucNewsDetail2.ascx" TagPrefix="uc1" TagName="ucNewsDetail2" %>
<%@ Register Src="~/Usercontrols_EN/ucMenuSideEN.ascx" TagPrefix="uc1" TagName="ucMenuSideEN" %>




<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
 <div class="main-content clearfix ">
	<div class="post-2061 page type-page status-publish hentry content">
            <uc1:ucNewsBreadCumb runat="server" ID="ucNewsBreadCumb" />
            <div class="container-fluid">
                <div class="content col-xs-12">
                    <div class="container">
                        <div class="row">
                            <div class="col-xs-12 col-sm-6 col-md-9">
                             <%--<uc1:ucNewsDetail2 runat="server" ID="ucNewsDetail2" ShowTitle="true" />--%>
                            </div>
                            <div class="col-xs-12 col-sm-6 col-md-3">
                                <div class="widget_left">
                                    <uc1:ucMenuSideEN runat="server" ID="ucMenuSideEN" TieuDeMenu="aaaa" ParentMenuID="4f848559-0698-4e7b-95fe-3341549e1dad" Language="en-US" MenuPosition="1" />
                                    <h5 class="widget-title">Recent Post</h5>
                                    <div class="recent-post">
                                        <ul class="list-unstyled">
                                            <li class="mb-3">
                                                <div class="recent-post-thumb">
                                                    <img class="img-fluid" src="http://themeht.com/misty/html/images/blog/blog-thumb/01.jpg" alt="">
                                                </div>
                                                <div class="recent-post-desc">
                                                    <a href="#">We Have A great Work</a>
                                                </div>
                                            </li>
                                            <li class="mb-3">
                                                <div class="recent-post-thumb">
                                                    <img class="img-fluid" src="http://themeht.com/misty/html/images/blog/blog-thumb/01.jpg" alt="">
                                                </div>
                                                <div class="recent-post-desc">
                                                    <a href="#">We Have A great Work</a>
                                                </div>
                                            </li>
                                            <li>
                                                <div class="recent-post-thumb">
                                                    <img class="img-fluid" src="http://themeht.com/misty/html/images/blog/blog-thumb/01.jpg" alt="">
                                                </div>
                                                <div class="recent-post-desc">
                                                    <a href="#">We Have A Great Work</a>
                                                </div>
                                            </li>
                                        </ul>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsDetail.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucNewsDetail" %>
<div class="navigator_bar bar_css" style="display:none">
    <ul>
        <li class="home">
            <a href="" title="" class="home_icon"></a>
        </li>
        <span class="breadcrumb"></span>
        <asp:Repeater ID="rptNewsBreadCumb" runat="server">
            <ItemTemplate>
                <li>
                    <a href='<%# string.Format("{0}?CatID={1}", UrlList, Eval("CategoryID")) %>'>
                        <%# Eval("Title") %>
                    </a>
                </li>
            </ItemTemplate>
            <SeparatorTemplate>
                <span class="breadcrumb"></span>
            </SeparatorTemplate>
        </asp:Repeater>
    </ul>
</div>
<div class="container news_mobile">
    <div class="row">
        <div class="col-xs-12">
            <asp:Panel ID="pnlTitle" runat="server">
                <!--main news-->
                <h2 class="post-title bot-m20"><span><%# Eval("Title") %><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></span></h2>
                <div class="entry-info" >
                    <abbr class="published">
                        <img style="height: 16px; margin-top: 3px;" src="/wp-includes/img/topmost-clock_w24.png"><span class="format_time">
                            <%--<asp:Literal ID="ltrTime" runat="server"></asp:Literal></span> |--%> 
                            <span class="format_date"></span>
                                <asp:Literal ID="ltrDate" runat="server"></asp:Literal>
                             <%--   <br />
                                <b>
                                    <img src="/wp-includes/img/mvctotal.png">
                                    Hits</b>:
                                <asp:Literal ID="ltrHits" runat="server"></asp:Literal>--%>
                    </abbr>
                </div>
            </asp:Panel>
            <div class="entry-content clear-fix">
                <div class="lead-post">
                    <p>
                        <asp:Panel ID="pnlSummary" runat="server">
                            <blockquote> <asp:Literal ID="ltrSummary" runat="server"></asp:Literal></blockquote> 
                        </asp:Panel>
                    </p>
                    <asp:Repeater ID="rptRelatedNews" runat="server">
                        <ItemTemplate>
                            <a class="relatednews" href='<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>'>
                                <%# Eval("Title") %></a>
                        </ItemTemplate>
                        <SeparatorTemplate>
                            <br />
                        </SeparatorTemplate>
                    </asp:Repeater>
                </div>
                <div class="post-content-detail">
                    <p style="text-align: justify;">
                        <asp:Literal ID="ltrInformation" runat="server"></asp:Literal>
                    </p>
                </div>
            </div>
        </div>
    </div>
    <div class="row">
        <div class="col-md-12">
            <!--keyword-->
            <asp:Panel ID="pnlTags" runat="server">
                <div class="news_breadcumb">
                    <ul>
                        <asp:Repeater ID="rptKeywords" runat="server">
                            <HeaderTemplate>
                                <b>Tags:</b>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <li>
                                    <a href='<%# string.Format("{0}?tag={1}", UrlSearchList, Eval("Keyword")) %>'>
                                        <%# Eval("Keyword") %>
                                    </a>
                                </li>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                <li>&nbsp;&nbsp</li>
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </ul>
                </div>
            </asp:Panel>
        </div>
    </div>
    <!--Timeline-->
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="pnlTimeline" runat="server">
                <div class="post_older related-post clearfix">
                    <h2>Sự kiện:</h2>
                    <div class="post_older_data">
                        <asp:Repeater ID="rptTimeline" runat="server">
                            <ItemTemplate>
                                <a href='<%# string.Format("{0}?tlid={1}", UrlSearchList, Eval("TimelineID")) %>'>
                                    <%# Eval("Name") %></a>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                &nbsp;&nbsp;
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
    <!--other news-->
    <div class="row">
        <div class="col-md-12">
            <asp:Panel ID="pnlOtherNews" runat="server">
                <div class="post_older related-post clearfix">
                    <h2>Other news:</h2>
                    <div id="related-list" class="post_older_data">
                        <ul class="clearfix">
                            <asp:Repeater ID="rptOtherNews" runat="server">
                                <ItemTemplate>
                                    <li><a href='<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>'>
                                        <%# Eval("Title") %></a>
                                        <span style="width: 47px; margin-top: 4px;"></span>
                                        - 
					            <span style="color: #B9B9B9">
                                    <i>(<%# Eval("BeginDate", "{0:dd/MM/yyyy}") %>)</i>
                                </span>
                                    </li>
                                </ItemTemplate>
                            </asp:Repeater>
                        </ul>
                    </div>
                </div>
            </asp:Panel>
        </div>
    </div>
</div>

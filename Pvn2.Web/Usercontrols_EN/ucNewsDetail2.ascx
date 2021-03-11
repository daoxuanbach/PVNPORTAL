<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsDetail2.ascx.cs" Inherits="Pvn2.Web.Usercontrols_EN.ucNewsDetail2" %>
<div class="container-fluid">
    <div class="container">
        <div class="row">
            <div class="col-xs-12">
                <h2 class="post-title bot-m20">
                    <a href="#"><%# Eval("Title") %><asp:Literal ID="ltrTitle" runat="server"></asp:Literal></a>

                </h2>
                <div class="entry-content clear-fix">
                    <div class="lead-post">
                        <asp:Panel ID="pnlSummary" runat="server">
                            <asp:Literal ID="ltrSummary" runat="server"></asp:Literal>
                        </asp:Panel>
                    </div>
                    <div class="post-content-detail">
                        <p style="text-align: justify;">
                            <asp:Literal ID="ltrInformation" runat="server"></asp:Literal>
                        </p>
                    </div>
                </div>
            </div>
        </div>
        <asp:Panel ID="pnlRelated" runat="server">
            <div class="row">
                <div class="col-md-12">
                    <div class="post_older related-post clearfix">
                        <h2>Related News:</h2>
                        <div id="related-list" class="post_older_data">
                            <ul class="clearfix">
                                <asp:Repeater ID="rptRelatedNews" runat="server">
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
                </div>
            </div>
        </asp:Panel>

        <!--other news-->
        <asp:Panel ID="pnlOtherNews" runat="server">
            <div id="element_108" class="petro_post post-lists blog-col-4 clearfix">
                <asp:Repeater ID="rptOtherNews" runat="server">
                    <ItemTemplate>
                        <div class="grid-column col-xs-12 col-lg-4 col-md-6">
                            <article id="post-1901" class="post-1901 post type-post status-publish format-standard has-post-thumbnail hentry category-chemical category-machinery category-metallurgy tag-company tag-manufacturing tag-metallurgy content">
                                <a href="<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>">
                                    <div class="blog-image clearfix">
                                        <asp:Image ID="imgImage" runat="server" ToolTip='<%# Eval("Title") %>' ImageUrl='<%# Eval("ImageURL") %>'
                                        AlternateText='<%# Eval("Title") %>'
                                        OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), "C150x86") + "\")" %>' />
                                    </div>
                                </a>
                                <div class="post-content clearfix">
                                    <h2 class="post-title"><a href="<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>"><%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(), 70) %></a></h2>
                                </div>
                                <div class="clearfix"></div>
                            </article>
                        </div>
                    </ItemTemplate>
                </asp:Repeater>
            </div>
        </asp:Panel>
    </div>
</div>

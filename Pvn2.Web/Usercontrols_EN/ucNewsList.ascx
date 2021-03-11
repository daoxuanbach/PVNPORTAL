<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsList.ascx.cs" Inherits="Pvn2.Web.Usercontrols_EN.ucNewsList" %>
<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Import Namespace="Pvn.Utils" %>
<form runat="server">
    <div class="container-fluid">
        <div class="content col-xs-12">
            <div class="container">
                <div class="row">
                    <div class="col-xs-12">
                        <div class="post-content">
                           <div class="inner-row">
								<div id="element_106" class="el_column col-md-12">
									<div class="inner-column">
										<div id="element_108" class="petro_post post-lists blog-col-4 clearfix" style="padding-top: 20px">
											<asp:Repeater ID="rptMainNewsItem" runat="server">
												<ItemTemplate>
													<div class="grid-column col-xs-12 col-lg-3 col-md-6">
														<article id="post-1901" class="post-1901 post type-post status-publish format-standard has-post-thumbnail hentry category-chemical category-machinery category-metallurgy tag-company tag-manufacturing tag-metallurgy content">
															<a href="<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>">
																<div class="blog-image clearfix">
																	<asp:Image ID="imgImage" runat="server" ToolTip='<%# Eval("Title") %>' ImageUrl='<%# Eval("ImageURL") %>'
																		AlternateText='<%# Eval("Title") %>'
																		OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) + "\")" %>' />
																</div>
															</a>
															<div class="post-content clearfix">
																<h2 class="post-title"><a href="<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>"><%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(), MaxLengthTitle) %></a></h2>
															</div>
															<div class="clearfix"></div>
														</article>
													</div>
												</ItemTemplate>
											</asp:Repeater>
											
										</div>
                                         <webdiyer:AspNetPager ID="pgMain" runat="server" ShowPageIndexBox="Never" ShowFirstLast="true" NextPageText="Next>>" AlwaysShowFirstLastPageNumber="true"
												PrevPageText="«Pre" CssClass="pagination"
												CurrentPageButtonClass="active" OnPageChanged="pgMain_PageChanged" />
									</div>
								</div>
							</div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    </form>
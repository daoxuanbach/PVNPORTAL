<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPhoto.ascx.cs" Inherits="Pvn2.Web.Usercontrols_EN.ucPhoto" %>
<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Usercontrols_EN/ucBreadcumbMEDIA.ascx" TagPrefix="uc1" TagName="ucBreadcumbMEDIA" %>

<script src="/wp-content/media/js/jquery.prettyPhoto.js"></script>
<link rel="stylesheet" href="/wp-content/media/css/prettyPhoto.css" type="text/css" media="screen" charset="utf-8" />

<div class="main-content clearfix ">
    <div class="post-2061 page type-page status-publish hentry content">
        <div class="breachcrum_bg">
            <img src="/wp-includes/img/photo.png" class="custom-logo" alt="">
        </div>
        <div class="navigator_bar">
            <div class="container">
                <uc1:ucBreadcumbMEDIA runat="server" id="ucBreadcumbMEDIA" MenuType="1" />
            </div>
        </div>
        <div class="container-fluid">
            <div class="container">
                <div class="row">
                    <div class="content col-xs-12 col-md-12">
                        <div id="element_3" class="gum_portfolio layout-fade col-4 clearfix">
                            <div class="portfolio-content" style="position: relative; height: 680.625px;">

                                <asp:Repeater ID="rptImageList" runat="server">
                                    <ItemTemplate>

                                        <asp:PlaceHolder ID="plhFolder" runat="server" Visible='<%# (Convert.ToString(Eval("ImageType")) == "1")? true : false %>'>
                                           <div class="content portfolio col-md-3">
                                                <a href="<%# string.Format("{0}?CatID={1}", UrlDetail, Eval("ImageCategoryID")) %>">
                                                    <div class="portfolio-image clearfix">
                                                      <img src="http://petro-wp.themegum.com/wp-content/uploads/2017/06/service-3-400x300.jpeg" alt="">
                                                        <%--<img src="<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) %>" alt="">--%>
                                                    </div>
                                                    <div class="image-overlay">
                                                        <div class="image-overlay-container">
                                                            <div class="portfolio-info">
                                                                <h3 class="portfolio-title">
                                                                    <%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %>
                                                                </h3>
                                                            </div>

                                                        </div>
                                                    </div>
                                                </a>
                                            </div>

                                        </asp:PlaceHolder>
                                        <asp:PlaceHolder ID="plhFile" runat="server" Visible='<%# (Convert.ToString(Eval("ImageType")) == "2")? true : false %>'>
                                                <div class="portfolio pvnPhotoGallery gallery" style="position: absolute; left: 0px; top: 0px;">
                                                    <a href="<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) %>" rel="prettyPhoto[gallery1]" title='<%# Eval("Desscription") %>'>
                                                        <div class="portfolio-image clearfix">
                                                            <asp:Image  runat="server" 
                                                            AlternateText='<%# Eval("Title") %>' ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) %>'
                                                            OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) + "\")" %>' />
                                                        </div>
                                                        <div class="image-overlay">
                                                            <div class="image-overlay-container">
                                                                <div class="portfolio-info">
                                                                    <h3 class="portfolio-title">
                                                                        <%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %>
                                                                    </h3>
                                                                </div>

                                                            </div>
                                                        </div>
                                                    </a>
                                            </div>
                                        </asp:PlaceHolder>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </div>
                            </div>
                    </div>

                    <div class="clearfix"></div>
                    <div class="pagination number" dir="ltr">
                        <ul>
                            <webdiyer:AspNetPager ID="pgMain" runat="server" NextPageText="Next»" PrevPageText="«Pre" CssClass="pagination" CurrentPageButtonClass="active" OnPageChanged="pgMain_PageChanged" />

                        </ul>
                    </div>


                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" charset="utf-8">
    $(document).ready(function () {
        if ($(".pvnPhotoGallery") !== undefined) {
            $(".gallery a[rel^='prettyPhoto']").prettyPhoto({ animation_speed: 'slow', slideshow: 10000, hideflash: true, social_tools: false, autoplay_slideshow: true });
        }
    });
</script>

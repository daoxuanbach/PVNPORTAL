<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVideo.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucVideo" %>

<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
<%@ Register Src="~/Usercontrols_EN/ucBreadcumbMEDIA.ascx" TagPrefix="uc1" TagName="ucBreadcumbMEDIA" %>

<script type="text/javascript" src="/wp-includes/js/jquery/html5lightbox.js"></script>

<style>
div#html5-watermark a div {
display: none !important;
}
.html5-elem-box{
    background-color:none !important;
}
</style>
<div class="main-content clearfix ">
    <div class="post-2061 page type-page status-publish hentry content">
        <div class="breachcrum_bg">
            <img src="/wp-includes/img/photo.png" class="custom-logo" alt="">
        </div>
        <div class="navigator_bar">
            <div class="container">
                <uc1:ucBreadcumbMEDIA runat="server" id="ucBreadcumbMEDIA" MenuType="2"  UrlDetail="/sites/en/Pages/video.aspx" />
            </div>
        </div>
        <div class="container-fluid">
            <div class="container">
                <div class="row">
                    <div class="content col-xs-12 col-md-12">
                        <div id="element_3" class="gum_portfolio layout-fade col-4 clearfix">
                            <div class="portfolio-content" style="position: relative; height: 680.625px;">
                                <asp:Repeater ID="rptMainVideo" runat="server">
                                    <ItemTemplate>
                                        <asp:PlaceHolder ID="plhFolder" runat="server" Visible='<%# (Convert.ToString(Eval("VideoType")) == "1")? true : false %>'>
                                            <div class="portfolio active gas industry oil" style="position: absolute; left: 0px; top: 0px;">
                                                <a href="<%# string.Format("{0}?CatID={1}", UrlDetail, Eval("VideoCategoryID")) %>">
                                                    <div class="portfolio-image clearfix">
                                                         <asp:Image  runat="server"  ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) %>'
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
                                        <asp:PlaceHolder ID="plhFile" runat="server" Visible='<%# (Convert.ToString(Eval("VideoType")) == "2")? true : false %>'>
                                                <div class="portfolio pvnVideo" style="position: absolute; left: 0px; top: 0px;">
                                                    <a href="<%# Eval("VideoUrl") %>"  class="html5lightbox" data-width="480" data-height="320" title='<%# Eval("Desscription") %>'>
                                                        <div class="portfolio-image clearfix">
                                                            <a href='<%# Eval("VideoUrl") %>' class="html5lightbox" data-width="480" data-height="320">
                                                                <asp:Image  runat="server"  ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) %>'
                                                            OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) + "\")" %>' />
                                                            </a>
                                                        </div>
                                                        <a href="<%# Eval("VideoUrl")%>" class="html5lightbox image-overlay"  data-width="480" data-height="320">
                                                            <div class="image-overlay-container">
                                                                <div class="portfolio-info">
                                                                    <h3 class="portfolio-title">
                                                                        <%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %>
                                                                    </h3>
                                                                </div>

                                                            </div>
                                                        </a>
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
                            <webdiyer:AspNetPager ID="pgMain" runat="server" NextPageText="Sau»" PrevPageText="«Trước" CssClass="pagination" CurrentPageButtonClass="active" OnPageChanged="pgMain_PageChanged" />

                        </ul>
                    </div>


                </div>
            </div>
        </div>
    </div>
</div>
<script type="text/javascript" charset="utf-8">

</script>



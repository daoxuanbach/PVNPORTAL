<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsListMain.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucNewsListMain" %>
<div class="container-fluid">
    <div class="container">
        <div id="element_105153740957948" class="el_row row">
            <div class="inner-row">
                <div id="element_106" class="el_column col-md-12">
                    <div class="inner-column">
                        <div id="element-107" class="section-head left layout-petro">
                            <div>
                                <h2 class="section-main-title"><%=TieuDe %></h2>
                            </div>
                        </div>
                        <div id="element_108" class="petro_post post-lists blog-col-4 clearfix">
                            <asp:Repeater ID="rptNews" runat="server">
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
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>



<script>
function LoadImages(id, str) {
    
    //alert("GetImage.ashx?File="+str + id);
}
</script>
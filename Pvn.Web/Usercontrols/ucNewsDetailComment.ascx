<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsDetailComment.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucNewsDetailComment" %>
<%@ Register Src="~/Usercontrols/Comment.ascx" TagPrefix="uc1" TagName="Comment" %>
<%@ Register Src="~/Usercontrols/ContentComment.ascx" TagPrefix="uc1" TagName="ContentComment" %>


<script>
    jssor_new_detail_slider_init = function () {
        var jssor_1_SlideshowTransitions = [
          { $Duration: 1200, x: -0.3, $During: { $Left: [0.3, 0.7] }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
          { $Duration: 1200, x: 0.3, $SlideOut: true, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 }
        ];

        var jssor_1_options = {
            $AutoPlay: 1,
            $SlideshowOptions: {
                $Class: $JssorSlideshowRunner$,
                $Transitions: jssor_1_SlideshowTransitions,
                $TransitionsOrder: 1
            },
            $ArrowNavigatorOptions: {
                $Class: $JssorArrowNavigator$
            },
            $ThumbnailNavigatorOptions: {
                $Class: $JssorThumbnailNavigator$,
                $Orientation: 2,
                $NoDrag: true
            }
        };

        var jssor_1_slider = new $JssorSlider$("jssor_new_detail", jssor_1_options);

        /*#region responsive code begin*/

        var MAX_WIDTH = 980;

        function ScaleSlider() {
            var containerElement = jssor_1_slider.$Elmt.parentNode;
            var containerWidth = containerElement.clientWidth;

            if (containerWidth) {

                var expectedWidth = Math.min(MAX_WIDTH || containerWidth, containerWidth);

                jssor_1_slider.$ScaleWidth(expectedWidth);
            }
            else {
                window.setTimeout(ScaleSlider, 30);
            }
        }

        ScaleSlider();

        $Jssor$.$AddEvent(window, "load", ScaleSlider);
        $Jssor$.$AddEvent(window, "resize", ScaleSlider);
        $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
        /*#endregion responsive code end*/
    };
</script>
 <style>
        /* jssor slider loading skin spin css */
        .jssorl-009-spin img {
            animation-name: jssorl-009-spin;
            animation-duration: 1.6s;
            animation-iteration-count: infinite;
            animation-timing-function: linear;
        }

        @keyframes jssorl-009-spin {
            from {
                transform: rotate(0deg);
            }

            to {
                transform: rotate(360deg);
            }
        }


        .jssora061 {display:block;position:absolute;cursor:pointer;}
        .jssora061 .a {fill:none;stroke:#fff;stroke-width:360;stroke-linecap:round;}
        .jssora061:hover {opacity:.8;}
        .jssora061.jssora061dn {opacity:.5;}
        .jssora061.jssora061ds {opacity:.3;pointer-events:none;}
    </style>
<div class="title_new marB0" style="font-size: 17px">
    <asp:Literal ID="ltrTitle" runat="server"></asp:Literal>
</div>
<div class="entry-info">
    <abbr class="published">
        <span class="format_time">
            <asp:Literal ID="ltrTime" runat="server"></asp:Literal></span> | <span class="format_date">
                <asp:Literal ID="ltrDate" runat="server"></asp:Literal></span>
        <div class="entry-hits">
            <b><%= HitsText %></b>:
            <asp:Literal ID="ltrHits" runat="server"></asp:Literal>
        </div>
    </abbr>
</div>

<b>
    <asp:Literal ID="ltrSummary" runat="server"></asp:Literal></b><br />
<br />
<asp:Repeater ID="rptRelatedNews" runat="server">
    <ItemTemplate>
        <a class="relatednews" href='<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>'>
            <%# Eval("Title") %></a>
    </ItemTemplate>
    <SeparatorTemplate>
        <br />
    </SeparatorTemplate>
</asp:Repeater>
<asp:Literal ID="ltrInformation" runat="server"></asp:Literal>
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
<!--Timeline-->
<asp:Panel ID="pnlTimeline" runat="server">
    <div class="post_older related-post clearfix">
        <h2><%= NewsTimelineText %></h2>
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
<%--User comments--%>
<uc1:Comment runat="server" ID="Comment" />
<uc1:ContentComment runat="server" id="ContentComment" />

<p class="news_khac">
    <b><%= OtherNewsText %></b><br />
</p>
<ul class="post_older">
    <asp:Repeater ID="rptOtherNews" runat="server">
        <ItemTemplate>
            <li><a href='<%# Pvn.Utils.Utilities.GetUrlRewite(UrlDetail,Eval("CategoryName").ToString(),Eval("Title").ToString(),Eval("NewsPublishingID").ToString())  %>'>
                <%# Eval("Title") %> &nbsp;<i>(<%# Eval("BeginDate", "{0:dd/MM/yyyy}") %>)</i></a>
            </li>
        </ItemTemplate>
    </asp:Repeater>
</ul>
<script>
    if ($("#jssor_new_detail").html() != undefined) {
        jssor_new_detail_slider_init();
    }
</script>

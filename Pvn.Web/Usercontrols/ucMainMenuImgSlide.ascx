<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMainMenuImgSlide.ascx.cs" Inherits="Pvn.Web.ucMainMenuImgSlide" %>

<body style="padding:0px; margin:0px; background-color:#fff;font-family:helvetica, arial, verdana, sans-serif">

    <!-- #region Jssor Slider Begin -->
    <!-- Generator: Jssor Slider Maker -->
    <!-- Source: http://www.jssor.com -->
    <!-- This code works without jquery library. -->
    <script type="text/javascript">
        jssor_advertise_slider_init = function () {

            var jssor_advertise_SlideshowTransitions = [
              { $Duration: 1200, x: -0.3, $During: { $Left: [0.3, 0.7] }, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 },
              { $Duration: 1200, x: 0.3, $SlideOut: true, $Easing: { $Left: $Jease$.$InCubic, $Opacity: $Jease$.$Linear }, $Opacity: 2 }
            ];

            var jssor_advertise_options = {
                $AutoPlay: true,
                $SlideshowOptions: {
                    $Class: $JssorSlideshowRunner$,
                    $Transitions: jssor_advertise_SlideshowTransitions,
                    $TransitionsOrder: 1
                },
                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$
                },
                $BulletNavigatorOptions: {
                    $Class: $JssorBulletNavigator$
                },
                $ThumbnailNavigatorOptions: {
                    $Class: $JssorThumbnailNavigator$,
                    $Cols: 1,
                    $Align: 0,
                    $NoDrag: true
                }
            };

            var jssor_advertise_slider = new $JssorSlider$("jssor_advertise", jssor_advertise_options);

            /*responsive code begin*/
            /*you can remove responsive code if you don't want the slider scales while window resizing*/
            function ScaleSlider() {
                var refSize = jssor_advertise_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 1000);
                    jssor_advertise_slider.$ScaleWidth(refSize);
                }
                else {
                    window.setTimeout(ScaleSlider, 30);
                }
            }
            ScaleSlider();
            $Jssor$.$AddEvent(window, "load", ScaleSlider);
            $Jssor$.$AddEvent(window, "resize", ScaleSlider);
            $Jssor$.$AddEvent(window, "orientationchange", ScaleSlider);
            /*responsive code end*/
        };
    </script>
    <style>
        /* jssor slider bullet navigator skin 01 css */
        /*
        .jssorb01 div           (normal)
        .jssorb01 div:hover     (normal mouseover)
        .jssorb01 .av           (active)
        .jssorb01 .av:hover     (active mouseover)
        .jssorb01 .dn           (mousedown)
        */
        .jssorb01 {
            position: absolute;
        }
        .jssorb01 div, .jssorb01 div:hover, .jssorb01 .av {
            position: absolute;
            /* size of bullet elment */
            width: 12px;
            height: 12px;
            filter: alpha(opacity=70);
            opacity: .7;
            overflow: hidden;
            cursor: pointer;
            border: #000 1px solid;
        }
        .jssorb01 div { background-color: gray; }
        .jssorb01 div:hover, .jssorb01 .av:hover { background-color: #d3d3d3; }
        .jssorb01 .av { background-color: #fff; }
        .jssorb01 .dn, .jssorb01 .dn:hover { background-color: #555555; }

        /* jssor slider arrow navigator skin 05 css */
        /*
        .jssora05l_advertise                  (normal)
        .jssora05r_advertise                  (normal)
        .jssora05l_advertise:hover            (normal mouseover)
        .jssora05r_advertise:hover            (normal mouseover)
        .jssora05l_advertise.jssora05l_advertisedn      (mousedown)
        .jssora05r_advertise.jssora05r_advertisedn      (mousedown)
        .jssora05l_advertise.jssora05l_advertiseds      (disabled)
        .jssora05r_advertise.jssora05r_advertiseds      (disabled)
        */
        .jssora05l_advertise, .jssora05r_advertise {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 37px;
            height: 37px;
            cursor: pointer;
            background: url('/Style%20Library/jqueryPage/images/a12.png') no-repeat;
            overflow: hidden;
        }
        .jssora05l_advertise { background-position: -10px -37px; }
        .jssora05r_advertise { background-position: -70px -37px; }
        .jssora05l_advertise:hover { background-position: -130px -37px; }
        .jssora05r_advertise:hover { background-position: -190px -37px; }
        .jssora05l_advertise.jssora05l_advertisedn { background-position: -250px -37px; }
        .jssora05r_advertise.jssora05r_advertisedn { background-position: -310px -37px; }
        .jssora05l_advertise.jssora05l_advertiseds { background-position: -10px -37px; opacity: .3; pointer-events: none; }
        .jssora05r_advertise.jssora05r_advertiseds { background-position: -70px -37px; opacity: .3; pointer-events: none; }
        /* jssor slider thumbnail navigator skin 09 css */.jssort09-1000-45 .p {    position: absolute;    top: 0;    left: 0;    width: 1000px;    height: 45px;}.jssort09-1000-45 .t {    font-family: verdana;    font-weight: normal;    position: absolute;    width: 100%;    height: 100%;    top: 0;    left: 0;    color:#fff;    line-height: 45px;    font-size: 20px;    padding-left: 10px;}
    </style>
    <div id="jssor_advertise" style="z-index: 1500; position: relative; margin: 0 auto; top: 0px; left: 0px; width: 1000px; height: 318px; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position:absolute;display:block;background:url('/sitecontent/img/loading.gif') no-repeat center center;top:0px;left:0px;width:100%;height:100%;"></div>
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1000px; height: 318px; overflow: hidden;">
		  <asp:Repeater ID="rptNewsLeft" runat="server">
                <ItemTemplate>
					 <div data-p="112.50">
                          <a href="<%# Eval("URL") %>" target="<%#Convert.ToString(Eval("IsNewWindow")) == "0"? "_self" : "_blank"%>"> 
                            <img data-u="image" src="<%# Eval("ImageURL") %>" />
                        </a>
						
						 <!--<div data-u="thumb"><%# Eval("ImageTitle") %></div>-->
					</div>
                </ItemTemplate>
            </asp:Repeater>	
			
           
        </div>
          <span data-u="arrowleft" class="jssora05l_advertise" style="top: 132px; left: -6px; width: 55px; height: 55px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora05r_advertise" style="top: 132px; right: -20px; width: 55px; height: 55px;" data-autocenter="2"></span>
        <!-- Arrow Navigator 
        <span data-u="arrowleft" class="jssora05l_advertise" style="top:0px;left:8px;width:37px;height:37px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora05r_advertise" style="top:0px;right:8px;width:37px;height:37px;" data-autocenter="2"></span>-->
    </div>
    <script type="text/javascript">jssor_advertise_slider_init();</script>
    <!-- #endregion Jssor Slider End -->
</body>
</html>

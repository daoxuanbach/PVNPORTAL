<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucImagesVideoMain.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucImagesVideoMain" %>



<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>

    <script type="text/javascript">
        jssor_ImgVideo_main_slider_init = function () {
            var jssor_ImgVideo_main_SlideoTransitions = [
              [{ b: 0, d: 600, y: -290, e: { y: 27 } }],
              [{ b: 0, d: 1000, y: 185 }, { b: 1000, d: 500, o: -1 }, { b: 1500, d: 500, o: 1 }, { b: 2000, d: 1500, r: 360 }, { b: 3500, d: 1000, rX: 30 }, { b: 4500, d: 500, rX: -30 }, { b: 5000, d: 1000, rY: 30 }, { b: 6000, d: 500, rY: -30 }, { b: 6500, d: 500, sX: 1 }, { b: 7000, d: 500, sX: -1 }, { b: 7500, d: 500, sY: 1 }, { b: 8000, d: 500, sY: -1 }, { b: 8500, d: 500, kX: 30 }, { b: 9000, d: 500, kX: -30 }, { b: 9500, d: 500, kY: 30 }, { b: 10000, d: 500, kY: -30 }, { b: 10500, d: 500, c: { x: 87.50, t: -87.50 } }, { b: 11000, d: 500, c: { x: -87.50, t: 87.50 } }],
              [{ b: 0, d: 600, x: 410, e: { x: 27 } }],
              [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, o: 1, e: { o: 5 } }],
              [{ b: -1, d: 1, c: { x: 175.0, t: -175.0 } }, { b: 0, d: 800, c: { x: -175.0, t: 175.0 }, e: { c: { x: 7, t: 7 } } }],
              [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, x: -570, o: 1, e: { x: 6 } }],
              [{ b: -1, d: 1, o: -1, r: -180 }, { b: 0, d: 800, o: 1, r: 180, e: { r: 7 } }],
              [{ b: 0, d: 1000, y: 80, e: { y: 24 } }, { b: 1000, d: 1100, x: 570, y: 170, o: -1, r: 30, sX: 9, sY: 9, e: { x: 2, y: 6, r: 1, sX: 5, sY: 5 } }],
              [{ b: 2000, d: 600, rY: 30 }],
              [{ b: 0, d: 500, x: -105 }, { b: 500, d: 500, x: 230 }, { b: 1000, d: 500, y: -120 }, { b: 1500, d: 500, x: -70, y: 120 }, { b: 2600, d: 500, y: -80 }, { b: 3100, d: 900, y: 160, e: { y: 24 } }],
              [{ b: 0, d: 1000, o: -0.4, rX: 2, rY: 1 }, { b: 1000, d: 1000, rY: 1 }, { b: 2000, d: 1000, rX: -1 }, { b: 3000, d: 1000, rY: -1 }, { b: 4000, d: 1000, o: 0.4, rX: -1, rY: -1 }]
            ];
            var jssor_ImgVideo_main_options = {
                $AutoPlay: true,
                $Idle: 2000,
                $CaptionSliderOptions: {
                    $Class: $JssorCaptionSlideo$,
                    $Transitions: jssor_ImgVideo_main_SlideoTransitions,
                    $Breaks: [
                      [{ d: 2000, b: 1000 }]
                    ]
                },
                $ArrowNavigatorOptions: {
                    $Class: $JssorArrowNavigator$
                },
                $BulletNavigatorOptions: {
                    $Class: $JssorBulletNavigator$
                }
            };
            var jssor_ImgVideo_main_slider = new $JssorSlider$("jssor_ImgVideo_main", jssor_ImgVideo_main_options);
            /*responsive code begin*/
            /*you can remove responsive code if you don't want the slider scales while window resizing*/
            function ScaleSlider() {
                var refSize = jssor_ImgVideo_main_slider.$Elmt.parentNode.clientWidth;
                if (refSize) {
                    refSize = Math.min(refSize, 600);
                    jssor_ImgVideo_main_slider.$ScaleWidth(refSize);
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

            .jssorb01 div {
                background-color: gray;
            }

                .jssorb01 div:hover, .jssorb01 .av:hover {
                    background-color: #d3d3d3;
                }

            .jssorb01 .av {
                background-color: #fff;
            }

            .jssorb01 .dn, .jssorb01 .dn:hover {
                background-color: #555555;
            }

        /* jssor slider arrow navigator skin 02 css */
        /*
        .jssora02l                  (normal)
        .jssora02r                  (normal)
        .jssora02l:hover            (normal mouseover)
        .jssora02r:hover            (normal mouseover)
        .jssora02l.jssora02ldn      (mousedown)
        .jssora02r.jssora02rdn      (mousedown)
        .jssora02l.jssora02lds      (disabled)
        .jssora02r.jssora02rds      (disabled)
        */
        .jssora02l, .jssora02r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 55px;
            height: 55px;
            cursor: pointer;
            background: url('/Style%20Library/jqueryPage/images/a12.png') no-repeat;
            overflow: hidden;
        }

        .jssora02l {
            background-position: -3px -33px;
              top:66px !important;
        }

        .jssora02r {
            background-position: -63px -33px;
            top:66px !important;
        }

        .jssora02l:hover {
            background-position: -123px -33px;
        }

        .jssora02r:hover {
            background-position: -183px -33px;
        }

        .jssora02l.jssora02ldn {
            background-position: -3px -33px;
        }

        .jssora02r.jssora02rdn {
            background-position: -63px -33px;
        }

        .jssora02l.jssora02lds {
            background-position: -3px -33px;
            opacity: .3;
            pointer-events: none;
        }

        .jssora02r.jssora02rds {
            background-position: -63px -33px;
            opacity: .3;
            pointer-events: none;
        }
    </style>
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

            .jssorb01 div {
                background-color: gray;
            }

                .jssorb01 div:hover, .jssorb01 .av:hover {
                    background-color: #d3d3d3;
                }

            .jssorb01 .av {
                background-color: #fff;
            }

            .jssorb01 .dn, .jssorb01 .dn:hover {
                background-color: #555555;
            }

        /* jssor slider arrow navigator skin 05 css */
        /*
        .jssora05l                  (normal)
        .jssora05r                  (normal)
        .jssora05l:hover            (normal mouseover)
        .jssora05r:hover            (normal mouseover)
        .jssora05l.jssora05ldn      (mousedown)
        .jssora05r.jssora05rdn      (mousedown)
        .jssora05l.jssora05lds      (disabled)
        .jssora05r.jssora05rds      (disabled)
        */
        .jssora05l, .jssora05r {
            display: block;
            position: absolute;
            /* size of arrow element */
            width: 40px;
            height: 40px;
            cursor: pointer;
            background: url('/Style%20Library/jqueryPage/images/a17.png') no-repeat;
            overflow: hidden;
        }

        .jssora05l {
            background-position: -10px -40px;
        }

        .jssora05r {
            background-position: -70px -40px;
        }

        .jssora05l:hover {
            background-position: -130px -40px;
        }

        .jssora05r:hover {
            background-position: -190px -40px;
        }

        .jssora05l.jssora05ldn {
            background-position: -250px -40px;
        }

        .jssora05r.jssora05rdn {
            background-position: -310px -40px;
        }

        .jssora05l.jssora05lds {
            background-position: -10px -40px;
            opacity: .3;
            pointer-events: none;
        }

        .jssora05r.jssora05rds {
            background-position: -70px -40px;
            opacity: .3;
            pointer-events: none;
        }
        /* jssor slider thumbnail navigator skin 09 css */ .jssort09-600-45 .p {
            position: absolute;
            top: 0;
            left: 0;
            width: 300px;
            height: 45px;
        }

        .jssort09-600-45 .t {
            font-family: verdana;
            font-weight: normal;
            position: absolute;
            width: 100%;
            height: 100%;
            top: 0;
            left: 0;
            color: #fff;
            line-height: 45px;
            font-size: 20px;
            padding-left: 10px;
        }
		
	
    </style>
</head>
<body style="padding: 0px; margin: 0px; background-color: #fff; font-family: helvetica, arial, verdana, sans-serif">
<div id="tabs-img-video" >
  <ul>
    <li class="li-tab" data-index="0">
		<a href="#tabs-1" onclick='goToURL("<%=UrlLinkVideo %>")' > 
				 <span class="pl5"> <%=TenTabVideo %> </span>
		</a>
	</li>
    <li class="li-tab" onclick='goToURL("<%=UrlLinkAnh%>")' data-index="1">
		<a href="#tabs-2" >
			<span class="pl5"> <%=TenTab %> </span>
		</a>
	</li>
  </ul>
  <div id="tabs-1" class="div-tabs">
     
    <asp:Repeater ID="rptMainVideo" runat="server">
		<ItemTemplate>
			 <video id="videoareatab"
				 width="300px"
				 height="200px"
				 poster="<%# Eval("ImageURL")%>"
				 controls="controls"
				 src="<%# Eval("VideoURL") %>"> 
			</video>
			 <div class="video_home_info" style="width: 100%;">
                <a href="<%=UrlLinkVideo %>?CatID=<%=CategoryVideoId %>" title="<%#Eval("Title")%>" class="video_home_tt"><%# Pvn.Utils.Utilities.SplitString(Convert.ToString(Eval("Title")),MaxLengthTitle)%></a>​​​
            </div>
		</ItemTemplate>
	</asp:Repeater>
  </div>
  <div id="tabs-2" class="div-tabs" > 
<div id="jssor_ImgVideo_main" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 300px; height: 230px; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" style="position: absolute; top: 0px; left: 0px;">
            <div style="filter: alpha(opacity=70); opacity: 0.7; position: absolute; display: block; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
            <div style="position: absolute; display: block; background: url('/Style%20Library/jqueryPage/images/loading.gif') no-repeat center center; top: 0px; left: 0px; width: 100%; height: 100%;"></div>
        </div>
        <div class="clsuslide" data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 300px; height: 194px; overflow: hidden;">
            <asp:Repeater ID="rptImageList" runat="server">
                <ItemTemplate>
                    <div class="pcaption" data-p="212.50" style="display: none;">
                        <img data-u="image" src="<%# Eval("ImageURL") %>" />
                        <div class="ucaption"  data-u="caption" data-t="4" style="position: absolute; top: 194px; left: 0px; width: 300px; height: 35px; background-color: rgba(152, 146, 142, 0.6); font-size: 14px; color: #ffffff; line-height: 16px; text-align: center;">
                              <%# Pvn.Utils.Utilities.SplitString(Convert.ToString(Eval("Title")), MaxLengthTitle) %>
                        </div>
                         </div>
                </ItemTemplate>
                <FooterTemplate>
                </FooterTemplate>
            </asp:Repeater>
        </div>
        <!-- Bullet Navigator -->
        <div data-u="navigator" class="jssorb01" style="bottom: 38px; right: 16px;">
            <div data-u="prototype" style="width: 12px; height: 12px;"></div>
        </div>
        <!-- Arrow Navigator -->
        <span data-u="arrowleft" class="jssora02l" style="top: 66.5px; left: -15px; width: 55px; height: 55px;" data-autocenter="2"></span>
        <span data-u="arrowright" class="jssora02r" style="top: 66.5px; right: -15px; width: 55px; height: 55px;" data-autocenter="2"></span>
    </div>
 
  </div>
</div>
    <script type="text/javascript">jssor_ImgVideo_main_slider_init();</script>
    
 <style>
 .clsuslide, .pcaption{height:230px !important}

   .tabs-img-video{
			
			padding: 0px;
		}
		.div-tabs{
			padding: 0px 1px !important;
		}
		div#tabs-img-video ul {
			background: none;
			border: none;
			padding-left: 0px;
			padding-top: 0px;
		}    
	.ui-tabs {
		position: relative;
		padding: 0px !important;
	}
	span.pl5 {
		cursor: pointer;
	}
 </style>

<script>
    $(function () {
        $("#tabs-img-video").tabs();
        $(".li-tab").hover(
               function () {
                   $("#tabs-img-video").tabs("option", "active", $(this).attr('data-index'));
               }
             );
    });
    function goToURL(url) {
        location.href = url;
    }
  </script>
</body>
</html>

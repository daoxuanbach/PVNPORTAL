<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucPanoSlideFullWidth.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucPanoSlideFullWidth" %>

<div class="slide_css">
    <!-- #region Jssor Slider Begin -->
    <!-- Generator: Jssor Slider Maker -->
    <!-- Source: https://www.jssor.com -->
    <script src="/wp-includes/js/jssor.slider-27.5.0.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        jssor_1_slider_init = function () {

            var jssor_1_SlideoTransitions = [
                [{ b: 0, d: 600, y: -290, e: { y: 27 } }],
                [{ b: 0, d: 1000, y: 185 }, { b: 1000, d: 500, o: -1 }, { b: 1500, d: 500, o: 1 }, { b: 2000, d: 1500, r: 360 }, { b: 3500, d: 1000, rX: 30 }, { b: 4500, d: 500, rX: -30 }, { b: 5000, d: 1000, rY: 30 }, { b: 6000, d: 500, rY: -30 }, { b: 6500, d: 500, sX: 1 }, { b: 7000, d: 500, sX: -1 }, { b: 7500, d: 500, sY: 1 }, { b: 8000, d: 500, sY: -1 }, { b: 8500, d: 500, kX: 30 }, { b: 9000, d: 500, kX: -30 }, { b: 9500, d: 500, kY: 30 }, { b: 10000, d: 500, kY: -30 }, { b: 10500, d: 500, c: { x: 125.00, t: -125.00 } }, { b: 11000, d: 500, c: { x: -125.00, t: 125.00 } }],
                [{ b: 0, d: 600, x: 535, e: { x: 27 } }],
                [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, o: 1, e: { o: 5 } }],
                [{ b: -1, d: 1, c: { x: 250.0, t: -250.0 } }, { b: 0, d: 800, c: { x: -250.0, t: 250.0 }, e: { c: { x: 7, t: 7 } } }],
                [{ b: -1, d: 1, o: -1 }, { b: 0, d: 600, x: -570, o: 1, e: { x: 6 } }],
                [{ b: -1, d: 1, o: -1, r: -180 }, { b: 0, d: 800, o: 1, r: 180, e: { r: 7 } }],
                [{ b: 0, d: 1000, y: 80, e: { y: 24 } }, { b: 1000, d: 1100, x: 570, y: 170, o: -1, r: 30, sX: 9, sY: 9, e: { x: 2, y: 6, r: 1, sX: 5, sY: 5 } }],
                [{ b: 2000, d: 600, rY: 30 }],
                [{ b: 0, d: 500, x: -105 }, { b: 500, d: 500, x: 230 }, { b: 1000, d: 500, y: -120 }, { b: 1500, d: 500, x: -70, y: 120 }, { b: 2600, d: 500, y: -80 }, { b: 3100, d: 900, y: 160, e: { y: 24 } }],
                [{ b: 0, d: 1000, o: -0.4, rX: 2, rY: 1 }, { b: 1000, d: 1000, rY: 1 }, { b: 2000, d: 1000, rX: -1 }, { b: 3000, d: 1000, rY: -1 }, { b: 4000, d: 1000, o: 0.4, rX: -1, rY: -1 }]
            ];

            var jssor_1_options = {
                $AutoPlay: 1,
                $Idle: 2000,
                $CaptionSliderOptions: {
                    $Class: $JssorCaptionSlideo$,
                    $Transitions: jssor_1_SlideoTransitions,
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

            var jssor_1_slider = new $JssorSlider$("jssor_1", jssor_1_options);

            /*#region responsive code begin*/

            var MAX_WIDTH = 3000;  

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
    <div id="jssor_1" style="position: relative; margin: 0 auto; top: 0px; left: 0px; width: 1366px; height: 400px; overflow: hidden; visibility: hidden;">
        <!-- Loading Screen -->
        <div data-u="loading" class="jssorl-009-spin" style="position: absolute; top: 0px; left: 0px; width: 100%; height: 100%; text-align: center; background-color: #0557a380;">
            <img style="margin-top: -19px; position: relative; top: 50%; width: 38px; height: 38px;" src="/wp-includes/img/spin.svg" />
        </div>
        <div data-u="slides" style="cursor: default; position: relative; top: 0px; left: 0px; width: 1366px; height: 400px; overflow: hidden;">
            <div>
                <img data-u="image" src="/wp-includes/img/img1.jpg" />
                <div class="caption_css" data-u="caption" data-t="0" style="position: absolute; top: 320px; left: 30px; width: 500px; height: 40px; font-family: Oswald,sans-serif; font-size: 32px; font-weight: 200; line-height: 1.2; text-align: center; background-color: #0557a380;">
                    <strong>PETROVIETNAM</strong>
                     <p><a  href="/sites/en/Pages/detailv1.aspx?NewsID=783dd318-69e4-4fe4-87b3-61d471c382d2">Fully integrated business model for sustainable development</a></p>
                </div>
            </div>
            <div>
                <img data-u="image" src="/wp-includes/img/img2.jpg" />
                <div data-ts="flat" data-p="1360" style="position: absolute; top: 0px; left: 0px; width: 1366px; height: 400px;">
                    <div class="caption_css" data-u="caption" data-t="2" style="position: absolute; top: 30px; left: -505px; width: 500px; height: 40px; font-family: Oswald,sans-serif; font-size: 32px; font-weight: 200; line-height: 1.2; text-align: center; background-color: #0557a380;">
                        <strong>PETROVIETNAM</strong>
                       <p> <a href="/sites/en/Pages/detailv1.aspx?NewsID=dc6b9731-d712-454a-b3e5-0e0b1c0a5ead">Innovative and effective solutions</a></p>
                    </div>
                </div>
            </div>
            <div>
                <img data-u="image" src="/wp-includes/img/img3.jpg" />
                <div class="caption_css" data-u="caption" data-t="3" style="position: absolute; top: 30px; right: 159px; width: 500px; height: 40px; font-family: Oswald,sans-serif; font-size: 32px; font-weight: 200; line-height: 1.2; text-align: center; background-color: #0557a380;">
                    <strong>PETROVIETNAM</strong>
                    <p> <a href="/sites/en/Pages/detailv1.aspx?NewsID=b4a900cc-3b78-45b6-a33c-f949ce806ec7" >Focus on the 5 core businesses</a></p>
                </div>
            </div>

        </div>
        <!-- Bullet Navigator -->
        <div data-u="navigator" class="jssorb052" style="position: absolute; bottom: 12px; right: 12px;" data-autocenter="1" data-scale="0.5" data-scale-bottom="0.75">
            <div data-u="prototype" class="i" style="width: 16px; height: 16px;">
                <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                    <circle class="b" cx="8000" cy="8000" r="5800"></circle>
                </svg>
            </div>
        </div>
        <!-- Arrow Navigator -->
        <div data-u="arrowleft" class="jssora053" style="width: 55px; height: 55px; top: 0px; left: 25px;" data-autocenter="2" data-scale="0.75" data-scale-left="0.75">
            <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                <polyline class="a" points="11040,1920 4960,8000 11040,14080 "></polyline>
            </svg>
        </div>
        <div data-u="arrowright" class="jssora053" style="width: 55px; height: 55px; top: 0px; right: 25px;" data-autocenter="2" data-scale="0.75" data-scale-right="0.75">
            <svg viewbox="0 0 16000 16000" style="position: absolute; top: 0; left: 0; width: 100%; height: 100%;">
                <polyline class="a" points="4960,1920 11040,8000 4960,14080 "></polyline>
            </svg>
        </div>
    </div>
    <script type="text/javascript">jssor_1_slider_init();</script>
    <!-- #endregion Jssor Slider End -->
</div>

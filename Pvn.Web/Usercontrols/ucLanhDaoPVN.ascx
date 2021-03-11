<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLanhDaoPVN.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucLanhDaoPVN" %>

<style>
    .story {
        padding-top: 84px;
        margin-left: 18px;
        text-align: justify;
        font-family: Arial,sans-serif;
        line-height: 20px;
    }

    .story_qk {
        padding-top: 65px;
        margin-left: 18px;
        text-align: justify;
        font-family: Arial,sans-serif;
        line-height: 20px;
    }

    .slides_image {
        background: linear-gradient(#4c98dc, #fdfdfc);
    }

    div[debug-id="slide-1"] {
        height: 900px !important;
    }

    .slider1_container {
        position: relative;
        top: 0px;
        left: 0px;
        width: 1000px !important;
        height: 900px !important;
        overflow: hidden;
        margin-left: -6px;
    }

    .leaders-info_qk {
        padding-left: 348px;
        margin-top: 7px;
    }
</style>
<link rel="stylesheet" type="text/css" href="/Style%20Library/CSS/style_board.css" />
<script type="text/javascript" src="/Style%20Library/jqueryPage/jssor.js"></script>
<script type="text/javascript" src="/Style%20Library/jqueryPage/jssor.slider.js"></script>
<div class="main_content">
    <div class="main">
        <div class="wapper">
            <div id="tabs">
                <ul>
                    <li class="li_tabs">
                        <a href="#tabs-1">
                            <img class="img_tab" src="/DataStore/Images/Our_Leaders/01.jpg"></br><p class="board">HỘI ĐỒNG THÀNH VIÊN</p>
                        </a>
                    </li>
                    <li class="li_tabs"><a href="#tabs-2">
                        <img class="img_tab" src="/DataStore/Images/Our_Leaders/02.jpg"></br><p class="board">BAN TỔNG GIÁM ĐỐC</p>
                    </a></li>
                    <li class="li_tabs"><a href="#tabs-3">
                        <img class="img_tab" src="/DataStore/Images/Our_Leaders/03.jpg"></br><p class="board">KIỂM SOÁT VIÊN</p>
                    </a></li>
                    <!-- Slides Container <li class="li_tabs"><a href="#tabs-4"><img class="img_tab" src="/Style%20Library/Images/sodotochuc/4.jpg"></br><p class="board"> AAA</p></a></li>-->
                </ul>
                <div id="tabs-1">
                    <div id="slider1_container2" class="slider1_container">

                        <!-- Slides Container -->
                        <div u="slides" class="slides" style="top: 0px;">
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/TranSyThanh_HDTV.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Trần sỹ thanh</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Trần sỹ thanh</p>
                                        <p class="leaders-position">Chủ tịch Hội đồng Thành viên</p>
                                        &emsp;- Sinh ngày 16/03/1971</br>	
												&emsp;- Quê quán: Nghệ An</br>
												&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 03/06/1995
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Trình độ học vấn: trên Đại học</br>	
												&emsp;- Trình độ chính trị: Cao cấp</br>
												&emsp;- Trình độ chuyên môn: Đại học Tài chính - Kế toán</br>													
												<i>* Quá trình công tác:</i></br>	
												&emsp;-  2004 – 2007: Chánh Văn phòng Kho bạc Nhà nước Việt Nam</br>
												&emsp;-  2007 – 2008: Phó Tổng Giám đốc Kho bạc Nhà nước Việt Nam</br>	
												&emsp;-  2008 – 2010: Phó Chủ tịch UBND tỉnh Daklak</br>
												&emsp;-  2010 – 2012: Ủy viên dự khuyết BCH TW Đảng Cộng sản Việt Nam, Phó Bí thư Tỉnh ủy Daklak</br>
												&emsp;-  2012 – 2015: Ủy viên BCH TW Đảng Cộng sản Việt Nam, Bí thư Tỉnh ủy Bắc Giang</br>
												&emsp;-  1/2015 – 10/2015: Ủy viên BCH TW Đảng Cộng sản Việt Nam, Phó Chủ nhiệm Ủy ban Kiểm tra TW</br>
												&emsp;-  10/2015 – 12/2017: Ủy viên BCH TW Đảng Cộng sản Việt Nam, Bí thư Tỉnh ủy Lạng Sơn</br>
												&emsp;-  24/12/2017: Ủy viên BCH TW Đảng Cộng sản Việt Nam, Phó Ban Kinh tế TW kiêm Bí thư Đảng ủy, Chủ tịch HĐTV Tập đoàn Dầu khí Việt Nam.</br>
                                        </p>
                                        </p>
											</p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYEN VU TRUONG SON-->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/NguyenVuTruongSon_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Nguyễn Vũ Trường Sơn</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Vũ Trường Sơn</p>
                                        <p class="leaders-position">Thành viên Hội Đồng Thành Viên</p>
                                        &emsp;- Sinh ngày 10/08/1962</br>	
												&emsp;- Quê quán: Quảng Trị</br>
												&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 06/08/1998
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Công nghệ Khai thác Dầu khí, Đại học Hóa dầu Bacu (Liên Xô) (1986)</br>	
												&emsp;- Thạc sỹ Thiết kế công nghệ Hệ thống, Đại học RMIT (Úc) (2002)</br>										
												<i>* Quá trình công tác:</i></br>	
												&emsp;-  1987 - 1996: Đốc công khai thác; Đội phó khai thác, Giàn phó và Giàn trưởng MSD - 2,</br>	
												&emsp;&nbsp;&nbsp;Xí nghiệp Khai thác Dầu khí Vietsovpetro.</br>	
												&emsp;-  1996 - 2003: Phó phòng Kỹ thuật Sản xuất, Xí nghiệp Khai thác Dầu khí Vietsovpetro</br>	
												&emsp;-  2003 - 2005: Trưởng phòng Kỹ thuật sản xuất Bộ máy điều hành Vietsovpetro</br>
												&emsp;-  2005 - 2009: Giám đốc Xí nghiệp Khai thác Dầu khí Vietsovpetro</br>
												&emsp;-  04/2009: Phó Tổng Giám đốc Xí nghiệp Liên doanh Vietsovpetro</br>
												&emsp;-  07/2009: Tổng Giám đốc Tổng Công ty Thăm dò Khai thác Dầu khí (PVEP)</br>
												&emsp;-  Từ 02/2012 - 03/2016: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam</br>
												&emsp;-	 Từ 3/2016 - 3/2017: Thành viên Hội đồng Thành viên, Tổng Giám đốc Tập đoàn;</br>
												&emsp;-	 Từ 3/2017 - 12/2017: Thành viên phụ trách Hội đồng Thành viên Tập đoàn, Tổng Giám đốc Tập đoàn;</br>
												&emsp;-	 Từ 01/2018 đến nay: Thành viên Hội đồng Thành viên Tập đoàn, Tổng Giám đốc Tập đoàn.</br>
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng hạng II, hạng III</br>	
												• Bằng khen Thủ tướng Chính phủ</br>	
												• Bằng khen Bộ Công Thương</br>	
												• Chiến sĩ Thi đua Bộ Công Thương</br></br></br>
                                        </p>
                                        </p>
											</p>
                                    </div>
                                </div>
                            </div>
                            <!-- PHAM XUAN CANH -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/PhamXuanCanh_HDTV.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Phạm Xuân Cảnh</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Phạm Xuân Cảnh</p>
                                        <p class="leaders-position">Thành viên Hội Đồng Thành Viên</p>
                                        &emsp;- Sinh ngày 10/03/1963</br>
											&emsp;- Quê quán: Nam Định</br>
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 03/10/1985
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Khoan Thăm dò Khai thác Dầu khí, Đại học Mỏ - Địa chất</br>
												&emsp;- Thạc sỹ chuyên ngành Quản trị Kinh doanh quốc tế, Đại học Grigggs (Hoa Kỳ)</br>
												&emsp;- Học viện chính trị Quốc gia Hồ Chí Minh: Chuyên ngành Chính trị học, cấp đào tạo Đại học</br>
												<i>* Quá trình công tác:</i></br>	
												&emsp;- 1985 - 1988: Cán bộ trường Đại học Mỏ - Địa chất</br>
												&emsp;- 1998 - 1995: Tổng thư ký Hội Sinh viên Hà Nội khoá I, Phó Bí thư thường trực Thành đoàn Hà</br>
												&emsp;&nbsp;&nbsp;Nội</br>
												&emsp;- 1995 - 1996: Chủ tịch Hội Sinh viên Hà Nội khóa II, Phó chủ tịch Trung ương Hội Sinh viên Việt</br>
												&emsp;&nbsp;&nbsp;Nam khóa V, Phó bí thư thường trực Thành đoàn Hà Nội, Chủ tịch Hội đồng Đội Thiếu niên</br>
												&emsp;&nbsp;&nbsp;Tiền phong Hồ Chí Minh TP.Hà Nội</br>
												&emsp;- 1997 - 2002: Bí thư Thành đoàn Hà Nội, Đại biểu Hội đồng nhân dân TP Hà Nội khóa XII, Bí</br>
												&emsp;&nbsp;&nbsp;thư Đảng bộ Thành đoàn Hà Nội, Chủ tịch Hội Hữu nghị Việt Nam - Lào TP.Hà Nội</br>
												&emsp;- 2000 - 2003: Bí thư Trung ương Đoàn Thanh niên cộng sản Hồ Chí Minh khóa VII</br>
												&emsp;- 2003 - 2006: Chuyên viên cao cấp, Vụ III, Văn phòng Chính phủ</br>
												&emsp;- 2006 - 2008: Phó vụ trưởng vụ III, Văn phòng chính phủ</br>
												&emsp;- 2008 - 08/2015: Phó Bí thư thường trực Đảng ủy, Trưởng Ban tổ chức Đảng ủy Tập đoàn Dầu</br>
												&emsp;&nbsp;&nbsp;khí Việt Nam</br>
												&emsp;- Từ 09/2015 đến nay: Phó Bí thư thường trực Đảng ủy, Thành viên Hội đồng thành viên Tập đoàn</br>
												&emsp;&nbsp;&nbsp;Dầu khí Việt Nam
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng III</br>
												• Bằng khen Thủ tướng Chính phủ
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYEN HUNG DUNG -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/NguyenHungDung_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Nguyễn Hùng Dũng</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Hùng Dũng</p>
                                        <p class="leaders-position">Thành viên Hội Đồng Thành Viên</p>
                                        &emsp;- Sinh ngày 19/08/1962</br>
											&emsp;- Quê quán: Thanh Hóa</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 30/05/1998
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Điều khiển tàu biển, Đại học Hàng hải</br>	
												&emsp;- Cử nhân Kinh tế, Đại học Kinh tế Quốc Dân</br>	
												&emsp;- Tiến sỹ chuyên ngành Tin học, khoa học tính toán và quản lý, Viện nghiên</br>	
												&emsp;&nbsp;&nbsp;cứu khoa học thực nghiệm Điện tử và trang thiết bị Điện (Liên bang Nga)</br>	
												&emsp;- Cao cấp Lý luật Chính trị, Học viện Chính trị Quốc gia Hồ Chí Minh</br>										
												<i>* Quá trình công tác:</i></br>
												&emsp;- 1988 - 1993: Thuyền trưởng, Công ty Dịch vụ Thủy sản Tây Nam (Bộ Thủy Sản)</br>
												&emsp;- 1993 - 1998: Thuyền phó, Xí nghiệp Tàu dịch vụ Dầu khí (PTSC)</br>
												&emsp;- 1998 - 2005: Chuyên viên Phòng Kỹ thuật sản xuất; Phòng Kinh tế Kế hoạch;</br>
												&emsp;&nbsp;&nbsp;Phó phòng phụ trách; Trưởng phòng Kinh tế Kế hoạch Công ty Dịch vụ Kỹ thuật Dầu khí</br>
												&emsp;&nbsp;&nbsp;(PTSC)</br>
												&emsp;- 2005: Ủy viên BCH Đảng bộ Công ty Dịch vụ Kỹ thuật Dầu khí (PTSC)</br>
												&emsp;- 2006 - 2008: Phó Tổng Giám đốc, Công ty Dịch vụ Kỹ thuật Dầu khí (PTSC)</br>
												&emsp;- 2008 - 07/2008: Ủy viên Ban thường vụ Đảng ủy, Phó Tổng Giám đốc Công ty Cổ phần Dịch</br>
												&emsp;&nbsp;&nbsp;vụ Kỹ thuật Dầu khí (PTSC)</br>
												&emsp;- 07/2008 - 09/2008: Tổng Giám đốc Công ty Cổ phần Dịch vụ Kỹ thuật Dầu khí (PTSC)</br>
												&emsp;- 09/2008 - 2013: Phó Bí thư Đảng ủy, Thành viên HĐQT, Tổng Giám đốc Tổng Công ty Cổ</br>
												&emsp;&nbsp;&nbsp;phần Dịch vụ Kỹ thuật Dầu khí (PTSC)</br>
												&emsp;- Từ 04/2013 đến nay: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Anh hùng Lao động thời kỳ đổi mới</br>
												• Huân chương Lao động hạng II, hạng III</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Chiến sĩ Thi đua toàn quốc</br>
												• Bằng khen Bộ Công Thương
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- DINH VAN SON-->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/DinhVanSon_HDTV.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Đinh Văn Sơn</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Đinh Văn Sơn</p>
                                        <p class="leaders-position">Thành Viên Hội Đồng Thành Viên</p>
                                        &emsp;- Sinh ngày 05/01/1961</br>	
											&emsp;- Quê quán: Thái Bình</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 10/10/1985
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Địa Vật lý Dầu khí, Trường Đại học Mỏ Địa chất</br>
												&emsp;- Thạc Sỹ chuyên ngành Quản trị Kinh doanh, Đại học Tổng hợp Washington (Hoa Kỳ)</br>
												&emsp;- Tiến sỹ chuyên ngành Kinh tế Công nghiệp, Đại học Bách Khoa Hà Nội</br>
												&emsp;- Cao cấp Lý luận Chính trị, Học viện Chính trị - Hành chính Khu vực I</br>
												&emsp;- Lớp bồi dưỡng kiến thức Quốc phòng an ninh, Học viện Quốc phòng</br>
												<i>* Quá trình công tác:</i></br>	
												&emsp;- 1984: Cán bộ phòng Kỹ thuật, Công ty Dầu khí I, Tổng cục Dầu khí Viêt Nam</br>
												&emsp;- 1984 - 1986: Tiểu đội trưởng, Trợ lý Quân khí</br>
												&emsp;- 1986 - 1988: Cán bộ phòng Kỹ thuật, Công ty Dầu khí I, Tổng cục Dầu khí Viêt Nam</br>
												&emsp;- 1988 - 1990: Tham gia chương trình hợp tác lao động tại Liên Xô</br>
												&emsp;- 1991 - 1992: Công ty Dầu khí I, Tổng cục Dầu khí Việt Nam</br>
												&emsp;- 1992 - 1996: Cán bộ phòng Kỹ thuật, Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 1996 - 2003: Cán bộ biệt phái tại Công ty Dịch vụ Kỹ thuật Dầu khí Schlumberger</br>
												&emsp;- 2003 - 2006: Trợ lý Tổng Giám đốc Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 2006 - 2007: Phó Chánh Văn phòng kiêm Trợ lý Tổng Giám đốc Tổng Công ty Dầu khí</br>
												&emsp;&nbsp;&nbsp;Việt Nam</br>
												&emsp;- 2007: Trưởng Ban Quản lý các Hợp đồng Dầu khí, Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 2007 - 2009: Chánh Văn phòng Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 2009 - 2012: Trưởng Ban Luật & Quan hệ Quốc tế, Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 2012 - 2013: Trưởng Ban Quan hệ Quốc tế, Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- Từ 2013 đến nay: Thành viên Hội đồng thành viên Tập đoàn Dầu khí Việt Nam
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng III</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Chiến sĩ Thi đua toàn quốc</br>
												• Bằng khen Bộ Công Thương</br>
												• Kỷ niệm chương Vì thế hệ trẻ
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- PHAN NGOC TRUNG -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/PhanNgocTrung_HDTV.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Phan Ngọc Trung</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Phan Ngọc Trung</p>
                                        <p class="leaders-position">Thành viên Hội Đồng Thành Viên</p>
                                        &emsp;- Sinh ngày: 10/07/1961</br>	
											&emsp;- Quê quán: Quảng Trị</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 10/03/1987
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>
												&emsp;- Kỹ sư Khai thác Dầu khí, Trường Đại học Dầu hóa Azerbaijan, Bacu (Liên Xô cũ)</br>
												&emsp;- Tiến sỹ Khai thác dầu khí, Trường Đại học Dầu hóa Azerbaijan, Bacu (Liên Xô cũ)</br>
												&emsp;- Cử nhân tiếng Anh, Trường Đại học Sư phạm Ngoại ngữ Hà Nội</br>
												&emsp;- Cao cấp Lý luận chính trị tại Học viện chính trị Quốc gia Hồ Chí Minh - Phân viện Hà Nội</br>
												<i>* Quá trình công tác:</i></br>
												&emsp;- 1987 - 1988: Cán bộ Viện Cơ học</br>
												&emsp;- 1988 - 1992: Cán bộ khoa học Viện Dầu khí Việt Nam</br>
												&emsp;- 1992 - 1993: Chuyên viên phòng khoa học kỹ thuật- Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 1993 - 1995: Chuyên viên phòng Thẩm định - Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 03/1995 - 09/1995: Cán bộ biệt phái, Phó chủ nhiệm dự án đường ống Nam Côn Sơn -</br>
												&emsp;&nbsp;&nbsp;Văn phòng BP, Tp. Hồ Chí Minh</br>
												&emsp;- 1995 - 2004: Chuyên viên Ban Thăm dò Khai thác Dầu khí, Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 2004 - 2007: Phó Trưởng ban Khai thác Dầu khí, Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 07/2007 - 12/2007: Trưởng Ban Khai thác Dầu khí, Tập đoàn Dầu khí Việt Nam;</br>
												&emsp;&nbsp;&nbsp;Uỷ viên Thành viên Hội đồng Thành viên Tổng Công ty Thăm dò Khai thác Dầu khí</br>
												&emsp;- 01/2008 - 04/2008: Phó Tổng Giám đốc Tổng Công ty Thăm dò Khai thác Dầu khí;</br>
												&emsp;&nbsp;&nbsp;Uỷ viên Thành viên Hội đồng Thành viên Tổng Công ty Thăm dò Khai thác Dầu khí</br>
												&emsp;- 2008 - 2014: Viện trưởng Viện Dầu khí Việt Nam;</br>
												&emsp;&nbsp;&nbsp;Thành viên Hội đồng Thành viên Tổng Công ty Thăm dò Khai thác Dầu khí</br>
												&emsp;- 2014 - 2015: Viện trưởng Viện Dầu khí Việt Nam</br>
												&emsp;- Từ 05/2015 đến nay: Thành viên Hội đồng Thành viên Tập đoàn Dầu khí Việt Nam
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng II, hạng III</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Chiến sĩ thi đua toàn quốc</br>
												• Chiến sĩ thi đua Bộ Công Thương</br>
												• Bằng khen Bộ Công Thương
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYEN TIEN VINH
								<div>
									<img u="image" class="slides_image"  src="/DataStore/Contacts/LDTD/NguyenTienVinh_HDTV.png" />
									<div u="thumb">
										<a href="#"><div class="t">Ông Nguyễn Tiến Vinh</div></a>
									</div>
									<div class="slider1_container_Content">
										<div class="leaders-info">
											<p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Tiến Vinh</p>
											<p class="leaders-position">Thành viên Hội Đồng Thành Viên</p>
											&emsp;- Sinh ngày: 30/10/1962</br>
											&emsp;- Quê quán: Thừa Thiên Huế</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 12/04/1997
										</div>
										<div class="story">		
											<p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
											<p style="width: 624px;color: #000; text-align: justify; margin-top: -9px;">
												<i>* Trình độ đào tạo:</i></br>
												&emsp;- Kỹ sư Máy và Thiết bị khoan Khai thác Dầu khí,  Đại học Hóa dầu Bacu (Liên Xô cũ)</br>
												&emsp;- Thạc sỹ Quản trị Kinh doanh Công nghiệp và Xây dựng cơ bản, Học viện Công nghệ</br>
												&emsp;&nbsp;&nbsp;Châu Á AIT</br>
												&emsp;- Tiến sỹ Kỹ thuật Dầu mỏ, Đại học Mỏ Địa chất</br>
												&emsp;- Cao cấp Lý luận Chính trị, Học viện chính trị Quốc gia</br>
												<i>* Quá trình công tác:</i></br>
												&emsp;- 05/1987 - 06/1991: Kỹ sư cơ khí, Kỹ sư trưởng giàn MSP4, Xí nghiệp khai thác,  Xí nghiệp liên</br>
												&emsp;&nbsp;&nbsp;doanh Vietsovpetro</br>	
												&emsp;- 07/1991 - 12/2004: Phó phòng, Trưởng phòng Cơ khí - Năng lượng, Xí nghiệp khai thác,</br>
												&emsp;&nbsp;&nbsp;Xí nghiệp liên doanh Vietsovpetro</br>
												&emsp;- 01/2005 - 11/2007: Trưởng phòng Quản lý Chất lượng, Xí nghiệp khai thác,  Xí nghiệp liên</br>
												&emsp;&nbsp;&nbsp;doanh Vietsovpetro</br>
												&emsp;- 12/2007 - 07/2009: Trưởng phòng Cơ khí-Năng lượng-Tự động hóa,  Xí nghiệp khai thác,</br>
												&emsp;&nbsp;&nbsp;Xí nghiệp liên doanh Vietsovpetro</br>
												&emsp;- 08/2009 - 04/2016: Trưởng ban, Ban Điện, Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- Từ 04/2016 đến nay: Thành viên HĐTV Tập đoàn Dầu khí Việt Nam
											</p>
											<p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
											<p style="width: 624px;color: #000; text-align: justify; margin-top: -9px;">
												• Huân chương Lao động hạng III</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Bằng khen Bộ Công Thương
											</p>
										</div>
									</div>
								</div>
								-->
                        </div>

                        <div u="thumbnavigator" class="jssort11" style="left: 0px; top: 0px;">
                            <!-- Thumbnail Item Skin Begin -->
                            <div u="slides" class="fixTop" style="top: 0px !important;">
                                <div u="prototype" class="p" style="top: 0; left: 0;">
                                    <div u="thumbnailtemplate" class="tp"></div>
                                </div>
                            </div>
                            <!-- Thumbnail Item Skin End -->
                        </div>

                    </div>

                </div>
                <div id="tabs-2">
                    <div id="slider1_container" class="slider1_container">
                        <!-- Slides Container -->
                        <div u="slides" class="slides">
                            <!-- NGUYEN VU TRUONG SON -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/NguyenVuTruongSon_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Nguyễn Vũ Trường Sơn</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Vũ Trường Sơn</p>
                                        <p class="leaders-position">Tổng Giám đốc</p>
                                        &emsp;- Sinh ngày 10/08/1962</br>	
											&emsp;- Quê quán: Quảng Trị</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 06/08/1998	
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Công nghệ Khai thác Dầu khí, Đại học Hóa dầu Bacu (Liên Xô) (1986)</br>	
												&emsp;- Thạc sỹ Thiết kế công nghệ Hệ thống, Đại học RMIT (Úc) (2002)</br>										
												<i>* Quá trình công tác:</i></br>	
												&emsp;-  1987 - 1996: Đốc công khai thác; Đội phó khai thác, Giàn phó và Giàn trưởng MSD - 2,</br>	
												&emsp;&nbsp;&nbsp;Xí nghiệp Khai thác Dầu khí Vietsovpetro.</br>	
												&emsp;-  1996 - 2003: Phó phòng Kỹ thuật Sản xuất, Xí nghiệp Khai thác Dầu khí Vietsovpetro</br>	
												&emsp;-  2003 - 2005: Trưởng phòng Kỹ thuật sản xuất Bộ máy điều hành Vietsovpetro</br>
												&emsp;-  2005 - 2009: Giám đốc Xí nghiệp Khai thác Dầu khí Vietsovpetro</br>
												&emsp;-  04/2009: Phó Tổng Giám đốc Xí nghiệp Liên doanh Vietsovpetro</br>
												&emsp;-  07/2009: Tổng Giám đốc Tổng Công ty Thăm dò Khai thác Dầu khí (PVEP)</br>
												&emsp;-  Từ 02/2012 - 03/2016: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam</br>
												&emsp;-	 Từ 3/2016 - 3/2017: Thành viên Hội đồng Thành viên, Tổng Giám đốc Tập đoàn;</br>
												&emsp;-	 Từ 3/2017 - 12/2017: Thành viên phụ trách Hội đồng Thành viên Tập đoàn, Tổng Giám đốc Tập đoàn;</br>
												&emsp;-	 Từ 01/2018 đến nay: Thành viên Hội đồng Thành viên Tập đoàn, Tổng Giám đốc Tập đoàn.</br>
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng hạng II, hạng III</br>	
												• Bằng khen Thủ tướng Chính phủ</br>	
												• Bằng khen Bộ Công Thương</br>	
												• Chiến sĩ Thi đua Bộ Công Thương
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYEN QUOC THAP -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/NguyenQuocThap_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Nguyễn Quốc Thập</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Quốc Thập</p>
                                        <p class="leaders-position">Phó Tổng giám đốc</p>
                                        &emsp;- Sinh ngày 02/08/1960</br>	
											&emsp;- Quê quán: Nam Định</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 26/09/1998</br>	
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>
													&emsp;- Kỹ sư Địa Vật lý, Đại học Mỏ - Địa chất</br>
													&emsp;- Tiến sỹ chuyên ngành Địa Vật lý, Đại học Mỏ - Địa chất</br>
												<i>* Quá trình công tác:</i>
                                        </br>	
													&emsp;- 1984 - 1986: Kỹ sư Địa Vật lý, Viện Dầu khí Hà Nội</br>
													&emsp;- 1986 - 1990: Kỹ sư Địa Vật lý, Xí nghiệp Liên doanh Dầu khí Vietsovpetro</br>
													&emsp;- 1990 - 1993: Kỹ sư Địa Vật lý, Công ty Dầu khí II - TP Hồ Chí Minh</br>
													&emsp;- 1993 - 2000: Cán bộ Công ty Dầu khí Anh BP tại TP Hồ Chí Minh (cán bộ biệt phái của PVEP)</br>
													&emsp;- 2000 - 2002: Trưởng phòng Công nghệ mỏ, Công ty Đầu tư và Phát triển Dầu khí (PIDC)</br>
													&emsp;- 2002 - 2003: Phó Giám đốc Công ty Đầu tư và Phát triển Dầu khí (PIDC)</br>
													&emsp;- 2003 - 2006: Phó Giám đốc Công ty Đầu tư và Phát triển Dầu khí (PIDC), Trưởng Chi nhánh</br>
													&emsp;&nbsp;&nbsp;PIDC tại Algeria</br>
													&emsp;- 2006 - 2007: Giám đốc Công ty Đầu tư và Phát triển Dầu khí (PIDC)</br>
													&emsp;- 2007 - 2008: Phó Tổng Giám đốc, sau đó là Tổng Giám đốc Tổng Công ty Thăm dò Khai thác</br>
													&emsp;&nbsp;&nbsp;Dầu khí (PVEP)</br>
													&emsp;- Từ 07/2009 đến nay: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam
											<p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng II, hạng III</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Chiến sĩ Thi đua toàn quốc</br>
												• Bằng khen Bộ Công Thương
                                        </p>
                                    </div>
                                </div>
                            </div>

                            <!-- LE MANH HUNG -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/LeManhHung_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Lê Mạnh Hùng</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Lê Mạnh Hùng</p>
                                        <p class="leaders-position">Phó Tổng Giám đốc</p>
                                        &emsp;- Sinh ngày 24/10/1973</br>
											&emsp;- Quê quán: Hưng Yên</br>	
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 30/08/2007
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Công nghệ Tổng hợp Hóa dầu và Hữu cơ, Đại học Bách Khoa</br>
												&emsp;- Thạc sỹ chuyên ngành Công nghệ Hóa dầu, Đại học Bách khoa Hà Nội (2003)</br>
												&emsp;- Tiến sỹ chuyên ngành Hóa dầu và xúc tác hữu cơ, Đại học Bách khoa Hà Nội (2008)</br>
												<i>* Quá trình công tác:</i></br>
												&emsp;- 2000 - 2001: Kỹ sư Công nghệ, Công ty Liên doanh Nhà máy lọc dầu Việt Nga</br>
												&emsp;- 2001 - 2005: Kỹ sư Công nghệ, Khối Kỹ thuật, Tổng Công ty Dung dịch khoan và Hóa phẩm</br>
												&emsp;&nbsp;&nbsp;Dầu khí (DMC)</br>
												&emsp;- 2005 - 2006: Cán bộ Ban Chế biến Dầu khí, Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 2006 - 2007: Cán bộ Vụ Dầu khí, Văn phòng Chính Phủ</br>
												&emsp;- 2007 - 2009: Phó Trưởng ban Chế biến Dầu khí, Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 2009: Phó Tổng Giám đốc Công ty Liên doanh Hóa dầu Long Sơn</br>
												&emsp;- 12/2009 - 2011: Trưởng Ban QLDA Cụm Khí Điện Đạm Cà Mau</br>
												&emsp;- 03/2011 - 2013: Tổng Giám đốc Công ty TNHH MTV Phân bón Dầu khí Cà Mau (PVCFC)</br>
												&emsp;- Từ 10/2013 đến nay: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng III</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Bằng khen Bộ Công Thương</br>
												• Chiến sĩ Thi đua Bộ Công Thương
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYEN SINH KHANG
								<div>
									<img u="image" class="slides_image"  src="/DataStore/Contacts/LDTD/NguyenSinhKhang_BanTGD.png" />
									<div u="thumb">
										<a href="#"><div class="t">Ông Nguyễn Sinh Khang</div></a>
									</div>
									<div class="slider1_container_Content">
										<div class="leaders-info">
											<p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Sinh Khang</p>
											<p class="leaders-position">Phó Tổng Giám đốc</p>
											&emsp;- Sinh ngày 09/05/1961</br>
											&emsp;- Quê quán: Nghệ An</br>
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 16/01/1982
										</div>
										<div class="story">		
											<p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
											<p style="width: 624px;color: #000; text-align: justify; margin-top: -9px;">
												<i>* Trình độ đào tạo:</i></br>
												&emsp;- Kỹ sư Điện tử Viễn thông, Đại học Kỹ thuật Quân sự</br>
												&emsp;- Cử nhân Quản trị Kinh doanh, Đại học Kinh tế TP Hồ Chí Minh</br>
												&emsp;- Thạc sỹ chuyên ngành Quản lý Dự án, Học viện Công nghệ Châu Á (AIT - Thái Lan)</br>
												<i>* Quá trình công tác:</i></br>
												&emsp;- 1983 - 1985: Trung úy, Kỹ sư Thông tin Vô tuyến điện, Bộ Tư lệnh Quân khu 7</br>
												&emsp;- 1985 - 1990: Đại úy, Tiểu đoàn phó Kỹ thuật, Tiểu đoàn Thông tin 42 - Mặt trận 779</br>
												&emsp;- 1990 - 1995: Cán bộ Phòng Kế hoạch Sở Công nghiệp Đặc khu Vũng Tàu</br>
												&emsp;- 1995 - 1996: Phó Trưởng phòng Kế hoạch, Sở Công nghiệp Đặc khu Vũng Tàu</br>
												&emsp;- 1996 - 1998: Cán bộ phòng Kế hoạch, Công ty Thương mại Kỹ thuật và Đầu tư Petec</br>
												&emsp;- 1998 - 2006: Bí thư Chi bộ Kế hoạch Đầu tư; Phó Trưởng phòng phụ trách Phòng Kế hoạch,</br>
												&emsp;&nbsp;&nbsp;Trưởng Phòng Kế hoạch Tổng hợp, Công ty Thương mại Dầu khí (Petechim)</br>
												&emsp;- 2007 - 2008: Phó Tổng Giám đốc Công ty Chế biến và Kinh doanh sản phẩm dầu mỏ</br>
												&emsp;- 2008 - 2010: Chủ tịch HĐTV Tổng Công ty Dầu Việt Nam (PVOil)</br>
												&emsp;- Từ 04/2010 đến nay: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam
											</p>
											<p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>	
											<p style="width: 624px;color: #000; text-align: justify; margin-top: -9px;">	
												• Huân chương Lao động hạng III</br>
												• Huân chương Chiến công hạng II</br>
												• Huân chương Chiến sỹ vẻ vang hạng II, hạng III</br>
												• Huân chương Bảo vệ Tổ quốc hạng II của Campuchia</br>
												• Bằng khen Thủ tướng Chính phủ</br>
												• Bằng khen Bộ Công Thương</br>
												• Bằng khen Tổng Liên đoàn Lao động Việt Nam</br>
												• Chiến sĩ Thi đua Bộ Công Thương
											</p>
										</div>
									</div>
								</div>
								 -->
                            <!-- DO CHI THANH -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/DoChiThanh_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông Đỗ Chí Thanh</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Đỗ Chí Thanh</p>
                                        <p class="leaders-position">Phó Tổng Giám đốc</p>
                                        &emsp;- Sinh ngày 17/03/1968</br>	
											&emsp;- Quê quán: Hải Phòng</br>
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 03/02/2005</br>	
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Kỹ sư Kinh tế, Đại học Mỏ Địa chất</br>
												&emsp;- Thạc sỹ Kinh tế, Đại học Mỏ Địa chất	</br>
												<i>* Quá trình công tác:</i></br>
												&emsp;- 1991 - 2006: Cán bộ phòng Hợp tác Quốc tế, Tổng Công ty Dầu khí Việt Nam</br>
												&emsp;- 2006 - 2007: Phó Trưởng phòng Quan hệ cộng đồng, Tổng công ty Dầu khí Việt Nam</br>
												&emsp;- 2007 - 2009: Phó Chánh Văn phòng kiêm Trợ lý Chủ tịch HĐQT Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 2009 - 2010: Chánh Văn phòng Tập đoàn Dầu khí Việt Nam</br>
												&emsp;- 2010 - 2014: Chủ tịch Hội đồng Thành viên Tổng Công ty Điện lực Dầu khí Việt Nam</br>
												&emsp;&nbsp;&nbsp;(PVPower)</br>
												&emsp;- Từ 01/2015 đến nay: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam
                                        </p>
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Khen thưởng</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            • Huân chương Lao động hạng III
                                        </p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYỄN XUÂN HÒA -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/NguyenXuanHoa_BanTGD.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">Ông NGUYỄN XUÂN HÒA</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">Ông Nguyễn Xuân Hòa</p>
                                        <p class="leaders-position">Phó Tổng Giám đốc</p>
                                        &emsp;- Sinh ngày 01/07/1972</br>	
											&emsp;- Quê quán: Hải Dương</br>
											&emsp;- Ngày gia nhập Đảng Cộng sản Việt Nam: 03/07/2003</br>	
                                    </div>
                                    <div class="story">
                                        <p style="background-color: rgba(202, 202, 202, 0.28); width: 624px; text-align: center; color: #C71585; font-weight: bold; text-transform: uppercase;">Tóm tắt tiểu sử</p>
                                        <p style="width: 624px; color: #000; text-align: justify; margin-top: -9px;">
                                            <i>* Trình độ đào tạo:</i></br>	
												&emsp;- Cử nhân Tài chính Kế toán</br>
												<i>* Quá trình công tác:</i></br>
												&emsp;- 11/1994 - 11/1999: Nhân viên, Petechim, Petrovietnam</br>
												&emsp;- 12/1999 - 11/2000: Cán bộ, Công ty Chế biến và Xuất khẩu đồ gỗ gia dụng Hoàng Mộc</br>
												&emsp;- 11/2000 - 6/2007: Nhân viên Phòng Thương mại (11/2000-4/2001);</br>
												&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; Phó phòng Thương mại (5/2001-8/2001);</br>
												&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; Phụ trách phòng Thương mại (9/2001-6/2003);</br>
												&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; Trưởng phòng Thương mại (từ 7/2003),</br>
												&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp;&emsp; Công ty TNHH 1 TV Chế biến và Kinh doanh các sản phẩm Khí</br>
												&emsp;- 7/2007 - 01/2009:  Phó Tổng giám đốc, Tổng công ty Khí Việt Nam (PV Gas)</br>
												&emsp;- 02/2009 - 3/2009: Phó Tổng giám đốc, Tổng Công ty Điện lực Dầu khí Việt Nam (PV Power)</br>
												&emsp;- 4/2009 - 10/06/2012: Tổng giám đốc, Chi nhánh Tập đoàn DKVN - Công ty Cung ứng và Phân phối Than Dầu khí</br>
												&emsp;- 11/06/2012 - 30/11/2013: Ủy viên HĐQT, Tổng giám đốc, Tổng Công ty Thương mại Kỹ thuật và Đầu tư - CTCP (PETEC)</br>
												&emsp;- 12/2013 - 9/2014: Phó Tổng giám đốc PV OIL kiêm Tổng giám đốc PETEC, PV OIL</br>
												&emsp;- 01/10/2014 - 20/10/2015: Ủy viên HĐQT, Hội đồng Quản trị, Tổng công ty Khí Việt Nam - CTCP</br>
											    &emsp;- 21/10/2015 - 30/06/2018: Tổng giám đốc, Tổng công ty Điện lực Dầu khí Việt Nam</br>
											    &emsp;- 01/07/2018 - 02/10/2018: Tổng giám đốc, Tổng Công ty Điện lực Dầu khí Việt Nam - CTCP</br>
											    &emsp;- Từ 03/10/2018 đến nay: Phó Tổng Giám đốc Tập đoàn Dầu khí Việt Nam</br>
                                        </p>
                                    </div>
                                </div>
                            </div>




                        </div>

                        <div u="thumbnavigator" class="jssort11" style="left: 0px; top: 0px;">
                            <!-- Thumbnail Item Skin Begin -->
                            <div u="slides" class="fixTop" style="top: 0px !important;">
                                <div u="prototype" class="p" style="top: 0; left: 0;">
                                    <div u="thumbnailtemplate" class="tp"></div>
                                </div>
                            </div>
                            <!-- Thumbnail Item Skin End -->
                        </div>

                    </div>

                </div>
                <div id="tabs-3">
                    <div id="slider1_container3" class="slider1_container">
                        <!-- Slides Container -->
                        <div u="slides" class="slides">
                            <!-- NGUYỄN MẠNH HÙNG -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/Nguyen_Manh_Hung_KSV.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">ÔNG NGUYỄN MẠNH HÙNG</div>
                                    </a>
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">ÔNG NGUYỄN MẠNH HÙNG</p>
                                        <p class="leaders-position">Kiểm soát viên phụ trách chung</p>
                                    </div>
                                </div>
                            </div>
                            <!-- NGUYEN THI NGOC LAN -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/nguyenthingonlan.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">BÀ NGUYỄN THỊ NGỌC LAN</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">BÀ NGUYỄN THỊ NGỌC LAN</p>
                                        <p class="leaders-position">Kiểm soát viên</p>
                                    </div>
                                </div>
                            </div>
                            <!-- VU HONG NHUNG -->
                            <div>
                                <img u="image" class="slides_image" src="/DataStore/Contacts/LDTD/vuhongnhung.png" />
                                <div u="thumb">
                                    <a href="#">
                                        <div class="t">BÀ VŨ HỒNG NHUNG</div>
                                    </a>
                                    <!-- <div class="c">360+ touch swipe slideshow effects</div> -->
                                </div>
                                <div class="slider1_container_Content">
                                    <div class="leaders-info">
                                        <p class="leaders-name" style="background-color: rgba(202, 202, 202, 0.28); width: 442px; text-align: center; color: #C71585;">BÀ VŨ HỒNG NHUNG</p>
                                        <p class="leaders-position">Kiểm soát viên tài chính</p>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <div u="thumbnavigator" class="jssort11" style="left: 0px; top: 0px;">
                            <!-- Thumbnail Item Skin Begin -->
                            <div u="slides" class="fixTop" style="top: 0px !important;">
                                <div u="prototype" class="p" style="top: 0; left: 0;">
                                    <div u="thumbnailtemplate" class="tp"></div>
                                </div>
                            </div>
                            <!-- Thumbnail Item Skin End -->
                        </div>
                    </div>
                </div>
                <!--<div id="tabs-4">
				
				</div>-->
            </div>
        </div>
    </div>

</div>
<script type="text/javascript" src="/Style%20Library/jqueryPage/jquery-ui.js"></script>
<script type="text/javascript" src="/Style%20Library/jqueryPage/sliderPVN.js"></script>
<script>
	$( "#tabs" ).tabs();
</script>
​

<style>
    .slides {
        width: 644px !important;
    }

    .story {
        padding-top: 84px;
        margin-left: 18px;
        text-align: justify;
        font-family: Arial,sans-serif;
        line-height: 20px;
    }

    .story_qk {
        padding-top: 65px;
        margin-left: 18px;
        text-align: justify;
        font-family: Arial,sans-serif;
        line-height: 20px;
    }

    div[debug-id="slide-1"] {
        height: 1201px !important;
    }

    .leaders-info_qk {
        padding-left: 348px;
        margin-top: 7px;
    }
</style>

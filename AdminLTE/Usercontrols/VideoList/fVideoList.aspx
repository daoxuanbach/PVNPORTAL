<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fVideoList.aspx.cs" Inherits="AdminLTE.Usercontrols.VideoList.fVideoList" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Cập nhật thông tin chuyên mục</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <button class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-share"></i>Quay lại</button>
                        <button type="submit" id="btn-Update" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></button>
                    </div>
                </div>
            </div>

        </div>
        <div class="content ">
            <div class="row">
                <div class="col-xs-12">
                    <div class="box box-info">
                        <div class="box-header with-border">
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->
                        <asp:HiddenField ID="hidAction" runat="server" Value="add" />
                        <asp:HiddenField ID="hidID" runat="server" />
                        <input type="hidden" name="VideoID" value="<%=objItemET.VideoID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Language</label>
                                        <select class="form-control cboLanguage" style="width: 100%" id="cboLanguage" tabindex="1" name="Language">
                                            <asp:Repeater ID="rptLanguage" runat="server">
                                                <ItemTemplate>
                                                    <option  value="<%#Eval("Value") %>"><%#Eval("Note") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trạng thái sử dụng</label>
                                        <select class="form-control select2 " id="cboUsedState" style="width: 100%;" name="UsedState" tabindex="2">
                                               <asp:Repeater ID="rptUsedState" runat="server">
                                                            <ItemTemplate>
                                                                <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <label>Xuất bản</label>
                                    <select class="form-control select2 " id="cboPublishedState" style="width: 100%;" name="PublishedState" tabindex="2">
                                        <option value="1">Intranet</option>
                                        <option value="2" selected>Intranet - Internet</option>
                                    </select>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Chuyên mục cha </label>
                                        <select class="form-control select2" style="width: 100%" id="cboVideoCategoryID" tabindex="6" name="VideoCategoryID">
                                            <option value="">-- Tất cả ---</option>
                                            <asp:Repeater ID="rptParentCategoryID" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("VideoCategoryID") %>"><%#Eval("IndentedTitle") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên</label>
                                        <input type="text" class="form-control" name="Title" tabindex="4" placeholder="Tên" data-validation="required" value="<%=objItemET.Title %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên tiếng anh</label>
                                        <input type="text" class="form-control" name="Note" tabindex="4" placeholder="Tên tiếng anh" value="<%=objItemET.Note %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label>Ảnh hiển thị</label>
                                            <div class="content-avatar">
                                                <div id="listImageAttach">
                                                    <img id="pic1" src="/UserControls/images/thumbnail.jpg">
                                                </div>
                                                <div id="btnChonAnh" tabindex="5" style="">Chọn</div>
                                                <div id="btnXoaAnh" tabindex="6" style="">Xóa</div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Đường dẫn ảnh	</label>
                                                <input id="newWinField" class="form-control" name="ImageURL" hidden="hidden" placeholder="Đường dẫn ảnh" value="">
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Tiêu đề ảnh hiển thị</label>
                                                <input type="text" class="form-control" name="ImageTitle" tabindex="4" placeholder="Tiêu đề" value="<%=objItemET.ImageTitle %>">
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Đường dẫn video	</label>
                                        <div class="row">
                                            <div class="col-md-10">
                                                <input type="text" id="VideoURL" class="form-control" name="VideoURL" tabindex="4" placeholder="Tiêu đề" value="<%=objItemET.VideoURL %>">
                                            </div>
                                            <div class="col-md-2">
                                                <div class="form-group">
                                                    <div id="btnChonVideo" class=" btn btn-info btn-sm"><i class="fa fa-share"></i>Chọn</div>
                                                    <div id ="btnXoaVideo" class=" btn btn-info btn-sm "><i class="fa fa-share"></i>Xóa</div>
                                                </div>

                                            </div>

                                        </div>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Mô tả	</label>
                                        <textarea class="form-control" tabindex="5" rows="3" id="Desscription" name="Desscription"> <%=objItemET.Desscription %> </textarea>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                        </div>
                        <!-- /.box-footer -->

                    </div>
                </div>
            </div>
        </div>

    </form>
</body>
</html>


<script type="text/javascript">
    $(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-back").click(function (event) {
            getPage("/UserControls/VideoList/viewVideoList.aspx?action=view");
            return false;
        });
        $.validate({
            modules: 'security',
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/VideoList/aVideoList.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/VideoList/viewVideoList.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });

        $(".select2").select2();

        mybindingData();

       
        $('.cboLanguage').on('select2:select', function () {
            $.post("/UserControls/Service/getVideoCategoryByNgonNgu.ashx", { "NgonNgu": $(this).val() }, function (data) {
                $("#cboVideoCategoryID").html(data);
                $("#cboVideoCategoryID").trigger("chosen:updated");
            });
        });
        $('#btnChonAnh').on('click', function (e) {
            e.preventDefault();
            var top = window.screenTop + 50;
            var left = window.screenLeft + 50;
            window.open('/FileBrowser/FileBrowser.aspx?type=images&caller=opener&fn=newWinFn&langCode=en', 'fileBrowser', 'top=' + top + ',left=' + left + ',menubar=0,scrollbars=0,toolbar=0,height=550,width=700');
        });
        $('#btnXoaAnh').on('click', function (e) {
            $("#pic1").attr("src", "/UserControls/images/thumbnail.jpg");
            $('#newWinField').val("");
        });


        $('#btnChonVideo').on('click', function (e) {
            e.preventDefault();
            var top = window.screenTop + 50;
            var left = window.screenLeft + 50;
            window.open('/FileBrowser/FileBrowser.aspx?type=media&caller=opener&fn=newWinFnVideo&langCode=en', 'fileBrowser', 'top=' + top + ',left=' + left + ',menubar=0,scrollbars=0,toolbar=0,height=550,width=700');
        });
        $('#btnXoaVideo').on('click', function (e) {
            $('#VideoURL').val("");
        });

    })
    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
    function newWinFnVideo(fileurl) {
        $('#VideoURL').val(fileurl);
    }
    function formatState(state) {
        if (!state.id) { return state.text; }
        var $state = $(
          '<span><img src="' + state.element.getAttribute('coquocgia') + '" class="img-flag" /> ' + state.text + '</span>'
        );
        return $state;
    };
    function mybindingData() {
        <%--$("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");--%>
        if ("<%=action%>" == "edit") {
            newWinFn("<%=objItemET.ImageURL%>")
            $("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");
            $("#cboVideoCategoryID").select2("val", "<%=objItemET.VideoCategoryID%>");
        }

    }
</script>

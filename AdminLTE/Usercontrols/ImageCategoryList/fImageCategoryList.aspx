<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fImageCategoryList.aspx.cs" Inherits="AdminLTE.Usercontrols.ImageCategoryList.fImageCategoryList" %>


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
                        <button class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                        <button type="submit" id="btn-Update" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></button>
                    </div>
                </div>
            </div>

        </div>
        <div class="content ">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-info">
                        <div class="box-header with-border">
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->
                        <asp:HiddenField ID="hidAction" runat="server" Value="add" />
                        <asp:HiddenField ID="hidID" runat="server" />
                        <input type="hidden" name="ImageCategoryID" value="<%=objItemET.ImageCategoryID %>">
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
                                    <div class="form-group">
                                        <label>Mã </label>
                                        <input type="text" class="form-control" name="Code" tabindex="3" placeholder="Mã chuyên mục" data-validation="required" value="<%=objItemET.Code %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Chuyên mục cha </label>
                                        <select class="form-control select2" style="width: 100%" id="cboParentImageCategoryID" tabindex="6" name="ParentImageCategoryID">
                                            <option value="">-- Tất cả ---</option>
                                            <asp:Repeater ID="rptParentCategoryID" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("ImageCategoryID") %>"><%#Eval("IndentedTitle") %></option>
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
                                        <input type="text" class="form-control" name="Title" tabindex="4" placeholder="Tiêu đề" data-validation="required" value="<%=objItemET.Title %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên tiếng anh</label>
                                        <input type="text" class="form-control" name="Note" tabindex="4" placeholder="Tiêu đề" value="<%=objItemET.Note %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label>Ảnh hiển thị</label>
                                            <input type="hidden" id="newWinField" class="form-control" name="ImageURL" hidden="hidden" value="<%=objItemET.ImageURL %>">
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
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Tiêu đề ảnh hiển thị</label>
                                                <input type="text" class="form-control" name="ImageTitle" tabindex="4" placeholder="Tiêu đề" value="<%=objItemET.ImageTitle %>">
                                            </div>
                                        </div>
                                          </div>
                                          <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Số thứ tự hiển thị	</label>
                                                <input type="text" class="form-control" name="Ordinal" tabindex="7" placeholder="Số thứ tự hiển thị" value="<%=objItemET.Ordinal %>">
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                           
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Mô tả	</label>
                                        <textarea class="form-control" tabindex="5" rows="3" id="Description" name="Description"> <%=objItemET.Description %> </textarea>
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
            getPage("/UserControls/ImageCategoryList/viewImageCategoryList.aspx?action=view");
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
                var urlPostAction = '/UserControls/ImageCategoryList/aImageCategoryList.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/ImageCategoryList/viewImageCategoryList.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });

        $(".select2").select2();
        mybindingData();
       
     
        $('.cboLanguage').on('select2:select', function () {
            $.post("/UserControls/Service/getImageCategoryByNgonNgu.ashx", { "NgonNgu": $(this).val() }, function (data) {
                $("#cboParentImageCategoryID").html(data);
                $("#cboParentImageCategoryID").trigger("chosen:updated");
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

    })

    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
    function mybindingData() {
        <%--$("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");--%>
        if ("<%=action%>" == "edit") {
            newWinFn("<%=objItemET.ImageURL%>");
            $("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");
            $("#cboParentImageCategoryID").select2("val", "<%=objItemET.ParentImageCategoryID%>");
        }

    }
</script>

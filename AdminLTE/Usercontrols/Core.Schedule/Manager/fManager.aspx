<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fManager.aspx.cs" Inherits="AdminLTE.Usercontrols.Manager.fManager" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">lãnh đạo</strong>
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
                        <input type="hidden" name="NgonNgu" value="<%=Pvn.Utils.Constants.Language.VIETNAMESE %>">
                        <input type="hidden" name="ManagerID" value="<%=objItemET.ManagerID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">

                                <div class="col-md-9">
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Mã lãnh đạo</label>
                                                <input type="text" class="form-control" name="Code" tabindex="1" value="<%=objItemET.Code %>">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Tên lãnh đạo</label>
                                                <input type="text" class="form-control" name="Name" tabindex="1" placeholder="Tên" data-validation="required" value="<%=objItemET.Name %>">
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Tên viết tắt</label>
                                                <input type="text" class="form-control" name="ShortName" tabindex="1" value="<%=objItemET.ShortName %>">
                                            </div>
                                        </div>
                                    </div>

                                </div>

                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Ảnh</label>
                                        <input type="hidden" id="newWinField" class="form-control" name="IconPath" hidden="hidden" placeholder="Ảnh hiển thị" value="">
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

                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Loại Lãnh đạo</label>
                                        <asp:CheckBox CssClass="form-control" runat="server" ID="chkHDTV" Checked="true" Text="Hội đồng thành viên" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Chức vụ</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtTitleHDTV"></asp:TextBox>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Thứ tự</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtHDTVOrdinal"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Loại Lãnh đạo</label>
                                        <asp:CheckBox CssClass="form-control" runat="server" ID="chkTGD" Checked="true" Text="Ban tổng giám đốc" />
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Chức vụ</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtTitleTGD"></asp:TextBox>

                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Thứ tự</label>
                                        <asp:TextBox CssClass="form-control" runat="server" ID="txtTGDOrdinal"></asp:TextBox>

                                    </div>
                                </div>
                            </div>
                            <%-- <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>ImageURL</label>
                                        <input type="text" class="form-control" name="IconPath" tabindex="1" value="<%=objItemET.IconPath %>">
                                    </div>
                                </div>
                            </div>--%>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Thông tin chi tiết</label>
                                        <textarea cols="80" id="editor" name="Information" tabindex="15" rows="10"><%=objItemET.Information %></textarea>
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
        CKEDITOR.replace('editor');
        $(".btn-back").click(function (event) {
            getPage("/UserControls/Core.Schedule/Manager/viewManager.aspx?action=view");
            return false;
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
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                var editorText = CKEDITOR.instances.editor.getData();
                $('#editor').val(editorText);
                var urlPostAction = '/UserControls/Core.Schedule/Manager/aManager.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Core.Schedule/Manager/viewManager.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        if ("<%=action%>" == "edit") {
            mybindingData();
        }

    })
    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
    function mybindingData() {
        newWinFn("<%=objItemET.IconPath %>");
    }

</script>

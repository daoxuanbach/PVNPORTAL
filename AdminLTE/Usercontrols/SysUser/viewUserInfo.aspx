<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewUserInfo.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUser.viewUserInfo" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">NGƯỜI DÙNG HỆ THỐNG</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                      <%--  <div class="btn-refresh btn btn-info btn-sm pull-right"><i class="fa fa-refresh" aria-hidden="true"></i>Đổi mật khẩu</div>--%>
                        <button type="submit" tabindex="10" id="btn-Update" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></button>
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
                        <asp:HiddenField ID="hidAction" runat="server" Value="userupd" />
                        <input type="hidden" value="<%=USERID %>" name="UserID" />
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Thuộc đơn vị</label>
                                        <label class="form-control select2"><%=UNITNAME %></label>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trạng thái sử dụng</label>
                                        <label class="form-control select2"><%=objItemET.UsedState==1?"Đang sử dụng": "Không hoạt động" %></label>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Tên hiển thị</label>
                                        <input type="text" class="form-control" name="LoginName" tabindex="3" placeholder="Tên hiển thị" data-validation="required" value="<%=objItemET.LoginName %>">
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Tên đăng nhập</label>
                                        <input type="text" class="form-control" readonly="readonly" name="UserName"  tabindex="4" placeholder="Tên đăng nhập" data-validation="required" value="<%=objItemET.UserName %>">
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <input type="hidden" id="listValueAnhAttach" name="listValueAnhAttach" value="" />
                                              <div class="content-avatar">
                                                    <div id="listImageAttach">
                                                        <img id="pic1" src="<%=FileServer %>">
                                                    </div>
                                                </div>
                                             <div id="btnChonAnh"></div>
                                        </div>


                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label>Điện thoại</label>
                                            <input type="text" class="form-control" name="Tel" tabindex="7" placeholder="Điện thoại" value="<%=objItemET.Tel %>">
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <input type="text" class="form-control" name="Email" tabindex="8" placeholder="Email" value="<%=objItemET.Email %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Ghi chú</label>
                                        <input type="text" class="form-control" name="Note" tabindex="9" placeholder="Ghi chú" value="<%=objItemET.Note %>">
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
        $(".btn-refresh").click(function (event) {
            //getPage("/UserControls/SysUser/pUserSP.aspx");
            getPage("/UserControls/SysUser/ResetPassword.aspx?ItemID=<%=USERID%>");
        });
        $.validate({
            modules: 'security',
            form: '#frm',
            onError: function ($form) {
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/SysUser/aSysUser.ashx?action=userupd';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysUser/viewUserInfo.aspx");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        createUploadAnhDaiDien("btnChonAnh", "Ảnh");
        if ("<%=checkFile%>" == "True") {
             setHiddenAnhDaiDien(<%=FileServerJson%>);
        }
    })
    function setHiddenAnhDaiDien(data) {
        var valueFile = '[';
        valueFile += '{"FileServer": "' + data.FileServer + '"\,';
        valueFile += '"FileName": "' + data.FileName + '"\}';
        valueFile += "]";
        $("#listValueAnhAttach").val(valueFile);
    }
</script>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ResetPassword.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUser.ResetPassword" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Đổi mật khẩu</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <div class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</div>
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
                        <asp:HiddenField ID="hidAction" runat="server" Value="uppPass" />
                        <input type="hidden" name="UserID" value="<%=ItemID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Mật khẩu</label>
                                        <input type="password" tabindex="5" class="form-control" name="Checksum" data-validation="length" data-validation-length="min6">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Xác nhập lại mật khẩu</label>
                                        <input type="password" class="form-control" name="Checksum2" tabindex="6" placeholder="Nhập lại mật khẩu" data-validation-confirm="Checksum" data-validation="confirmation">
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
            location.reload();
        });
        $.validate({
            modules: 'security',
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/SysUser/aSysUser.ashx';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        alert("Cập nhật mật khẩu thành công")
                        location.reload();
                    }
                });
                return false;
            }
        });
    })
</script>

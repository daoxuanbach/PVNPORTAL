<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fSysUser.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUser.fSysUser" %>
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
                        <button class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
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
                        <asp:HiddenField ID="hidAction" runat="server" Value="add" />
                        <asp:HiddenField ID="hidID" runat="server" />
                        <input type="hidden" name="UserID" value="<%=objItemET.UserID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Thuộc đơn vị</label>
                                        <select class="form-control select2" id="cbSysUnit" tabindex="1" name="UnitID">
                                            <asp:Repeater ID="rptSysUnit" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6" style="display:none">
                                    <div class="form-group">
                                        <label>Trạng thái sử dụng</label>
                                        <select class="form-control select2 " id="cbUsedState" style="width: 100%;" name="UsedState" tabindex="2">
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
                                        <label>Tên hiển thị</label>
                                        <input  type="text" class="form-control" name="UserName" tabindex="3" placeholder="Tên đăng nhập" data-validation="required" value="<%=objItemET.UserName %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên đăng nhập</label>
                                        <input type="text"  readonly="readonly"  class="form-control" name="LoginName" tabindex="4" placeholder="Tên hiển thị" data-validation="required" value="<%=objItemET.LoginName %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row" id="editPass">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Mật khẩu</label>
                                        <input type="password" class="form-control" tabindex="5" name="Checksum" data-validation="length" data-validation-length="min6">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Xác nhập lại mật khẩu</label>
                                        <input type="password" class="form-control" name="Checksum2" tabindex="6" placeholder="Nhập lại mật khẩu" data-validation-confirm="Checksum" data-validation="confirmation">

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
        $(".btn-back").click(function (event) {
            getPage("/UserControls/SysUser/viewSysUser.aspx?action=view");
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
                var urlPostAction = '/UserControls/SysUser/aSysUser.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysUser/viewSysUser.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });

        $(".select2").select2();
        mybindingData();
    })
    function mybindingData() {
        $("#cbUsedState").select2("val", "<%=objItemET.UsedState%>");
        if ("<%=action%>" == "edit") {
            $("#editPass").hide();
            $("#cbSysUnit").select2("val", "<%=objItemET.UnitID%>");
        }

    }
</script>

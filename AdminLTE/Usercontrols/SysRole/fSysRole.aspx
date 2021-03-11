<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fSysRole.aspx.cs" Inherits="AdminLTE.Usercontrols.SysRole.fSysRole" %>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">CHỨC NĂNG TRÊN PAGE</strong>
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
                        <input type="hidden" name="RoleID" value="<%=objSysRoleET.RoleID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Page</label>
                                        <select class="form-control select2" data-validation="required" id="cbFuntion" tabindex="1" name="FunctionID">
                                            <option value="">-- Thuộc Page ---</option>
                                            <asp:Repeater ID="rptFuntion" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("FunctionID") %>"><%#Eval("FullName") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <label>Kiểu chức năng</label>
                                    <select class="form-control select2 " id="cbQuyTrinh" style="width: 100%;" name="QuyTrinh" tabindex="1">
                                        <asp:Repeater ID="rptQuyTrinh" runat="server">
                                            <ItemTemplate>
                                                <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                    </select>
                                </div>
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Thứ tự hiển thị</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.ThuTu %>" name="ThuTu" placeholder="Thứ tự ">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên hiển thị</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.Name %>" name="Name" data-validation="required" placeholder="Tên hiển thị">
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên chức năng</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.Title %>" name="Title" data-validation="required" placeholder="Tên chức năng">
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Dữ liệu gửi đến</label>
                                        <input type="number" class="form-control" value="<%=objSysRoleET.TrangThaiHienThi %>" name="TrangThaiHienThi" placeholder="Tên hiển thị">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên trạng thái hiển thị</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.TextTrangThaiHienThi %>" name="TextTrangThaiHienThi" placeholder="Tên hiển thị">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Dữ liệu gửi đi</label>
                                        <input type="number" class="form-control" value="<%=objSysRoleET.TrangThaiGuiDi %>" name="TrangThaiGuiDi" placeholder="Trang thái chuyển đi">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên hiển thị gửi đi</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.TextTrangThaiGuiDi %>" name="TextTrangThaiGuiDi" placeholder="Tên trạng thái chuyển">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Dữ liệu bị trả lại</label>
                                        <input type="number" class="form-control" value="<%=objSysRoleET.TrangThaiTraLai %>" name="TrangThaiTraLai" placeholder="Trang thái chuyển đi">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên hiển thị bị trả lại</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.TextTrangThaiTraLai %>" name="TextTrangThaiTraLai" placeholder="Tên trạng thái chuyển">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Class hiển thị</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.ClassView %>" name="ClassView" data-validation="required" placeholder="Class View">
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Icon hiển thị</label>
                                        <input type="text" class="form-control" value="<%=objSysRoleET.IconView %>" name="IconView" data-validation="required" placeholder="Icon View">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Vị trí hiển thị</label>
                                        <select class="form-control select2" data-validation="required" id="cbViTri" tabindex="1" name="ViTri">
                                            <asp:Repeater ID="rptPosition" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Trạng thái</label>
                                        <select class="form-control select2" data-validation="required" id="cbTrangThai" tabindex="1" name="TrangThai">
                                            <option value="1">Hiển thị </option>
                                            <option value="0">Không hiển thị</option>
                                        </select>
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
            getPage("/UserControls/SysRole/viewSysRole.aspx?action=view");
            return false;
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/SysRole/aSysRole.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysRole/viewSysRole.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        mybindingData();
    })
    function mybindingData() {
        //if ("<%=action%>" == "edit") {
        $("#cbFuntion").select2("val", "<%=objSysRoleET.FunctionID%>");
        $("#cbViTri").select2("val", "<%=objSysRoleET.ViTri%>");
        $("#cbQuyTrinh").select2("val", "<%=objSysRoleET.QuyTrinh%>");

        $("#cbTrangThai").select2("val", "<%=objSysRoleET.TrangThai%>");
    }
</script>

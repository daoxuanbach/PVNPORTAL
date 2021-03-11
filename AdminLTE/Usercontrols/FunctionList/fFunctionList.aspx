<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fFunctionList.aspx.cs" Inherits="AdminLTE.Usercontrols.FunctionList.fFunctionList" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">PAGE HỆ THỐNG</strong>
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
                        <input type="hidden" name="FunctionID" value="<%=objItemET.FunctionID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ngôn ngữ</label>
                                        <select class="form-control select2" id="cbLanguage" tabindex="1" name="Language">
                                            <asp:Repeater ID="rptNgonNgu" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("MaNgonNgu") %>"><%#Eval("TenNgonNgu") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trạng thái sử dụng</label>
                                        <select class="form-control select2 select2-hidden-accessible" id="cbUsedState" style="width: 100%;" name="UsedState" tabindex="2">
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
                                        <label>Tên chức năng</label>
                                        <input type="text" class="form-control" name="Name" tabindex="3" placeholder="Tên chức năng" data-validation="required" value="<%=objItemET.Name %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Thuộc nhóm chức năng</label>
                                        <select class="form-control select2 select2-hidden-accessible" id="cbParentFunctionID" name="ParentFunctionID" style="width: 100%;" tabindex="4" aria-hidden="true">
                                               <option value="">--Thuộc nhóm  --</option>
                                            <asp:Repeater ID="rptNhomChucNang" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("FunctionID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Số thứ tự</label>
                                        <input type="text" class="form-control" name="Ordinal" tabindex="5" placeholder="Số thứ tự hiển thị" data-validation="required" value="<%=objItemET.Ordinal %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Icon class</label>
                                        <input type="text" class="form-control" name="ImageFileName" placeholder="Font-Awesome" tabindex="6" value="<%=objItemET.ImageFileName %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Đường dẫn</label>
                                        <select class="form-control select2 select2-hidden-accessible" id="cbPageID" style="width: 100%;" tabindex="7" name="PageID" aria-hidden="true">
                                            <option value="">--Chọn đường dẫn --</option>
                                            <asp:Repeater ID="rptSysPage" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("PageID") %>"><%#Eval("URL") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ghi chú</label>
                                        <input type="text" class="form-control" name="Infor" placeholder="Ghi chú" tabindex="8" value="<%=objItemET.Infor %>">
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
            getPage("/UserControls/FunctionList/viewFunctionList.aspx?action=view");
            return false;
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/FunctionList/aFunctionList.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/FunctionList/viewFunctionList.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        mybindingData();
    })
    function mybindingData() {
        $("#cbLanguage").select2("val", "<%=objItemET.Language%>");
        $("#cbUsedState").select2("val", "<%=objItemET.UsedState%>");
        $("#cbParentFunctionID").select2("val", "<%=objItemET.ParentFunctionID%>");
        $("#cbPageID").select2("val", "<%=objItemET.PageID%>");
    }
</script>

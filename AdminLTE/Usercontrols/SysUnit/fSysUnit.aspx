<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fSysUnit.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUnit.fSysUnit" %>


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
                        <input type="hidden" name="UnitID" value="<%=objItemET.UnitID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ngôn ngữ</label>
                                        <select class="form-control select2 cboLanguage" id="cbLanguage" tabindex="1" name="Language">
                                            <asp:Repeater ID="rptNgonNgu" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Nhóm đơn vị</label>
                                        <select class="form-control select2" id="cbSysGroupUnit" tabindex="1" name="GroupUnitID">
                                             <option value="00000000-0000-0000-0000-000000000000"> -- Thuộc nhóm đơn vị ---</option>
                                                <asp:Repeater ID="rptGroupUnit" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("GroupUnitID") %>"><%#Eval("Name") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên đơn vị</label>
                                        <input type="text" class="form-control" name="Name" tabindex="3" placeholder="Tên đơn vị" data-validation="required" value="<%=objItemET.Name %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Mã đơn vị</label>
                                        <input type="text" class="form-control" name="Code" tabindex="3" placeholder="Mã đơn vị" value="<%=objItemET.Code %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Thuộc đơn vị</label>
                                        <select class="form-control select2" id="cbParentUnitID" tabindex="1" name="ParentUnitID">
                                            <option value="00000000-0000-0000-0000-000000000000"> -- Thuộc đơn vị ---</option>
                                            <asp:Repeater ID="rptParentUnit" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Địa chỉ</label>
                                        <input type="text" class="form-control" name="Address" tabindex="3" placeholder="Địa chỉ" value="<%=objItemET.Address %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Điện thoại</label>
                                        <input type="text" class="form-control" name="Tel" tabindex="5" placeholder="Tel" value="<%=objItemET.Tel %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Fax</label>
                                        <input type="text" class="form-control" name="Fax" tabindex="8" value="<%=objItemET.Fax %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Email</label>
                                        <input type="text" class="form-control" name="Email" tabindex="5" placeholder="Tel" value="<%=objItemET.Email %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Website</label>
                                        <input type="text" class="form-control" name="Website" tabindex="8" value="<%=objItemET.Website %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Ghi chú</label>
                                        <input type="text" class="form-control" name="Note" tabindex="5" placeholder="Tel" value="<%=objItemET.Note %>">
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
            getPage("/UserControls/SysUnit/viewSysUnit.aspx?action=view");
            return false;
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/SysUnit/aSysUnit.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysUnit/viewSysUnit.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        $(".cboLanguage").select2({
            templateResult: formatState,
            templateSelection: formatState
        });
        mybindingData();
    })
    function mybindingData() {
        <%--alert("<%=objItemET.ParentUnitID%>");
        alert("<%=objItemET.UnitID%>");--%>
        $("#cbLanguage").select2("val", "<%=objItemET.Language%>");
        $("#cbSysGroupUnit").select2("val", "<%=objItemET.GroupUnitID%>");
        $("#cbParentUnitID").select2("val", "<%=objItemET.ParentUnitID%>");
    }

</script>

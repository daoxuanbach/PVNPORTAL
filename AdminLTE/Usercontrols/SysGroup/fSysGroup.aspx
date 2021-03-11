<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fSysGroup.aspx.cs" Inherits="AdminLTE.Usercontrols.SysGroup.fSysGroup" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">NHÓM NGƯỜI DÙNG HỆ THỐNG</strong>
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
                        <input type="hidden" name="GroupID" value="<%=objItemET.GroupID %>">
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
                                <div class="col-md-3">
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
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Quyền của nhóm	</label>
                                        <select class="form-control select2 " id="cbRolePermission" style="width: 100%;" name="RolePermission" tabindex="2">
                                          <asp:Repeater ID="rptRolePermission" runat="server">
                                            <ItemTemplate>
                                                <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                            </ItemTemplate>
                                        </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Mã nhóm</label>
                                        <input type="text" class="form-control" name="Code" tabindex="3" placeholder="Mã nhóm" data-validation="required" value="<%=objItemET.Code %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên nhóm</label>
                                        <input type="text" class="form-control" name="Name" tabindex="3" placeholder="Tên nhóm" data-validation="required" value="<%=objItemET.Name %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                
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
            getPage("/UserControls/SysGroup/viewSysGroup.aspx?action=view");
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
                var urlPostAction = '/UserControls/SysGroup/aSysGroup.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysGroup/viewSysGroup.aspx?action=view");
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
            $("#cbSysUnit").select2("val", "<%=objItemET.UnitID%>");
            $("#cbRolePermission").select2("val", "<%=objItemET.RolePermission%>");
        }

    }
</script>

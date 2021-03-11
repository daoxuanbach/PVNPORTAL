<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fSysGroupUser.aspx.cs" Inherits="AdminLTE.Usercontrols.SysGroupUser.fSysGroupUser" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frmUserGROUP">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Người dùng thuộc nhóm</strong>
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
                        <div class="box-body">
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Mã, Tên nhóm</label>
                                        <select class="form-control select2" id="fcbGroupID" style="width: 100%;" tabindex="1" name="GroupID">
                                            <asp:Repeater ID="rptGroup" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("GroupID") %>"><%#Eval("Name") %> || <%#Eval("UnitName") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>

                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Thêm người dùng vào nhóm</label>
                                        <select class="form-control select2 " id="cbSysUser" style="width: 100%;" name="UserID" tabindex="2">
                                            <asp:Repeater ID="rptSysUser" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("UserID") %>"><%#Eval("UserName") %> (<%#Eval("LoginName") %>)</option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>

                            </div>
                            <div class="row" style="height: 120px;">
                                <div class="col-md-12">
                                    <%--<div class="form-inline text-right">
                                        <div class="form-group">
                                            <button tabindex="3" type="submit" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></button>
                                        </div>
                                    </div>--%>
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
    $(document).ready(function () {
        $(".btn-back").click(function (event) {
            getPage("/UserControls/SysGroupUser/viewSysGroupUser.aspx?action=view&GroupID=<%=GroupID%>");
            return false;
        });
        $("#fcbGroupID").select2();
        $("#cbSysUser").select2();
        $.validate({
            form: '#frmUserGROUP',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/SysGroupUser/aSysGroupUser.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysGroupUser/viewSysGroupUser.aspx?action=view&GroupID=<%=GroupID%>");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $("#fcbGroupID").select2("val", "<%=GroupID%>");
    })

</script>

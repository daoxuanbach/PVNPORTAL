<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSysGroupUser.aspx.cs" Inherits="AdminLTE.Usercontrols.SysGroupUser.viewSysGroupUser" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            var cbGroupID = $('#cbGroupID').val();
            getPage("/UserControls/SysGroupUser/fSysGroupUser.aspx?action=add&GroupID=" + cbGroupID);
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysGroupUser/fSysGroupUser.aspx?action=edit&ItemID=" + ItemID);
        });
        $("input").keypress(function (event) {
            if (event.which == 13) {
                fnSearch();
                event.preventDefault();
            }
        });
        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            $("#pageId").val(ItemID);
            fnSearch();
        });
        $('#checkAll').click(function () {
            $(".table input:checkbox").prop('checked', $(this).prop("checked"));
        });
        $('.delete').click(function () {
            BootstrapDialogconfirm($(this).closest("td").attr('data-id'));
        });

        $(".btn-delete").click(function () {
            var arrID = GetListIDChecked();
            if (arrID != '') {
                BootstrapDialogconfirm(arrID);
            }
            else {
                BootstrapDialogalert("Chọn bản ghi cần xóa");
            }
        });
        $(".select2").select2();
        $("#cbGroupID").select2("val", "<%=GroupID%>");

        
        $('#cbGroupID').on('select2:select', function (e) {
            fnSearch();
            return;
        });
        $("#btnSearch").click(function () {
            fnSearch();
            return;
        });
    })

    function fndelete(dataid) {

        $.post(encodeURI("/UserControls/SysGroupUser/aSysGroupUser.ashx"), { "GroupID": dataid, "hidAction": "del" },
            function (data) {
                if (data.Error) {
                    BootstrapDialogalert(data.Message);
                }
                else {
                    displayOverlay(data.Message);
                    getPage("/UserControls/SysGroupUser/viewSysGroupUser.aspx?action=view");
                }
            });
        return false;
    };
    function fnSearch() {
        var CurPage = $('#pageId').val();
        var cbUsedState = $('#cbUsedState').val(),
            cbGroupID = $('#cbGroupID').val();
        postData(1, "/UserControls/SysGroupUser/viewSysGroupUser.aspx?GroupID=" + cbGroupID + "&p=" + CurPage);
    }


</script>
<head runat="server">
    <title></title>
</head>
<body>
    <!-- Content Header (Page header) -->
    <form runat="server" id="frm">
        <input type="hidden" name="p" id="pageId" value="1">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">DANH SÁCH NHÓM NGƯỜI DÙNG -  NGƯỜI DÙNG</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
                <%--   <div class="form-inline text-right">
                    <div class="form-group">
                        <div class="btn-add btn btn-info btn-sm"><i class="fa fa-plus"></i><strong>Thêm mới</strong></div>
                      
                    </div>

                </div>--%>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box">
                        <div class="box-body">
                            <div class="">
                                <div class="row">
                                    <div class="col-md-5">
                                        <div class="form-group">
                                            <select class="form-control select2" id="cbGroupID" tabindex="1" name="GroupID">
                                                <asp:Repeater ID="rptGroup" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("GroupID") %>"><%#Eval("Name") %> || <%#Eval("UnitName") %></option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="col-md-1 img-search">
                                        <div id="btnSearch" class="btn btn-info btn-flat" >Xem</div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12">
                                    <table class="table table-bordered table-striped table-hover">
                                        <thead>
                                            <tr class="table-header">
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-11">Người dùng thuộc nhóm</th>
                                                <th class="align-center">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("UserName") %> (<%#Eval("LoginName") %>)</td>

                                                    <td class="actions" data-id="<%#Eval("Group_UserID") %>">
                                                        <%-- <a class="delete" href="javascript:void(0)" data-id="<%#Eval("Group_UserID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a>--%>
                                                        <%=ucChucNang.ChucNang %>
                                                    </td>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <div class="dataTables_info" id="example1_info" role="status" aria-live="polite">Tổng <%=totalRows %> bản ghi</div>
                                </div>
                                <div class="col-sm-6">
                                    <div class="dataTables_paginate paging_simple_numbers" id="example1_paginate">
                                        <asp:Literal ID="litMsg" runat="server"></asp:Literal>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                    <!-- /.box-body -->
                </div>
                <!-- /.box -->
            </div>
            <!-- /.col -->
        </div>
        <!-- /.row -->
        <!-- /.content -->

    </form>
</body>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSysUser.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUser.viewSysUser" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>
<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/SysUser/pUserSP.aspx");
            //getPage("/UserControls/SysUser/fSysUser.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysUser/fSysUser.aspx?action=edit&ItemID=" + ItemID);
        });

        $('.refreshPass').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysUser/ResetPassword.aspx?ItemID=" + ItemID);
        });
        $('.RoleUser').click(function () {
            var UserID = $(this).closest("td").attr('data-id'),
                UserName = $(this).closest("td").attr('data-name');
            getPage("/UserControls/SysUser/fSysUserFunction.aspx?UserID=" + UserID + "&UserName=" + UserName);
        });
        $('.chucnang').click(function () {
            var UserID = $(this).closest("td").attr('data-id'),
                UserName = $(this).closest("td").attr('data-name');
            getPage("/UserControls/SysUser/fPhanQuyen.aspx?UserID=" + UserID + "&UserName=" + UserName);
        });

        $("input").keypress(function (event) {
            if (event.which == 13) {
                fnSearch();
                event.preventDefault();
            }
        });
        $("#btnSearch").click(function () {
            fnSearch();
        });
        //$('#checkAll').click(function () {
        //    $(".table input:checkbox").prop('checked', $(this).prop("checked"));
        //});
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

        $("#cbUsedState").select2("val", "<%=UsedState%>");
        $("#cbUnitID").select2("val", "<%=UnitID%>");
        $('input[type="checkbox"].flat-red').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });


        $('.CheckAll')
            .on('ifChecked', function (event) {
                $('.flat-red').iCheck('check');
            })
            .on('ifUnchecked', function () {
                $('.flat-red').iCheck('uncheck');
            });

        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            $("#pageId").val(ItemID);
            fnSearch();
        });
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/SysUser/aSysUser.ashx"), { "PageID": dataid, "hidAction": "del" },
            function (data) {
                if (data.Error) {
                    BootstrapDialogalert(data.Message);
                }
                else {
                    displayOverlay(data.Message);
                    getPage("/UserControls/SysUser/viewSysUser.aspx?action=view");
                }
            });
        return false;
    };
    function fnSearch() {
        var cbUsedState = $('#cbUsedState').val(),
            cbUnitID = $('#cbUnitID').val();
        postData(1, "/UserControls/SysUser/viewSysUser.aspx?txtSearch=" + $('#txtSearch').val() + "&LoginName=" + $('#txtLoginName').val() + "&UnitID=" + cbUnitID + "&UsedState=" + cbUsedState + "&p=" + $('#pageId').val());
    }


</script>
<head runat="server">
    <title></title>
</head>
<body>
    <!-- Content Header (Page header) -->
    <form runat="server" id="frm">
        <input type="hidden" name="p" id="pageId" value="">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">DANH SÁCH NGƯỜI DÙNG</strong>
            </div>
            <div class="col-xs-6 padding-right-0px">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
                <%-- <div class="form-inline text-right">
                    <div class="form-group">
                        <div class="btn-add btn btn-info btn-sm"><i class="fa fa-plus"></i><strong>Thêm mới</strong></div>
                        <div class="btn-delete btn btn-info btn-sm"><i class="fa fa-times"></i><strong>Xóa</strong></div>

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
                            <div class="row">
                                <div class="col-md-11 vcenter">
                                    <div class="row">
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Thuộc đơn vị</label>
                                                <select class="form-control select2" id="cbUnitID" tabindex="1" name="UnitID" style="width: 100%">
                                                    <option value="00000000-0000-0000-0000-000000000000">-- Thuộc đơn vị ---</option>
                                                    <asp:Repeater ID="rpttUnit" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Tên hiển thị	</label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=KeyWord %>">
                                            </div>
                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Tên đăng nhập	</label>
                                                <input id="txtLoginName" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%= loginName %>">
                                            </div>
                                        </div>

                                    </div>
                                    <div class="row">
                                        <div class="col-md-12" style="display: none">
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
                                </div>
                                <div class="col-md-1 vcenter img-search">
                                    <div id="btnSearch" class="imgSearch" type="button"></div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12">
                                    <table class="table table-bordered table-striped table-hover">
                                        <thead>
                                            <tr class="table-header">
                                                <th class="align-center">
                                                    <input class="flat-red CheckAll" id="checkAll" type="checkbox" value=""></th>
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-2">Tên hiển thị</th>
                                                <th class="col-xs-3">Tên đăng nhập</th>
                                                <th class="col-xs-2">Trạng thái sử dụng</th>
                                                <th class="col-xs-3">Thuộc đơn vị</th>
                                                <th class="align-center">Chức năng</th>
                                                <%--   <th class="align-center">Phân quyền Chức năng</th>
                                                <th class="align-center col-xs-1    " scope="col">Cập nhật</th>
                                                <th class="align-center">Xóa</th>--%>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="flat-red checkSingle" type="checkbox" value="<%#Eval("UserID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                     <td><%#Eval("UserName") %></td>
                                                    <td><%#Eval("LoginName") %></td>
                                                    <td><%# Convert.ToInt32(Eval("UsedState"))==1? "Hoạt động": "Không hoạt động" %></td>
                                                    <td><%#Eval("UnitName") %></td>
                                                    <td data-id="<%#Eval("UserID") %>" data-name="<%#Eval("UserName") %>" ><%=ucChucNang.ChucNang%></td>

                                               <%--      <td class=" actions"><a class="RoleUser" href="javascript:void(0)" data-name="<%#Eval("UserName") %>" data-id="<%#Eval("UserID") %>" title="Phân quyền module"><i class="fa fa-plus-square-o (alias)"></i></a></td>
                                                    <td class=" actions"><a class="chucnang" href="javascript:void(0)" data-name="<%#Eval("UserName") %>" data-id="<%#Eval("UserID") %>" title="Phân quyền chức năng"><i class="fa fa-plus-square-o (alias)"></i></a></td>
                                                    <td class=" actions"><a class="edit" href="javascript:void(0)" data-id="<%#Eval("UserID") %>" title="Sửa"><i class="fa fa-edit (alias)"></i></a></td>
                                                    <td class=" actions"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("UserID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
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
        </div>
    </form>
</body>

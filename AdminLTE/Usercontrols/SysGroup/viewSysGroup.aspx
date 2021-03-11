<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSysGroup.aspx.cs" Inherits="AdminLTE.Usercontrols.SysGroup.viewSysGroup" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/SysGroup/fSysGroup.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysGroup/fSysGroup.aspx?action=edit&ItemID=" + ItemID);
        });
        $("input").keypress(function (event) {
            if (event.which == 13) {
                fnSearch();
                event.preventDefault();
            }
        });
        $('.RoleGroup').click(function () {
            var GroupID = $(this).closest("td").attr('data-id'),
            GroupName = $(this).closest("td").attr('data-name');
            getPage("/UserControls/SysGroup/fSysGroupFunction.aspx?GroupID=" + GroupID + "&GroupName=" + GroupName);
        });
        $('.chucnang').click(function () {
            var GroupID = $(this).closest("td").attr('data-id'),
             GroupName = $(this).closest("td").attr('data-name');
            getPage("/UserControls/SysGroup/fPhanQuyenGroup.aspx?GroupID=" + GroupID + "&GroupName=" + GroupName);
        });

        $("#btnSearch").click(function () {
            fnSearch();
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

        $("#cbUsedState").select2("val", "<%=UsedState%>");
        $("#cbUnitID").select2("val", "<%=UnitID%>");
        $('input[type="checkbox"].flat-red').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });

        //$('#checkAll').click(function () {
        //    $(".table input:checkbox").prop('checked', $(this).prop("checked"));
        //});
        $('#checkAll')
             .on('ifChecked', function (event) {
                 $('.flat-red').iCheck('check');
             })
             .on('ifUnchecked', function () {
                 $('.flat-red').iCheck('uncheck');
             });

    })
    $(".select2 ").change(function () {
        fnSearch();
    });
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/SysGroup/aSysGroup.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/SysGroup/viewSysGroup.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        var cbUsedState = $('#cbUsedState').val(),
            cbUnitID = $('#cbUnitID').val();
        postData(1, "/UserControls/SysGroup/viewSysGroup.aspx?txtSearch=" + $('#txtSearch').val() + "&NameGroup=" + $('#NameGroup').val() + "&UnitID=" + cbUnitID + "&UsedState=" + cbUsedState);
    }


</script>
<head runat="server">
    <title></title>
</head>
<body>
    <!-- Content Header (Page header) -->
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">DANH SÁCH NHÓM NGƯỜI DÙNG</strong>
            </div>
            <div class="col-xs-6">
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
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Thuộc đơn vị</label>
                                                <select class="form-control select2" id="cbUnitID" tabindex="1" name="UnitID">
                                                    <option value="00000000-0000-0000-0000-000000000000">-- Thuộc đơn vị ---</option>
                                                    <asp:Repeater ID="rpttUnit" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="col-md-6">
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
                                                <label>Mã nhóm</label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=KeyWord %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Tên nhóm</label>
                                                <input id="NameGroup" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%= NameGroup %>">
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
                                                    <input class="flat-red" id="checkAll" type="checkbox" value=""></th>
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-2 align-center">Mã nhóm</th>
                                                <th class="col-xs-3 align-center">Tên nhóm</th>
                                                <th class="col-xs-2 align-center">Quyền hạn</th>
                                                <th class="col-xs-3 align-center ">Thuộc đơn vị</th>
                                                <th class="align-center">Thao tác</th>

                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="flat-red checkSingle" type="checkbox" value="<%#Eval("GroupID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("Code") %></td>
                                                    <td><%#Eval("Name") %></td>
                                                     <td><%#  Pvn.Utils.EnumHelper.GetDescription(((Pvn.Utils.EnumET.EnumRole)Convert.ToInt32(Eval("RolePermission")))) %></td>
                                                    <td><%#Eval("UnitName") %></td>
                                                      <td data-name="<%#Eval("Name") %>" data-id="<%#Eval("GroupID") %>"><%=ucChucNang.ChucNang %></td>
                                                   <%-- <td class=" actions"><a class="RoleGroup" href="javascript:void(0)" data-name="<%#Eval("Name") %>" data-id="<%#Eval("GroupID") %>" title="Xóa"><i class="fa fa-plus-square-o (alias)"></i></a></td>
                                                     <td class=" actions"><a class="chucnang" href="javascript:void(0)" data-name="<%#Eval("Name") %>"  data-id="<%#Eval("GroupID") %>" title="Xóa"><i class="fa fa-plus-square-o (alias)"></i></a></td>
                                                    <td class=" actions"><a class="edit" href="javascript:void(0)" data-id="<%#Eval("GroupID") %>" title="Xóa"><i class="fa fa-edit (alias)"></i></a></td>
                                                    <td class=" actions"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("GroupID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
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

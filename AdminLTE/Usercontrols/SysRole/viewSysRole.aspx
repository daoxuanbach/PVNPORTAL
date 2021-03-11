<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSysRole.aspx.cs" Inherits="AdminLTE.Usercontrols.SysRole.viewSysRole" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/SysRole/fSysRole.aspx?action=add");
        });
        $('.edit').click(function () {
            var RoleID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysRole/fSysRole.aspx?action=edit&RoleID=" + RoleID);
        });
        $('.themdungmau').click(function () {
            var RoleID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysRole/fSysRole.aspx?action=addbytem&RoleID=" + RoleID);
        });
        $("input").keypress(function (event) {
            if (event.which == 13) {
                postData(1, "/UserControls/SysRole/viewSysRole.aspx?Search=" + $('#txtSearch').val());
                event.preventDefault();
            }
        });
        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            $("#pageId").val(ItemID);
            fnSearch();
        });

        $("#btnSearch").click(function () {
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
        $("#cbFuntion").select2("val", "<%=FunctionID%>");
    })

    function fnSearch() {
        $.cookie("txtSearch", decodeURIComponent($('#txtSearch').val()), { path: '/' });
        $.cookie("FunctionID", $('#cbFuntion').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/SysRole/viewSysRole.aspx");
    }


    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/SysRole/aSysRole.ashx"), { "RoleID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/SysRole/viewSysRole.aspx?action=view");
              }
          });
        return false;
    };


</script>
<head runat="server">
    <title></title>
</head>
<body>
    <!-- Content Header (Page header) -->
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">DANH MỤC CHỨC NĂNG TRÊN PAGE</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
                <%--<div class="form-inline text-right">
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
                                        <div class="col-md-5">
                                            <div class="form-group">
                                                <label>Tên</label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Tìm theo Tên" aria-controls="example1" value="<%=KeyWord %>">
                                            </div>
                                        </div>
                                        <div class="col-md-7">
                                            <div class="form-group">
                                                <label>Thuộc Page</label>
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
                                    </div>

                                </div>
                                <div class="col-md-1 vcenter img-search">
                                    <div id="btnSearch" class="imgSearch"></div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-sm-12">
                                    <table class="table table-bordered table-striped table-hover">
                                        <thead>
                                            <tr class="table-header">
                                                <th class="align-center">
                                                    <input id="checkAll" type="checkbox" value=""></th>
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-2">Tên hiển thị </th>
                                                 <th class="col-xs-2">Tên chức năng</th>
                                                 <th class="col-xs-2">Module</th>
                                                 <th class="col-xs-2">Kiểu</th>
                                                <th class="col-xs-1">HT. Trạng thái</th>
                                                <th class="col-xs-1">Chuyển trạng thái</th>

                                                 <th class="col-xs-2">Vị trí</th>
                                                 <th class="col-xs-2">Thư tự</th>

                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="checkSingle" type="checkbox" value="<%#Eval("RoleID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("Name") %></td>
                                                    <td><%#Eval("Title") %></td>
                                                    <td><%#Eval("FunctionName") %></td>
                                                      <td><%#  Pvn.Utils.EnumHelper.GetDescription(((Pvn.Utils.EnumET.QuyTrinh)Convert.ToInt16(Eval("QuyTrinh")))) %></td>
                                                    <td><%#Eval("TrangThaiHienThi") %></td>
                                                    <td><%#Eval("TrangThaiGuiDi") %></td>
                                                      <td><%#  Pvn.Utils.EnumHelper.GetDescription(((Pvn.Utils.EnumET.PositionView)Convert.ToInt16(Eval("ViTri")))) %></td>
                                                    <td><%#Eval("ThuTu") %></td>

                                                    <td class="actions"  data-id="<%#Eval("RoleID") %>">
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

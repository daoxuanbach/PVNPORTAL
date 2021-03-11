<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewLoaiVanBan.aspx.cs" Inherits="AdminLTE.Usercontrols.LoaiVanBan.viewLoaiVanBan" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>
<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/CoreDoc/LoaiVanBan/fLoaiVanBan.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/CoreDoc/LoaiVanBan/fLoaiVanBan.aspx?action=edit&ItemID=" + ItemID);
        });
        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            $("#pageId").val(ItemID);
            fnSearch();
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
        $('#divFromDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#divToDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $(".select2").select2();
        $("#cboUsedState").select2("val", "<%=UsedState%>");
      $("#cboLoaiVanBan").select2("val", "<%=LoaiVanBanID%>");
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/CoreDoc/LoaiVanBan/aLoaiVanBan.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/CoreDoc/LoaiVanBan/viewLoaiVanBan.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        $.cookie("txtMa", $('#txtMa').val(), { path: '/' });
        $.cookie("UsedState", $('#cboUsedState').val(), { path: '/' });
        $.cookie("txtTen", $('#txtTen').val(), { path: '/' });
        $.cookie("FromDate", $('#FromDate').val(), { path: '/' });
        $.cookie("LoaiVanBanID", $('#cboLoaiVanBan').val(), { path: '/' });
        postData(1, "/UserControls/CoreDoc/LoaiVanBan/viewLoaiVanBan.aspx");
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
                <strong class="text-uppercase">Danh mục loại văn bản</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <uc1:ucChucNang runat="server" ID="ucChucNang" />
                        <%--<div class="btn-add btn btn-info btn-sm"><i class="fa fa-plus"></i><strong>Thêm mới</strong></div>
                        <div class="btn-delete btn btn-info btn-sm"><i class="fa fa-times"></i><strong>Xóa</strong></div>
                        --%>
                    </div>

                </div>
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
                                                <label>Mã</label>
                                                <input id="txtMa" type="search" name="txtMa" class="form-control input-sm" placeholder="Mã" value="<%=txtMa %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Trạng thái sử dụng</label>
                                                <select class="form-control select2 " id="cboUsedState" style="width: 100%;" name="UsedState" tabindex="2">
                                                    <option value="">Tất cả</option>
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
                                            <label>Tên</label>
                                            <input id="txtTen" type="search" name="txtTen" class="form-control input-sm" placeholder="Tên" value="<%=txtTen %>">
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label> Thuộc loại văn bản </label>
                                                 <select class="cboLoaiVanBan form-control select2" style="width: 100%" id="cboLoaiVanBan" tabindex="1" name="LoaiVanBanID">
                                                        <asp:Repeater ID="rptLoaiVanBan" runat="server">
                                                            <ItemTemplate>
                                                                <option value="<%#Eval("LoaiVanBanID") %>"><%#Eval("IndentedTitle") %> 
                                                                </option>
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
                                                    <input id="checkAll" type="checkbox" value=""></th>
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-3">Mã</th>
                                                <th class="col-xs-3">Tên</th>
                                                <th class="col-xs-2">Trạng thái sử dụng</th>
                                                <th class="col-xs-3">Thuộc loại</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                    <input class="checkSingle" type="checkbox" value="<%#Eval("LoaiVanBanID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("Ma") %><br /><%#Eval("LoaiVanBanID") %> </td>
                                                    <td><%#Eval("Ten") %></td>
                                                    <td><%#Eval("TrangThaiSuDungName") %></td>
                                                    <td><%#  Eval("TenLoaiVanBanCha")%></td>
                                                    <td class=" actions" data-id="<%#Eval("LoaiVanBanID") %>">
                                                        <%=ucChucNang.ChucNang %>
                                                    </td>
                                                    <%--    <a class="edit" href="javascript:void(0)"  title="Xóa"><i class="fa fa-edit (alias)"></i></a></td>
                                                <td class=" actions"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("UnitID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewRoom.aspx.cs" Inherits="AdminLTE.Usercontrols.Room.viewRoom" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>
<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/Core.Meeting/Room/fRoom.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/Core.Meeting/Room/fRoom.aspx?action=edit&ItemID=" + ItemID);
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
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/Core.Meeting/Room/aRoom.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/Core.Meeting/Room/viewRoom.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        $.cookie("RoomName", $('#RoomName').val(), { path: '/' });
        $.cookie("UsedState", $('#cboUsedState').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/Core.Meeting/Room/viewRoom.aspx");
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
                <strong class="text-uppercase">DANH SÁCH ROOM</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <uc1:ucChucNang runat="server" ID="ucChucNang" />
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
                                                <label>Tên phòng</label>
                                                <input id="RoomName" type="search" name="RoomName" class="form-control input-sm" placeholder="RoomName" value="<%=RoomName%>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Trạng thái sử dụng</label>
                                                <select class="form-control select2 " id="cboUsedState" style="width: 100%;" name="UsedState" tabindex="2">
                                                    <option value="">-- Tất cả ---</option>
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
                                                    <input id="checkAll" type="checkbox" value=""></th>
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-6">Tên</th>
                                                 <th class="col-xs-1">Thứ tự</th>
                                                <th class="col-xs-3">Địa chỉ</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                    <input class="checkSingle" type="checkbox" value="<%#Eval("RoomID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <%--<td><%#Eval("RoomCode") %></td>--%>
                                                    <td><%#Eval("RoomName") %></td>
                                                    <td><%#Eval("OrderNumber") %></td>
                                                    <td><%#Eval("RoomAddress") %></td>
                                                    <td class=" actions" data-id="<%#Eval("RoomID") %>">
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewVanBanBanHanh.aspx.cs" Inherits="AdminLTE.Usercontrols.VanBan.viewVanBanBanHanh" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>
<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
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
        $('.xuatban ').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/CoreDoc/VanBan/viewBanHanh.aspx?action=xuatban&ItemID=" + ItemID);
        });
        $('#divFromDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#divToDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $(".select2").select2();
    })
    function fnSearch() {
        $.cookie("txtSoVanBan", $('#txtSoVanBan').val(), { path: '/' });
        $.cookie("txtTieuDe", $('#txtTieuDe').val(), { path: '/' });
        $.cookie("FromDate", $('#FromDate').val(), { path: '/' });
        $.cookie("ToDate", $('#ToDate').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        $.cookie("LoaiVanBanID", $('#LoaiVanBanID').val(), { path: '/' });
        $.cookie("LinhVucID", $('#LinhVucID').val(), { path: '/' });
        postData(1, "/UserControls/CoreDoc/VanBan/viewVanBanBanHanh.aspx");
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
                <strong class="text-uppercase">Quản lý văn bản </strong>
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
                                                <label>Số văn bản </label>
                                                <input id="txtSoVanBan" type="search" name="txtSoVanBan" class="form-control input-sm" placeholder="Mã" value="<%=txtSoVanBan %>">
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                           <div class="form-group">
                                                <label>Lĩnh vực </label>
                                                <select class="cboLinhVuc form-control select2" style="width: 100%" id="LinhVucID" tabindex="1" name="LinhVucID">
                                                    <option value="">Tất cả</option>
                                                    <asp:Repeater ID="rptLinhVuc" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("LinhVucID") %>"><%#Eval("Ten") %> 
                                                            </option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                            </div>
                                        </div>
                                         <div class="col-md-3">
                                           <label>Loại văn bản  </label>
                                            <select class="cboLinhVuc form-control select2" style="width: 100%" id="LoaiVanBanID" tabindex="1" name="LoaiVanBanID">
                                                <asp:Repeater ID="rptLoaiVanBan" runat="server">
                                                    <ItemTemplate>
                                                        <option value="<%#Eval("LoaiVanBanID") %>"><%#Eval("IndentedTitle") %> 
                                                        </option>
                                                    </ItemTemplate>
                                                </asp:Repeater>
                                            </select>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Trích yếu </label>
                                                <input id="txtTieuDe" type="search" name="txtTieuDe" class="form-control input-sm" placeholder="Tên" value="<%=txtTieuDe %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                             <div class="form-group">
                                                <label>Ngày tạo</label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class='input-group date' id='divFromDate'>
                                                            <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="FromDate" name="FromDate" tabindex="11" value="<%=String.Format("{0:dd/MM/yyyy}", CreatedDateFrom)%>" placeholder="Bắt đầu">
                                                            <span class="input-group-addon">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class='input-group date' id='divToDate'>
                                                            <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="ToDate" name="ToDate" tabindex="11" value="<%= String.Format("{0:dd/MM/yyyy}", CreatedDateTo) %>" placeholder="Kết thúc">
                                                            <span class="input-group-addon">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
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
                                                <th class="col-xs-2">Số văn bản</th>
                                                <th class="col-xs-4">Trích yếu</th>
                                                <th class="col-xs-2">Trạng thái sử dụng</th>
                                                <th class="col-xs-1">Ngày ban hành</th>
                                                <th class="col-xs-2">Loại văn bản</th>

                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="checkSingle" type="checkbox" value="<%#Eval("VanBanID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("SoVanBan") %></td>
                                                    <td><%#Eval("TieuDe") %></td>
                                                    <td><%#Pvn.Utils.EnumHelper.GetDescription((Pvn.Utils.Common.Parameter.DocumentState)Convert.ToInt32(Eval("TrangThaiVanBan"))) %></td>
                                                    <td><%# string.Format("{0:dd/MM/yyyy}", Eval("NgayBanHanh"))%></td>
                                                    <td><%# Eval("LoaiVanBanName")%></td>
                                                    <td class=" actions" data-id="<%#Eval("VanBanID") %>">
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

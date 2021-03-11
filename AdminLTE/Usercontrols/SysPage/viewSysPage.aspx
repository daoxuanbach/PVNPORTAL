<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSysPage.aspx.cs" Inherits="AdminLTE.Usercontrols.SysPage.viewSysPage" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/SysPage/fSysPage.aspx?action=add");
        });
        $('.edit').click(function () {
            var PageID=   $(this).closest("td").attr('data-id')
         getPage("/UserControls/SysPage/fSysPage.aspx?action=edit&PageID="+PageID);
        });
        $("input").keypress(function (event) {
            if (event.which == 13) {
                postData(1, "/UserControls/SysPage/viewSysPage.aspx?Search=" + $('#txtSearch').val());
                event.preventDefault();
            }
        });
        $("#btnSearch").click(function () {
            postData(1, "/UserControls/SysPage/viewSysPage.aspx?txtSearch=" + $('#txtSearch').val());
        });
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
        $('.delete').click(function () {
            BootstrapDialogconfirm($(this).closest("td").attr('data-id'));
        });

        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            postData(1, "/UserControls/SysPage/viewSysPage.aspx?p_search=" + $('#p_search').val() + "&CurPage=" + ItemID);
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
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/SysPage/aSysPage.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/SysPage/viewSysPage.aspx?action=view");
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
                <strong class="text-uppercase">DANH SÁCH PAGE HỆ THỐNG</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" id="ucChucNang"/>
            </div>
        </div>
        <!-- Main content -->
        <div class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box">
                        <div class="box-body">
                            <div id="example1_wrapper" class="dataTables_wrapper form-inline dt-bootstrap">
                                <div class="row">
                                    <div class="col-sm-12">
                                        <div id="" class="dataTables_filter">
                                            <label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Tìm kiếm Url Page" aria-controls="example1" value="<%=KeyWord %>">
                                                <button id="btnSearch" class="btn btn-info btn-flat" type="button">Tìm kiếm</button>
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="row">
                                    <div class="col-sm-12">
                                        <table class="table table-bordered table-striped table-hover">
                                            <thead>
                                                <tr class="table-header">
                                                    <th class="align-center">
                                                        <input  class="flat-red CheckAll" id="checkAll" type="checkbox" value=""></th>
                                                    <th class="align-center">TT</th>
                                                    <th class="col-xs-10">URL của Page</th>
                                                    <th class="align-center" scope="col">Chức năng</th>
                                                   

                                                </tr>
                                            </thead>
                                            <asp:Repeater ID="rptDatabind" runat="server">
                                                <ItemTemplate>
                                                    <tr>
                                                        <td class=" actions">
                                                            <input class="flat-red checkSingle" type="checkbox" value="<%#Eval("PageID") %>"></td>
                                                        <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                        <td><%#Eval("URL") %></td>
                                                        <td class=" actions"  data-id="<%#Eval("PageID") %>">
                                                         <%= ucChucNang.ChucNang %>

                                                           <%-- <a class="edit" href="javascript:void(0)" title="Xóa"><i class="fa fa-edit (alias)"></i></a>
                                                        </td>
                                                        <td class=" actions">
                                                            <a class="delete" href="javascript:void(0)" data-id="<%#Eval("PageID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a>--%>

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
        </div>
    </form>
</body>

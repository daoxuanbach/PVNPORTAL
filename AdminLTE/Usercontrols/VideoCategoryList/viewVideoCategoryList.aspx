<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewVideoCategoryList.aspx.cs" Inherits="AdminLTE.Usercontrols.VideoCategoryList.viewVideoCategoryList" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/VideoCategoryList/fVideoCategoryList.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/VideoCategoryList/fVideoCategoryList.aspx?action=edit&ItemID=" + ItemID);
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
        $(".select2").select2();
        
        $("#cboLanguage").select2("val", "<%=Language%>");
        $("#cbUsedState").select2("val", "<%=UsedState%>");
        //$(".select2").on("change", function (e) {
        //    fnSearch();
        //});

    })




    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/VideoCategoryList/aVideoCategoryList.ashx"), { "CategoryID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/VideoCategoryList/viewVideoCategoryList.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        var Language = $('#cboLanguage').val(),
        UsedState = $('#cbUsedState').val();
        postData(1, "/UserControls/VideoCategoryList/viewVideoCategoryList.aspx?Language=" + Language + "&UsedState=" + UsedState);
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
                <strong class="text-uppercase">DANH SÁCH CHUYÊN MỤC VIDEO</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
              <%--  <div class="form-inline text-right">
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
                <div class="col-xs-12">
                    <div class="box">
                        <div class="box-body">
                            <div class="row">
                                <div class="col-lg-11 vcenter">
                                    <div class="">
                                        <div class="row">
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>Ngôn ngữ</label>
                                                    <select class="cboLanguage form-control select2" style="width: 100%" id="cboLanguage" tabindex="1" name="Language">
                                                        <asp:Repeater ID="rpttUnit" runat="server">
                                                            <ItemTemplate>
                                                                <option value="<%#Eval("Value") %>"><%#Eval("Note") %> 
                                                                </option>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                    </select>

                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>Trạng thái sử dụng</label>
                                                    <select class="form-control select2 " id="cbUsedState" style="width: 100%;" name="UsedState" tabindex="2">
                                                        <option value="">-- Tất cả --</option>
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
                                </div>
                                <div class="col-lg-1 vcenter img-search">
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
                                                <th class="col-xs-2">Tiêu đề</th>
                                                <th class="col-xs-2">Mã</th>
                                                <th class="col-xs-1">Số thứ tự</th>
                                                <th class="col-xs-3">ImageCategoryID</th>
                                                <th class="col-xs-2">Trạng thái sử dụng</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="checkSingle" type="checkbox" value="<%#Eval("VideoCategoryID") %>"></td>
                                                    <td><%#Eval("OrdinalTitle") %></td>
                                                    <td><%#Eval("Code") %></td>
                                                    <td><%#Eval("Ordinal") %></td>
                                                    <td><%#Eval("VideoCategoryID") %></td>
                                                    <td><%#Eval("UsedStateName") %></td>
                                                    <%--  <td><%#Eval("LanguageName") %></td>--%>
                                                    <td class="align-center" data-id="<%#Eval("VideoCategoryID") %>">
                                                        <%=ucChucNang.ChucNang %>
                                                        <%--<a class="edit" href="javascript:void(0)" data-id="<%#Eval("VideoCategoryID") %>" title="Xóa"><i class="fa fa-edit (alias)"></i></a>--%>
                                                    </td>
                                                    <%--<td class="align-center"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("VideoCategoryID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
                                                </tr>
                                            </ItemTemplate>
                                        </asp:Repeater>

                                    </table>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-sm-6">
                                    <%--  <div class="dataTables_info" id="example1_info" role="status" aria-live="polite">Tổng <%=totalRows %> bản ghi</div>--%>
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

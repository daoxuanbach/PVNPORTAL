<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSysUnit.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUnit.viewSysUnit" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/SysUnit/fSysUnit.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/SysUnit/fSysUnit.aspx?action=edit&ItemID=" + ItemID);
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

        $("#cbLanguage").select2("val", "<%=Language%>");
        $("#cbParentUnitID").select2("val", "<%=ParentUnitID%>");
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/SysUnit/aSysUnit.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/SysUnit/viewSysUnit.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        var cbLanguage = $('#cbLanguage').val(),
            cbParentUnitID = $('#cbParentUnitID').val();
        postData(1, "/UserControls/SysUnit/viewSysUnit.aspx?txtSearch=" + $('#txtSearch').val() + "&Language=" + cbLanguage + "&Code=" + $('#txtCode').val() + "&ParentUnitID=" + cbParentUnitID);
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
                <strong class="text-uppercase">DANH SÁCH ĐƠN VỊ</strong>
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
                                                <label>Ngôn ngữ</label>
                                                <select class="form-control select2" id="cbLanguage" tabindex="1" name="Language">
                                                    <asp:Repeater ID="rptNgonNgu" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Thuộc đơn vị</label>
                                                <select class="form-control select2" id="cbParentUnitID" tabindex="1" name="ParentUnitID">
                                                    <option value="00000000-0000-0000-0000-000000000000">-- Thuộc đơn vị ---</option>
                                                    <asp:Repeater ID="rptParentUnit" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Tên đơn vị</label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=KeyWord %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Mã đơn vị</label>
                                                <input id="txtCode" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%= Code %>">
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
                                            <th class="col-xs-3">Mã đơn vị</th>
                                            <th class="col-xs-4">Tên đơn vị</th>
                                            <th class="col-xs-2">Thuộc đơn vị</th>
                                            <th class="col-xs-1">Ngôn ngữ</th>
                                            <th class="align-center" scope="col">Thao tác</th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="rptDatabind" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class=" actions">
                                                    <input class="checkSingle" type="checkbox" value="<%#Eval("UnitID") %>"></td>
                                                <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                <td><%#Eval("Code") %></td>
                                                <td><%#Eval("Name") %></td>
                                                <td><%#Eval("ParentUnitName") %></td>
                                                <td><%#Eval("Language") %></td>
                                                <td class=" actions" data-id="<%#Eval("UnitID") %>">
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
        </div>
    </form>
</body>

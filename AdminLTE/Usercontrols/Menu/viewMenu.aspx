<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewMenu.aspx.cs" Inherits="AdminLTE.Usercontrols.Menu.viewMenu" %>
<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>

<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/Menu/fMenu.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/Menu/fMenu.aspx?action=edit&ItemID=" + ItemID);
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
        $('#divFromDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#divToDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
     
        $("#cboLanguage").select2("val", "<%=Language%>");
        $('#cbUsedState').select2("val", "<%=UsedState%>");
        $('#cboMenuPosition').select2("val", "<%=MenuPosition%>");
        $('#cboParentMenuID').select2("val", "<%=ParentMenuID%>");
       <%-- $('#cboObjectType').select2("val", "<%=ObjectType%>");--%>
        $("#btnSearch").click(function () {
            fnSearch();
        });
        //$(".select2").on("change", function () {
        //    fnSearch();
        //    return false;
        //});
    });

    //$(".select2 ").change(function () {
    //    fnSearch();
    //});
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/Menu/aMenu.ashx"), { "CategoryID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/Menu/viewMenu.aspx?action=view");
              }
          });
        return false;
    };


    function fnSearch() {

        $.cookie("Language", $('#cboLanguage').val(), { path: '/' });
        //$.cookie("txtCode", decodeURIComponent($('#txtCode').val()), { path: '/', expires: 60 });
        $.cookie("txtTitle", decodeURIComponent($('#txtTitle').val()), { path: '/' });
        $.cookie("UsedState", $('#cbUsedState').val(), { path: '/' });
        $.cookie("txtUrl", decodeURIComponent($('#idUrl').val()), { path: '/' });
        $.cookie("MenuPosition", $('#cboMenuPosition').val(), { path: '/' });
        $.cookie("ParentMenuID", $('#cboParentMenuID').val(), { path: '/' });
        //$.cookie("ObjectType", $('#cboObjectType').val(), { path: '/' });
        $.cookie("FromDate", $('#FromDate').val(), { path: '/' });
        $.cookie("ToDate", $('#ToDate').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/Menu/viewMenu.aspx");
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
                <strong class="text-uppercase">DANH SÁCH CHUYÊN MỤC</strong>
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
                                          <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Ngôn ngữ</label>
                                                <select class="cboLanguage form-control select2" style="width: 100%" id="cboLanguage" tabindex="1" name="Language">
                                                    <asp:Repeater ID="rptLanguage" runat="server">
                                                        <ItemTemplate>
                                                            <option  value="<%#Eval("Value") %>"><%#Eval("Note") %> 
                                                            </option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>

                                            </div>

                                        </div>
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Tiêu đề</label>
                                                <input id="txtTitle" name="txtTitle" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=txtTitle %>">
                                            </div>
                                        </div>
                                      <%--  <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Mã menu</label>
                                                <input id="txtCode" name="txtCode" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=Code %>">
                                            </div>
                                        </div>--%>
                                        <div class="col-md-4">
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
                                  
                                    <div class="row">
                                          <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Đường dẫn</label>
                                                <input id="idUrl" name="txtURL" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=txtURL %>">
                                            </div>
                                        </div>
                                         <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Menu cha	</label>
                                                <select class="cboParentMenuID form-control select2" style="width: 100%" id="cboParentMenuID" tabindex="1" name="ParentMenuID">
                                                    <option value="">-- Tất cả --</option>
                                                    <asp:Repeater ID="rptParentMenuID" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("MenuID") %>"><%#Eval("Title") %> 
                                                            </option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                            </div>
                                        </div>
                                      
                                        <div class="col-md-4">
                                            <div class="form-group">
                                                <label>Vị trí	</label>
                                                <select class="cboMenuPosition form-control select2" style="width: 100%" id="cboMenuPosition" tabindex="1" name="MenuPosition">
                                                    <option value="">-- Tất cả --</option>
                                                    <option value="1">Top</option>
                                                    <option value="2">Left</option>
                                                    <option value="3">Right</option>
                                                    <option value="3">Bottom</option>
                                                </select>

                                            </div>
                                        </div>
                                        <%-- <div class="col-md-3">
                                            <div class="form-group">
                                                <label>Loại đối tượng</label>
                                                <select class="cboObjectType form-control select2" style="width: 100%" id="cboObjectType" tabindex="1" name="ObjectType">
                                                    <option value="">-- Tất cả --</option>
                                                    <option value="Category">Category</option>
                                                    <option value="ImageCategory">ImageCategory</option>
                                                    <option value="Image">Image</option>
                                                    <option value="Link">Link</option>
                                                    <option value="News">News</option>
                                                    <option value="VideoCategory">VideoCategory</option>
                                                    <option value="Video">Video</option>
                                                </select>

                                            </div>
                                        </div>--%>
                                    </div>
                                 
                                    <div class="row" style="display: none">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngày tạo	</label>
                                                <div class='input-group date' id='divFromDate'>
                                                    <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="FromDate" name="FromDate" tabindex="11" value="<%=String.Format("{0:dd/MM/yyyy}", FromDate)%>" placeholder="Bắt đầu">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngày tạo	</label>
                                                <div class='input-group date' id='divToDate'>
                                                    <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="ToDate" name="ToDate" tabindex="11" value="<%= String.Format("{0:dd/MM/yyyy}", ToDate) %>" placeholder="Kết thúc">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
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
                                                <th class="col-xs-1">Mã</th>
                                                <th class="col-xs-2">Tiêu đề</th>
                                                <th class="col-xs-2">Số thứ tự</th>
                                                <th class="col-xs-1">Vị trí</th>
                                                <th class="col-xs-3">Menu cha</th>
                                                <th class="col-xs-1">Trạng thái</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="checkSingle" type="checkbox" value="<%#Eval("MenuID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("Code") %></td>
                                                    <td><%#Eval("OrdinalTitle") %></td>
                                                    <td><%#Eval("Ordinal") %></td>
                                                    <td><%#Eval("MenuPositionName") %></td>
                                                    <td><%#Eval("MenuParentName") %></td>
                                                    <td><%# Convert.ToInt32(Eval("UsedState"))==1? "Đang sử dụng":(Convert.ToInt32(Eval("UsedState"))==2? "Không hoạt động": "Đã xóa khỏi hệ thống") %></td>
                                                    <td class="actions" data-id="<%#Eval("MenuID") %>">
                                                       <%-- <a class="edit" href="javascript:void(0)" data-id="<%#Eval("MenuID") %>" title="Xóa"><i class="fa fa-edit (alias)"></i></a>--%>
                                                        <%=ucChucNang.ChucNang %>
                                                    </td>
                                                    <%--<td class=" actions"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("MenuID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
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
                </div>

                <!-- /.box-body -->
            </div>
            <!-- /.box -->
        </div>
        <!-- /.col -->

    </form>
</body>

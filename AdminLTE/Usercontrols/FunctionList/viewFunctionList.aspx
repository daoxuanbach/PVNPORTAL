<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewFunctionList.aspx.cs" Inherits="AdminLTE.Usercontrols.FunctionList.viewFunctionList" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/FunctionList/fFunctionList.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/FunctionList/fFunctionList.aspx?action=edit&ItemID=" + ItemID);
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
        $("#cbUsedState").select2("val", "<%=UsedState%>");
        $("#cbParentFunctionID").select2("val", "<%=ParentFunction%>");

        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            $("#pageId").val(ItemID);
            fnSearch();
        });
        $('input[type="checkbox"]').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });


        $('#checkAll')
             .on('ifChecked', function (event) {
                 $('input[type="checkbox"]').iCheck('check');
             })
             .on('ifUnchecked', function () {
                 $('input[type="checkbox"]').iCheck('uncheck');
             });
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/FunctionList/aFunctionList.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/FunctionList/viewFunctionList.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        $.cookie("Search", decodeURIComponent($('#txtSearch').val()), { path: '/' });
        $.cookie("Language", $('#cbLanguage').val(), { path: '/' });
        $.cookie("UsedState", $('#cbUsedState').val(), { path: '/' });
        $.cookie("ParentFunctionID", $('#cbParentFunctionID').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/FunctionList/viewFunctionList.aspx");
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
                <strong class="text-uppercase">DANH SÁCH CÁC CHỨC NĂNG HỆ THỐNG</strong>
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
                                                    <label>Ngôn ngữ</label>
                                                    <select class="form-control select2 cboLanguage" id="cbLanguage" tabindex="1" name="Language" style="width:100%">
                                                        <asp:Repeater ID="rptNgonNgu" runat="server">
                                                            <ItemTemplate>
                                                                <option  value="<%#Eval("MaNgonNgu") %>"><%#Eval("TenNgonNgu") %></option>
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
                                                    <label>Tên chức năng</label>
                                                    <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=KeyWord %>">
                                                </div>
                                            </div>
                                            <div class="col-md-6">
                                                <div class="form-group">
                                                    <label>Thuộc nhóm chức năng</label>
                                                    <select class="form-control select2 " id="cbParentFunctionID" name="ParentFunctionID" style="width: 100%;" tabindex="4" aria-hidden="true">
                                                        <option value="00000000-0000-0000-0000-000000000000">-- Chọn nhóm chức năng --- </option>
                                                        <asp:Repeater ID="rptNhomChucNang" runat="server">
                                                            <ItemTemplate>
                                                                <option value="<%#Eval("FunctionID") %>"><%#Eval("Name") %></option>
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
                                            <th class="col-xs-5">Tên chức năng</th>
                                            <th class="col-xs-5">URL của Page</th>
                                            <th class="align-center" scope="col">Chức năng</th>
                                           

                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="rptDatabind" runat="server">
                                        <ItemTemplate>
                                            <tr>
                                                <td class=" actions">
                                                    <input class="checkSingle" type="checkbox" value="<%#Eval("FunctionID") %>"></td>
                                                <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                <td><%#Eval("Name") %></td>
                                                <td><%#Eval("URL") %></td>
                                                <td class=" actions" data-id="<%#Eval("FunctionID") %>" >
                                                      <%= ucChucNang.ChucNang %>
                                                 </td>
                                                   <%-- <a class="edit" href="javascript:void(0)" title="Xóa"><i class="fa fa-edit (alias)"></i></a>

                                                </td>
                                                <td class=" actions"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("FunctionID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
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

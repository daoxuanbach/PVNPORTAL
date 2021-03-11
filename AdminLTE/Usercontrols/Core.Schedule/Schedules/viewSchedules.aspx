<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewSchedules.aspx.cs" Inherits="AdminLTE.Usercontrols.Schedules.viewSchedules" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>
<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/Core.Schedule/Schedules/fSchedules.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/Core.Schedule/Schedules/fSchedules.aspx?action=edit&ItemID=" + ItemID);
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
       
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/Core.Schedule/Schedules/aSchedules.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/Core.Schedule/Schedules/viewSchedules.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        $.cookie("txtSearch", $('#txtSearch').val(), { path: '/' });
        $.cookie("Description", $('#Description').val(), { path: '/' });
        $.cookie("FromAddress", $('#FromAddress').val(), { path: '/' });
        $.cookie("FromDate", $('#FromDate').val(), { path: '/' });
        $.cookie("ToDate", $('#ToDate').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/Core.Schedule/Schedules/viewSchedules.aspx");
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
                <strong class="text-uppercase">Danh sách Schedules</strong>
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
                                                <label>Tiêu đề</label>
                                                <input id="txtSearch" type="search" name="txtSearch" class="form-control input-sm" placeholder="Title" value="<%=txtSearch%>">
                                            </div>
                                        </div>
                                         <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Chi tiết</label>
                                                <input id="Description" type="search" name="Description" class="form-control input-sm" placeholder="Description" value="<%=Description%>">
                                            </div>
                                        </div>
                                        
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Thời gian</label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class='input-group date' id='divFromDate'>
                                                            <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="FromDate" name="FromDate" tabindex="11" value="<%=String.Format("{0:dd/MM/yyyy}", FromBeginDate)%>" placeholder="Bắt đầu">
                                                            <span class="input-group-addon">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class='input-group date' id='divToDate'>
                                                            <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="ToDate" name="ToDate" tabindex="11" value="<%= String.Format("{0:dd/MM/yyyy}", ToBeginDate) %>" placeholder="Kết thúc">
                                                            <span class="input-group-addon">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </span>
                                                        </div>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Địa điểm </label>
                                                <input id="FromAddress" type="search" name="FromAddress" class="form-control input-sm" placeholder="FromAddress" value="<%=FromAddress%>">
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
                                                <th class="col-xs-2">Tiêu dề</th>
                                                <th class="col-xs-2">Chi tiết</th>
                                                <th class="col-xs-2">Lãnh đạo</th>
                                                <th class="col-xs-2">Ngày bắt đầu</th>
                                                <th class="col-xs-2">Ngày kết thúc</th>
                                                <th class="col-xs-2">Địa điểm</th>
                                                <th class="col-xs-1">Private</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                    <input class="checkSingle" type="checkbox" value="<%#Eval("ScheduleID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("Title") %></td>
                                                    <td><%#Eval("Descriptions") %></td>
                                                    <td><%# SubString(DataBinder.Eval(Container.DataItem,"ListManagerName")) %></td>
                                                    <td> <%# string.Format("{0:dd/MM/yy} {0:T}", Eval("BeginDate"))%> </td>
                                                    <td> <%# string.Format("{0:dd/MM/yy} {0:T}", Eval("EndDate"))%> </td>
                                                    <td><%#Eval("ToAddress") %></td>
                                                    <td>
                                                        <asp:Image runat="server" ID="imgPrivate" Visible='<%# (Convert.ToString(Eval("Private")).ToUpper() == "TRUE") %>' ImageUrl="~/_layouts/Core.Branding/Images/Icons/publish.gif" />
                                                    </td>
                                                    <td class=" actions" data-id="<%#Eval("ScheduleID") %>">
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewEventList.aspx.cs" Inherits="AdminLTE.Usercontrols.EventList.viewEventList" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>

<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function () {
            $.post("/UserControls/EventList/fEventList.aspx?action=add", {},
                function (data) {
                    $("#data-content").html(data);
                });
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/EventList/fEventList.aspx?action=edit&ItemID=" + ItemID);
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

       $("#cboEventType").select2("val", "<%=EventType%>");
      $("#cboEstiomae").select2("val", "<%=cbEstiomae%>");

        //$("#FromDate").datepicker({ dateFormat: 'dd/mm/yy' });
        //$("#ToDate").datepicker({ dateFormat: 'dd/mm/yy' });
        $('#divFromDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $('#divToDate').datetimepicker({
            format: 'DD/MM/YYYY'
        });

        $('.pageOnclick').click(function () {
            var ItemID = $(this).attr('pnumber')
            $("#pageId").val(ItemID);
            fnSearch();
        });
    })

    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/EventList/aEventList.ashx"), { "NewsID": dataid, "hidAction": "del" },
            function (data) {
                if (data.Error) {
                    BootstrapDialogalert(data.Message);
                }
                else {
                    displayOverlay(data.Message);
                    getPage("/UserControls/EventList/viewEventList.aspx?action=view");
                }
            });
        return false;
    };
    function fnSearch() {
        $.cookie("txtEventName", $('#txtEventName').val(), { path: '/' });
        $.cookie("cboEventType", $('#cboEventType').val(), { path: '/' });
        $.cookie("FromDate", $('#FromDate').val(), { path: '/' });
        $.cookie("ToDate", $('#ToDate').val(), { path: '/' });
        $.cookie("cboEstiomae", $('#cboEstiomae').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/EventList/viewEventList.aspx?EventName");

    }
</script>
<head runat="server">
    <title></title>
    <style type="text/css">
        
    </style>
</head>
<body>
    <!-- Content Header (Page header) -->
    <form runat="server" id="frm">
        <input type="hidden" name="p" id="pageId" value="">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">DANH SÁCH EVENT</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
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
                                                <label>Tên thông báo</label>
                                                <input id="txtEventName" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=EventName %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Loại thông báo</label>
                                                <select class="form-control select2 " id="cboEventType" style="width: 100%;" name="EventType" tabindex="2">
                                                    <option value="">-- Tất cả ---</option>
                                                    <asp:Repeater ID="rptEventType" runat="server">
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
                                                <label>Dự kiến</label>
                                                <select class="form-control select2 " id="cboEstiomae" style="width: 100%;" name="Estiomae" tabindex="2">
                                                    <option value="0">Tất cả</option>
                                                    <option value="1">Dự kiến </option>
                                                    <option value="2">Chắc chắn</option>
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
                                                <th class="col-xs-4">Tên thông báo </th>
                                                <th class="col-xs-2">Ngày thông báo</th>
                                                <th class="col-xs-2">Ngày kết thúc</th>
                                                <th class="col-xs-2">Loại thông báo</th>
                                                <th class="col-xs-1">Thứ tự</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="checkSingle" type="checkbox" value="<%#Eval("EventID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%# Eval("Name")%></td>
                                                    <td>
                                                        <%# string.Format("{0:dd/MM/yyyy}", Eval("BeginDate"))%> 
                                                    </td>
                                                    <td>
                                                        <%# string.Format("{0:dd/MM/yyyy}", Eval("EndDate"))%> 
                                                    </td>
                                                    <td>
                                                        <%#Eval("EventTypeName")%> 
                                                    </td>
                                                    <td>
                                                        <%#Eval("Ordinal")%>
                                                    </td>
                                                    <td class=" actions" data-id="<%#Eval("EventID") %>">
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

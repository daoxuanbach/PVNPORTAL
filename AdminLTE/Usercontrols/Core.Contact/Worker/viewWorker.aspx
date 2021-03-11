<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewWorker.aspx.cs" Inherits="AdminLTE.Usercontrols.Worker.viewWorker" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>
<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/Core.Contact/Worker/fWorker.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/Core.Contact/Worker/fWorker.aspx?action=edit&ItemID=" + ItemID);
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
        $("#cboCompany").select2("val", "<%=CompanyID%>");
        
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/Core.Contact/Worker/aWorker.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/Core.Contact/Worker/viewWorker.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        $.cookie("FirstName", $('#FirstName').val(), { path: '/' });
        $.cookie("LastName", $('#LastName').val(), { path: '/' });
        $.cookie("UsedState", $('#cboUsedState').val(), { path: '/' });
        $.cookie("CompanyID", $('#cboCompany').val(), { path: '/' });
        $.cookie("FromDate", $('#FromDate').val(), { path: '/' });
        $.cookie("ToDate", $('#ToDate').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        postData(1, "/UserControls/Core.Contact/Worker/viewWorker.aspx");
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
                <strong class="text-uppercase">DANH SÁCH WORKER</strong>
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
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>Tên</label>
                                                <input id="FirstName" type="search" name="FirstName" class="form-control input-sm" placeholder="FirstName" value="<%=FirstName%>">
                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                 <label>Họ</label>
                                                <input id="LastName" type="search" name="LastName" class="form-control input-sm" placeholder="LastName" value="<%=LastName%>">

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Công ty</label>
                                                <select class="form-control select2 " id="cboCompany" style="width: 100%;" name="CompanyID" tabindex="2">
                                                    <option value="">-- Tất cả ---</option>
                                                    <asp:Repeater ID="rptCompany" runat="server"> 
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("CompanyID") %>"><%#Eval("IndentedTitle") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        
                                       <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngày sinh</label>
                                                <div class="row">
                                                    <div class="col-md-6">
                                                        <div class='input-group date' id='divFromDate'>
                                                            <input type="text" class="form-control" data-format="dd/MM/yyyy" id="FromDate" name="FromDate" tabindex="11" value="<%=String.Format("{0:dd/MM/yyyy}", FromDate)%>" placeholder="Bắt đầu">
                                                            <span class="input-group-addon">
                                                                <span class="glyphicon glyphicon-calendar"></span>
                                                            </span>
                                                        </div>
                                                    </div>
                                                    <div class="col-md-6">
                                                        <div class='input-group date' id='divToDate'>
                                                            <input type="text" class="form-control" data-format="dd/MM/yyyy" id="ToDate" name="ToDate" tabindex="11" value="<%= String.Format("{0:dd/MM/yyyy}", ToDate) %>" placeholder="Kết thúc">
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
                                                <th class="align-center">STT</th>
                                                <th class="col-xs-2">Họ tên</th>
                                                <th class="col-xs-1">Ảnh đại diện</th>
                                                <th class="col-xs-2">Chi tiết</th>
                                                <th class="col-xs-3">Liên hệ</th>
                                                <th class="col-xs-2">Trạng thái sử dụng</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                    <input class="checkSingle" type="checkbox" value="<%#Eval("WorkerID") %>"></td>
                                                    <td><%#Eval("OrderNumber") %></td>
                                                    <td><%#Eval("FullName") %></td>
                                                     <td>
                                                         <asp:Image ID="imgTitle" runat="server" ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("Images"), "C80x130")%>'
                                                            style="width:80px; height:130px; padding:2px;"
                                                              OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("Images"), "C80x130") + "\")" %>'/> 
                                                     </td>
                                                       <td>
                                                           <asp:Label ID="lblCreatedBy" runat="server" CssClass="Label" Text="Ngày sinh" /> :<%# Eval("BornDate", "{0:dd/MM/yyyy}")%> <br />
                                                            <asp:Label ID="lblSex" runat="server" CssClass="Label" Text="Giới tính" /> : <%# Eval("SexName").ToString()%>
                                                       </td>
                                                       <td>
                                                            <asp:Label ID="lblCompany" runat="server" CssClass="Label" Text="- Công ty" /> : <%# Eval("CompanyName").ToString()%><BR/>
                                                            <asp:Label ID="lblJobTitle" runat="server" CssClass="Label" Text="- Chức vụ" /> : <%# Eval("JobTitle").ToString()%><BR/>
                                                            <asp:Label ID="lblContactDetail" runat="server" Text='<%# Pvn.Utils.Utilities.HtmlEncode(Eval("ContactDetail").ToString()) %>'></asp:Label>   
                                                       </td>
                                                    <td><%#Eval("UsedStateName") %></td>
                                                    <td class=" actions" data-id="<%#Eval("WorkerID") %>">
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewRolePermissionForUserList.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUser.viewRolePermissionForUserList" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-Update").click(function (event) {
            fnUpdate();
        });
        $("input").keypress(function (event) {
            if (event.which == 13) {
                fnSearch();
                event.preventDefault();
            }
        });
        $("#btnSearch").click(function () {
            fnSearch();
        })
        $(".select2").select2();
        $("#cbUsedState").select2("val", "<%=UsedState%>");
        $("#cbUnitID").select2("val", "<%=UnitID%>");
        fnSelectRole();
    });
    function fnSelectRole() {
        $("select[id^='cbRole']").each(function () {
            $(this).select2("val", $(this).attr('data-rore'));
        });
    }
    function fnUpdate() {
        var arrID = GetListUpdateValue();
        var jsonRole = JSON.stringify(arrID);
        $.post(encodeURI("/UserControls/SysUser/aSysUser.ashx"), { "hidAction": "updaterole", "jsonRole": jsonRole },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  fnSearch();
              }
          });
        return false;
    };
    function fnSearch() {
        var cbUsedState = $('#cbUsedState').val(),
            cbUnitID = $('#cbUnitID').val(),
            p = "<%=p%>";
        postData(1, "/UserControls/SysUser/viewRolePermissionForUserList.aspx?p=" + p + "&txtSearch=" + $('#txtSearch').val() + "&LoginName=" + $('#txtLoginName').val() + "&UnitID=" + cbUnitID + "&UsedState=" + cbUsedState);
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
                <strong class="text-uppercase">DANH SÁCH NGƯỜI DÙNG</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
               <%-- <div class="form-inline text-right">
                    <div class="form-group">
                        <div type="submit" id="btn-Update" class="btn-Update btn btn-info btn-sm"><i class="fa fa-check"></i><strong>Cập nhật</strong></div>

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
                                                <label>Thuộc đơn vị</label>
                                                <select class="form-control select2" id="cbUnitID" tabindex="1" name="UnitID">
                                                    <option value="00000000-0000-0000-0000-000000000000">-- Thuộc đơn vị ---</option>
                                                    <asp:Repeater ID="rpttUnit" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
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
                                                <label>Tên hiển thị	</label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=KeyWord %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Tên đăng nhập	</label>
                                                <input id="txtLoginName" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%= loginName %>">
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
                                    <table class="table table-bordered table-striped table-hover" id="table-updatevalue">
                                        <thead>
                                            <tr class="table-header">
                                                <th class="align-center">TT</th>
                                                <th class="col-xs-3">Tên đăng nhập</th>
                                                <th class="col-xs-3">Tên hiển thị</th>
                                                <th class="col-xs-2">Trạng thái sử dụng</th>
                                                <th class="col-xs-3">Thuộc đơn vị</th>
                                                <th class="col-xs-1">Quyền hạn</th>

                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server" OnItemDataBound="rptDatabind_ItemDataBound">
                                            <ItemTemplate>
                                                <tr class="table-content">
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%#Eval("LoginName") %></td>
                                                    <td><%#Eval("UserName") %></td>
                                                    <td><%# Convert.ToInt32(Eval("UsedState"))==1? "Hoạt động": "Không hoạt động" %></td>
                                                    <td><%#Eval("UnitName") %></td>
                                                    <td class="actions" itemid="<%#Eval("UserID") %>">
                                                        <select class="form-control select2 " data-rore="<%#Eval("RolePermission") %>" id="cbRole<%#Eval("UserID") %>" style="width: 100%;" name="Role" tabindex="2">
                                                           <asp:Repeater ID="rptRolePermission" runat="server">
                                                            <ItemTemplate>
                                                                <option value="<%#Eval("Key") %>"><%#Eval("Value") %></option>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                        </select>
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

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fPhanQuyenGroup.aspx.cs" Inherits="AdminLTE.Usercontrols.SysGroup.fPhanQuyenGroup" %>


<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title>Thêm mới </title>
    <style type="text/css">
        #UserNameId {
            color: red;
        }
    </style>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Nhóm chức năng hệ thống:
                    <asp:Label ID="GroupName" runat="server" CssClass="css-username"></asp:Label></strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <button class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                        <button id="btn-Update" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></button>
                    </div>
                </div>
            </div>
        </div>
        <div class="content">
            <div class="row">
                <div class="col-md-12">
                    <div class="box">
                        <div class="box-body">
                      
                        </div>
                        <div class="row">
                            <div class="col-sm-12">
                                <table class="table table-bordered table-striped table-hover">
                                    <thead>
                                        <tr class="table-header">
                                           
                                            <th class="align-center">TT</th>
                                            <th class="col-xs-3">Tên chức năng</th>
                                             <th class="align-left">
                                                <input class="flat-red checkAll" id="input-0" type="checkbox" value=""> <label for= 'input-0' > <span class='cslchucnang' >Chọn tất</span></label></th>
                                        </tr>
                                    </thead>
                                    <asp:Repeater ID="rptDatabind" runat="server"  OnItemDataBound="rptDatabind_ItemDataBound">
                                        <ItemTemplate>
                                            <tr class="<%#Eval("CheckGroupFunction") %>">
                                                <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                <td><%#Eval("FullName") %></td>
                                                   <td class="align-left"> 
                                                    <asp:Literal ID="ltlChucNang" runat="server"></asp:Literal>
                                                </td>
                                              </tr>
                                        </ItemTemplate>
                                    </asp:Repeater>

                                </table>
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-sm-6">
                             <%--   <div class="dataTables_info" id="example1_info" role="status" aria-live="polite">Tổng <%=totalRows %> bản ghi</div>--%>
                            </div>
                            <div class="col-sm-6">
                                <div class="dataTables_paginate paging_simple_numbers" id="example1_paginate">
                                    <asp:Literal ID="litMsg" runat="server"></asp:Literal>
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

    </form>
</body>
</html>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/SysGroup/pUserSP.aspx");
            // getPage("/UserControls/SysGroup/fSysGroup.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).attr('data-id')
            getPage("/UserControls/SysGroup/fSysGroup.aspx?action=edit&ItemID=" + ItemID);
        });
        $('.RoleGroup').click(function () {
            var UserID = $(this).attr('data-id'),
             UserName = $(this).attr('data-name');

            getPage("/UserControls/SysGroup/fSysGroupFunction.aspx?UserID=" + UserID + "&UserName=" + UserName);
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
        $('input[type="checkbox"].flat-red').iCheck({
            checkboxClass: 'icheckbox_flat-green',
            radioClass: 'iradio_flat-green'
        });


        $('.checkAll')
             .on('ifChecked', function (event) {
                 $('.flat-red').iCheck('check');
             })
             .on('ifUnchecked', function () {
                 $('.flat-red').iCheck('uncheck');
             });

        $('.delete').click(function () {
            BootstrapDialogconfirm($(this).attr('data-id'));
        });
        
        $(".btn-back").click(function () {
            getPage("/UserControls/SysGroup/viewSysGroup.aspx?action=view");
            return false;
        });

        $("#btn-Update").click(function () {
            var arrID = GetListIDChecked();
            $.post(encodeURI("/UserControls/SysGroup/aSysGroup.ashx"), { "GroupID": "<%=GroupID%>", "lstchucnang": arrID, "hidAction": "phanquyen" },
                function (data) {
                    if (data.Error) {
                        BootstrapDialogalert(data.Message);
                    }
                    else {
                        displayOverlay(data.Message);
                        getPage("/UserControls/SysGroup/viewSysGroup.aspx?action=view");
                    }
                });
            return false;
        });
    })
    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/SysGroup/aSysGroup.ashx"), { "PageID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/SysGroup/viewSysGroup.aspx?action=view");
              }
          });
        return false;
    };
</script>

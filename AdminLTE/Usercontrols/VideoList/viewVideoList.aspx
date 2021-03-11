<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="viewVideoList.aspx.cs" Inherits="AdminLTE.Usercontrols.VideoList.viewVideoList" %>

<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>


<script type="text/javascript">
    $(document).ready(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-add").click(function (event) {
            getPage("/UserControls/VideoList/fVideoList.aspx?action=add");
        });
        $('.edit').click(function () {
            var ItemID = $(this).closest("td").attr('data-id')
            getPage("/UserControls/VideoList/fVideoList.aspx?action=edit&ItemID=" + ItemID);
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

        $("#cboUsedState").select2("val", "<%=UsedState%>");
        $("#cboVideoCategoryID").select2("val", "<%=VideoCategoryID%>");

        $("#cboLanguage").select2("val", "<%=Language%>");
        $("#cboPublishedState").select2("val", "<%=PublishedState%>");
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
        //$(".select2").on("change", function (e) {
        //    fnSearch();
        //});
    })



    function formatState(state) {
        if (!state.id) { return state.text; }
        var $state = $(
          '<span><img src="' + state.element.getAttribute('coquocgia') + '" class="img-flag" /> ' + state.text + '</span>'
        );
        return $state;
    };

    function fndelete(dataid) {
        $.post(encodeURI("/UserControls/VideoList/aVideoList.ashx"), { "CategoryID": dataid, "hidAction": "del" },
          function (data) {
              if (data.Error) {
                  BootstrapDialogalert(data.Message);
              }
              else {
                  displayOverlay(data.Message);
                  getPage("/UserControls/VideoList/viewVideoList.aspx?action=view");
              }
          });
        return false;
    };
    function fnSearch() {
        $.cookie("Language", $('#cboLanguage').val(), { path: '/' });
        $.cookie("txtDesscription", decodeURIComponent($('#txtDesscription').val()), { path: '/' });
        $.cookie("VideoCategoryID", $('#cboVideoCategoryID').val(), { path: '/' });
        $.cookie("txtSearch", decodeURIComponent($('#txtSearch').val()), { path: '/' });
        $.cookie("UsedState", $('#cboUsedState').val(), { path: '/' });
        $.cookie("CurPage", $('#pageId').val(), { path: '/' });
        $.cookie("PublishedState", $('#cboPublishedState').val(), { path: '/' });

        postData(1, "/UserControls/VideoList/viewVideoList.aspx");
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
                <strong class="text-uppercase">DANH SÁCH VIDEO</strong>
            </div>
            <div class="col-xs-6">
                <uc1:ucChucNang runat="server" ID="ucChucNang" />
               <%-- <div class="form-inline text-right">
                    <div class="form-group">
                        <div class="btn-add btn btn-info btn-sm">
                            <i class="fa fa-plus"></i><strong>Thêm mới</strong>
                        </div>
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
                                <div class="col-md-11 vcenter">

                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngôn ngữ</label>
                                                <select class="cboLanguage form-control select2" style="width: 100%" id="cboLanguage" tabindex="1" name="Language">
                                                    <asp:Repeater ID="rptLanguage" runat="server">
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
                                                <label>Chuyên mục</label>
                                                <select class="form-control select2" style="width: 100%" id="cboVideoCategoryID" tabindex="1" name="VideoCategoryID">
                                                    <option value="">-- Tất cả ---</option>
                                                    <asp:Repeater ID="rptVideoCategoryID" runat="server">
                                                        <ItemTemplate>
                                                            <option value="<%#Eval("VideoCategoryID") %>"><%#Eval("IndentedTitle") %></option>
                                                        </ItemTemplate>
                                                    </asp:Repeater>
                                                </select>

                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>Trạng thái tin tức</label>
                                                <select class="form-control select2 " id="cboUsedState" style="width: 100%;" name="UsedState" tabindex="2">
                                                    <option value="0">Tất cả</option>
                                                     <asp:Repeater ID="rptUsedState" runat="server">
                                                            <ItemTemplate>
                                                                <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                            </ItemTemplate>
                                                        </asp:Repeater>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="col-md-3">
                                            <div class="form-group">
                                                <label>Xuất bản</label>
                                                <select class="form-control select2 " id="cboPublishedState" style="width: 100%;" name="PublishedState" tabindex="2">
                                                    <option value="1">Intranet</option>
                                                    <option value="2">Intranet - Internet</option>
                                                </select>

                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Tiêu đề</label>
                                                <input id="txtSearch" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=KeyWord %>">
                                            </div>
                                        </div>
                                    </div>

                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <label>Tóm tắt</label>
                                                <input id="txtDesscription" type="search" class="form-control input-sm" placeholder="Enter Search" value="<%=Desscription %>">
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
                                                <th class="align-center"> STT </th>
                                                <th class="col-xs-2">Chuyên mục </th>
                                                <th class="col-xs-3">Tiêu đề</th>
                                                <th class="col-xs-3">Tóm tắt</th>
                                                <th class="col-xs-2">Trạng thái tin tức</th>
                                                <th class="col-xs-2">Audit</th>
                                                <th class="align-center" scope="col">Thao tác</th>
                                            </tr>
                                        </thead>
                                        <asp:Repeater ID="rptDatabind" runat="server">
                                            <ItemTemplate>
                                                <tr>
                                                    <td class=" actions">
                                                        <input class="checkSingle" type="checkbox" value="<%#Eval("VideoID") %>"></td>
                                                    <td><%#(Container.ItemIndex + 1) +  (CurPage-1)*RowPerPage %></td>
                                                    <td><%# Eval("VideoCategoryName")%></td>
                                                    <td>
                                                        <div>
                                                            <asp:Image ID="imgTitle" runat="server" ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageUrl"), "C130x80")%>'
                                                                Visible='<%# string.IsNullOrEmpty(Eval("ImageUrl").ToString())? false : true %>'
                                                                Style="padding: 2px; float: left; width: 130px; height: 80px;" 
                                                                OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), "C130x80") + "\")" %>'/>
                                                            <%--<asp:Image ID="Image1" runat="server" ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageUrl"), "C130x80")%>'
                                                            onerror='<%# String.Format("LoadImages(this.id,\"{0}\")",Pvn.Utils.Utilities.ProcessImage(Eval("ImageUrl"), "C130x80")) %>'
                                                            Visible='<%# string.IsNullOrEmpty(Eval("ImageUrl").ToString())? false : true %>'
                                                            style="padding:2px; float:left; width:130px; height:80px;" /> --%>
                                                            <p>
                                                                <%# Eval("Title")%>
                                                            </p>
                                                        </div>
                                                    </td>
                                                    <td>
                                                        <%# Eval("Desscription")%>
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblNewsState" runat="server" CssClass="Label" Text="Trạng thái hình ảnh" />:
                                                        <%# Eval("UsedStateName")%><br />
                                                        <asp:Label ID="lblLanguage" runat="server" CssClass="Label" Text="Ngôn ngữ" />:
                                                        <%# Eval("LanguageName  ")%><br />
                                                        <asp:Label ID="lblAuthor" runat="server" CssClass="Label" Text="Tác giả" />:
                                                        <%# Eval("Author")%><br />
                                                        <asp:Label ID="lblReference" runat="server" CssClass="Label" Text="Nguồn" />:
                                                        <%# Eval("Reference")%><br />
                                                    </td>
                                                    <td>
                                                        <asp:Label ID="lblCreatedBy" runat="server" CssClass="Label" Text="Người tạo" />:
                                                    <%# Eval("CreatedByName")%><br />
                                                        <asp:Label ID="lblCreatedDate" runat="server" CssClass="Label" Text="Ngày tạo" />:
                                                    <%# string.Format("{0:dd/MM/yyyy}", Eval("CreatedDate"))%><br />
                                                        <asp:Label ID="lblModifiedBy" runat="server" CssClass="Label" Text="Người sửa" />:
                                                    <%# Eval("ModifiedByName")%><br />
                                                        <asp:Label ID="lblModifiedDate" runat="server" CssClass="Label" Text="Ngày sửa" />:
                                                    <%# string.Format("{0:dd/MM/yyyy}", Eval("ModifiedDate"))%><br />
                                                    </td>
                                                    <td class="actions" data-id="<%#Eval("VideoID") %>">
                                                        <%=ucChucNang.ChucNang %>
                                                        <%--<a class="edit" href="javascript:void(0)" data-id="<%#Eval("VideoID") %>" title="Xóa"><i class="fa fa-edit (alias)"></i></a>--%>

                                                    </td>
                                                    <%--<td class=" actions"><a class="delete" href="javascript:void(0)" data-id="<%#Eval("VideoID") %>" title="Xóa"><i class="fa fa-trash-o"></i></a></td>--%>
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

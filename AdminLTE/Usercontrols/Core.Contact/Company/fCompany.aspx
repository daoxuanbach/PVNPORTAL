<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fCompany.aspx.cs" Inherits="AdminLTE.Usercontrols.Company.fCompany" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Loại liên hệ</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <button class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                        <button type="submit" id="btn-Update" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></button>
                    </div>
                </div>
            </div>

        </div>
        <div class="content ">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-default box-solid">
                        <div class="box-header with-border">
                            <h3 class="box-title">Thông tin công ty</h3>
                            <div class="box-tools pull-right">
                                <button type="button" class="btn btn-box-tool" data-widget="collapse">
                                    <i class="fa fa-minus"></i>
                                </button>
                            </div>
                            <!-- /.box-tools -->
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <asp:HiddenField ID="hidAction" runat="server" Value="add" />
                        <asp:HiddenField ID="hidID" runat="server" />
                        <input type="hidden" name="NgonNgu" value="<%=Pvn.Utils.Constants.Language.VIETNAMESE %>">
                        <input type="hidden" name="CompanyID" value="<%=objItemET.CompanyID %>">
                        <input type="hidden" id="lstThongTinLienHe" name="lstThongTinLienHe" value="">
                        <input type="hidden" id="ThongTinLienHeXoa" name="ThongTinLienHeXoa" value="">

                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên công ty	</label>
                                        <input type="text" class="form-control" name="CompanyName" tabindex="1" placeholder="Tên công ty" data-validation="required" value="<%=objItemET.CompanyName %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên quốc tế</label>
                                        <input type="text" class="form-control" name="InternationalName" tabindex="1" placeholder="Tên quốc tế" value="<%=objItemET.InternationalName %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên viết tắt	</label>
                                        <input type="text" class="form-control" name="ShortName" tabindex="1" placeholder="Tên viết tắt" value="<%=objItemET.ShortName %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Công ty cha	</label>
                                        <select class="form-control select2 " id="cboParentCompany" style="width: 100%;" name="ParentCompanyID" tabindex="2">
                                            <option value="">-- Gốc ---</option>
                                            <asp:Repeater ID="rptParentCompany" runat="server">
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
                                        <label>Loại công ty	</label>
                                        <select class="form-control select2 " id="cboCompanyLevel" style="width: 100%;" name="CompanyLevel" tabindex="2">
                                            <asp:Repeater ID="rptCompanyLevel" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Trạng thái</label>
                                        <select class="form-control select2 " id="cboUsedState" style="width: 100%;" name="UsedState" tabindex="2">
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
                                        <label>Thứ tự</label>
                                        <input type="number" class="form-control" name="OrderNumber" tabindex="1" placeholder="Thứ tự" value="<%=objItemET.OrderNumber %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                            </div>
                        </div>
                        <!-- /.box-body -->
                    </div>
                </div>
            </div>
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-default box-solid">
                        <div class="box-header with-border">
                            <h3 class="box-title">Thông tin liên hệ</h3>
                            <div class="box-tools pull-right">
                                <button type="button" id="btnThemMoiLH" class="btn btn-box-tool">
                                    <i class="fa fa-plus"></i><strong>Thêm chi tiết liên hệ</strong>
                                </button>
                            </div>
                            <!-- /.box-tools -->
                        </div>
                        <div class="box-body">
                            <table id="tb_loaiLienHe" class="table table-bordered table-striped table-hover">
                                <thead>
                                    <tr class="table-header">
                                        <th class="align-center">TT</th>
                                        <th class="col-xs-6">Tên liên hệ</th>
                                        <th class="col-xs-5">Tên loại liên hệ</th>
                                        <th class="align-center" scope="col">Xóa</th>
                                    </tr>
                                </thead>
                                <asp:Repeater ID="rptDatabind" runat="server">
                                    <ItemTemplate>
                                        <tr>
                                            <td class="Itemid" itemid="<%#Eval("ContactDetailID") %>"><%#(Container.ItemIndex + 1)%></td>
                                            <td><%#Eval("Contact") %></td>
                                            <td><%#Eval("ContactType") %></td>
                                            <td><a class='btn btnXoaRow'><i class='fa fa-times'></i></a></td>
                                        </tr>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </table>
                        </div>
                        <!-- /.box-body -->
                        <div style="display: none">
                            <select class='form-control select2 ' id='cboContactType' style='width: 100%;' name='ContactType' tabindex='2'>
                                <asp:Repeater ID='rptContactType' runat='server'>
                                    <ItemTemplate>
                                        <option value='<%#Eval("ContactTypeID") %>'><%#Eval("ContactType") %></option>
                                    </ItemTemplate>
                                </asp:Repeater>
                            </select>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
<script type="text/javascript">
    $(function () {
        document.title = "<%=Page.Title%>";
        $(".btn-back").click(function (event) {
            getPage("/UserControls/Core.Contact/Company/viewCompany.aspx?action=view");
            return false;
        });


        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                var arrID = GetThongTinLienHe();
                var jsonLienHe = JSON.stringify(arrID);
                $("#lstThongTinLienHe").val(jsonLienHe);
                var urlPostAction = '/UserControls/Core.Contact/Company/aCompany.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Core.Contact/Company/viewCompany.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        if ("<%=action%>" == "edit") {
            mybindingData();
        }
        $("#btnThemMoiLH").button().click(function () {
            var rowCount = $('#tb_loaiLienHe tr').length;
            //var newRow = "<tr class='delrow1' > <td class='left' align='center'>" + rowCount + "</td>";
            var newRow = "<tr id='tr_" + rowCount + "+ class='delrow1'>";
            newRow += " <td  class='Itemid' itemid='0'>" + rowCount + "</td>"
            newRow += "<td><input type='text' class='form-control Contact' data-validation='required' name='Contact' tabindex='1' placeholder='Tên liên hệ'> </td>";
            newRow += "<td><select class='form-control select2 ' id='cboContactType" + rowCount + "'' style='width: 100%;' name='ContactType' tabindex='2'></select></td>";
            newRow += "<td><a class='btn btnXoaRow'><i class='fa fa-times'></i></a> </td>";
            $($("#tb_loaiLienHe tr")[rowCount - 1]).after(newRow);
            $('#cboContactType option').clone().appendTo("#cboContactType" + rowCount);
            $(".select2").select2();
        });
        $('#tb_loaiLienHe').on('click', 'a.btnXoaRow', function () {
            var arrID = '';
            arrID = $("#ThongTinLienHeXoa").val();
            if (arrID != '') {
                arrID += ",";
            }
            var itemID = $(this).parents('tr').find('.Itemid').attr('itemid');
            if (itemID > 0) {
                arrID += itemID;
            }
            $("#ThongTinLienHeXoa").val(arrID);
            $(this).parents('tr').remove();
        });
    })
    function mybindingData() {
        $("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");
        $("#cboParentCompany").select2("val", "<%=objItemET.ParentCompanyID%>");
        $("#cboCompanyLevel").select2("val", "<%=objItemET.CompanyLevel%>");
    }
    function GetThongTinLienHe() {
        var ListThongTinLienHe = new Array();
        $("#tb_loaiLienHe tr").each(function () {
            var myObj = new Object();
            myObj.OwnerType = 1;
            myObj.UsedState = 1;
            myObj.Contact = $(this).find('.Contact').val();
            myObj.ContactDetailID = $(this).find('.Itemid').attr('itemid');
            if (myObj.Contact != undefined && myObj.ContactDetailID == 0) {
                myObj.ContactTypeID = $(this).find('.select2').val();
                ListThongTinLienHe.push(myObj);
            }
        });
        return ListThongTinLienHe;
    }
</script>

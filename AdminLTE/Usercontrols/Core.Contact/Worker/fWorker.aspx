<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fWorker.aspx.cs" Inherits="AdminLTE.Usercontrols.Worker.fWorker" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Worker</strong>
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
                            <h3 class="box-title">Thông tin nhân viên</h3>
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
                        <input type="hidden" name="WorkerID" value="<%=objItemET.WorkerID %>">
                        <input type="hidden" id="lstThongTinLienHe" name="lstThongTinLienHe" value="">
                        <input type="hidden" id="ThongTinLienHeXoa" name="ThongTinLienHeXoa" value="">

                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên</label>
                                        <input type="text" class="form-control" name="FirstName" tabindex="1" placeholder="Tên" data-validation="required" value="<%=objItemET.FirstName %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Họ và</label>
                                        <input type="text" class="form-control" name="LastName" tabindex="1" placeholder="Họ Và" value="<%=objItemET.LastName %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngày sinh</label>
                                                <div class='input-group date' id='divNgaySinh'>
                                                    <input type="text" class="form-control" data-format="dd/MM/yyyy" id="BornDate" name="BornDate" tabindex="3" placeholder="dd/MM/yyyy" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.BornDate) %>">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Mã NV</label>
                                        <input type="text" class="form-control" name="TaxCode" tabindex="1" placeholder="TaxCode" value="<%=objItemET.TaxCode %>">

                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-12">
                                            <div class="form-group">
                                                <div class="form-group">
                                                     <label>Giới tính</label>
                                                    <div class="radio">
                                                        <label>
                                                            <input type="radio" name="Sex" id="Sex2" value="1" <%=objItemET.Sex==true? "checked": "" %>> Nam
                                                        </label>
                                                   
                                                        <label>
                                                            <input type="radio" name="Sex" id="Sex3" value="0" <%=objItemET.Sex==true? "": "checked" %>>Nữ
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ảnh đại diện</label>
                                        <input type="hidden" id="newWinField" class="form-control" name="Images" hidden="hidden" value="">
                                        <div class="content-avatar">
                                            <div id="listImageAttach">
                                                <img id="pic1" src="/UserControls/images/thumbnail.jpg">
                                            </div>
                                            <div id="btnChonAnh" tabindex="5" style="">Chọn</div>
                                            <div id="btnXoaAnh" tabindex="6" style="">Xóa</div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Công ty 	</label>
                                        <select class="form-control select2 " id="cboCompany" style="width: 100%;" name="CompanyID" tabindex="2">
                                            <option value="">-- Gốc ---</option>
                                            <asp:Repeater ID="rptCompany" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("CompanyID") %>"><%#Eval("IndentedTitle") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Chức vụ	</label>
                                        <select class="form-control select2 " id="cboJobTitle" style="width: 100%;" name="JobTitleID" tabindex="2">
                                            <asp:Repeater ID="rptJobTitle" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("JobTitleID") %>"><%#Eval("JobTitle") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                
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
            getPage("/UserControls/Core.Contact/Worker/viewWorker.aspx?action=view");
            return false;
        });

        $('#divNgaySinh').datetimepicker({
            format: 'DD/MM/YYYY'
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
                var urlPostAction = '/UserControls/Core.Contact/Worker/aWorker.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Core.Contact/Worker/viewWorker.aspx?action=view");
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

        $('#btnChonAnh').on('click', function (e) {
            e.preventDefault();
            var top = window.screenTop + 50;
            var left = window.screenLeft + 50;
            window.open('/FileBrowser/FileBrowser.aspx?type=images&caller=opener&fn=newWinFn&langCode=en', 'fileBrowser', 'top=' + top + ',left=' + left + ',menubar=0,scrollbars=0,toolbar=0,height=550,width=700');
        });
        $('#btnXoaAnh').on('click', function (e) {
            $("#pic1").attr("src", "/UserControls/images/thumbnail.jpg");
            $('#newWinField').val("");
        });

    })
    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
    function mybindingData() {
        newWinFn("<%=objItemET.Images%>")
        $("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");
      $("#cboCompany").select2("val", "<%=objItemET.CompanyID%>");
      $("#cboJobTitle").select2("val", "<%=objItemET.JobTitleID%>");
    }
    function GetThongTinLienHe() {
        var ListThongTinLienHe = new Array();
        $("#tb_loaiLienHe tr").each(function () {
            var myObj = new Object();
            myObj.OwnerType = 2;
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

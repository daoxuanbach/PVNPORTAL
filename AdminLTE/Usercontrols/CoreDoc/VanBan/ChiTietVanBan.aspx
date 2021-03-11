<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ChiTietVanBan.aspx.cs" Inherits="AdminLTE.Usercontrols.VanBan.ChiTietVanBan" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Cập nhật văn bản </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase"> Gửi phê duyệt </strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <button class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                        <button style="display:none" type="submit" id="btn-Reject" class="btn btn-warning btn-sm pull-right"><i class="fa fa-check"></i><strong> Hủy phê duyệt </strong></button>
                        <button type="submit" id="btn-Update" class="btn btn-success btn-sm pull-right"><i class="fa fa-check"></i><strong> <%=btnsubmit %> </strong></button>
                    
                    </div>
                </div>
            </div>
        </div>
        <div class="content ">
            <div class="row">
                <div class="col-md-12">
                    <div class="box box-info">
                        <div class="box-header with-border">
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <asp:HiddenField ID="hidAction" runat="server" Value="add" />
                        <asp:HiddenField ID="hidID" runat="server" />
                        <input type="hidden" name="NgonNgu" value="<%=Pvn.Utils.Constants.Language.VIETNAMESE %>">
                        <input type="hidden" name="VanBanID" value="<%=objItemET.VanBanID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Số văn bản </label>
                                        <input type="text" readonly="readonly" class="form-control" name="SoVanBan" tabindex="1" placeholder="Số văn bản" data-validation="required" value="<%=objItemET.SoVanBan %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Loại văn bản </label>
                                        <select disabled="disabled" class="cboLoaiVanBan form-control select2" style="width: 100%" id="LoaiVanBanID" tabindex="1" name="LoaiVanBanID">
                                            <asp:Repeater ID="rptLoaiVanBan" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("LoaiVanBanID") %>"><%#Eval("IndentedTitle") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trích yếu </label>
                                        <textarea readonly="readonly" class="form-control" rows="5"  name="TieuDe" tabindex="3" placeholder="Trích yếu" data-validation="required"><%=objItemET.TieuDe %></textarea>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngày ban hành </label>
                                                <div class='input-group date' id='divNgayBanhanh'>
                                                    <input  readonly="readonly" type="text" class="form-control" data-format="dd/MM/yyyy" id="NgayBanhanh" name="NgayBanHanh" tabindex="11" placeholder="Ngày ban hành" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.NgayBanHanh) %>">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6">
                                            <div class="form-group">
                                                <label>Ngày hiệu lực </label>
                                                <div class='input-group date' id='divNgayHieuLuc'>
                                                    <input  readonly="readonly" type="text" class="form-control" data-format="dd/MM/yyyy" id="NgayHieuLuc" name="NgayHieuLuc" tabindex="11" placeholder="Ngày hiệu lực" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.NgayHieuLuc) %>">
                                                    <span class="input-group-addon">
                                                        <span class="glyphicon glyphicon-calendar"></span>
                                                    </span>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Lĩnh vực </label>
                                        <select  disabled="disabled" class="cboLinhVuc form-control select2" style="width: 100%" id="LinhVucID" tabindex="1" name="LinhVucID">
                                            <option value="">----Chọn----</option>
                                            <asp:Repeater ID="rptLinhVuc" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("LinhVucID") %>"><%#Eval("Ten") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Đơn vị ban hành</label>
                                        <select  disabled="disabled" class="cboLinhVuc form-control select2" style="width: 100%" id="DonViBanHanhID" tabindex="1" name="DonViBanHanhID">
                                            <option value="">----Chọn----</option>
                                            <asp:Repeater ID="rptDonViBanHanh" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("DonViBanHanhID") %>"><%#Eval("Ten") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="row">
                                            <div class="col-md-12">
                                               <%if (objItemET.DuongDanVanBan != null){%>
                                                <a target="_blank" href="<%=objItemET.DuongDanVanBan%>" class="btn btn-primary"><i class="fa fa-download"></i> File Văn bản </a>
                                                <%} else{ %>
                                                 <a  href="#" class="btn btn-primary"><i class="fa fa-download"></i>Chưa tải File</a>
                                                <%} %>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label> Nội dung văn bản </label>
                                        <textarea  readonly="readonly" cols="80" id="editor" name="NoiDungVanBan" tabindex="15" rows="10"><%=objItemET.NoiDungVanBan %></textarea>
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                        </div>
                        <!-- /.box-footer -->

                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


<script type="text/javascript">
    $(function () {
        if ("<%=action%>" == "xuatban") {
            $("#btn-Reject").show();
        }
        CKEDITOR.replace('editor');
        document.title = "<%=Page.Title%>";
        $(".btn-back").click(function (event) {
            getPage("/UserControls/CoreDoc/VanBan/viewVanBan.aspx?action=view");
            return false;
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                var editorText = CKEDITOR.instances.editor.getData();
                $('#editor').val(editorText);
                var urlPostAction = '/UserControls/CoreDoc/VanBan/aVanBan.ashx';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/CoreDoc/VanBan/viewVanBan.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $('#divNgayHieuLuc').datetimepicker({
            format: 'DD/MM/YYYY'
        });

        $('#divNgayBanhanh').datetimepicker({
            format: 'DD/MM/YYYY'
        });
        $(".select2").select2();
        mybindingData();
    })
    function setDuongDanVanBan(fileurl) {
        $('#DuongDanVanBan').val(fileurl);
    }
    function mybindingData() {

        $("#DonViBanHanhID").select2("val", "<%=objItemET.DonViBanHanhID%>");
        $("#LinhVucID").select2("val", "<%=objItemET.LinhVucID%>");
        <%--if ("<%=objItemET.TrangThaiSuDung%>" != "") {
            $("#cbTrangThaiSuDung").select2("val", "<%=objItemET.TrangThaiSuDung%>");
        }--%>

    }

</script>

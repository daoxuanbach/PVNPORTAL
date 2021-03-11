<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fDonViBanHanh.aspx.cs" Inherits="AdminLTE.Usercontrols.DonViBanHanh.fDonViBanHanh" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Đơn Vị Ban Hành</strong>
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
                    <div class="box box-info">
                        <div class="box-header with-border">
                        </div>
                        <!-- /.box-header -->
                        <!-- form start -->

                        <asp:HiddenField ID="hidAction" runat="server" Value="add" />
                        <asp:HiddenField ID="hidID" runat="server" />
                        <input type="hidden" name="NgonNgu" value="<%=Pvn.Utils.Constants.Language.VIETNAMESE %>">
                        <input type="hidden" name="DonViBanHanhID" value="<%=objItemET.DonViBanHanhID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Mã</label>
                                        <input type="text" class="form-control" name="Ma" tabindex="1" placeholder="Mã" data-validation="required" value="<%=objItemET.Ma %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên viết tắt</label>
                                        <input type="text" class="form-control" name="TenVietTat" tabindex="3" placeholder="Tên viết tắt" value="<%=objItemET.TenVietTat %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tên</label>
                                        <input type="text" class="form-control" name="Ten" tabindex="3" placeholder="Tên" data-validation="required" value="<%=objItemET.Ten %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trạng thái</label>
                                        <select class="form-control select2 " id="cbTrangThaiSuDung" style="width: 100%;" name="TrangThaiSuDung" tabindex="5">
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
        document.title = "<%=Page.Title%>";
        $(".btn-back").click(function (event) {
            getPage("/UserControls/CoreDoc/DonViBanHanh/viewDonViBanHanh.aspx?action=view");
            return false;
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/CoreDoc/DonViBanHanh/aDonViBanHanh.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/CoreDoc/DonViBanHanh/viewDonViBanHanh.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        mybindingData();
    })
    function mybindingData() {
      
        if ("<%=objItemET.TrangThaiSuDung%>" !="") {
              $("#cbTrangThaiSuDung").select2("val", "<%=objItemET.TrangThaiSuDung%>");
        }
      
    }

</script>

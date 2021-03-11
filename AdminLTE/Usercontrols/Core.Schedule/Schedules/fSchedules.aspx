<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fSchedules.aspx.cs" Inherits="AdminLTE.Usercontrols.Schedules.fSchedules" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Lịch công tác</strong>
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
                        <input type="hidden" name="ScheduleID" value="<%=objItemET.ScheduleID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-10">
                                    <div class="form-group">
                                        <label>Tiêu đề </label>
                                        <input type="text" class="form-control" name="Title" tabindex="1" placeholder="Tiêu đề " data-validation="required" value="<%=objItemET.Title %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-10">
                                    <div class="form-group">
                                        <label>Chi tiết</label>
                                        <textarea class="form-control" tabindex="2" rows="3" id="Descriptions" name="Descriptions"> <%=objItemET.Descriptions %> </textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Ngày bắt đầu </label>
                                        <div class='input-group date' id='divBeginDate'>
                                            <input type="text" class="form-control" data-format="dd/MM/yyyy HH:mm:ss PP" id="BeginDate" name="BeginDate" tabindex="13" placeholder="Bắt đầu"  value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.BeginDate) %>">
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Ngày kết thúc </label>
                                        <div class='input-group date' id='divEndDate'>
                                            <input type="text" class="form-control" data-format="MM/dd/yyyy HH:mm:ss PP" id="EndDate" name="EndDate" tabindex="14" placeholder="Kết thúc"  value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.EndDate) %>">
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>
                              <div class="row">
                                <div class="col-md-10">
                                    <div class="form-group">
                                        <label>Địa điểm</label>
                                        <textarea class="form-control" tabindex="2" rows="3" id="ToAddress" name="ToAddress"> <%=objItemET.ToAddress %> </textarea>
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:CheckBox runat="server" ID="chkActive"  Checked="true" Text="Active" />
                                    </div>
                                </div>
                            </div>
                             <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <asp:CheckBox  runat="server" ID="chkPrivate" Checked="true" Text="Private" />
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Chủ trì</label>
                                        <select class="form-control select2 " id="cboChuTri" style="width: 100%;" name="ChuTri" tabindex="2">
                                             <option value=""> --- Chọn ---</option>
                                            <asp:Repeater ID="rptChuTri" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("ManagerID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-5">
                                    <div class="form-group">
                                        <label>Lãnh đạo</label>
                                        <select class="form-control select2 " id="cboLanhDao" style="width: 100%;" name="LanhDao" tabindex="2">
                                             <option value=""> --- Chọn ---</option>
                                            <asp:Repeater ID="rptLanhDao" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("ManagerID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                
                            </div>
                            <div class="row">
                                <div class="col-md-10">
                                    <div class="form-group">
                                        <label>Lãnh đạo tham gia</label>
                                        <select multiple class="form-control select2" id="cboLanhDaoThamGia" style="width: 100%;" name="LanhDaoThamGia" tabindex="2">
                                            <asp:Repeater ID="rptLanhDaoThamGia" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("ManagerID") %>"><%#Eval("Name") %></option>
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
            getPage("/UserControls/Core.Schedule/Schedules/viewSchedules.aspx?action=view");
            return false;
        });
        $('#divBeginDate').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });
        $('#divEndDate').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/Core.Schedule/Schedules/aSchedules.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Core.Schedule/Schedules/viewSchedules.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });
        $(".select2").select2();
        if ("<%=action%>" == "edit") {
            mybindingData();
        }
    })
    function mybindingData() {
       var selectedValues = JSON.parse('<%=lstManagerIDJSon%>');
       $("#cboLanhDaoThamGia").val(selectedValues).trigger("change");
       $("#cboChuTri").select2("val", "<%=chutri%>");
       $("#cboLanhDao").select2("val", "<%=lanhdao%>");
    }

</script>

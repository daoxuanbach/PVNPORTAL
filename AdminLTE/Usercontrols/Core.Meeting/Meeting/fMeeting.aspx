<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fMeeting.aspx.cs" Inherits="AdminLTE.Usercontrols.Meeting.fMeeting" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Lịch họp</strong>
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
                        <input type="hidden" name="MeetingID" value="<%=objItemET.MeetingID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ngày họp</label>
                                         <div class='input-group date' id='divMeetingDate'>
                                            <input type="text" class="form-control" data-format="dd/MM/yyyy HH:mm:ss PP" id="txtMeetingDate" name="MeetingDate" tabindex="13" placeholder="Thời gian họp" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.MeetingDate) %>">
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
                                        <label>Phòng họp</label>
                                        <select class="form-control select2 " id="cboRoom" style="width: 100%;" name="RoomID" tabindex="3">
                                            <asp:Repeater ID="rptRoom" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("RoomID") %>"><%#Eval("RoomName") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tiêu đề</label>
                                        <input type="text" class="form-control" name="Title" tabindex="1" placeholder="Tiêu đề" data-validation="required" value="<%=objItemET.Title %>">
                                    </div>
                                </div>
                            </div>
                           
                            <div class="row">
                                <div class="col-md-6">
                                        <div class="radio">
                                            <label>
                                                <input type="radio" name="Active" id="Active" value="1" <%=objItemET.Active==true? "checked": "" %>>Hiển thị
                                            </label>
                                               <label>
                                                <input type="radio" name="Active" id="Active1" value="0" <%=objItemET.Active==true? "": "checked" %>>Không
                                            </label>
                                        </div>
                                    </div>
                            </div>
                             <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ghi chú</label>
                                        <input type="text" class="form-control" name="Note" tabindex="1" placeholder="Note" value="<%=objItemET.Note %>">
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
        $('#divMeetingDate').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });
        document.title = "<%=Page.Title%>";
        $(".btn-back").click(function (event) {
            getPage("/UserControls/Core.Meeting/Meeting/viewMeeting.aspx?action=view");
            return false;
        });
        $.validate({
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/Core.Meeting/Meeting/aMeeting.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Core.Meeting/Meeting/viewMeeting.aspx?action=view");
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
        $("#cboRoom").select2("val", "<%=objItemET.RoomID%>");
    }

</script>

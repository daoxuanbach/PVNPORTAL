<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fEventList.aspx.cs" Inherits="AdminLTE.Usercontrols.EventList.fEventList" %>

<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frmCMSNews">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Cập nhật EVENT</strong>
            </div>
            <div class="col-xs-6"> 
                <div class="form-inline text-right">
                    <div class="form-group">
                        <button class="btn-back btn btn-info btn-sm pull-right" tabindex="20"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                        <div tabindex="18" class="btn-Update btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></div>
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

                        <input type="hidden" id="hidAction" name="hidAction" value="add">
                        <input type="hidden" name="EventID" value="<%=objItemET.EventID %>">
                        <input type="hidden" name="UserID" value="<%=UserID  %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Tên thông báo</label>
                                        <input type="text" class="form-control" name="Name" tabindex="1" placeholder="Tiêu đề" data-validation="required" value="<%=objItemET.Name %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Loại thông báo</label>
                                        <select class="form-control select2 " id="cboEventType" style="width: 100%;" name="EventType" tabindex="3">
                                            <asp:Repeater ID="rptEventType" runat="server">
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
                                        <input type="number"  class="form-control" name="Ordinal" tabindex="9" placeholder="Thư tự" value=" <%=objItemET.Ordinal %>">
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Bắt đầu</label>
                                        <div class='input-group date' id='divBeginDate'>
                                            <input type="text" class="form-control" data-format="dd/MM/yyyy HH:mm:ss PP" id="txtBeginDate" name="BeginDate" tabindex="13" placeholder="Bắt đầu" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.BeginDate) %>">
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Kết thúc</label>
                                        <div class='input-group date' id='divEndDate'>
                                            <input type="text" class="form-control" data-format="MM/dd/yyyy HH:mm:ss PP" id="txtEndDate" name="EndDate" tabindex="14" placeholder="Kết thúc" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.EndDate) %>">
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Địa điểm		</label>
                                        <textarea class="form-control" tabindex="2" rows="3" id="EventPlace" name="EventPlace"> <%=objItemET.EventPlace %> </textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Đơn vị tổ chức	</label>
                                        <textarea class="form-control" tabindex="2" rows="3" id="OrgaUnit" name="OrgaUnit"> <%=objItemET.OrgaUnit %> </textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <div class="col-sm-12">
                                            <div class="checkbox">
                                                <label>
                                                    <input name="Estimate" type="checkbox" <%=objItemET.Estimate!=true?"":"checked='checked'"%> >
                                                    Dự kiến	
                                                </label>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Chi tiết	</label>
                                        <textarea cols="80" id="editor" name="Body" tabindex="15" rows="10"><%=objItemET.Body %></textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Ghi chú	</label>
                                        <textarea class="form-control" tabindex="2" rows="3" id="Note" name="Note"> <%=objItemET.Note %> </textarea>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <div class="form-group">
                                <button class="btn-back btn btn-info btn-sm pull-right" tabindex="17"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                                <div class="btn-Update btn btn-info btn-sm pull-right" tabindex="16"><i class="fa fa-check"></i><strong>Cập nhật</strong></div>
                            </div>
                        </div>
                        <!-- /.box-footer -->

                    </div>
                </div>
            </div>
        </div>

    </form>
</body>

<script type="text/javascript">
    var selectedValues;
    $(document).ready(function () {
        CKEDITOR.replace('editor');
        $('#divBeginDate').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });
        $('#divEndDate').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });
        document.title = "<%=Page.Title%>";
        $(".btn-back").click(function (event) {
            getPage("/UserControls/EventList/viewEventList.aspx?action=view");
            return false;
        });
        $(".btn-Update").click(function (event) {
            if ("<%=action%>" == "edit") {
                $("#hidAction").val("upd");
            }
            else {
                $("#hidAction").val("add");
            }
            $("#frmCMSNews").submit();
        });
        
        $.validate({
            modules: 'security',
            form: '#frmCMSNews',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                var editorText = CKEDITOR.instances.editor.getData();
                $('#editor').val(editorText);
                var urlPostAction = '/UserControls/EventList/aEventList.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/EventList/viewEventList.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });

        $(".select2").select2();
        mybindingData();
    })
    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
    function formatState(state) {
        if (!state.id) { return state.text; }
        var $state = $(
            '<span><img src="' + state.element.getAttribute('coquocgia') + '" class="img-flag" /> ' + state.text + '</span>'
        );
        return $state;
    };
    function mybindingData() {
    $("#cboEventType").select2("val", "<%=objItemET.EventType%>");
        if ("<%=action%>" == "edit") {
           // alert("<%=objItemET.EventType%>");
            //$(".cboEventType").select2("val", "<%=objItemET.EventType%>");
        }
    }
    CKEDITOR.editorConfig = function (config) {
        config.filebrowserBrowseUrl = 'http:/FileBrowser/FileBrowser.aspx?type=files';
        config.filebrowserImageBrowseUrl = 'http:/FileBrowser/FileBrowser.aspx?type=images';
        config.filebrowserFlashBrowseUrl = '/FileBrowser/FileBrowser.aspx?type=flash';
    };
</script>


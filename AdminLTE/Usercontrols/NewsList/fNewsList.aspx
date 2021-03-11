<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fNewsList.aspx.cs" Inherits="AdminLTE.Usercontrols.NewsList.fNewsList" %>
<%@ Register Src="~/Usercontrols/ucChucNang.ascx" TagPrefix="uc1" TagName="ucChucNang" %>

<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frmCMSNews">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Cập nhật tin</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <asp:PlaceHolder ID="plhChucNangTop" runat="server"></asp:PlaceHolder>
                       <%-- <button class="btn-back btn btn-info btn-sm pull-right" tabindex="20"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                        <div tabindex="19" class="btn-Update-Publich btn btn-info btn-sm pull-right">
                            <i class="fa fa-check"></i><strong>
                                <asp:Label ID="btnUpdateAnd" runat="server"></asp:Label></strong>
                        </div>
                        <div tabindex="18" class="btn-Update btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></div>--%>
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
                        <input type="hidden" name="NewsState" value="<%=objItemET.NewsState %>">
                        <input type="hidden" name="Version" value="<%=objItemET.Version %>">
                        <input type="hidden" id="hidAction" name="hidAction" value="add">
                        <input type="hidden" name="NewsID" value="<%=objItemET.NewsID %>">
                        <input type="hidden" name="UserID" value="<%=UserID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Tiêu đề</label>
                                        <input type="text" class="form-control" name="Title" tabindex="1" placeholder="Tiêu đề" data-validation="required" value="<%=objItemET.Title %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Tóm tắt	</label>
                                        <textarea class="form-control" tabindex="2" rows="3" id="Summary" name="Summary"> <%=objItemET.Summary %> </textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-2">
                                    <div class="form-group">
                                        <label>Language</label>
                                        <select class="form-control cboLanguage" id="cboLanguage" style="width: 100%" tabindex="10" name="Language">
                                            <asp:Repeater ID="rptLanguage" runat="server">
                                                <ItemTemplate>
                                                    <option  value="<%#Eval("Value") %>"><%#Eval("Note") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-4">
                                    <div class="form-group">
                                        <label>Thuộc chuyên mục chính</label>
                                        <select class="form-control select2 " id="cboCategoryID"  data-validation="required" style="width: 100%;" name="CategoryID" tabindex="3">
                                             <option value=""> -- Chọn --</option>
                                            <asp:Repeater ID="rptCategoryID" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("CategoryID") %>"><%#Eval("IndentedTitle") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Danh sách chuyên mục </label>
                                        <select class="form-control select2" multiple="multiple" style="width: 100%" id="cboListCategory" tabindex="4" name="ListCategory">
                                            <option value="">-- Tất cả ---</option>
                                            <asp:Repeater ID="rptListCategory" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("CategoryID") %>"><%#Eval("IndentedTitle") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Ảnh hiển thị</label>
                                        <input type="hidden" id="newWinField" class="form-control" name="ImageURL" hidden="hidden" placeholder="Ảnh hiển thị" value="">
                                        <div class="content-avatar">
                                            <div id="listImageAttach">
                                                <img id="pic1" src="/UserControls/images/thumbnail.jpg">
                                            </div>
                                            <div id="btnChonAnh" tabindex="5" style="">Chọn</div>
                                            <div id="btnXoaAnh" tabindex="6" style="">Xóa</div>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="row">
                                        <div class="form-group">
                                            <label>Tiêu đề ảnh hiển thị</label>
                                            <input type="text" class="form-control" name="ImageTitle" tabindex="7" placeholder="Tiêu đề ảnh hiển thị" value="<%=objItemET.ImageTitle %>">
                                        </div>
                                    </div>
                                    <div class="row">
                                        <div class="col-md-6 pading-left-0">
                                            <div class="form-group">
                                                <label>Tác giả</label>
                                                <input type="text" class="form-control" name="Author" tabindex="8" placeholder="Tác giả" value="<%=objItemET.Author %>">
                                            </div>
                                        </div>
                                        <div class="col-md-6 pading-left-0">
                                            <div class="form-group">
                                                <label>Nguồn cung cấp tin</label>
                                                <input type="text" class="form-control" name="Reference" tabindex="9" placeholder="Nguồn cung cấp tin" value="<%=objItemET.Reference %>">
                                            </div>
                                        </div>
                                    </div>

                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="form-group">
                                        <label>Mức độ ưu tiên</label>
                                        <select class="form-control select2" id="cboPriorityPublishing" style="width: 100%" tabindex="12" name="PriorityPublishing">
                                            <asp:Repeater ID="rptPriorityPublishing" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group" style="display:none">
                                        <label>Ngày xuất bản</label>

                                        <div class='input-group date' id='divPublishedDate'>
                                            <input type="text" class="form-control" data-format="dd/MM/yyyy h:mm tt" id="txtPublishedDate" name="PublishedDate" tabindex="11" placeholder="Ngày xuất bản" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.PublishedDate) %>">
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Ngày xuất bản</label>
                                        <div class='input-group date' id='divBeginPriority'>
                                            <input type="text" class="form-control" data-format="dd/MM/yyyy HH:mm:ss PP"  data-validation="required" id="txtBeginPriority" name="BeginPriority" tabindex="13" placeholder="Bắt đầu" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.BeginPriority) %>">
                                            <span class="input-group-addon">
                                                <span class="glyphicon glyphicon-calendar"></span>
                                            </span>
                                        </div>

                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Kết thúc</label>

                                        <div class='input-group date' id='divEndPriority'>
                                            <input type="text" class="form-control" data-format="MM/dd/yyyy HH:mm:ss PP" id="txtEndPriority" name="EndPriority" tabindex="14" placeholder="Kết thúc" value="<%=Pvn.Utils.formatUtils.formatDateToString(objItemET.EndPriority) %>">
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
                                        <label>Thông tin chi tiết</label>
                                        <textarea cols="80" id="editor" name="Information" tabindex="15" rows="10"><%=objItemET.Information %></textarea>
                                    </div>
                                </div>
                            </div>
                            <%-- <textarea type="hidden" id="idInformation" name="Information" /> 
                            --%>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Từ khóa cách nhau bởi dấu phẩy (,)</label>
                                        <input type="text" class="form-control" name="NewsKeyword" tabindex="16" placeholder="Tiêu đề" value="<%=objItemET.strNewsKeyword %>">
                                    </div>
                                </div>
                            </div>

                        </div>
                        <!-- /.box-body -->
                        <div class="box-footer">
                            <div class="form-group">
                                 <asp:PlaceHolder ID="plhChucNangBottom" runat="server"></asp:PlaceHolder>
                                <%--<button class="btn-back btn btn-info btn-sm pull-right" tabindex="17"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</button>
                                <div tabindex="19" class="btn-Update-Publich btn btn-info btn-sm pull-right">
                                    <i class="fa fa-check"></i><strong>
                                        <asp:Label ID="btnUpdateAnd2" runat="server"></asp:Label></strong>
                                </div>
                                <div class="btn-Update btn btn-info btn-sm pull-right" tabindex="16"><i class="fa fa-check"></i><strong>Cập nhật</strong></div>--%>
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
        //CKEDITOR.replace('editor');
        CKEDITOR.replace('editor', {
            extraPlugins: 'embed'
        });
        $('#divBeginPriority').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });
        $('#divEndPriority').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });

        $('#divPublishedDate').datetimepicker({
            format: 'DD/MM/YYYY hh:mm A'
        });

        $(".btn-back").click(function (event) {
            getPage("/UserControls/NewsList/viewNewsList.aspx?action=view");
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
        $(".btn-Update-Publich").click(function (event) {
            if ("<%=action%>" == "edit") {
                $("#hidAction").val("updNewsAndNewsPublich");
            }
            else {
                $("#hidAction").val("addPublich");
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
                var urlPostAction = '/UserControls/NewsList/aNewsList.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/NewsList/viewNewsList.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });

        $(".select2").select2();
       
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
        $('.cboLanguage').on('select2:select', function () {
            $.post("/UserControls/Service/getChuyenMucByNgonNgu.ashx", { "NgonNgu": $(this).val() }, function (data) {
                $("#cboCategoryID").html(data);
                $("#cboCategoryID").trigger("chosen:updated");
            });
        });
        mybindingData();
    })
    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
   
    function mybindingData() {
        $('.btn-Update-Publich').find("strong").text("<%=btnUpdateAnd%>");
        if ("<%=action%>" == "edit") {
            selectedValues = JSON.parse('<%=ListCategoryJSon%>');
            newWinFn("<%=objItemET.ImageURL %>");
            $("#cboCategoryID").select2("val", "<%=objItemET.CategoryID%>");
            $(".cboLanguage").select2("val", "<%=objItemET.Language%>");
            $("#cboPriorityPublishing").select2("val", "<%=objItemET.PriorityPublishing%>");
            $("#cboListCategory").val(selectedValues).trigger("change");
        }
    }
    CKEDITOR.editorConfig = function (config) {

        config.extraPlugins = 'embed';
    };
</script>


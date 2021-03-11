<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fMenu.aspx.cs" Inherits="AdminLTE.Usercontrols.Menu.fMenu" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Cập nhật thông tin menu</strong>
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
                        <input type="hidden" name="MenuID" value="<%=objItemET.MenuID %>">
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Language</label>
                                        <select class="form-control cboLanguage" id="cboLanguage" tabindex="1" name="Language">
                                            <asp:Repeater ID="rptLanguage" runat="server">
                                                <ItemTemplate>
                                                    <option  value="<%#Eval("Value") %>"><%#Eval("Note") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trạng thái sử dụng</label>
                                        <select data-validation="required" class="form-control select2 " id="cbUsedState" style="width: 100%;" name="UsedState" tabindex="2">
                                            <asp:Repeater ID="rptUsedState" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Mã</label>
                                        <input type="text" class="form-control" name="Code" tabindex="3" placeholder="Mã chuyên mục" value="<%=objItemET.Code %>">
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tiêu đề</label>
                                        <input type="text" class="form-control" name="Title" tabindex="4" placeholder="Tiêu đề" data-validation="required" value="<%=objItemET.Title %>">
                                    </div>
                                </div>
                            </div>

                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Menu cha </label>
                                        <select class="cboParentMenuID form-control select2" style="width: 100%" id="cboParentMenuID" tabindex="5" name="ParentMenuID">
                                            <option value="">-- Gốc --</option>
                                            <asp:Repeater ID="rptParentMenuID" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("MenuID") %>"><%#Eval("Title") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>

                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Vị trí </label>
                                        <select data-validation="required" class="cboMenuPosition form-control select2" style="width: 100%" id="cboMenuPosition" tabindex="6" name="MenuPosition">
                                            <option value="">-- Tất cả --</option>
                                            <asp:Repeater ID="rptMenuPosition" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Loại đối tượng </label>
                                        <select class="cboObjectType form-control select2" data-validation="required" style="width: 100%" id="cboObjectType" tabindex="7" name="ObjectType">
                                            <option value="">-- Chọn --</option>
                                            <asp:Repeater ID="rptObjectType" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("Value") %>"><%#Eval("Note") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Chuyên mục </label>
                                        <select class="form-control select2" style="width: 100%" id="cboCategoryID" tabindex="8" name="CategoryID">
                                            <option value="">-- Tất cả ---</option>
                                            <asp:Repeater ID="rptParentCategoryID" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("CategoryID") %>"><%#Eval("IndentedTitle") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>

                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tin bài </label>
                                        <select class="cboNewsPublishingID form-control select2" style="width: 100%" id="cboNewsPublishingID" tabindex="9" name="NewsPublishingID">
                                            <asp:Repeater ID="rptNewsPublishingID" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("NewsPublishingID") %>"><%#Eval("Title") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Đường dẫn</label>
                                        <input type="text" data-validation="required" class="form-control" name="URL" tabindex="10" placeholder="Tiêu đề" value="<%=objItemET.URL %>">
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <div class="checkbox">
                                            <label>
                                                <input type="checkbox" name="IsNewWindow" id="IsNewWindow" tabindex="11">
                                                Mở cửa sổ mới
                                            </label>
                                        </div>
                                    </div>
                                </div>
                                <div class="col-md-3">
                                    <div class="form-group">
                                        <label>Số thứ tự</label>
                                        <input type="text" class="form-control" name="Ordinal" tabindex="12" placeholder="Mã chuyên mục" value="<%=objItemET.Ordinal %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <div class="form-group">
                                            <label>Ảnh hiển thị</label>
                                            <input type="hidden" id="newWinField" class="form-control" name="ImageURL" hidden="hidden" placeholder="Ảnh hiển thị" value="">
                                            <div class="content-avatar">
                                                <div id="listImageAttach">
                                                    <img id="pic1" src="/UserControls/images/thumbnail.jpg">
                                                </div>
                                                <div id="btnChonAnh" tabindex="13" style="">Chọn</div>
                                                <div id="btnXoaAnh" tabindex="14" style="">Xóa</div>
                                            </div>
                                        </div>


                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Tiêu đề ảnh hiển thị</label>
                                        <input type="text" class="form-control" name="ImageTitle" tabindex="15" placeholder="Tiêu đề" value="<%=objItemET.ImageTitle %>">
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Tóm tắt	</label>
                                        <textarea class="form-control" tabindex="16" rows="3" id="txtSummary" name="Summary"> <%=objItemET.Summary %> </textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Ghi chú</label>
                                        <textarea class="form-control" tabindex="17" rows="3" id="txtNote" name="Note"> <%=objItemET.Note %> </textarea>
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
            getPage("/UserControls/Menu/viewMenu.aspx?action=view");
            return false;
        });
        $.validate({
            modules: 'security',
            form: '#frm',
            onError: function ($form) {
                //alert('Validation of form ' + $form.attr('id') + ' failed!');
            },
            onSuccess: function ($form) {
                // alert('ok');
                var urlPostAction = '/UserControls/Menu/aMenu.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("Thongbao", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Menu/viewMenu.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
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
        $(".select2").select2();
        mybindingData();

     
        $(".cboLanguage").select2("val", "<%=objItemET.Language%>");
        $("#cboCategoryID").select2("val", "<%=objItemET.ObjectID%>");
        $("#cboNewsPublishingID").select2("val", "<%=objItemET.Note%>");
        $('.cboLanguage').on('select2:select', function () {
            $.post("/UserControls/Menu/GetParentMenu.ashx", { "NgonNgu": $(this).val(), "Position": $("#cboMenuPosition").val() }, function (data) {
                $("#cboParentMenuID").html(data);
                $("#cboParentMenuID").trigger("chosen:updated");
            });

            $.post("/UserControls/Menu/getChuyenMucByNgonNgu.ashx", { "NgonNgu": $(this).val() }, function (data) {
                $("#cboCategoryID").html(data);
                $("#cboCategoryID").trigger("chosen:updated");
            });
        });
        $('#cboCategoryID').on('select2:select', function () {
            $.post("/UserControls/Menu/getTinByChuyenMuc.ashx", { "NgonNgu": $(".cboLanguage").val(), "CategoryID": $("#cboCategoryID").val() }, function (data) {
                $("#cboNewsPublishingID").html(data);
                $("#cboNewsPublishingID").trigger("chosen:updated");
            });
        });
    })
    function newWinFn(fileurl) {
        $("#pic1").attr("src", fileurl);
        $('#newWinField').val(fileurl);
    }
  
    function mybindingData() {
        if ("<%=action%>" == "edit") {
            $("#cbUsedState").select2("val", "<%=objItemET.UsedState%>");
            $("#cboMenuPosition").select2("val", "<%=objItemET.MenuPosition%>");
            $("#cboObjectType").select2("val", "<%=objItemET.ObjectType%>");
            $("#cbUsedState").select2("val", "<%=objItemET.UsedState%>");
            if ("<%=objItemET.IsNewWindow%>" == "True") {
                $('#IsNewWindow').attr('checked', true)
            }
            $("#cboParentMenuID").select2("val", "<%=objItemET.ParentMenuID%>");
        }

    }
</script>

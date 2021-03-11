<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="fCategorylist.aspx.cs" Inherits="AdminLTE.Usercontrols.Categorylist.fCategorylist" %>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">Cập nhật thông tin chuyên mục</strong>
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
                        <input type="hidden" name="CategoryID" value="<%=objItemET.CategoryID %>">
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
                                                    <option value="<%#Eval("MaNgonNgu") %>"><%#Eval("TenNgonNgu") %> 
                                                    </option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Trạng thái sử dụng</label>
                                        <select class="form-control select2 " id="cboUsedState" style="width: 100%;" name="UsedState" tabindex="2">
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
                                        <label>Mã chuyên mục</label>
                                        <input type="text" class="form-control" name="Code" tabindex="3" placeholder="Mã chuyên mục" data-validation="required" value="<%=objItemET.Code %>">
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
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Tóm tắt	</label>
                                        <textarea class="form-control" tabindex="5" rows="3" id="Summary" name="Summary"> <%=objItemET.Summary %> </textarea>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Chuyên mục cha </label>
                                        <select class="form-control select2" style="width: 100%" id="cboParentCategoryID" tabindex="6" name="ParentCategoryID">
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
                                        <label>Số thứ tự hiển thị	</label>
                                        <input type="text" class="form-control" name="Ordinal" tabindex="7" placeholder="Số thứ tự hiển thị" value="<%=objItemET.Ordinal %>">
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
            getPage("/UserControls/Categorylist/viewCategorylist.aspx?action=view");
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
                var urlPostAction = '/UserControls/Categorylist/aCategorylist.ashx?action=add';
                $.post(urlPostAction, $form.find("input,textarea,select,hidden").not("#__VIEWSTATE,#__EVENTVALIDATION").serialize(), function (data) {
                    if (data.Error) {
                        createMessagewarning("Thongbao", data.Message);
                    }
                    else {
                        //createMessagesuccess("content", data.Message);
                        displayOverlay(data.Message);
                        getPage("/UserControls/Categorylist/viewCategorylist.aspx?action=view");
                    }
                });
                return false;// Will stop the submission of the form
            }
        });

        $(".select2").select2();
        mybindingData();

    })
   
    function mybindingData() {
        $("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");
        if ("<%=action%>" == "edit") {
            $("#cboUsedState").select2("val", "<%=objItemET.UsedState%>");
           
            $("#cboParentCategoryID").select2("val", "<%=objItemET.ParentCategoryID%>");
        }

    }
</script>

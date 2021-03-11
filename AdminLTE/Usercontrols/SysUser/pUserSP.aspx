<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pUserSP.aspx.cs" Inherits="AdminLTE.Usercontrols.SysUser.pUserSP" %>
<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Thêm mới </title>
</head>
<body>
    <form runat="server" id="frm"  action="/UserControls/SysUser/pUserSP.aspx">
        
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">NGƯỜI DÙNG SHAREPOINT</strong>
            </div>
            <div class="col-xs-6">
                <div class="form-inline text-right">
                    <div class="form-group">
                        <div class="btn-back btn btn-info btn-sm pull-right"><i class="fa fa-long-arrow-left" aria-hidden="true"></i>Quay lại</div>
                        <div id="btn-Update" class="btn btn-info btn-sm pull-right"><i class="fa fa-check"></i><strong>Cập nhật</strong></div>
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
                        <input type="hidden" id="UserSP" name="UserSP" value=""/>
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-6">
                                    <div class="form-group">
                                        <label>Thuộc đơn vị</label>
                                        <select class=" select2" id="cbSysUnit" tabindex="1" name="UnitID">
                                            <asp:Repeater ID="rptSysUnit" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>

<%--         <sharepoint:PeopleEditor id="PeopleEditorKeHoachDuocDuyetKS" class="no-border" runat="server"
                        width="250px" allowempty="true" multiselect="true" selectionset="User" />--%>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-6" style="height: 66px;">
                                    <div class="form-group">
                                        <label style="width: 74px">Người dùng</label>
                                        <sharepoint:peopleeditor runat="server" id="usfUser" selectionset="User" 
                                        width="400px" allowempty="true" cssclass="ms-inputuserfield" browsebuttontooltip="Danh sách người dùng" checkitemtooltip="Kiểm tra" />
                                    </div>
                                </div>
                                 <div class="row"></div>
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
            getPage("/UserControls/SysUser/viewSysUser.aspx?action=view");
            return false;
        });
        $("#btn-Update").click(function (event) {
            var arrayUser = new Array();
            $("#usfUser span.ms-entity-resolved div[key]").each(function () {
                arrayUser.push(new setUserSP($("#cbSysUnit").val(), ($(this).attr("key")), ($(this).attr("displaytext"))));
            });
            var lstUser = JSON.stringify(arrayUser);
            var urlPostAction = '/UserControls/SysUser/aSysUser.ashx?action=add';
            $.post(urlPostAction, { "hidAction": "addUserSP", "listUser": lstUser }, function (data) {
                if (data.Error) {
                    createMessagewarning("Thongbao", data.Message);
                }
                else {
                    //createMessagesuccess("content", data.Message);
                    displayOverlay(data.Message);
                    getPage("/UserControls/SysUser/viewSysUser.aspx?action=view");
                }
            });
            return false;

        });
        $(".select2").select2();
        mybindingData();
    })

    function setUserSP( UnitID, LoginName, UserName) {
        this.UnitID = UnitID;
        this.LoginName = LoginName;
        this.UserName = UserName;
    }
    function mybindingData() {
      

    }
</script>

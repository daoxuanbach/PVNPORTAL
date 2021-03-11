<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucUserEditSP.ascx.cs" Inherits="AdminLTE.Usercontrols.SysUser.ucUserEditSP" %>

<%@ Register TagPrefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<body>
    <form  id="frm">
        <div class="content-header row">
            <div class="col-xs-6">
                <strong class="text-uppercase">NGƯỜI DÙNG SHAREPOINT</strong>
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
                        <%--   <input type="hidden" name="UserID" value="<%=objItemET.UserID %>">--%>
                        <div class="box-body">
                            <div id="Thongbao">
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Thuộc đơn vị</label>
                                        <select class="form-control select2" id="cbSysUnit" tabindex="1" name="UnitID">
                                            <asp:Repeater ID="rptSysUnit" runat="server">
                                                <ItemTemplate>
                                                    <option value="<%#Eval("UnitID") %>"><%#Eval("Name") %></option>
                                                </ItemTemplate>
                                            </asp:Repeater>
                                        </select>
                                    </div>
                                </div>
                            </div>
                            <div class="row">
                                <div class="col-md-12">
                                    <div class="form-group">
                                        <label>Người dùng</label>
                                        <sharepoint:peopleeditor runat="server" id="usfUser" selectionset="User"
                                            width="400px" allowempty="true" cssclass="ms-inputuserfield" browsebuttontooltip="Danh sách người dùng" checkitemtooltip="Kiểm tra" />
                                        <asp:RequiredFieldValidator ID="rfUser" ControlToValidate="usfUser" ErrorMessage="User field is not null"
                                            Text="" runat="server" Display="Dynamic" />
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

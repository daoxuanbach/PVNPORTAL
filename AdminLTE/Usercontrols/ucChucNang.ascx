<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChucNang.ascx.cs" Inherits="AdminLTE.Usercontrols.ucChucNang" %>
<div class="form-inline text-right" runat="server" id="menuTop">
    <div class="form-group">
        <asp:Repeater runat="server" ID="rptchucnang">
            <ItemTemplate>
                <div title="<%#Eval("Title")%>" trangthai-HienThi="<%#Eval("TrangThaiHienThi")%>" trangthai-gui="<%#Eval("TrangThaiGuiDi")%>" class="<%#Eval("ClassView")%> <%# (Pvn.Utils.EnumET.QuyTrinh)Eval("QuyTrinh") %> "><i class="<%#Eval("IconView") %>"></i><strong><%#Eval("Name") %></strong></div>
            </ItemTemplate>
        </asp:Repeater>
    </div>
</div>
<asp:Literal ID="ltlchucnang" runat="server"  />
               

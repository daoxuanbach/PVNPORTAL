<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpDocumentListUserControl.ascx.cs" Inherits="Pvn.Web.Usercontrols.wpDocumentListUserControl" %>
<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>


<div class="list-search">
    <div class="list-search-title">Tra cứu&nbsp;<asp:Literal ID="ltrSearchTitle" runat="server"></asp:Literal></div>
    Năm ban hành&nbsp;<asp:DropDownList ID="ddlNamBanHanh" Width="100px" Height="27px" runat="server"></asp:DropDownList>
    <asp:TextBox ID="txtSearchCondtion" Height="27px" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" CssClass="submitbutton" OnClick="btnSearch_Click" runat="server" Text="Tìm kiếm" />
    <div class="list-search-note">(Nhập tên văn bản, số văn bản,... vào ô tìm kiếm để thực hiện tìm kiếm)</div>
</div>
<hr />
<div class="list-search-title">
    <asp:Literal ID="ltrDocTitle" runat="server"></asp:Literal>
</div>
<asp:HiddenField ID="SortColumn" runat="server" Value="[NgayBanHanh]" />
<div class="table-container">
    <table>
        <colgroup>
            <col width="5%">
            <col width="20%">
            <col width="40%">
            <col width="20%">
            <col width="25%">
        </colgroup>
        <tr>
            <td style="background:#80caed">STT</td>
            <td style="background:#80caed">Số văn bản <asp:ImageButton ID="btnSortSoVanBan" CssClass="imageSort" ImageUrl="/DataStore/Icon/sort-up-down.png" runat="server" OnClick="btnSortSoVanBan_Click" />
            </td>
            <td style="background:#80caed">Tên văn bản</td>
            <td style="background:#80caed">Ngày ban hành <asp:ImageButton ID="btnSortNgayBanHanh" CssClass="imageSort" ImageUrl="/DataStore/Icon/sort-up-down.png" runat="server" OnClick="btnSortNgayBanHanh_Click"  />
            </td>
            <td style="background:#80caed">File đính kèm</td>
        </tr>
        <asp:Repeater ID="rptDocumentList" runat="server" OnItemCommand="rptDocumentList_ItemCommand">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> 
                    <td><%# Eval("STT") %></td>
                    <%--<td class="align-left"><%# string.Format("{0} {1} {2}", Eval("LoaiVanBanName"),  Eval("SoVanBan"), Eval("TieuDe")) %></td>--%>
                    <td class="align-left breakword"><%# Eval("SoVanBan") %></td>
                    <td class="align-left"><%# string.Format("{0}", Eval("TieuDe")) %></td>
                    <td><%# Eval("NgayBanHanh", "{0:dd/MM/yyyy}") %></td>
                    <td>
                        <asp:Repeater ID="rptFileAttach" runat="server" DataSource='<%# Eval("FileAttach") %>' OnItemCommand="rptDocumentList_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtDownLoadAttach" ToolTip='<%# Eval("Value")%>' CommandName="DownloadDocAttach" OnClientClick="_spFormOnSubmitCalled = false; _spSuppressFormOnSubmitWrapper=true;"
                                    CommandArgument='<%# Eval("Key")%>' runat="server">File <%# Container.ItemIndex + 1 %></asp:LinkButton>
                            </ItemTemplate>
                            <SeparatorTemplate>
                                ,
                            </SeparatorTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
            </ItemTemplate>


            <FooterTemplate>
            </FooterTemplate>
        </asp:Repeater>
    </table>
</div>
<webdiyer:AspNetPager ID="pgMain" runat="server" NextPageText="Sau»" PrevPageText="«Trước" CssClass="pagination" CurrentPageButtonClass="active" OnPageChanged="pgMain_PageChanged" />

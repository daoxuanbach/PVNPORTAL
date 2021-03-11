<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucDocBao.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucDocBao" %>
<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<div class="list-search-title">
    <asp:Literal ID="ltrDocTitle" runat="server"></asp:Literal>
</div>
<div class="table-container docbao">
    <table>
        <colgroup>
            <col width="5%">
            <col width="70%">
            <col width="25%">
        </colgroup>
        <tr>
            <td style="background:#80caed">STT</td>
            <td style="background:#80caed">Tiêu đề</td>
            <td style="background:#80caed">Tải file</td>
        </tr>
        <asp:Repeater ID="rptDocumentList" runat="server" OnItemCommand="rptDocumentList_ItemCommand">
            <HeaderTemplate>
            </HeaderTemplate>
            <ItemTemplate>
                <tr> 
                    <td><%# Eval("STT") %></td>
                   
                    <td class="align-left"><%# string.Format("{0}", Eval("TieuDe")) %></td>
                    <td>
                        <asp:Repeater ID="rptFileAttach" runat="server" DataSource='<%# Eval("FileAttach") %>' OnItemCommand="rptDocumentList_ItemCommand">
                            <ItemTemplate>
                                <asp:LinkButton ID="lbtDownLoadAttach" ToolTip='<%# Eval("Value")%>' CommandName="DownloadDocAttach" OnClientClick="_spFormOnSubmitCalled = false; _spSuppressFormOnSubmitWrapper=true;"
                                    CommandArgument='<%# Eval("Key")%>' runat="server"> <img alt="" src="/DataStore/Images/2016/PVN/small_03_2013_129.gif"> <%# Eval("Value")%> </asp:LinkButton>
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

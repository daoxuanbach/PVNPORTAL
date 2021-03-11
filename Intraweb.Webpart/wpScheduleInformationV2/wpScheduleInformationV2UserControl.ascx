<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpScheduleInformationV2UserControl.ascx.cs" Inherits="Intraweb.Webpart.wpScheduleInformationV2UserControl" %>
<style type="text/css">    
    .dateTextbox {height:19px;}
</style>
 <script>
     function exportToExcelWeek() {
         var FromDate = $(".dtFromDate").val();
         var dtToDate = $(".dtToDate").val();
         var ddlManager = $('#<%= ddlManager.ClientID %>').val();
         var url = "/Usercontrols/ExportScheduleForManagerWeek.aspx?FromDate=" + FromDate + "&ToDate=" + dtToDate + "&ManagerID=" + ddlManager;
         window.location = url;
         return false;
     }
  </script>
<div style="display:inline-block;font-size:12px;">
    <a href='<%= UrlLink %>'>Xem theo ngày</a><%--, <a href='<%= UrlSearchComboBox %>'>Tìm kiếm theo Đơn vị/Phòng/Ban</a>--%>
</div>
<div class="list-search">
	<div class="list-search-title"><%= TenTab %></div>
    <br />
    <table border="0" width="100%">
        <colgroup>
        <col width="25%">
        <col width="15%">
        <col width="15%">
        <col width="45%">
      </colgroup>
        <tr>
            <td colspan="4">Lãnh đạo &nbsp;<asp:DropDownList ID="ddlManager" runat="server" Height="22px"></asp:DropDownList></td>            
        </tr>
        <tr>
            <td colspan="4">&nbsp;</td>
        </tr>
        <tr>
            <td align="right">Từ ngày &nbsp;</td>
            <td><SharePoint:DateTimeControl AutoPostBack="false" CssClassTextBox="dtFromDate" LocaleId="2057" ID="dtFromDate" runat="server" DateOnly="true" /></td>
            <td align="right">đến ngày &nbsp;</td>
            <td><SharePoint:DateTimeControl AutoPostBack="false"  CssClassTextBox="dtToDate" ID="dtToDate" LocaleId="2057" runat="server" DateOnly="true" /></td>
        </tr>
        <tr>
            <td colspan="4">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td colspan="4">
                <asp:Button ID="btnSearch" CssClass="submitbutton" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />	
            </td>
        </tr>
    </table>        
</div>
<div class="fr">
     <a href="javascript:exportToExcelWeek()" class="exportexcel">In lịch</a>
</div>
<div class="clear"></div>
<div class="table-container">
    <%--<asp:GridView ID="grvSchedule" runat="server" AutoGenerateColumns="false">
        <Columns>
            <asp:BoundField ItemStyle-Width="5%" DataField="STT" HeaderText="STT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            <asp:TemplateField ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Thời gian">
                <ItemTemplate>
                    <%# Eval("BeginDate", "{0:dd/MM/yyyy hh:mm}") %> - <%# Eval("EndDate", "{0:dd/MM/yyyy hh:mm}") %>
                </ItemTemplate>
            </asp:TemplateField>
            <asp:BoundField ItemStyle-Width="35%" DataField="Descriptions" HeaderText="Nội dung" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="align-left" />
            <asp:BoundField ItemStyle-Width="20%" DataField="ListMangerName" HeaderText="Lãnh đạo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />            
            <asp:BoundField ItemStyle-Width="20%" DataField="ToAddress" HeaderText="Địa điểm" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
        </Columns>
    </asp:GridView>--%>
    <asp:Repeater ID="rptScheduleInfo" runat="server">
        <HeaderTemplate>
               <table> 
                   <colgroup>
                        <col width="5%">
                        <col width="20%">
                        <col width="35%">
                        <col width="20%">
                        <col width="20%">
                    </colgroup>
                   <tr>
                       <th>STT</th>
                       <th>Thời gian</th>
                       <th>Nội dung</th>
                       <th>Lãnh đạo</th>
                       <th>Địa điểm</th>
                   </tr>           
         </HeaderTemplate>
        <ItemTemplate>       
                <tr>
                    <th colspan="5" style="border-bottom:none;text-align:center;">
                        Ngày <%# Eval("Ngay") %>
                    </th>
                </tr>
                <tr>
                    <td colspan="5" style="border:none;padding:0px;">
                        <asp:Repeater DataSource='<%# Eval("ListScheduleDetail") %>' ID="rptScheduleInfoDetail" runat="server">
                            <HeaderTemplate>
                                <table>
                                    <colgroup>
                                        <col width="5%">
                                        <col width="20%">
                                        <col width="35%">
                                        <col width="20%">
                                        <col width="20%">
                                    </colgroup>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <tr>
                                    <td><%# Eval("STT") %></td>
                                    <td><%# Eval("ThoiGianRange") %></td>
                                    <td><%# Eval("NoiDung") %></td>
                                    <td><%# Eval("LanhDao") %></td>
                                    <td><%# Eval("DiaDiem") %></td>
                                </tr>
                            </ItemTemplate>
                            <FooterTemplate>
                                </table>
                            </FooterTemplate>
                        </asp:Repeater>
                    </td>
                </tr>
        </ItemTemplate>
        <FooterTemplate>
            </table>        
        </FooterTemplate>
    </asp:Repeater>
</div>
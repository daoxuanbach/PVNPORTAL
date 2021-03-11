<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpMeetingScheduleUserControl.ascx.cs" Inherits="Intraweb.Webpart.wpMeetingScheduleUserControl" %>
<style type="text/css">
    .table-container table tr td table tr td {border:none;}
    .dateTextbox {height:19px;}
</style>
 
<asp:UpdatePanel ID="meetingUpdatePanel" runat="server">
    <Triggers>
        <asp:AsyncPostBackTrigger ControlID="lbtPrevious" />
        <asp:AsyncPostBackTrigger ControlID="lbtNext" />
    </Triggers>    
    <ContentTemplate>      
        <div class="list-search">
	        <div class="list-search-title"><%= TenTab %></div>
            <table border="0" width="100%">
                <colgroup>
		        <col width="41%">
		        <col width="20%">
                <col width="40%">		       
		        </colgroup>
                <tr>  
                    <td align="right"><asp:LinkButton OnClick="lbtPrevious_Click" ID="lbtPrevious" ToolTip="Ngày hôm trước" runat="server"><img src="/Style Library/Images/arrow_left.png" /></asp:LinkButton>&nbsp;&nbsp;</td>                             
                    <td><SharePoint:DateTimeControl CssClassTextBox="dateTextbox" ID="dtMeeting" LocaleId="2057" runat="server" AutoPostBack="true" OnDateChanged="dtMeeting_DateChanged" DateOnly="true"  /></td>
                    <td align="left">
                        <asp:LinkButton ToolTip="Ngày hôm sau" OnClick="lbtNext_Click" ID="lbtNext" runat="server"><img src="/Style Library/Images/arrow_right.png" /></asp:LinkButton></td>
                </tr>
                <tr>
                    <td colspan="3">
                        &nbsp;
                    </td>
                </tr>
            </table>   
        </div> 
        <%--<div class="table-container">
        <asp:GridView ID="grvSchedule" runat="server" AutoGenerateColumns="false" OnPreRender="grvSchedule_PreRender" OnRowCreated="grvSchedule_RowCreated">
            <Columns>
                <asp:BoundField ItemStyle-CssClass="morning" HeaderStyle-CssClass="morning" ItemStyle-Width="10%" DataField="AMTime" HeaderText="Thời gian" 
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:HH:mm}" />
                <asp:BoundField ItemStyle-CssClass="morning align-left" HeaderStyle-CssClass="morning" ItemStyle-Width="30%" DataField="AMTitle" HeaderText="Cuộc họp" 
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                <asp:BoundField ItemStyle-CssClass="place" HeaderStyle-CssClass="place" ItemStyle-Width="20%" DataField="RoomName" HeaderText="Địa điểm" 
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField ItemStyle-CssClass="afternoon" HeaderStyle-CssClass="afternoon" ItemStyle-Width="10%" DataField="PMTime" HeaderText="Thời gian" 
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" DataFormatString="{0:HH:mm}" />
                <asp:BoundField ItemStyle-CssClass="afternoon align-left" HeaderStyle-CssClass="afternoon" ItemStyle-Width="30%" DataField="PMTitle" HeaderText="Cuộc họp" 
                    HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
            </Columns>
        </asp:GridView>
        </div>--%>
        <asp:Repeater ID="rptMeeting" runat="server"  >
            <HeaderTemplate>
                <div class="table-container">
                <table>
                    <colgroup>
                        <col width="10%">
                        <col width="30%">
                        <col width="20%">
                        <col width="10%">
                         <col width="30%">
                    </colgroup>
                    <tr>
                        <th class="morning morningheader" colspan="2">Sáng</th>            
                        <th>&nbsp;</th>
                        <th class="afternoon afternoonheader" colspan="2">Chiều</th>
                    </tr>
                   <tr>
                    <th class="morning">Thời gian</th>
                    <th class="morning">Cuộc họp</th>
                    <th class="place">Địa điểm</th>
                    <th class="afternoon">Thời gian</th>
                    <th class="afternoon">Cuộc họp</th>
                    </tr>
                    </HeaderTemplate>
                    <ItemTemplate>
                            <tr> 
                                <td class="align-left morning" colspan="2"> <%# this.Page.Server.HtmlDecode(Eval("AMTable") as String) %></td>
                                <td class="place"><%# Eval("RoomName") %></td>
                                <td class="afternoon align-left" colspan="2"><%# this.Page.Server.HtmlDecode(Eval("PMTable") as String) %></td>
                            </tr>

                    </ItemTemplate>
                    <FooterTemplate>
                        </table>
                        </div>
                    </FooterTemplate>
        </asp:Repeater>
    </ContentTemplate>
</asp:UpdatePanel>
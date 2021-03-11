<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpScheduleForManagerUserControl.ascx.cs" Inherits="Intraweb.Webpart.wpScheduleForManagerUserControl" %>
<style type="text/css">    
    .dateTextbox {height:19px;}
</style>
 <script>
     function exportToExcel() {
         
         var ReportDate = $(".dtMeeting").val();
         var url = "/Usercontrols/ExportScheduleForManager.aspx?ReportDate=" + ReportDate;
         window.location = url;
         return false;
     }
  </script>
<div style="display:inline-block;font-size:12px;">
    <a href='<%= UrlLink %>'>Xem theo tuần</a><%--, <a href='<%= UrlSearchComboBox %>'>Tìm kiếm theo Đơn vị/Phòng/Ban</a>--%>
</div>
<asp:UpdatePanel ID="meetingUpdatePanel" runat="server">   
  
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
                    <td><SharePoint:DateTimeControl CssClassTextBox="dtMeeting" ID="dtMeeting" LocaleId="2057" runat="server" AutoPostBack="true" OnDateChanged="dtMeeting_DateChanged" DateOnly="true" /></td>
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
        <div class="fr">
             <%--<asp:LinkButton ID="imgbExport" OnClick="imgbExport_Click" runat="server" CssClass="exportexcel">In lịch</asp:LinkButton>--%>
             <a href="javascript:exportToExcel()" class="exportexcel">In lịch</a>
        </div>
        <div class="clear"></div>
        <div class="table-container">
            <asp:GridView ID="grvSchedule" runat="server" AutoGenerateColumns="false" OnRowDataBound="grvSchedule_RowDataBound" OnPreRender="grvSchedule_PreRender">
                <Columns>
                    <asp:BoundField ItemStyle-Width="5%" DataField="STT" HeaderText="STT" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" />
                    <asp:BoundField ItemStyle-Width="25%" DataField="Name" HeaderText="Lãnh đạo" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />  
                    <asp:BoundField ItemStyle-Width="30%" DataField="Title" HeaderText="Hoạt động" HeaderStyle-HorizontalAlign="Center" ItemStyle-CssClass="align-left" /> 
                    <asp:TemplateField ItemStyle-Width="20%" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Center" HeaderText="Thời gian">
                        <ItemTemplate>
                            <asp:Label ID="lbThoiGian" runat="server" Text=""></asp:Label>
                          <%--  <%# string.IsNullOrEmpty(Convert.ToString(Eval("Title")))?"": string.Format("Từ {0}", Eval("BeginDate", "{0:HH:mm}")) %>--%>
                        </ItemTemplate>
                    </asp:TemplateField> 
                    <asp:BoundField ItemStyle-Width="20%" DataField="ToAddress" HeaderText="Địa điểm" HeaderStyle-HorizontalAlign="Center" ItemStyle-HorizontalAlign="Left" />
                </Columns>
            </asp:GridView>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>
<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpEventSchedulerUserControl.ascx.cs" Inherits="Intraweb.Webpart.wpEventSchedulerUserControl" %>
<script src="/Style%20Library/Javascripts/jquery-ui-1.11.2.custom/jquery-1.11.2.min.js" type="text/javascript"></script>
<script src="/Style%20Library/Javascripts/jquery-ui-1.11.2.custom/jquery-ui.min.js" type="text/javascript"></script>
<link href="/Style%20Library/Javascripts/jquery-ui-1.11.2.custom/jquery-ui.min.css" rel="stylesheet"
    type="text/css" />
<link href="/Style%20Library/Javascripts/jquery-ui-1.11.2.custom/jquery-ui.structure.min.css"
    rel="stylesheet" type="text/css" />
<link href="/Style%20Library/Javascripts/jquery-ui-1.11.2.custom/jquery-ui.theme.min.css" rel="stylesheet"
    type="text/css" />
<link href="/Style%20Library/css/lichsk.css" rel="stylesheet" type="text/css" />
<script src="/Usercontrols/Javascripts/EventScheduler.js" type="text/javascript"></script>
<style>
    .ui-dialog-title {
        font-family: Arial !important;
        font-size: 13px;
        font-weight: bold;
    }
    .submitbutton {}
    .ui-button-text{
        height: 20px !important;
    }
</style>
<div class="event_fillterbox">
    <div class="list-search-title">LỊCH CÁC SỰ KIỆN, HOẠT ĐỘNG CỦA TẬP ĐOÀN DẦU KHÍ QUỐC GIA VIỆT NAM</div>
    <table>
        <tr>
            <td align="right" class="event_fillter_cell">
                <asp:LinkButton ID="lbtPrevious" ToolTip="Tháng trước" runat="server" OnClick="lbtPrevious_Click"><img src="/Style Library/Images/lightbox-prev.png" /></asp:LinkButton>
            </td>

            <td align="right" class="event_fillter_cell">
                <asp:Label ID="Label1" runat="server" Text="Tháng"></asp:Label></td>
            <td class="event_fillter_cell">
                <asp:DropDownList ID="cbMonth" runat="server" Width="60px">
                </asp:DropDownList>
            </td>
            <td align="left" class="event_fillter_cell">
                <asp:Label ID="Label2" runat="server" Text="Năm"></asp:Label></td>
            <td class="event_fillter_cell">
                <asp:DropDownList ID="cbYear" runat="server" Width="80px"></asp:DropDownList>
            </td>
            <td align="left" class="event_fillter_cell">
                <asp:LinkButton ToolTip="Tháng sau" ID="lbtNext" runat="server" OnClick="lbtNext_Click"><img src="/Style Library/Images/lightbox-next.png" /></asp:LinkButton></td>

            <td class="event_fillter_cell">

                <asp:Button ID="cmdView" runat="server" CssClass="submitbutton" Text="Xem" />

            </td>
            <td class="event_fillter_cell">
               
            </td>
        </tr>
    </table>
</div>
<div id="viewEventDetailContainer" class="dt_container">
    <table cellspacing="5" cellpadding="5" class="dt_container">
        <tr>
            <td colspan="4" class="dt_eventnamebox">
                <div id="eventName">
                </div>
            </td>
        </tr>
        <tr>
            <td class="label_cell">
                <asp:Label ID="lbStartDate" runat="server" Text="Thời gian:" CssClass="dt_label"></asp:Label>
            </td>
            <td colspan="3" class="content_cell">
                <div id="txtStartDate" class="dt_control">
                </div>
            </td>
        </tr>
        <tr id="rowDiadiem">
            <td class="label_cell">
                <asp:Label ID="Label3" runat="server" Text="Địa điểm:" CssClass="dt_label"></asp:Label>
            </td>
            <td colspan="3" class="content_cell">
                <div id="txtPlace" class="dt_control">
                </div>
            </td>
        </tr>
        <tr id="rowTochuc">
            <td class="label_cell" width="100px">
                <asp:Label ID="Label4" runat="server" Text="Đơn vị tổ chức:" CssClass="dt_label"></asp:Label>
            </td>
            <td colspan="3" class="content_cell">
                <div id="txtDVTochuc" class="dt_control">
                </div>
            </td>
        </tr>
        <tr id="rowCTLabel">
            <td colspan="4" class="dt_detaillable">
                <asp:Label ID="lbDetail" runat="server" Text="Thông tin chi tiết"></asp:Label>
            </td>
        </tr>
        <tr id="rowCTInfo">
            <td colspan="4">
                <div id="eventDetail">
                </div>
            </td>
        </tr>
    </table>
</div>
<div id="viewEventDetailContainerHover" class="dt_container">
    chi tiet su kien
</div>
<div class="table-container">
    <div>
        <table id="tblCalendar" runat="server" enableviewstate="False">
        </table>
    </div>
</div>
<script type="text/javascript">
    var eventdata = <%= EventData %>;
    var dialog = $("#viewEventDetailContainer").dialog({
        title:'Chi tiết sự kiện',
        autoOpen: false,
        modal: true,
        width: 400,
        height: 'auto'});

    var dialogHover = $("#viewEventDetailContainerHover").dialog({
        title:'Chi tiết sự kiện',
        autoOpen: false,
        modal: false,
        width: 400,
        height: 'auto'});

    function showDetail(el, id){
        var info = eventdata[id];
        var str = info.EventName;
        if (info.Estimate)str +=" (Dự kiến)";

        $("#eventName").html(str);
        $("#txtStartDate").html(info.EventTime);
        str = info.EventPlace;
        if (str == '' || str == null) $("#rowDiadiem").hide();
        else{
            $("#rowDiadiem").show();
            $("#txtPlace").html(str);
        }

        str = info.OrgaUnit;
        if (str == '' || str == null) $("#rowTochuc").hide();
        else {
            $("#rowTochuc").show();
            $("#txtDVTochuc").html(str);
        }

        str = info.EventDetail;
        if (str == '' || str == null) {
            $("#rowCTLabel").hide();
            $("#rowCTInfo").hide();
        }
        else {
            $("#rowCTLabel").show();
            $("#rowCTInfo").show();
            var decoded = $('<div/>').html(info.EventDetail).text();
            $("#eventDetail").html(decoded);
        }
        var position = { 
            my: 'left top', at: 'left bottom',
            of: $('#' + el.id)};
        dialog.dialog( "option", "position", position);
        dialog.dialog("open");
    }
    function showDetailHover(el, id){

        var info = eventdata[id];
        var str = info.EventName;
        if (info.Estimate)str +=" (Dự kiến)";

        $("#eventName").html(str);
        $("#txtStartDate").html(info.EventTime);
        str = info.EventPlace;
        if (str == '' || str == null) $("#rowDiadiem").hide();
        else{
            $("#rowDiadiem").show();
            $("#txtPlace").html(str);
        }

        str = info.OrgaUnit;
        if (str == '' || str == null) $("#rowTochuc").hide();
        else {
            $("#rowTochuc").show();
            $("#txtDVTochuc").html(str);
        }

        str = info.EventDetail;
        if (str == '' || str == null) {
            $("#rowCTLabel").hide();
            $("#rowCTInfo").hide();
        }
        else {
            $("#rowCTLabel").show();
            $("#rowCTInfo").show();
            var decoded = $('<div/>').html(info.EventDetail).text();
            $("#eventDetail").html(decoded);
        }
        var position = { 
            my: 'left top', at: 'left bottom',
            of: $('#' + el.id)};
        dialogHover.dialog( "option", "position", position);
        dialogHover.dialog("open");
    }
</script>

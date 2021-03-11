<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ScheduleDayView.ascx.cs" Inherits="Pvn.Web.Usercontrols.ScheduleDayView" %>
<asp:Panel ID="pnDate" runat="server" CssClass="ev_daylabel">
    <asp:Label ID="lbDate" runat="server" Text=""></asp:Label>
</asp:Panel>
<asp:Repeater ID="Repeater1" runat="server">
    <ItemTemplate>
        <div id="div_event_<%# DataBinder.Eval(Container.DataItem, "EventCode")%>" onclick="showDetail(this, '<%# DataBinder.Eval(Container.DataItem, "EventCode")%>');" class="<%#(( Pvn.Entity.EventInfo)Container.DataItem).Estimate ? "ev_box event_dk" :"ev_box" %>">
            <%#Eval("EventName")%>
        </div>
    </ItemTemplate>
    <AlternatingItemTemplate>
        <div id="div_event_<%# DataBinder.Eval(Container.DataItem, "EventCode")%>" onclick="showDetail(this, '<%# DataBinder.Eval(Container.DataItem, "EventCode")%>');" class="<%#(( Pvn.Entity.EventInfo)Container.DataItem).Estimate ? "ev_box event_dk" :"ev_box ev_box_alt" %>">
            <%#Eval("EventName")%>
        </div>
    </AlternatingItemTemplate>
</asp:Repeater>
<asp:Panel ID="pnEmpty" runat="server" Visible="False" CssClass="emptyday">
</asp:Panel>

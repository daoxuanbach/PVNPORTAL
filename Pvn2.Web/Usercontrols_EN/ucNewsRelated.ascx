<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsRelated.ascx.cs" Inherits="Pvn2.Web.Usercontrols_EN.ucNewsRelated" %>
<asp:Repeater ID="rptNewsLeft" runat="server">
    <HeaderTemplate>
        <div class="cls-newrelated">
            <h5 style="text-transform:uppercase" class="widget-title"><%= TenTab %></h5>
            <ul>
    </HeaderTemplate>
    <ItemTemplate>
        <li class='<%# Container.ItemIndex ==0 ? "" : "new-border-top"%>'>
            <a href='<%# Pvn.Utils.Utilities.GetUrlRewite(UrlDetail,Eval("CategoryName").ToString(),Eval("Title").ToString(),Eval("NewsPublishingID").ToString())  %>'>
                <img class="thumb" src="<%# Eval("ImageURL") %>" alt="<%# Eval("Title") %>”">
                <%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %>
            </a>

        </li>
    </ItemTemplate>
    <FooterTemplate>
        </ul>
        </div>
    </FooterTemplate>
</asp:Repeater>
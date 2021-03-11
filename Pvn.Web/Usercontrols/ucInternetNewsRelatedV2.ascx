<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucInternetNewsRelatedV2.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucInternetNewsRelatedV2" %>

<asp:Repeater ID="rptNewsLeft" runat="server">
    <HeaderTemplate>
        <div class="cls-newrelated">
            <div style="text-transform: uppercase" class="title"><%= TenTab %></div>
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

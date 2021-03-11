<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBannerWeb.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucBannerWeb" %>
<div class="banner" style="background-image: url(/Usercontrols/Banner/background_logo_2018.png);">
    <div class="navbar-header">
        <a href="/" class="logo">
            <img src="/Usercontrols/Banner/logoPVN_2018.png">
        </a>
        <div class="pull-right">
            <p class="bn_icon">
                <a href="<%= SiteVNLink %>">
                    <img src="/Style%20Library/images/vi.png"></a>
                <a href="<%= SiteENLink %>">
                    <img src="/Style%20Library/images/en.png"></a>
            </p>
            <div class="searchform">

                <asp:TextBox ID="txtSearchBox" CssClass="s" runat="server"></asp:TextBox>
                <asp:Button ID="btnSearch" CssClass="searchsubmit" OnClick="btnSearch_Click" runat="server" />

            </div>
        </div>
    </div>
</div>

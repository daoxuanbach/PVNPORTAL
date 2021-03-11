<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucSearchbox.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucSearchbox" %>
<p class="bn_icon">
	<a href="<%= SiteVNLink %>"><img  src="/Style%20Library/images/vi.png"></a>
	<a href="<%= SiteENLink %>"><img src="/Style%20Library/images/en.png"></a>
</p>
<div class="searchform">	
	
    <asp:TextBox ID="txtSearchBox" CssClass="s" runat="server"></asp:TextBox>
    <asp:Button ID="btnSearch" CssClass="searchsubmit" OnClick="btnSearch_Click" runat="server" />				

</div>

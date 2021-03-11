<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsList.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucNewsList" %>
<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>
	
<asp:Repeater ID="rptMainNewsItem" runat="server">
    <ItemTemplate>
        <div class="news marR10"> 
			<div class="title_new"><a href='<%# Pvn.Utils.Utilities.GetUrlRewite(UrlDetail,Eval("CategoryName").ToString(),Eval("Title").ToString(),Eval("NewsPublishingID").ToString()) %>'><%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %> (<%# Eval("BeginDate", "{0:dd/MM/yyyy}") %>)</a></div>		            	
			<div class="img_div">  
                <asp:Image Width="350px" Height="200px" ID="Image1" runat="server" ToolTip='<%# Eval("Title") %>' ImageUrl='<%# Eval("ImageURL") %>'
                                AlternateText='<%# Eval("Title") %>'   /></a>
			</div>
			<p style="text-align:justify;"><%# Pvn.Utils.Utilities.SplitString(Eval("Summary").ToString(),MaxLengthSummary) %></p>
			<p class="detail"><a href='<%# Pvn.Utils.Utilities.GetUrlRewite(UrlDetail,Eval("CategoryName").ToString(),Eval("Title").ToString(),Eval("NewsPublishingID").ToString())  %>'> <%= ViewDetailButtonText %></a> </p>
		</div>
    </ItemTemplate>
</asp:Repeater>
<div class="clear"></div>

<webdiyer:aspnetpager id="pgMain" runat="server" ShowPageIndexBox="Never" ShowFirstLast="true" NextPageText="Sau>>" AlwaysShowFirstLastPageNumber="true"
prevpagetext="«Trước" cssclass="page" 
currentpagebuttonclass="active" onpagechanged="pgMain_PageChanged" />

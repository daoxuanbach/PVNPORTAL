<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucVideoMain.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucVideoMain" %>

<div class="videopanel">
<a class="glow btn-u btn-block btn-block-left btn-u-default-grey fs16" href="<%=UrlLink %>" title="<%=TenTab %>">
	<img src="/Style%20Library/jqueryPage/images/icon_video.png" alt="<%=TenTab %>" style="width:32px;">
 
	<span class="pl5"><%=TenTab %></span>
</a>
</div>

<asp:Repeater ID="rptMainVideo" runat="server">
    <ItemTemplate>
		<video id="videoareatab"
				 width="290px"
                    loop="loop"
				 height="200px"
				 poster="<%# Eval("ImageURL")%>"
				 controls="controls"
				 src="<%# Eval("VideoURL") %>"> 
			</video>

    </ItemTemplate>
</asp:Repeater>

<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBanner.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucBanner" %>
<asp:Repeater ID="rptBannerText" runat="server">
    <ItemTemplate>
        <%# Eval("Description") %>
    </ItemTemplate>
    <SeparatorTemplate>
        <br />
    </SeparatorTemplate>
</asp:Repeater>
<asp:Repeater ID="rptBanner" runat="server">
    <HeaderTemplate>
        <a href="/">  
    </HeaderTemplate>
    <ItemTemplate>
        <asp:Panel ID="pnlFlash" Visible='<%# IsFlashFile(Eval("ImageURL"))  %>' runat="server">
            <EMBED src='<%# Eval("ImageURL") %>' class="embededBanner" wmode="transparent" quality=high bgcolor=#5CBDF2 WIDTH="1000" flashvars="speedvar=<%# SpeedVar %>&textvar=<%# TextVar %>"
                NAME="myMovieName" ALIGN="" TYPE="application/x-shockwave-flash"
                PLUGINSPAGE="http://www.macromedia.com/go/getflashplayer">
            </EMBED>  
        </asp:Panel>                
        <asp:Image Visible='<%# !IsFlashFile(Eval("ImageURL"))  %>' AlternateText='<%# Eval("Title")  %>' ID="imgBanner" ImageUrl='<%# Eval("ImageURL") %>' runat="server" /> 
        <div runat="server" visible='<%# !IsFlashFile(Eval("ImageURL"))  %>' class="cls_marquee"> 
		<marquee onmouseover="this.stop()" onmouseout="this.start()" scrollamount="<%# Convert.ToInt16(SpeedVar) +2 %>"> <%=TextVar %> </marquee> 
        </div>
     
    </ItemTemplate>
    <FooterTemplate>
        </a>
    </FooterTemplate>
</asp:Repeater>

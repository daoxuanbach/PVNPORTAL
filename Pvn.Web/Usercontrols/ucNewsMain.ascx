<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsMain.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucNewsMain" %>
<div class="middle-box">
   
    <div class="box-content">
        <div class="news-left">
        <asp:Repeater ID="rptNewsLeft" runat="server">
            <ItemTemplate>
                <div class="big-news">
                    <div class="news-img">						
                        <asp:Image Width="440px" ID="imgImage" runat="server" ToolTip='<%# Eval("Title") %>' ImageUrl='<%# Eval("ImageURL") %>'
                            AlternateText='<%# Eval("Title") %>' />
                        <div class="news-info">
                       <%-- <a href='<%# string.Format("{0}?NewsID={1}", UrlDetail, Eval("NewsPublishingID")) %>'>
                            <h5><%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %></h5>
                        </a>--%>
                        <a href='<%# Pvn.Utils.Utilities.GetUrlRewite(UrlDetail,Eval("CategoryName").ToString(),Eval("Title").ToString(),Eval("NewsPublishingID").ToString())  %>'>
                            <h5><%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthTitle) %></h5>
                        </a>
                        <p>
                            <%# Pvn.Utils.Utilities.SplitString(Eval("Summary").ToString(),MaxLengthSummary) %>
                        </p>
                        </div>
                    </div>
                </div><!--END BIG NEWS-->              
            </ItemTemplate>
        </asp:Repeater>
		</div>
        <div class="news-right">
		<ul>
            <asp:Repeater ID="rptNewsRight" runat="server">
                <ItemTemplate>
					<li>
						 <div class="news-img">
                             <asp:Image Width="94px" Height="70px" ID="imgImage" runat="server" ToolTip='<%# Eval("Title") %>'
                                AlternateText='<%# Eval("Title") %>' ImageUrl='<%# Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) %>'  
                                    OnError='<%# "LoadImages(this.id,\"" + Pvn.Utils.Utilities.ProcessImage(Eval("ImageURL"), OtherImageSize) + "\")" %>'
							/>		
                        </div>
                        <div class="news-info">
						<a href='<%# Pvn.Utils.Utilities.GetUrlRewite(UrlDetail,Eval("CategoryName").ToString(),Eval("Title").ToString(),Eval("NewsPublishingID").ToString())  %>'><h6><%# Pvn.Utils.Utilities.SplitString(Eval("Title").ToString(),MaxLengthOtherTitle) %></h6></a>
						<p class="">
                            <img src="/Style%20Library/Images/news-time.png">
                            <span class="pl5"><%# Eval("BeginDate", "{0:dd/MM/yyyy}") %> </span>
                        </p>
                        </div>
					</li>
					                
                </ItemTemplate>
            </asp:Repeater>
			
            <div class="ms-clear"></div>
			</ul>
        </div>
		<!--END NEWS-->
                    
    </div>
</div><!--END BOX I-->
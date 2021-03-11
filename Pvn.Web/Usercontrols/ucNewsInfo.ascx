<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsInfo.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucNewsInfo" %>
<div class="newsinfocontainer">
    <div class="list_carousel">
        <ul id="foo2">
            <asp:Repeater ID="rptNewsContent" runat="server">
                <ItemTemplate>
                    <li>
                        <div class="newsinfoslidecontent" style="height: 497px">
                            <div style="background-image: url(/Style%20Library/images/thanhtuu.png); background-repeat: no-repeat; height: 150px; width: 300px; background-color: #0871b5;">
                                <div class="newsinfotitle">
                                    <span style="color: #fff;"><%# Eval("InfoTitle") %></span>
                                </div>
                            </div>
                            <span style="color: #fff;"><%# Eval("InfoContent") %></span>
                        </div>
                    </li>
                </ItemTemplate>
            </asp:Repeater>

        </ul>
    </div>
</div>
<script type="text/javascript" language="javascript" src="/_layouts/Core.Branding/Javascripts/jquery.carouFredSel-6.2.1-packed.js"></script>
<script type="text/javascript" language="javascript" src="/Style Library/Javascripts/jscarouFredSelpage.js"></script>
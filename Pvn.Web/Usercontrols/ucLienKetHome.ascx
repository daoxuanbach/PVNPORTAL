<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLienKetHome.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucLienKetHome" %>
<!DOCTYPE html>
<html>
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title></title>
</head>
<body style="padding:0px; margin:0px; background-color:#fff;font-family:helvetica, arial, verdana, sans-serif">
<div class="lienkethome">
   <asp:Repeater ID="rptNewsLeft" runat="server">
        <ItemTemplate>
				
				<a href="<%# Eval("URL") %>" target="<%#Convert.ToString(Eval("IsNewWindow")) == "0"? "_self" : "_blank"%>"> 
                    <img data-u="image" src="<%# Eval("ImageURL") %>"  style="width:286px;"/>
                </a>
						
        </ItemTemplate>
    </asp:Repeater>	
	</div>
</body>
</html>

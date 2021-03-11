<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucMenuAnhLienKet.ascx.cs" Inherits="Pvn.Web.ucMenuAnhLienKet" %>

    <asp:Repeater ID="rptChuyenDeDauKhi" runat="server">
        <ItemTemplate>
			<div class="icap <%# Container.ItemIndex ==0 ? "margin-top-35px" : ""%>" >
				<img alt="" src="<%# Eval("ImageURL") %>"><br>
				<div class="cap">
						<p><a class="hvr-float-shadow" target="<%#Convert.ToString(Eval("IsNewWindow")) == "0"? "_self" : "_blank"%>" href='<%# string.Format("{0}", Eval("Url")) %>'><%#Eval("Title").ToString() %></a></p>
				</div>
            </div>
			
        </ItemTemplate>
    </asp:Repeater>	

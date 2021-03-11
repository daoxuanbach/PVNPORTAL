<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucChuyenDeDauKhi.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucChuyenDeDauKhi" %>
<div class="MainContentChuyenDe-right2">
<div class="title"><%= TenTab %></div>
<ul>
    <asp:Repeater ID="rptChuyenDeDauKhi" runat="server">
        <ItemTemplate>
            <li>
                <a href='<%# string.Format("{0}", Eval("Url")) %>'>
                  <img class="thumb" src="<%# Eval("ImageURL") %>">
                  <%#Eval("Title").ToString() %>
                </a>
            </li>
        </ItemTemplate>
    </asp:Repeater>	
</ul>
</div>
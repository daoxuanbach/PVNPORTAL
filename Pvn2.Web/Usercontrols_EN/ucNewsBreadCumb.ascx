<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucNewsBreadCumb.ascx.cs" Inherits="Pvn2.Web.Usercontrols_EN.ucNewsBreadCumb" %>
<div class="breachcrum_bg">
    <img src="<%=ImageURL %>"" class="custom-logo" alt="">
</div>
<div class="navigator_bar">
    <div class="container">
        <ul>
            <li class="home">
                <a href="/sites/en/" title="" class="home_icon"></a>
            </li>
            <span class="breadcrumb"></span>
            <li >
                <a href="/sites/en/">Home</a>
            </li>
            <asp:Repeater ID="rptnewsbreadcumb" runat="server">
                <ItemTemplate>
                    <li>
                        <span class="breadcrumb"></span>
                        <a href='<%# (Eval("URL") == null)? "#" : Eval("URL") %>'>
                            <%# Eval("Title") %>
                        </a>
                    </li>
                </ItemTemplate>
                <SeparatorTemplate>
                </SeparatorTemplate>
            </asp:Repeater>
        </ul>
    </div>
</div>   
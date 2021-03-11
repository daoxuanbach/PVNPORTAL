<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBreadcumbMEDIA.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucBreadcumbMEDIA" %>

 <ul class="ul_breadcumb">
    <asp:Repeater ID="rptNewsBreadCumb" runat="server">
        <HeaderTemplate>
            <li>
                <a href='<%# UrlDetail %>'>
                    Media
                </a>
            </li>
            <li>
                <a href='<%# UrlDetail %>'>
                    <%# Title %>
                </a>
            </li>
            <li>&nbsp;&nbsp>&nbsp;&nbsp</li>
        </HeaderTemplate>

        <ItemTemplate>
            <li>                
                <a href='<%# string.Format("{0}?catid={1}", UrlDetail, Eval("CatID")) %>'>
                    <%# Eval("Title") %>
                </a>
            </li>
        </ItemTemplate>
        <SeparatorTemplate>
            <li>&nbsp;&nbsp>&nbsp;&nbsp</li>
        </SeparatorTemplate>       
    </asp:Repeater>
    </ul>
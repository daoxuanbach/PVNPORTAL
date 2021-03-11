<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucBreadcumb.ascx.cs" Inherits="PvnEN.Web.Usercontrols_EN.ucBreadcumb" %>

<div class="breachcrum_bg">
        <img src="/wp-includes/img/br_1.png" class="custom-logo" alt="">
    </div>
    <div class="navigator_bar">
        <div class="container">
            <ul> 
                <li class="home">
                        <a href="" title="" class="home_icon"></a>
                 </li>
                 <asp:Repeater ID="rptNewsBreadCumb" runat="server">
        <HeaderTemplate>
            <li>
                <a href='<%# UrlDetail %>'>
                    Thư viện
                </a>
            </li>
            <li>&nbsp;&nbsp>&nbsp;&nbsp</li>
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
             <span class="breadcrumb"></span>
        </SeparatorTemplate>       
    </asp:Repeater>

                   
            </ul>
        </div>
    </div>


<div class="breachcrum_bg">
        <img src="/wp-includes/img/br_1.png" class="custom-logo" alt="">
    </div>
    <div class="navigator_bar">
        <div class="container">
            <ul>
          <li class="home">
            <a href="" title="" class="home_icon"></a>
            </li>
        <span class="breadcrumb"></span>
            
        </ul>
        </div>
    </div>
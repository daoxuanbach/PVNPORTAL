<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ContentComment.ascx.cs" Inherits="Pvn.Web.Usercontrols.ContentComment" %>
<%@ Register Assembly="AspNetPager, Version=7.4.2.0, Culture=neutral, PublicKeyToken=fb0a0fe055d40fd4" Namespace="Wuqi.Webdiyer" TagPrefix="webdiyer" %>

<style type="text/css">
    /*Y kien ban doc */
    .title_show {
        color: #333;
        background: #eee;
        position: relative;
        height: 26px;
        width: 100%;
        float: left;
        text-rendering: geometricPrecision;
    }

    .ykien_pvn {
        font: 400 14px/26px arial;
        color: #9d234c;
        padding: 0 0 0 10px;
    }

    .left {
        float: left;
    }

    .filter_coment {
        float: right;
        padding: 0 10px 0 0;
        color: #666;
        text-align: right;
        white-space: nowrap;
    }

        .filter_coment a {
            font: 400 11px arial;
            color: #666;
        }

            .filter_coment a.active {
                color: #9D234C;
            }

    .filter_coment_mobile {
        float: right;
    }

        .filter_coment_mobile select {
            font: 400 14px arial;
            display: none;
        }

    .width_common {
        width: 100%;
        float: left;
    }

    .comment_item p {
        padding-bottom: 2px;
        line-height: 0px;
        font-size: 13px;
    }

    .hight_light {
        background: #f8f8f8;
        margin-top: -23px;
    }

    .icon_show_full_comment.icon_tru {
        background-position: -20px -320px;
    }

    .user_status {
        position: relative;
        z-index: 999;
    }

    .box_width_common {
        width: 100%;
        float: left;
    }

    .icon_show_full_comment:hover {
        background-position: -53px -320px;
    }

    .icon_show_full_comment {
        width: 11px;
        height: 12px;
        display: inline-block;
        margin: 0 0 0 3px;
        line-height: 12px;
    }

    .sub_comment {
        float: right;
        width: 95%;
        padding: 1px 0 0;
    }
</style>
<asp:Panel ID="pnlTitle" runat="server">
    <div class="title_show">
        <div class="ykien_pvn" style="">
            <strong>
                <asp:Literal ID="ltrYKBD" Text="Ý kiến bạn đọc" runat="server"></asp:Literal></strong> (<label id="total_comment"><%= TotalRows %></label>) 
        </div>
    </div>
</asp:Panel>

<asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
        <asp:Repeater ID="rptComment" runat="server">
            <HeaderTemplate>
                <div class="main_show_comment box_width_common" id="list_comment">
            </HeaderTemplate>
            <ItemTemplate>
                <div class="comment_item">
                    <div class="right width_comment_item width_common">
                        <div class="width_common">
                            <div class="full_content"><%# Eval("Content") %></div>
                            <div class="user_status width_common" data-user-type="5">
                                <span class="left txt_666 txt_11">
                                    <a><b><%# Eval("Name") %></b></a> - <%# Eval("ModifiedDate", "{0:HH:mm dd/MM/yyyy}") %>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="clear">&nbsp;</div>
                </div>
            </ItemTemplate>
            <AlternatingItemTemplate>
                <div class="comment_item hight_light">
                    <div class="right width_comment_item width_common">
                        <div class="width_common">
                            <p class="full_content"><%# Eval("Content") %></p>
                            <div class="user_status width_common">
                                <span class="left txt_666 txt_11">
                                    <a><b><%# Eval("Name") %></b></a> - <%# Eval("ModifiedDate", "{0:HH:mm dd/MM/yyyy}") %>
                                </span>
                            </div>
                        </div>
                    </div>
                    <div class="clear">&nbsp;</div>
                </div>
            </AlternatingItemTemplate>
            <FooterTemplate>
                </div>         
            </FooterTemplate>
        </asp:Repeater>
        <div class="clear">
        </div>
        <webdiyer:AspNetPager ID="pgMain" runat="server" NextPageText="Sau»" PrevPageText="«Trước"
            CssClass="pagination" CurrentPageButtonClass="active" OnPageChanged="pgMain_PageChanged" />
    </ContentTemplate>
</asp:UpdatePanel>

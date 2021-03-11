<%@ Assembly Name="Microsoft.Web.CommandUI, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="SharePoint" Namespace="Microsoft.SharePoint.WebControls" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %> 
<%@ Register Tagprefix="Utilities" Namespace="Microsoft.SharePoint.Utilities" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Register Tagprefix="asp" Namespace="System.Web.UI" Assembly="System.Web.Extensions, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" %>
<%@ Import Namespace="Microsoft.SharePoint" %> 
<%@ Register Tagprefix="WebPartPages" Namespace="Microsoft.SharePoint.WebPartPages" Assembly="Microsoft.SharePoint, Version=15.0.0.0, Culture=neutral, PublicKeyToken=71e9bce111e9429c" %>
<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpDocumentMainV2UserControl.ascx.cs" Inherits="Intraweb.Webpart.wpDocumentMainV2UserControl" %>
<link href="/Style%20Library/jqueryPage/jquery-ui.css" rel="stylesheet">
<style>
	.bctl_img{
		width: 34px;
		padding-left: 59px
	}
	.table-container{
		font-size: 12px;
		margin-right: 10px;
	}
	.table-container table {
		border-collapse: collapse;
		width: 100%;
		}
		
	.table-container th {
		text-transform: uppercase;
		background-color: #80caed;
		border: 1px solid #0096DE;
		padding: 6px;
		color: #08384f;
		text-align: center;
	}
	.table-container .align-left {
		text-align: left;
		}
	.table-container td {
		text-align: center;
		border: 1px solid #0096DE;
		padding: 6px;
		background-color: #ffffff;
    }
    .bctl{
    border: 1px solid #A7BCCD;
    }
    .breakword {
	    -ms-word-break: break-all;

            /* Be VERY careful with this, breaks normal words wh_erever */
            word-break: break-all;

            /* Non standard for webkit */
            word-break: break-word;

    -webkit-hyphens: auto;
        -moz-hyphens: auto;
            hyphens: auto;
    }

</style>
<div class="bctl">
    <div id="accordion" class="ui-accordion ui-widget ui-helper-reset" role="tablist">
        <asp:Repeater ID="rptDocInfo" runat="server">
            <ItemTemplate>
                <h3 class="ui-accordion-header ui-state-default ui-accordion-header-active ui-state-active ui-corner-top ui-accordion-icons" role="tab" id="ui-id-1" aria-controls="ui-id-2" aria-selected="true" aria-expanded="true" tabindex="0"><span class="ui-accordion-header-icon ui-icon ui-icon-triangle-1-s"></span><%# Eval("LoaiVanBan") %></h3>
                <div class="table-container ui-accordion-content ui-helper-reset ui-widget-content ui-corner-bottom ui-accordion-content-active" id="ui-id-2" aria-labelledby="ui-id-1" role="tabpanel" aria-hidden="false" style="display: block;">
                    <table>
				        <colgroup>
				        <col width="5%">
				        <col width="15%">
				        <col width="50%">
				        <col width="15%">
				        <col width="15%">
				        </colgroup>
			            <tbody>
			            <tr>
				            <th>STT</th>
				            <th>SỐ VĂN BẢN</th>
				            <th class="align-left">TÊN VĂN BẢN</th>
				            <th>NGÀY BAN HÀNH</th>
				            <th>FILE ĐÍNH KÈM</th>
			            </tr>
                        <asp:Repeater ID="rptDocInfoDetail" runat="server" DataSource='<%# Eval("ListDocInfoDetail") %>'>
                            <ItemTemplate>
                                <tr>
			                        <td><%# Eval("STT") %></td>		
                                    <td class="align-left breakword"><%# Eval("SoVanBan") %></td>			                    
                                    <td class="align-left"><%# string.Format("{0}", Eval("TieuDe")) %></td>
			                        <td><%# Eval("NgayBanHanh", "{0:dd/MM/yyyy}") %></td>
			                        <td>                    
                                        <asp:Repeater ID="rptFileAttach" runat="server" DataSource='<%# Eval("FileAttach") %>' OnItemCommand="rptDocumentList_ItemCommand">
                                            <ItemTemplate>
                                                <asp:LinkButton ID="lbtDownLoadAttach" ToolTip='<%# Eval("Value")%>' CommandName="DownloadDocAttach" OnClientClick="_spFormOnSubmitCalled = false; _spSuppressFormOnSubmitWrapper=true;"
                                                         CommandArgument='<%# Eval("Key")%>' runat="server">
                                                    <img src="/Style%20Library/images/download_btn.png" alt="File <%# Container.ItemIndex + 1 %>" style="width: 30px;">    
                                                </asp:LinkButton>
                                            </ItemTemplate>      
                                            <SeparatorTemplate>
                                                ,
                                            </SeparatorTemplate>              
                                        </asp:Repeater>
			                        </td>
		                        </tr>
                            </ItemTemplate>                            
                        </asp:Repeater>
                        </tbody>
                    </table>
                </div>
            </ItemTemplate>
        </asp:Repeater>
   
         </div>
</div>
<script>

    $("#accordion").accordion({
        heightStyle: "content"
    });

</script>
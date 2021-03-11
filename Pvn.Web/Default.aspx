<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Pvn.Web.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
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
    </form>
</body>
</html>

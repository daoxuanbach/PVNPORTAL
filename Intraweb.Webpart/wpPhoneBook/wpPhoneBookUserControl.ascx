<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="wpPhoneBookUserControl.ascx.cs" Inherits="Intraweb.Webpart.wpPhoneBookUserControl" %>
<div style="display:inline-block;font-size:12px;">
    <a href='<%= UrlSearchName %>'>Tìm kiếm theo tên</a><%--, <a href='<%= UrlSearchComboBox %>'>Tìm kiếm theo Đơn vị/Phòng/Ban</a>--%>
</div>
        <div class="list-search">
	        <div class="list-search-title"><%= TenTab %></div>    
            <table border="0" width="100%" >
                <colgroup>                
		            <col width="30%">                        
		            <col width="70%">                
		        </colgroup>
                <tr style="text-align:left">
                    <td style="text-align:right">Loại hình đơn vị&nbsp;</td> 
                    <td><asp:DropDownList ID="ddlCompanyLevel" OnSelectedIndexChanged="ddlCompanyLevel_SelectedIndexChanged" AutoPostBack="true" Width="350px" runat="server"></asp:DropDownList></td>
                </tr>
                <tr style="text-align:left">                
                    <td style="text-align:right">Tên đơn vị&nbsp;</td>
                    <td><asp:DropDownList ID="ddlCompany" OnSelectedIndexChanged="ddlCompany_SelectedIndexChanged" AutoPostBack="true" Width="350px" runat="server"></asp:DropDownList></td>
                </tr>
                <tr style="text-align:left">                
                    <td style="text-align:right">Phòng/Ban&nbsp;</td> 
                    <td><asp:DropDownList ID="ddlDepartment" Width="350px" runat="server"></asp:DropDownList></td>
                </tr>
                <tr>
                    <td colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Button ID="btnSearch" CssClass="submitbutton" runat="server" Text="Tìm kiếm" OnClick="btnSearch_Click" />
                    </td>
                </tr>
            </table>
        </div>
        <hr />
        <div class="fr">            
            <a href="javascript:exportFromHTML()" class="exportexcel">In lịch</a>
        </div> 
        <div id="danhbaContent">            
        <asp:Repeater ID="rptCompany" runat="server">
            <ItemTemplate>
                <div class="phonebook-companytitle"><%# Eval("CompanyName") %></div>
                <div class="list-search-address">
	                <ul>
		               <%# Eval("CompanyContact") %>
	                </ul>
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <div class="phonebookcontainer">
            <asp:Repeater ID="rptDepartment" runat="server">
                <HeaderTemplate><ol></HeaderTemplate>
                <ItemTemplate>
                    <li>
                        <div class="phonebook-departname"><%# Eval("DepartmentName") %></div>
                        <div class="phonebook-departitem">
                            <asp:Repeater ID="rptWorker" DataSource='<%# Eval("ListPhoneDetail") %>' runat="server">                        
                                <ItemTemplate>                            
                                    <div class="phonebookitem">
		                                <div class="phonebook-jobtitle"><%# Eval("JobTitle") %></div>
                                        <asp:Repeater ID="rptWorkerDetail" runat="server" DataSource='<%# Eval("ListWorkerDetail") %>'>
                                            <ItemTemplate>
                                                <div class="phonebook-name"><%# Eval("GioiTinh") %><b><%# Eval("HoTen") %></b></div>
		                                        <div class="phonebook-detail">
			                                        <div class="phonebook-detail-contact fl">
				                                        <ul>
					                                        <%# Eval("Contact") %>
				                                        </ul>
			                                        </div>
			                                        <div class="phonebook-detail-image fr">
				                                            <asp:Image Width="80px" Visible='<%# !string.IsNullOrEmpty(Convert.ToString(Eval("ImageUrl"))) %>' Height="100px" ID="imgImage" 
                                                                runat="server" ToolTip='<%# Eval("HoTen") %>'
                                                            AlternateText='<%# Eval("HoTen") %>' ImageUrl='<%# Eval("ImageURL") %>' 
                                                                OnError='<%# "HideImages(this.id)" %>' />
			                                        </div>	
			                                        <div class="clear"></div>
		                                        </div>
                                            </ItemTemplate>
                                        </asp:Repeater>
	                                </div>                           
                                </ItemTemplate>                       
                            </asp:Repeater>
                        </div>
                    </li>
                </ItemTemplate>
                <FooterTemplate></ol></FooterTemplate>
            </asp:Repeater>
        </div>
        </div>
<script type="text/javascript">
    function exportFromHTML() {
        var Company = $('#<%=ddlCompany.ClientID%>').val();
        var Department = $('#<%=ddlDepartment.ClientID%>').val();
        var url = "/Usercontrols/ExportPVNPhoneBook.aspx?Company=" + Company + "&Department=" + Department;
        window.location = url;
        return false;
    }
</script>
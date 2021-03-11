<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PVNPhoneBook.aspx.cs" Inherits="Pvn.Web.PVNPhoneBook" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
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
        
        <div id="danhbaContent">            
        <asp:Repeater ID="rptCompany" runat="server">
            <ItemTemplate>
                <div class="phonebook-companytitle" style="display:none "><%# Eval("CompanyName") %></div>
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
     
    </form>
</body>
</html>

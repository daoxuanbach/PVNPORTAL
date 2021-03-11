<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Comment.ascx.cs" Inherits="Pvn.Web.Usercontrols.Comment" %>
<script type="text/javascript">
    $(document).ready(function () {
        $('#InputArea :input[type=text]').bind('keypress', function (e) {
            var code = e.keyCode ? e.keyCode : e.which;
            if (code.toString() == 13) {
                var searchButton = $('#InputArea a[id$="btnSend"]');
                if (searchButton != undefined) {
                    var searchButtonHref = searchButton.attr('href');
                    //excecute javascript function
                    eval(searchButtonHref);
                    return false;
                }
            }
        });
        setMess();
    });
    function replaceString(strsearch) {
        while (strsearch.indexOf('_') > 0) {
            strsearch = strsearch.replace('_', '$');
        }
        return strsearch;
    }
    function setMess() { 
      
        $('#<%= hdfHotenMess.ClientID %>').val('Bạn phải nhập Họ tên !');
        $('#<%= hdfEmailCompareMess.ClientID %>').val('Bạn phải nhập Email đúng định dạng');
        $('#<%= hdfEnamilMess.ClientID %>').val('Bạn phải nhập Email');
        $('#<%= hdfMaMess.ClientID %>').val('Bạn phải  nhập mã !');
        $('#<%= hdfNoiDungMess.ClientID %>').val('Bạn phải nhập Nội dung');
        $('#<%= hdfPostSuccess.ClientID %>').val('Gửi thông tin thành công !');
        $('#<%= hdfPostFail.ClientID %>').val('Mã xác nhận không đúng !');
        
    }

</script>
<style>
    .tablecomment td {padding-bottom:5px;}
</style>
<br />
<a><b>
    <asp:Literal ID="ltrComment" Text="Bình luận" runat="server"></asp:Literal></b></a>
<br />
<asp:UpdatePanel ID="udpComment" runat="server">  
    <ContentTemplate>
        <table width="100%" border="0" class="tablecomment">
        	<colgroup>
                <col width="30%" />
                <col width="70%" />
            </colgroup>
            <tbody>
				<tr>
					<td><asp:Literal ID="ltrName" Text="Họ Tên:" runat="server"></asp:Literal></td>
					<td><asp:TextBox class="input" TabIndex="1" ID="txtHoTen" runat="server" Style="width: 50%" /></td>
				</tr>
				<tr>
					<td><asp:Literal ID="ltrEmail" Text="Email:" runat="server"></asp:Literal></td>
					<td><asp:TextBox class="input" ID="txtEmail" runat="server" Style="width: 50%" TabIndex="2" /></td>
				</tr>
				<tr>
					<td><asp:Literal ID="ltrCaptcha" Text="Mã xác nhận:" runat="server"></asp:Literal></td>
					<td><asp:TextBox class="input" ID="txtMa" runat="server" Style="width: 50%" TabIndex="3" /></td>
				</tr>
				<tr>
					<td>&nbsp;</td>					
                    <td style="padding:0 2px; vertical-align:middle; cursor: pointer">
                        <asp:Image Style="" ID="imgCaptcha" runat="server" ImageUrl="" Width="70px" Height="20px" />
                        <asp:Image ID="imgRefresh" Style="vertical-align:middle;" onclick="imgsecuri_click()" ImageUrl="/Style Library/Images/refresh.png"
                            runat="server" Width="20px" Height="20px" />
                        <br />
                        <asp:Literal ID="lblThongBao" runat="server" />
                    </td>
				</tr>
                <tr>
                    <td valign="top" colspan="2">&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:TextBox TextMode="MultiLine" class="marT5" ID="txtNoiDung" runat="server" Style="height:80px;width:720px" TabIndex="4" />
                    </td>
                </tr>			
			</tbody>
		</table>
        <br />
        <div style="display:flex" class="marB5">            
            <asp:LinkButton ID="btnSend" runat="server" CssClass="button" Text="Gửi bình luận"
                                OnClick="btnSend_Click" OnClientClick="return Validate();" TabIndex="5" />   
        </div>
     <Triggers>
        <asp:AsyncPostBackTrigger ControlID="btnSend" EventName="btnSend_Click" />
    </Triggers>    
    </ContentTemplate>
</asp:UpdatePanel>
<asp:HiddenField ID="hdfTemp" runat="server" />
<asp:HiddenField ID="hdfHoTen" runat="server" />
<asp:HiddenField ID="hdfHotenMess" Value="" runat="server" />
<asp:HiddenField ID="hdfEmailCompareMess" Value="" runat="server" />
<asp:HiddenField ID="hdfEmail" runat="server" />
<asp:HiddenField ID="hdfEnamilMess" Value="" runat="server" />
<asp:HiddenField ID="hdfMa" runat="server" />
<asp:HiddenField ID="hdfMaMess" Value="" runat="server" />
<asp:HiddenField ID="hdfNoiDung" runat="server" />
<asp:HiddenField ID="hdfNoiDungMess" Value="" runat="server" />
<asp:HiddenField ID="hdfPostSuccess" Value="Gửi thông tin thành công !" runat="server" />
<asp:HiddenField ID="hdfPostFail" Value="Mã xác nhận không đúng !" runat="server" />
<script type="text/javascript" language="javascript">
    function toggle_feedback_form() {
        $("#feedback_form").toggle();
    }

    function clearit() {
       <%-- $('#<%= txtHoTen.ClientID %>').val('');
        $('#<%= txtEmail.ClientID %>').val('');--%>
        $('#<%= txtNoiDung.ClientID %>').val('');
        $('#<%= txtMa.ClientID %>').val('');
    }
    function imgsecuri_click() {

        var random;
        var temp = "";
        lengthCode = Math.floor(Math.random() * 11);
        for (var i = 0; i < 9; i++) {
            temp += Math.floor(Math.random() * 11);
        }

        var imgCaptcha = document.getElementById('<%= imgCaptcha.ClientID %>');
        imgCaptcha.src = '/Usercontrols/GetCaptcha.ashx?captchaId=' + temp;

    }
    function Validate() {
        if ($('#<%= txtHoTen.ClientID %>').val() == "" || $('#<%= txtHoTen.ClientID %>').val() == "<%= hdfHoTen.Value %>") {
            alert( $('#<%= hdfHotenMess.ClientID %>').val());
           
            $('#<%= txtHoTen.ClientID %>').focus();
            return false;
        }
        if ($('#<%= txtEmail.ClientID %>').val() == "" || $('#<%= txtEmail.ClientID %>').val() == "<%= hdfEmail.Value %>") {
            alert( $('#<%= hdfEnamilMess.ClientID %>').val());
            $('#<%= txtEmail.ClientID %>').focus();
            return false;
        }
        if (echeck($('#<%= txtEmail.ClientID %>').val())) {
            alert( $('#<%= hdfEmailCompareMess.ClientID %>').val());
            $('#<%= txtEmail.ClientID %>').focus();
            return false;
        }
        if ($('#<%= txtMa.ClientID %>').val() == "" || $('#<%= txtMa.ClientID %>').val() == "<%=hdfMa.Value %>") {
            alert($('#<%= hdfMaMess.ClientID %>').val());
            $('#<%= txtMa.ClientID %>').focus();
            return false;
        }
        if ($('#<%= txtNoiDung.ClientID %>').val() == "" || $('#<%= txtNoiDung.ClientID %>').val() == "<%=hdfNoiDung.Value %>") {
            alert($('#<%= hdfNoiDungMess.ClientID %>').val());
            
            $('#<%= txtNoiDung.ClientID %>').focus();
            return false;
        }
        return true;
    }
    function echeck(str) {

        var at = "@"
        var dot = "."
        var lat = str.indexOf(at)
        var lstr = str.length
        var ldot = str.indexOf(dot)
        if (str.indexOf(at) == -1) {
            //		   alert("Invalid E-mail ID")
            return true
        }

        if (str.indexOf(at) == -1 || str.indexOf(at) == 0 || str.indexOf(at) == lstr) {
            //		   alert("Invalid E-mail ID")
            return true
        }

        if (str.indexOf(dot) == -1 || str.indexOf(dot) == 0 || str.indexOf(dot) == lstr) {
            //		    alert("Invalid E-mail ID")
            return true
        }

        if (str.indexOf(at, (lat + 1)) != -1) {
            //		    alert("Invalid E-mail ID")
            return true
        }

        if (str.substring(lat - 1, lat) == dot || str.substring(lat + 1, lat + 2) == dot) {
            //		    alert("Invalid E-mail ID")
            return true
        }

        if (str.indexOf(dot, (lat + 2)) == -1) {
            //		    alert("Invalid E-mail ID")
            return true
        }

        if (str.indexOf(" ") != -1) {
            //		    alert("Invalid E-mail ID")
            return true
        }
        return false
    }
</script>
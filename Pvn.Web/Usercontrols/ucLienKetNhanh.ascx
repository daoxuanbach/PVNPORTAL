<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ucLienKetNhanh.ascx.cs" Inherits="Pvn.Web.Usercontrols.ucLienKetNhanh" %>
<div class="input-group input-group-sm lienketnhanh">
    <span class="input-group-addon" style="position: relative; top: 0px; font-family: fantasy; font-style: normal; left: 0px; border-radius: 0px;">
        <i class="fa fa-internet-explorer" aria-hidden="true"></i>
    </span>
    <select name="ddlWeblink" id="ddlWeblink" class="form-control" style="height: 30px; padding: 5px 10px; font-size: 12px; line-height: 1.5; border-radius: 0px;">
        <option selected="selected" value="#">Liên kết</option>
        <asp:Repeater ID="rptLienKetNhanh" runat="server">
            <ItemTemplate>
                <option value="<%# string.Format("{0}", Eval("Url")) %>"><%#Eval("Title").ToString() %></option>
            </ItemTemplate>
        </asp:Repeater>
    </select>
</div>

<script>
    $('#ddlWeblink').bind('change', function () { // bind change event to select
        var url = $(this).val(); // get selected value
        if (url != '') { // require a URL
            //window.location = url; // redirect
            var win = window.open(url, '_blank');
            win.focus();
        }
        return false;
    });
</script>
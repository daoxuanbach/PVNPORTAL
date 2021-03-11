using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;

namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wp_LanhDaoPVN : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols/ucLanhDaoPVN.ascx";
        ucLanhDaoPVN _uc = new ucLanhDaoPVN();
        protected override void CreateChildControls()
        {
            _uc = (ucLanhDaoPVN)Page.LoadControl(_ascxPath);
            this.Controls.Add(_uc);
        }
    }
}

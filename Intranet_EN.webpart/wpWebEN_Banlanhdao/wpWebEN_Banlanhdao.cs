using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PvnEN.Web.Usercontrols_EN;

namespace Intranet_EN.webpart
{
    [ToolboxItemAttribute(false)]
    public class wpWebEN_Banlanhdao : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucbanlanhdao.ascx";
        ucbanlanhdao _uc = new ucbanlanhdao();
        protected override void CreateChildControls()
        {
            _uc = (ucbanlanhdao)Page.LoadControl(_ascxPath);
            this.Controls.Add(_uc);
        }
    }
}

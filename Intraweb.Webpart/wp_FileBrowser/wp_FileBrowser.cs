using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using FileBrowser.FileBrowser;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wp_FileBrowser : WebPart
    {
        private const string _ascxPath = @"~/FileBrowser/ucFileBrowser.ascx";
        ucFileBrowser _uc = new ucFileBrowser();
        protected override void CreateChildControls()
        {
            _uc = (ucFileBrowser)Page.LoadControl(_ascxPath);
            //_uc.TotalItems = this.TotalItems;
            //_uc.BannerPosition = this.BannerPosition;
            //_uc.IsBannerText = this.IsBannerText;
            this.Controls.Add(_uc);
        }

    }
}

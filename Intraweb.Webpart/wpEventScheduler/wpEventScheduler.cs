using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpEventScheduler : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/UserControls/wpEventSchedulerUserControl.ascx";
        wpEventSchedulerUserControl _ucPhoneBook = new wpEventSchedulerUserControl();
        protected override void CreateChildControls()
        {
            _ucPhoneBook = (wpEventSchedulerUserControl)Page.LoadControl(_ascxPath);
            //_ucPhoneBook.UrlSearchComboBox = this.UrlSearchComboBox;
            //_ucPhoneBook.UrlSearchName = this.UrlSearchName;
            //_ucPhoneBook.CompanyID = this.CompanyID;
            //_ucPhoneBook.CompanyLevelID = this.CompanyLevelID;
            //_ucPhoneBook.TenTab = this.TenTab;
            this.Controls.Add(_ucPhoneBook);
        }
    }
}

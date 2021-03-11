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
    public class wpMeetingSchedule : WebPart
    {
        private string strTenTab = "LỊCH HỌP TẠI TRỤ SỞ TẬP ĐOÀN DẦU KHÍ VIỆT NAM"; //string.Empty; // Tiêu đề của webpart
        [Browsable(true),
        WebDisplayName("Tiêu đề webpart"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public string TenTab
        {
            get { return strTenTab; }
            set { strTenTab = value; }
        }
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/Usercontrols/wpMeetingScheduleUserControl.ascx";
        wpMeetingScheduleUserControl _ucPhoneBook = new wpMeetingScheduleUserControl();
        protected override void CreateChildControls()
        {
            _ucPhoneBook = (wpMeetingScheduleUserControl)Page.LoadControl(_ascxPath);
            //_ucPhoneBook.UrlSearchComboBox = this.UrlSearchComboBox;
            //_ucPhoneBook.UrlSearchName = this.UrlSearchName;
            //_ucPhoneBook.CompanyID = this.CompanyID;
            //_ucPhoneBook.CompanyLevelID = this.CompanyLevelID;
            _ucPhoneBook.TenTab = this.TenTab;
            this.Controls.Add(_ucPhoneBook);
        }
    }
}

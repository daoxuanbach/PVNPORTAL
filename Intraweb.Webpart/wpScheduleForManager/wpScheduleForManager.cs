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
    public class wpScheduleForManager : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/UserControls/wpScheduleForManagerUserControl.ascx";
        wpScheduleForManagerUserControl _ucPhoneBook = new wpScheduleForManagerUserControl();
        protected override void CreateChildControls()
        {
            //Control control = Page.LoadControl(_ascxPath);
            //Controls.Add(control);
            _ucPhoneBook = (wpScheduleForManagerUserControl)Page.LoadControl(_ascxPath);
            _ucPhoneBook.UrlLink = this.UrlLink;
            _ucPhoneBook.TenTab = this.TenTab;
            this.Controls.Add(_ucPhoneBook);
        }

        private String _urlLink = "/Pages/lichcongtac.aspx";
        [Browsable(true),
        WebDisplayName("Đường dẫn link"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlLink
        {
            get { return _urlLink; }
            set { _urlLink = value; }
        }

        private String _TenTab = "LỊCH HOẠT ĐỘNG CỦA LÃNH ĐẠO TẬP ĐOÀN DẦU KHÍ QUỐC GIA VIỆT NAM";
        [Browsable(true),
        WebDisplayName("Tiêu đề webpart"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }
    }
}

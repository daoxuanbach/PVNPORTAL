using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpVideoMain : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucVideoMain.ascx";
        ucVideoMain _uc = new ucVideoMain();
        protected override void CreateChildControls()
        {
            _uc = (ucVideoMain)Page.LoadControl(_ascxPath);
            _uc.UrlLink = this.UrlLink;
            _uc.TenTab = this.TenTab;
            _uc.CategoryId = this.CategoryId;
            _uc.MaxLengthTitle = this.MaxLengthTitle;
            this.Controls.Add(_uc);
        }
        private String _urlLink = "/pages/thu-vien-video.aspx";
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

        private String _TenTab = "Thư viện video";
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

        private String _CategoryId = string.Empty;
        [Browsable(true),
        WebDisplayName("Video thuộc chuyên mục"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String CategoryId
        {
            get { return _CategoryId; }
            set { _CategoryId = value; }
        }

        private int _MaxLengthTitle = 100;
        [Browsable(true),
        WebDisplayName("Đội dài tiêu đề Vide"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public int MaxLengthTitle
        {
            get { return _MaxLengthTitle; }
            set { _MaxLengthTitle = value; }
        }
    }
}

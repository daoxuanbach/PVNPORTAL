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
    public class wpImagesVideoMain : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucImagesVideoMain.ascx";
        ucImagesVideoMain _uc = new ucImagesVideoMain();
        protected override void CreateChildControls()
        {
            _uc = (ucImagesVideoMain)Page.LoadControl(_ascxPath);
            _uc.UrlLinkAnh = this.UrlLinkAnh;
            _uc.UrlLinkVideo = this.UrlLinkVideo;
            _uc.TenTab = this.TenTab;
            _uc.TenTabVideo = this.TenTabVideo;
            
            _uc.CategoryAnhId = this.CategoryAnhId;
            _uc.CategoryVideoId = this.CategoryVideoId;
            _uc.TotalItems = this.TotalItems;
            _uc.MaxLengthTitle = this.MaxLengthTitle;
            this.Controls.Add(_uc);
        }
        private String _UrlLinkVideo = "/pages/thu-vien-video.aspx";
        [Browsable(true),
        WebDisplayName("Đường dẫn link Video"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlLinkVideo
        {
            get { return _UrlLinkVideo; }
            set { _UrlLinkVideo = value; }
        }


        private String _urlLinkAnh = "/pages/thu-vien-anh.aspx";
        [Browsable(true),
        WebDisplayName("Đường dẫn link anh"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlLinkAnh
        {
            get { return _urlLinkAnh; }
            set { _urlLinkAnh = value; }
        }

        private String _TenTab = "Thư viện ảnh";
        [Browsable(true),
        WebDisplayName("Tiêu đề Tab Anh"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }
        private String _TenTabVideo = "Thư viện Video";
        [Browsable(true),
        WebDisplayName("Tiêu đề Tab Video"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String TenTabVideo
        {
            get { return _TenTabVideo; }
            set { _TenTabVideo = value; }
        }
        
        private String _CategoryAnhId = string.Empty;
        [Browsable(true),
        WebDisplayName("Ảnh thuộc chuyên mục"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String CategoryAnhId
        {
            get { return _CategoryAnhId; }
            set { _CategoryAnhId = value; }
        }

        private String _CategoryVideoId = string.Empty;
        [Browsable(true),
        WebDisplayName("Video thuộc chuyên mục"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String CategoryVideoId
        {
            get { return _CategoryVideoId; }
            set { _CategoryVideoId = value; }
        }
        private int _TotalItems = 5;
        [Browsable(true),
        WebDisplayName("Số ảnh hiển thị"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public int TotalItems
        {
            get { return _TotalItems; }
            set { _TotalItems = value; }
        }
        private int _MaxLengthTitle = 100;
        [Browsable(true),
        WebDisplayName("Đội dài tiêu đề ảnh"),
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

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
    public class wpInternetNewsRelatedV2 : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucInternetNewsRelatedV2.ascx";
        ucInternetNewsRelatedV2 _uc = new ucInternetNewsRelatedV2();
        protected override void CreateChildControls()
        {
             _uc = (ucInternetNewsRelatedV2)Page.LoadControl(_ascxPath);
            _uc.TotalNews = this.TotalNews;
            _uc.TenTab = this.TenTab;
            _uc.MaxLengthTitle = this.MaxLengthTitle;
            _uc.MaxLengthSummary = this.MaxLengthSummary;
            _uc.UrlDetail = this.UrlDetail;
                _uc.CurrentLanguage = this.CurrentLanguage;
            this.Controls.Add(_uc);
        }


       
        //Task list name string
        private int _totalNews=5;
        private int _maxLengthTitle =100;
        private int _maxLengthSummary;
        private String _urlDetail="/chuyen-muc";///detail.aspx";
        private String currentLanguage="vi-VN";
        /// <summary>
        /// Number of news item
        /// </summary>
        private String _TenTab = "Tin liên quan";
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

        [Browsable(true),
        WebDisplayName("Số lượng tin sẽ hiển thị"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public int TotalNews
        {
            get { return _totalNews; }
            set { _totalNews = value; }
        }


        /// <summary>
        /// Max length summary
        /// </summary>
           [Browsable(true),
        WebDisplayName("Độ dài của tiêu đề tin"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public int MaxLengthSummary
        {
            get { return _maxLengthSummary; }
            set { _maxLengthSummary = value; }
        }
        /// <summary>
        /// Max length title
        /// </summary>
           [Browsable(true),
        WebDisplayName("Độ dài của tóm tắt tin"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public int MaxLengthTitle
        {
            get { return _maxLengthTitle; }
            set { _maxLengthTitle = value; }
        }


        /// <summary>
        /// Url detail
        /// </summary>
          [Browsable(true),
        WebDisplayName("Đường dẫn link trang chi tiết"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }


        /// <summary>
        /// Url detail
        /// </summary>
       [Browsable(true),
        WebDisplayName("Ngôn ngữ"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }

    }
}

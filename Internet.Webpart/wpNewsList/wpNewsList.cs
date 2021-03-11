using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using Pvn.Web.Usercontrols;

namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpNewsList : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucNewsList.ascx";
        ucNewsList _uc = new ucNewsList();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsList)Page.LoadControl(_ascxPath);
            _uc.TotalNews = this.TotalNews;
            _uc.TotalOtherNews=this.TotalOtherNews;
            _uc.UrlDetail=this.UrlDetail;
            _uc.UrlList=this.UrlList;
            _uc.MainImageSize=this.MainImageSize;
            _uc.OtherImageSize=this.OtherImageSize;
            _uc.MaxLengthTitle=this.MaxLengthTitle;
            _uc.MaxLengthSummary=this.MaxLengthSummary;
            _uc.CurrentLanguage = this.CurrentLanguage;
            _uc.ViewDetailButtonText = this.ViewDetailButtonText;
            _uc.PrePagingButtonText = this.PrePagingButtonText;
            _uc.NextPagingButtonText = this.NextPagingButtonText;
            this.Controls.Add(_uc);
        }

       
        //Task list name string
        private int _totalNews;
       
        private String _urlDetail;
        private String _urlList;
        private String _mainImageSize;
        private String _otherImageSize;
        private int _maxLengthTitle =90;
        private int _maxLengthSummary =200;
        private String currentLanguage;
        /// <summary>
        /// Number of news item
        /// </summary>
        public int TotalNews
        {
            get { return _totalNews; }
            set { _totalNews = value; }
        }
        /// <summary>
        /// News priority
        /// </summary>
        /// 
        private int _totalOtherNews;
        public int TotalOtherNews
        {
            get { return _totalOtherNews; }
            set { _totalOtherNews = value; }
        }
        /// <summary>
        /// Url detail
        /// </summary>
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }
        /// <summary>
        /// Url list
        /// </summary>
        public String UrlList
        {
            get { return _urlList; }
            set { _urlList = value; }
        }
        /// <summary>
        /// Main image size
        /// </summary>
        public String MainImageSize
        {
            get { return _mainImageSize; }
            set { _mainImageSize = value; }
        }
        /// <summary>
        /// other image size
        /// </summary>
        public String OtherImageSize
        {
            get { return _otherImageSize; }
            set { _otherImageSize = value; }
        }

        /// <summary>
        /// Max length summary
        /// </summary>
        public int MaxLengthSummary
        {
            get { return _maxLengthSummary; }
            set { _maxLengthSummary = value; }
        }
        /// <summary>
        /// Max length title
        /// </summary>
        public int MaxLengthTitle
        {
            get { return _maxLengthTitle; }
            set { _maxLengthTitle = value; }
        }

        public String CategoryTitle { get; set; }

        /// <summary>
        /// Url detail
        /// </summary>
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }

        [WebBrowsable(true),
        WebDisplayName("Nút xem chi tiết text"),
        Personalizable(PersonalizationScope.Shared)]
        public string ViewDetailButtonText { get; set; }
        [WebBrowsable(true),
         WebDisplayName("Nút pre phân trang text"),
         Personalizable(PersonalizationScope.Shared)]
        public string PrePagingButtonText { get; set; }
        [WebBrowsable(true),
         WebDisplayName("Nút next phân trang text"),
         Personalizable(PersonalizationScope.Shared)]
        public string NextPagingButtonText { get; set; }

        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            NewsListProperties edPart = new NewsListProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    }
}

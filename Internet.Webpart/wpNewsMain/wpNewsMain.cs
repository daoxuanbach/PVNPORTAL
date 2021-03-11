using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;
using System.Collections;

namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpNewsMain : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucNewsMain.ascx";
        ucNewsMain _uc = new ucNewsMain();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsMain)Page.LoadControl(_ascxPath);
            _uc.TieuDe = this.TieuDe; ;
            _uc.TotalNews = this.TotalNews; ;
            _uc.NewsPriority = this.NewsPriority; ;
            _uc.OtherNewsPriority = this.OtherNewsPriority; ;
            _uc.OtherTotalNews = this.OtherTotalNews; ;
            _uc.MaxLengthTitle = this.MaxLengthTitle; ;
            _uc.MaxLengthOtherTitle = this.MaxLengthOtherTitle; ;
            _uc.MaxLengthSummary = this.MaxLengthSummary; ;
            _uc.CategoryID = this.CategoryID;
            _uc.CurrentLanguage = this.CurrentLanguage; 
            _uc.UrlDetail = this.UrlDetail; ;
            _uc.UrlList = this.UrlList; ;
            _uc.MainImageSize = this.MainImageSize; ;
            _uc.OtherImageSize = this.OtherImageSize; ;
            this.Controls.Add(_uc);
        }

       
        public override object WebBrowsableObject
        {
            get
            {
                return this;
            }
        }
        //Task list name string
        private int _totalNews;
        private string _TieuDe = "Tin tức";

        private int _newsPriority;
        private int _otherNewsPriority;
        private int _otherTotalNews;
        private int _maxLengthTitle;
        private int _maxLengthOtherTitle;
        private int _maxLengthSummary;
        private String _categoryID;
        private string currentLanguage;
        private String _urlDetail;
        private String _urlList;
        private String _mainImageSize;
        private String _otherImageSize;
        [Personalizable(), WebBrowsable(false)]
        public string TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        /// <summary>
        /// Number of news item
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int TotalNews
        {
            get { return _totalNews; }
            set { _totalNews = value; }
        }
        /// <summary>
        /// News priority
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int NewsPriority
        {
            get { return _newsPriority; }
            set { _newsPriority = value; }
        }
        /// <summary>
        /// Number of other news item
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int OtherTotalNews
        {
            get { return _otherTotalNews; }
            set { _otherTotalNews = value; }
        }
        /// <summary>
        /// News priority
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int OtherNewsPriority
        {
            get { return _otherNewsPriority; }
            set { _otherNewsPriority = value; }
        }
        /// <summary>
        /// Max length summary
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int MaxLengthSummary
        {
            get { return _maxLengthSummary; }
            set { _maxLengthSummary = value; }
        }
        /// <summary>
        /// Max length title
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int MaxLengthTitle
        {
            get { return _maxLengthTitle; }
            set { _maxLengthTitle = value; }
        }
        /// <summary>
        /// Max length other title
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int MaxLengthOtherTitle
        {
            get { return _maxLengthOtherTitle; }
            set { _maxLengthOtherTitle = value; }
        }
        /// <summary>
        /// CategoryID
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public String CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
        }
        [Personalizable(), WebBrowsable(false)]
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
        /// <summary>
        /// Url detail
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }
        /// <summary>
        /// Url list
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public String UrlList
        {
            get { return _urlList; }
            set { _urlList = value; }
        }
        /// <summary>
        /// Main image size
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public String MainImageSize
        {
            get { return _mainImageSize; }
            set { _mainImageSize = value; }
        }
        /// <summary>
        /// other image size
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public String OtherImageSize
        {
            get { return _otherImageSize; }
            set { _otherImageSize = value; }
        }
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            ToolpartNewsMain edPart = new ToolpartNewsMain();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    }
}

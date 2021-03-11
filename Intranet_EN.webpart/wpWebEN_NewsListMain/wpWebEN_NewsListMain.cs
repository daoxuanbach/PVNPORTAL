using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PvnEN.Web.Usercontrols_EN;
using System.Collections;

namespace Intranet_EN.webpart
{
    [ToolboxItemAttribute(false)]
    public class wpWebEN_NewsListMain : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucNewsListMain.ascx";
        ucNewsListMain _uc = new ucNewsListMain();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsListMain)Page.LoadControl(_ascxPath);
            //_uc.TieuDeMenu = this.TieuDeMenu; ;
            _uc.TotalNews = this.TotalNews;
            _uc.NewsPriority = this.NewsPriority;
            _uc.MaxLengthTitle = this.MaxLengthTitle;
            _uc.MaxLengthSummary = this.MaxLengthSummary;
            _uc.CategoryID = this.CategoryID;
            _uc.UrlDetail = this.UrlDetail;
            _uc.UrlList = this.UrlList;
            _uc.MainImageSize = this.MainImageSize;
            _uc.OtherImageSize = this.OtherImageSize;
            _uc.CurrentLanguage = this.CurrentLanguage;
            _uc.TieuDe = this.TieuDe;
            this.Controls.Add(_uc);
        }
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            Toolpart_NewsListMain edPart = new Toolpart_NewsListMain();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
        #region Custom Web part property
        //Task list name string
        private int _totalNews = 4;
        private int _newsPriority = 2;
        private int _maxLengthTitle = 100;
        private int _maxLengthSummary = 100;
        private String _categoryID;
        private String _urlDetail = "/Pages/detail.aspx";
        private String _urlList = "/Pages/list.aspx";
        private String _mainImageSize = "C500x310";
        private String _otherImageSize = "C116x76";
        private String currentLanguage = Pvn.Utils.Constants.Language.VIETNAMESE;
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
        public int NewsPriority
        {
            get { return _newsPriority; }
            set { _newsPriority = value; }
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
        /// <summary>
        /// CategoryID
        /// </summary>
        public String CategoryID
        {
            get { return _categoryID; }
            set { _categoryID = value; }
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
        /// Url detail
        /// </summary>
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }

        private string _TieuDe = "NEWS";
        [Category("Tieu De"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("TieuDe"),
      WebDescription("TieuDe")]
        public String TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
        #endregion
    }
}

using System;
using System.Collections;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PvnEN.Web.Usercontrols_EN;

namespace Intranet_EN.webpart
{
    [ToolboxItemAttribute(false)]
    public class wpWebEN_NewsList : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucNewsList.ascx";
        ucNewsList _uc = new ucNewsList();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsList)Page.LoadControl(_ascxPath);
            //_uc.TieuDeMenu = this.TieuDeMenu; ;
            _uc.TotalNews = this.TotalNews;
            _uc.TotalOtherNews = this.TotalOtherNews;
            _uc.CategoryID = this.CategoryID;
            _uc.UrlDetail = this.UrlDetail;
            _uc.UrlList = this.UrlList;
            _uc.MainImageSize = this.MainImageSize;
            _uc.OtherImageSize = this.OtherImageSize;
            _uc.CurrentLanguage = this.CurrentLanguage;
            _uc.TitleXemChiTiet = this.TitleXemChiTiet;
            this.Controls.Add(_uc);
        }

        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            Toolpart_NewList edPart = new Toolpart_NewList();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
        #region Custom Web part property
        private string _TitleXemChiTiet = "Detail >>";
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("TitleXemChiTiet"),
        WebDescription("TitleXemChiTiet")]
        public string TitleXemChiTiet
        {
            get { return _TitleXemChiTiet; }
            set { _TitleXemChiTiet = value; }

        }
        private int _MaxLengthTitle = 100;
       
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("MaxLengthTitle"),
        WebDescription("MaxLengthTitle")]
        public int MaxLengthTitle { 
            get { return _MaxLengthTitle; }
            set { _MaxLengthTitle = value; } }

        //this will be taken from query string
        private Guid _categoryID;
        private int _totalNews = 10;
        private int _totalOtherNews = 5;
        //this will be taken from query string
        private String _urlDetail = "/sites/en/Pages/detail.aspx";
        private String _urlList = "/sites/en/Pages/list.aspx";
        private String _mainImageSize = "C254x172";
        private String _otherImageSize = "C150x86";
        private string currentLanguage = string.Empty;
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
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
        public int TotalOtherNews
        {
            get { return _totalOtherNews; }
            set { _totalOtherNews = value; }
        }
        /// <summary>
        /// CategoryID
        /// </summary>        
        public Guid CategoryID
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
        public String CategoryTitle { get; set; }
        #endregion

    }
}

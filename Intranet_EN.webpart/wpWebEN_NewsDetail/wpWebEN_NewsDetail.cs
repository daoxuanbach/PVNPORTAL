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
    public class wpWebEN_NewsDetail : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucNewsDetail.ascx";
        ucNewsDetail _uc = new ucNewsDetail();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsDetail)Page.LoadControl(_ascxPath);
            //_uc.TieuDeMenu = this.TieuDeMenu; ;
            _uc.TotalNewsTimeLine = this.TotalNewsTimeLine;
            _uc.TotalOtherNews = this.TotalOtherNews;
            //this will be taken from query string
            _uc.UrlDetail = this.UrlDetail;
            _uc.UrlList = this.UrlList;
            _uc.UrlSearchList = this.UrlSearchList;
            //show hide components
            _uc.IsShowBreadcum = this.IsShowBreadcum;
            _uc.IsShowTitle = this.IsShowTitle;
            _uc.IsShowSummary = this.IsShowSummary;
            _uc.IsShowRelatedNews = this.IsShowRelatedNews;
            _uc.IsShowTags = this.IsShowTags;
            _uc.IsShowOtherNews = this.IsShowOtherNews;
            _uc.IsShowNewsInSubject = this.IsShowNewsInSubject;
            this.Controls.Add(_uc);
        }
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            Toolpart_NewDetail edPart = new Toolpart_NewDetail();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
        #region Custom Web part property
        private int _totalNewsTimeLine = 3;
        private int _totalOtherNews = 5;
        //this will be taken from query string
        private String _urlDetail = "/sites/en/Pages/detail.aspx";
        private String _urlList = "/sites/en/Pages/list.aspx";
        private String _urlSearchList = "/sites/en/Pages/newssearch.aspx";
        //show hide components
        private bool isShowBreadcum = true;
        private bool isShowTitle = true;
        private bool isShowSummary = true;
        private bool isShowRelatedNews = true;
        private bool isShowTags = true;
        private bool isShowOtherNews = true;
        private bool isShowNewsInSubject = true;
        /// <summary>
        /// Number of news item
        /// </summary>
        public int TotalNewsTimeLine
        {
            get { return _totalNewsTimeLine; }
            set { _totalNewsTimeLine = value; }
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
        /// Url search list
        /// </summary>
        public String UrlSearchList
        {
            get { return _urlSearchList; }
            set { _urlSearchList = value; }
        }

        /// <summary>
        /// Is show breadcumb
        /// </summary>
        public bool IsShowBreadcum
        {
            get { return isShowBreadcum; }
            set { isShowBreadcum = value; }
        }
        /// <summary>
        /// Is show title
        /// </summary>
        public bool IsShowTitle
        {
            get { return isShowTitle; }
            set { isShowTitle = value; }
        }
        /// <summary>
        /// Is show Summary
        /// </summary>
        public bool IsShowSummary
        {
            get { return isShowSummary; }
            set { isShowSummary = value; }
        }
        /// <summary>
        /// Is show related news
        /// </summary>
        public bool IsShowRelatedNews
        {
            get { return isShowRelatedNews; }
            set { isShowRelatedNews = value; }
        }
        /// <summary>
        /// Is show tags
        /// </summary>
        public bool IsShowTags
        {
            get { return isShowTags; }
            set { isShowTags = value; }
        }
        /// <summary>
        /// Is show other news
        /// </summary>
        public bool IsShowOtherNews
        {
            get { return isShowOtherNews; }
            set { isShowOtherNews = value; }
        }
        /// <summary>
        /// Is show news in subject
        /// </summary>
        public bool IsShowNewsInSubject
        {
            get { return isShowNewsInSubject; }
            set { isShowNewsInSubject = value; }
        }
        #endregion

    }
}

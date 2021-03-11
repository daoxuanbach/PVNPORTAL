using Pvn.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace PvnEN.Web.Usercontrols_EN
{
    public partial class ucNewsListMain : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                BindData();
            }
        }

        #region BindData

        /// <summary>
        /// Bind news data
        /// </summary>
        private void BindData()
        {
            try
            {
                CMS_NewsDA objBL = new CMS_NewsDA();

                DataSet ds = objBL.GetListTopNews(CurrentLanguage, TotalNews, NewsPriority,
                    _otherTotalNews, _otherNewsPriority, string.IsNullOrEmpty(CategoryID) ? (Guid?)null : new Guid(CategoryID));

                if (ds == null || ds.Tables.Count == 0)
                    return;
                DataTable dtNews = ds.Tables[0];
                //bind main news
                rptNews.DataSource = dtNews;
                rptNews.DataBind();
            }
            catch (Exception exc)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("UC", "UC", exc.Message);

            }
        }
        #endregion

        #region Custom Web part property
        //Task list name string
        private int _otherNewsPriority = 0;
        private int _otherTotalNews = 0;

        private int _totalNews = 4;
        private int _newsPriority = 2;
        private int _maxLengthTitle = 100;
        private int _maxLengthSummary = 100;
        private String _categoryID;
        private String _urlDetail = "/sites/en/Pages/detail.aspx";
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
        #endregion
        private string _TieuDe = "NEWS";
        public String TieuDe
        {
            get { return _TieuDe; }
            set { _TieuDe = value; }
        }
    }
}
using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucNewsMain : System.Web.UI.UserControl
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
                CMS_NewsBL objBL = new CMS_NewsBL();

                DataSet ds = objBL.GetListTopNews(CurrentLanguage, TotalNews, NewsPriority,
                    OtherTotalNews, OtherNewsPriority, string.IsNullOrEmpty(CategoryID) ? (Guid?)null : new Guid(CategoryID));

                if (ds == null || ds.Tables.Count == 0)
                    return;
                DataTable dtNews = ds.Tables[0];
                //bind main news
                rptNewsLeft.DataSource = ds.Tables[0];
                rptNewsLeft.DataBind();
                //bind other news
                rptNewsRight.DataSource = ds.Tables[1];
                rptNewsRight.DataBind();
            }
            catch (Exception exc)
            {
                //Module failed to load 
                //CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }
        #endregion

        #region Custom Web part property
        //Task list name string
        private int _totalNews;
        private int _newsPriority;
        private int _otherNewsPriority;
        private int _otherTotalNews;
        private int _maxLengthTitle;
        private int _maxLengthOtherTitle;
        private int _maxLengthSummary;
        private String _categoryID;
        private String _urlDetail;
        private String _urlList;
        private String _mainImageSize;
        private String _otherImageSize;
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
        public int NewsPriority
        {
            get { return _newsPriority; }
            set { _newsPriority = value; }
        }
        /// <summary>
        /// Number of other news item
        /// </summary>
        public int OtherTotalNews
        {
            get { return _otherTotalNews; }
            set { _otherTotalNews = value; }
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
        /// News priority
        /// </summary>
        public int OtherNewsPriority
        {
            get { return _otherNewsPriority; }
            set { _otherNewsPriority = value; }
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
        /// Max length other title
        /// </summary>
        public int MaxLengthOtherTitle
        {
            get { return _maxLengthOtherTitle; }
            set { _maxLengthOtherTitle = value; }
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

        public string TieuDe { get; set; }
    }
}
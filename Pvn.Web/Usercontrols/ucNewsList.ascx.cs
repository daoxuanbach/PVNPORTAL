using Pvn.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucNewsList : System.Web.UI.UserControl
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    //init paging
                    pgMain.PageSize = TotalNews + TotalOtherNews;
                    pgMain.ShowFirstLast = false;
                    pgMain.ShowFirstLast = false;
                    pgMain.CurrentPageIndex = 1;
                    pgMain.PrevPageText = PrePagingButtonText;
                    pgMain.NextPageText = NextPagingButtonText;
                    //bind data
                    BindData();
                    
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                   // CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
        }

        protected void pgMain_PageChanged(object src, EventArgs e)
        {
            BindData();
        }

        #region BindData
        /// <summary>
        /// bind news list data
        /// </summary>
        private void BindData()
        {
            try
            {
                CMS_NewsDA objDA = new CMS_NewsDA();
                if (CategoryID == Guid.Empty)
                {
                    return;
                }
                int totalRows = 0;
                DataSet ds = objDA.GetNewsWithPaging(
                    CurrentLanguage,
                    pgMain.CurrentPageIndex - 1,
                    TotalNews + TotalOtherNews,
                    ref totalRows,
                    CategoryID);

                if (ds == null || ds.Tables.Count != 2)
                    return;

                pgMain.RecordCount = totalRows;

                DataTable dt = ds.Tables[0];

                rptMainNewsItem.DataSource = dt;
                rptMainNewsItem.DataBind();
                //build breadcumb
                BuildBreadCumb(ds.Tables[1]);
            }
            catch (Exception exc)
            {
                //Module failed to load 
                //CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }

        /// <summary>
        /// Build breadcumb
        /// </summary>
        /// <param name="dtCategory"></param>
        private void BuildBreadCumb(DataTable dtCategory)
        {
            if (dtCategory != null && dtCategory.Rows.Count > 0)
            {
                //rptNewsBreadCumb.DataSource = dtCategory;
                //rptNewsBreadCumb.DataBind();

                //bind category name 
                DataRow[] drCategory = dtCategory.Select("Level = 0");
                CategoryTitle = Convert.ToString(drCategory[0]["Title"]);
            }
        }
        #endregion

        #region Custom Web part property
       
        //Task list name string
        private int _totalNews;
        private int _totalOtherNews;
        //this will be taken from query string
        private Guid _categoryID;
        private String _urlDetail;
        private String _urlList;

        private String _mainImageSize;
        private String _otherImageSize;
        private int _maxLengthTitle;
        private int _maxLengthSummary;
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
            get
            {
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["CatID"], out _categoryID))
                {
                    _categoryID = Guid.Empty;
                }
                return _categoryID;
            }
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

        public string ViewDetailButtonText { get; set; }
      
        public string PrePagingButtonText { get; set; }
      
        public string NextPagingButtonText { get; set; }

        #endregion
    }
}
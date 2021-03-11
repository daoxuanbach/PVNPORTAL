using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pvn.Utils;
using Pvn.DA;
using System.Data;

namespace Pvn2.Web.Usercontrols_EN
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
                    //bind data
                    BindData();
                }
                catch (Exception ex)
                {
                    Pvn.Utils.LogFile.WriteLogFile("WebNewsList", "Page_Load", ex.Message);
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
                Guid _cate;
                if (Utilities.IsGuid(this.Page.Request.QueryString["CatID"], out _cate))
                {
                    CategoryID = _cate;
                }

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
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("WebNewsList", "BindData", ex.Message);
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

        //this will be taken from query string
        private Guid _categoryID;
        private int _totalNews = 10;
        private int _totalOtherNews = 5;
        //this will be taken from query string
        private String _urlDetail = "/sites/en/Pages/detail.aspx";
        private String _urlList = "/sites/en/Pages/list.aspx";
        private String _mainImageSize = "C254x172";
        private String _otherImageSize = "C150x86";
        private string currentLanguage = Pvn.Utils.Constants.Language.ENGLISH;

        private int _MaxLengthTitle =100;

        public int MaxLengthTitle { get => _MaxLengthTitle; set => _MaxLengthTitle = value; }
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
        private string _TitleXemChiTiet = "Detail >>";

        public string TitleXemChiTiet
        {
            get { return _TitleXemChiTiet; }
            set { _TitleXemChiTiet = value; }
        }



        #endregion
    }
}
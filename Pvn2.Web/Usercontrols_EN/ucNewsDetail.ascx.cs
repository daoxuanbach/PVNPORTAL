using Pvn.DA;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn2.Web.Usercontrols_EN
{
    public partial class ucNewsDetail : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    BindData();
                }
                catch (Exception ex)
                {
                    Pvn.Utils.LogFile.WriteLogFile("WebNewsDetail", "Page_Load()", ex.Message);
                }
            }
        }

        #region BindData

        /// <summary>
        /// bind news detail data
        /// </summary>
        private void BindData()
        {
            try
            {
                CMS_NewsDA objDA = new CMS_NewsDA();
                if (NewsID == Guid.Empty)
                {
                    return;
                }
                string categoryName = string.Empty;

                DataSet ds = objDA.GetNewsDetailData(Pvn.Utils.Constants.Language.ENGLISH, TotalOtherNews,
                    NewsID, TotalOtherNews, TotalNewsTimeLine, ref categoryName);

                if (ds == null || ds.Tables.Count == 0)
                    return;

                BindMainNews(ds.Tables[0]);

                //show other news
                if (IsShowOtherNews)
                {
                    rptOtherNews.DataSource = ds.Tables[1];
                    rptOtherNews.DataBind();
                }
                else
                {
                    pnlOtherNews.Visible = false;

                }
                //show news in subject
                if (IsShowNewsInSubject && ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
                {
                    //show timline
                    rptTimeline.DataSource = ds.Tables[5];
                    rptTimeline.DataBind();
                }
                else
                {
                    pnlTimeline.Visible = false;
                }
                //show breadcum
                if (IsShowBreadcum)
                {
                    //bind breadcumb
                    BuildBreadCumb(ds.Tables[2]);
                }
                //show related news 
                if (IsShowRelatedNews)
                {
                    //bind related news
                    rptRelatedNews.DataSource = ds.Tables[3];
                    rptRelatedNews.DataBind();
                }
                //show keywords
                if (IsShowTags)
                {
                    DataTable dtKeyWords = ds.Tables[4];
                    if (dtKeyWords != null && dtKeyWords.Rows.Count > 0)
                    {
                        //bind keywords
                        rptKeywords.DataSource = ds.Tables[4];
                        rptKeywords.DataBind();
                    }
                    else
                    {
                        rptKeywords.Visible = false;
                    }
                }
                else
                {
                    pnlTags.Visible = false;
                }
                //show title
                if (!IsShowTitle)
                {
                    pnlTitle.Visible = false;
                }
                //show summary
                if (!IsShowSummary)
                {
                    pnlSummary.Visible = false;
                }

            }
            catch (Exception ex)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("WebNewsDetail", "BindData()", ex.Message);
            }
        }
        /// <summary>
        /// Build breadcumb
        /// </summary>
        /// <param name="dtCategory"></param>
        private void BuildBreadCumb(DataTable dtCategory)
        {
            rptNewsBreadCumb.DataSource = dtCategory;
            rptNewsBreadCumb.DataBind();
        }
        /// <summary>
        /// Bind main news information
        /// </summary>
        /// <param name="dtMainNews"></param>
        private void BindMainNews(DataTable dtMainNews)
        {
            if (dtMainNews != null && dtMainNews.Rows.Count > 0)
            {
                //title 
                ltrTitle.Text = Convert.ToString(dtMainNews.Rows[0]["Title"]);
                DateTime _beginDate = Convert.ToDateTime(dtMainNews.Rows[0]["BeginDate"]);
                //set time
                //ltrTime.Text = _beginDate.ToString("hh:mm");
                //set date
                ltrDate.Text = _beginDate.ToString("dd/MM/yyyy");
                //set summary
                ltrSummary.Text = Convert.ToString(dtMainNews.Rows[0]["Summary"]);
                //set information
                string content = Page.Server.HtmlDecode(Convert.ToString(dtMainNews.Rows[0]["Information"]));
                //set hits 
                //ltrHits.Text = Convert.ToString(dtMainNews.Rows[0]["Hits"]);
                //cap nhat cac thuoc tinh phu
                content = RenderNewsContent.ProcessRender(content);
                ltrInformation.Text = content;

            }
        }
        #endregion
        #region Custom Web part property

        private Guid _categoryID;
        private Guid _newsID;

       
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
        private int _totalNewsTimeLine = 3;
        private int _totalOtherNews = 5;
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
        /// NewsID
        /// </summary>        
        public Guid NewsID
        {
            get
            {
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["NewsID"], out _newsID))
                {
                    _newsID = Guid.Empty;
                }
                return _newsID;
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
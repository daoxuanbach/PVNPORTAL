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
    public partial class ucNewsDetail2 : System.Web.UI.UserControl
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

        private bool _ShowTitle;

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
                //show related news 
                if (IsShowRelatedNews && ds.Tables[3] != null && ds.Tables[3].Rows.Count > 0)
                {
                    //bind related news
                    rptRelatedNews.DataSource = ds.Tables[3];
                    rptRelatedNews.DataBind();
                }
                else
                {
                    pnlRelated.Visible = false;
                }
                //show other news
                if (IsShowOtherNews&& ds.Tables[1] != null && ds.Tables[1].Rows.Count > 0)
                {
                    rptOtherNews.DataSource = ds.Tables[1];
                    rptOtherNews.DataBind();
                }
                else
                {
                    pnlOtherNews.Visible = false;

                }

            }
            catch (Exception ex)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("WebNewsDetail", "BindData()", ex.Message);
            }
        }

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
        public bool IsShowOtherNews { get => _IsShowOtherNews; set => _IsShowOtherNews = value; }

        private bool _IsShowOtherNews = true;
        private Guid _categoryID;
        private Guid _newsID;
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
        private bool _IsShowRelatedNews = true;
        public bool IsShowRelatedNews
        {
            get { return _IsShowRelatedNews; }
            set { _IsShowRelatedNews = value; }
        }
        public bool ShowTitle { get => _ShowTitle; set => _ShowTitle = value; }
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }
        public bool ShowIMGNull { get => _ShowIMGNull; set => _ShowIMGNull = value; }
        private bool _ShowIMGNull;
        private string _urlDetail;
        /// <summary>
        /// Bind main news information
        /// </summary>
        /// <param name="dtMainNews"></param>
        private void BindMainNews(DataTable dtMainNews)
        {
            if (dtMainNews != null && dtMainNews.Rows.Count > 0)
            {
                //title 
                if (ShowTitle)
                {
                    ltrTitle.Text =  string.Format("{0}", Convert.ToString(dtMainNews.Rows[0]["Title"]));
                }
                DateTime _beginDate = Convert.ToDateTime(dtMainNews.Rows[0]["BeginDate"]);
                //set time
                //ltrTime.Text = _beginDate.ToString("hh:mm");
                //set date
                //set summary
                if (!string.IsNullOrEmpty(Convert.ToString(dtMainNews.Rows[0]["Summary"])))
                {
                    ltrSummary.Text = string.Format("{0}", Convert.ToString(dtMainNews.Rows[0]["Summary"]));

                }
                else
                {
                    pnlSummary.Visible = false;
                }
                //set information
                string content = Page.Server.HtmlDecode(Convert.ToString(dtMainNews.Rows[0]["Information"]));
                ltrInformation.Text = content;

            }
        }
        #endregion
    }
}
using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn2.Web.Usercontrols_EN
{
    public partial class ucNewsRelated : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {

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
        #region BindData

        /// <summary>
        /// Bind news data
        /// </summary>
        private void BindData()
        {
            try
            {
                CMS_NewsBL objBL = new CMS_NewsBL();
                DataTable dsResult = objBL.GetOtherRelatedNews(CurrentLanguage, TotalNews, NewsID);

                if (dsResult.Rows.Count <= 0)
                    dsResult = objBL.GetOtherNewsInCate(CurrentLanguage, TotalNews, NewsID);

                //bind main news
                rptNewsLeft.DataSource = dsResult;
                rptNewsLeft.DataBind();
            }
            catch (Exception exc)
            {
                //Module failed to load 
                //  CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }
        #endregion
        #region Custom Web part property

        //Task list name string
        private int _totalNews;
        private int _newsPriority;
        private int _maxLengthTitle;
        private int _maxLengthSummary;
        private String _urlDetail;
        private Guid _newsID;
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
        /// Url detail
        /// </summary>

        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }

        /// <summary>
        /// NewsID
        /// </summary>        
        public Guid? NewsID
        {
            get
            {
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["NewsID"], out _newsID))
                {
                    return (Guid?)null;
                }
                return _newsID;
            }
        }

        /// <summary>
        /// Url detail
        /// </summary>

        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
        private string _TenTab;
        public string TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }
    }
        #endregion

    }

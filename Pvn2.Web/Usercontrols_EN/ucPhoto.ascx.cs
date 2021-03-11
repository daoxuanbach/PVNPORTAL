using Pvn.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn2.Web.Usercontrols_EN
{
    public partial class ucPhoto : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    //init paging
                    pgMain.PageSize = TotalItems;
                    pgMain.ShowFirstLast = false;
                    pgMain.ShowFirstLast = false;
                    pgMain.CurrentPageIndex = 1;
                    //bind data
                    BindData();
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    Pvn.Utils.LogFile.WriteLogFile("ucImageList", "Page_Load", exc.Message);

                }
            }
        }
        protected void pgMain_PageChanged(object src, EventArgs e)
        {
            BindData();
        }

        private void BindData()
        {
            try
            {
                CMS_ImageDA objDA = new CMS_ImageDA();

                int totalRows = 0;
                DataTable dtVideoResult = objDA.GetImageSearchPaging(CurrentLanguage,
                    pgMain.CurrentPageIndex - 1, TotalItems, ref totalRows, ImageCategoryID, string.Empty, string.Empty);
                //display image
                if (dtVideoResult == null || dtVideoResult.Rows.Count == 0)
                    return;

                pgMain.RecordCount = totalRows;
                rptImageList.DataSource = dtVideoResult;
                rptImageList.DataBind();

            }
            catch (Exception exc)
            {
                //Module failed to load 
                Pvn.Utils.LogFile.WriteLogFile("UC", "UC", exc.Message);

            }

        }

        #region Custom Web part property

        //Task list name string
        private string currentLanguage = Pvn.Utils.Constants.Language.VIETNAMESE;
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }

        private int _totalItems = 20;
        private String _mainImageSize;
        private String _otherImageSize = "C130X80";
        private String _urlDetail;
        private int _maxLengthTitle=50;
        /// <summary>
        /// Number of news item
        /// </summary>
        public int TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }
        /// <summary>
        /// Video CategoryID
        /// </summary>        
        public Guid? ImageCategoryID
        {
            get
            {
                Guid _categoryID = Guid.Empty;
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["CatID"], out _categoryID))
                {
                    return null;
                }
                return _categoryID;
            }
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

        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }
        #endregion
    }
}
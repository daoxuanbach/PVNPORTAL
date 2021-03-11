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
    public partial class ucBreadcumbMEDIA : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                BindData();
            }
        }

        private void BindData()
        {
            try
            {

                try
                {
                    CMS_CategoryDA objCateDA = new CMS_CategoryDA();
                    //get info from database
                    DataTable dtMenu = objCateDA.GetMenuBreadCumb( Pvn.Utils.Constants.Language.VIETNAMESE, CategoryID, MenuType);
                    rptNewsBreadCumb.DataSource = dtMenu;
                    rptNewsBreadCumb.DataBind();
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    //CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
            catch (Exception exc)
            {
                Pvn.Utils.LogFile.WriteLogFile("wpBreadcumb", " BindData..", exc.Message);
            }

        }

        private Guid _categoryID;

        /// <summary>
        /// CategoryID
        /// </summary>        
        public Guid? CategoryID
        {
            get
            {
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["catid"], out _categoryID))
                {
                    _categoryID = Guid.Empty;
                }
                return _categoryID;
            }
        }


        #region Custom Web part property
        private string _stTitle;

        public string Title
        {
            get { return _stTitle; }
            set { _stTitle = value; }
        }
        private String _urlDetail = "/sites/en/Pages/photo.aspx";
        private int _menuType;
        /// <summary>
        /// Url detail
        /// </summary>
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }
        /// <summary>
        /// Menu Type
        /// </summary>
        public int MenuType
        {
            get { return _menuType; }
            set { _menuType = value; }
        }
        #endregion

    }
}
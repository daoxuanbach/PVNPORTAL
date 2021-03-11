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
    public partial class ucBreadcumb : System.Web.UI.UserControl
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

                //get info from database
                CMS_MenuDA obj = new CMS_MenuDA();
                DataTable dtMenu = obj.GetMenuBreadCumb(CategoryID, MenuType);
                rptNewsBreadCumb.DataSource = dtMenu;
                rptNewsBreadCumb.DataBind();
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
        private String _urlDetail;
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
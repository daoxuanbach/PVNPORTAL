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
    public partial class ucNewsBreadCumb : System.Web.UI.UserControl
    {
        public string ImageURL = "/wp-includes/img/br_1.png";
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
                CMS_CategoryDA objDA = new CMS_CategoryDA();
                 //get info from database
                 DataTable dtMenu = objDA.GetBreadCumbNews(CategoryID, NewsID, HttpContext.Current.Request.Url.AbsolutePath);
                if (dtMenu != null && dtMenu.Rows.Count > 0)
                {
                    int RowCount = dtMenu.Rows.Count;
                    if (!string.IsNullOrEmpty(dtMenu.Rows[RowCount-1]["ImageURL"].ToString()))
                    {
                        ImageURL = dtMenu.Rows[RowCount-1]["ImageURL"].ToString();
                    }  
                }
                rptnewsbreadcumb.DataSource = dtMenu;
                rptnewsbreadcumb.DataBind();
            }
            catch (Exception exc)
            {
                //Module failed to load 
               // CommonLib.Common.Info.Instance.WriteToLog(exc);
            }

        }

        private Guid _categoryID;
        private Guid _newsID;
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
        /// <summary>
        /// NewsID
        /// </summary>        
        public Guid? NewsID
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
    }
}
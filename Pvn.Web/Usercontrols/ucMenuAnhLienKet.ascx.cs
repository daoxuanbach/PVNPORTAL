using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web
{
    public partial class ucMenuAnhLienKet : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                BindMenuData();
            }
        }

        #region BindData
        /// <summary>
        /// Bind menu data
        /// </summary>
        private void BindMenuData()
        {
            try
            {
                CMS_MenuBL objBL = new CMS_MenuBL();
                StringBuilder strBuilder = new StringBuilder();
                DataTable dt = objBL.GetTreeByLanguagePosition(Pvn.Utils.Constants.Language.VIETNAMESE,
                        MenuPosition,//Top
                        true,//No Recursive
                        string.IsNullOrEmpty(ParentMenuID) ? (Guid?)null : new Guid(ParentMenuID));
                //DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0)
                    return;

                rptChuyenDeDauKhi.DataSource = dt;
                rptChuyenDeDauKhi.DataBind();
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        #endregion
        private int _menuPosition;
        private String _parentMenuID;
        public int MenuPosition
        {
            get { return _menuPosition; }
            set { _menuPosition = value; }
        }
        private String _TenTab;
        public String TenTab
        {
            get { return _TenTab; }
            set { _TenTab = value; }
        }

        public String ParentMenuID
        {
            get { return _parentMenuID; }
            set { _parentMenuID = value; }
        }

    }
}
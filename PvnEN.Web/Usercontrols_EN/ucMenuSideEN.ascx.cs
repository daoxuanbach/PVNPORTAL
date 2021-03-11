using Pvn.BL;
using Pvn.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace PvnEN.Web.Usercontrols_EN
{
    public partial class ucMenuSideEN : System.Web.UI.UserControl
    {
        private string _Language = Pvn.Utils.Constants.Language.VIETNAMESE;
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
                CMS_MenuDA objBL = new CMS_MenuDA();
                StringBuilder strBuilder = new StringBuilder();
                DataSet ds = objBL.GetTreeByLanguagePositionDataset(Language,
                        MenuPosition,//Top
                        true,//No Recursive
                        string.IsNullOrEmpty(ParentMenuID) ? (Guid?)null : new Guid(ParentMenuID));

                DataTable dt = ds.Tables[0];
                DataTable dtParent = ds.Tables[1];
                DataTable dtMenu;
                //DataTable dt = ds.Tables[0];
                if (dt == null || dt.Rows.Count <= 0)
                    return;
                //build menu
                dtMenu = dtParent;
                if (MultiMenuLeve1)
                {
                    DataTable drParents = dt.Select(string.Format("ParentMenuID = '{0}'", ParentMenuID)).CopyToDataTable();
                    dtMenu = drParents;
                }

                int i = 0; //keep the index
                foreach (DataRow dr in dtMenu.Select())
                {
                    //build level 1 menu
                    if (string.IsNullOrEmpty(TieuDeMenu))
                    {
                        TieuDeMenu = dr["Title"].ToString();
                    }
                    //build level 1 menu
                    strBuilder.AppendFormat("<div class='widget-categories list-unstyled MenuPosition_" + MenuPosition + "'><div class='box-title'><h6><i class='fa fa-caret-right'>&nbsp;</i><a href='{0}' target='{1}'>{2}</a></h6></div>",
                        string.IsNullOrEmpty(Convert.ToString(dr["Url"])) ? "#" : dr["Url"],
                        string.IsNullOrEmpty(Convert.ToString(dr["IsNewWindow"])) || Convert.ToString(dr["IsNewWindow"]) == "0" ? "_self" : "_blank",
                                dr["Title"]);//need to provide detail link

                    var drChilds = dt.Select(string.Format("ParentMenuID = '{0}'", dr["MenuID"]));
                    if (drChilds != null && drChilds.Length > 0)
                    {
                        strBuilder.AppendFormat("<div class='box-content'><ul id='{0}_{1}'>", ltrMenu.ClientID, i);
                        foreach (DataRow drChild in drChilds)
                        {

                            //build level 3 menu
                            var dr3Childs = dt.Select(string.Format("ParentMenuID = '{0}'", drChild["MenuID"]));
                            if (dr3Childs != null && dr3Childs.Length > 0)
                            {
                                //build level 2 menu with level 3
                                strBuilder.AppendFormat("<li><a href='{0}' target='{1}'>{2}</a><span class='fa fa-plus'>&nbsp;</span>",
                                      string.IsNullOrEmpty(Convert.ToString(drChild["Url"])) ? "#" : drChild["Url"],
                                      string.IsNullOrEmpty(Convert.ToString(drChild["IsNewWindow"])) || Convert.ToString(drChild["IsNewWindow"]) == "0" ? "_self" : "_blank",
                                      drChild["Title"]);
                                //build level 3
                                strBuilder.AppendLine("<ul class='ul-menu-side'>");
                                foreach (DataRow dr3Child in dr3Childs)
                                {
                                    strBuilder.AppendFormat("<li><a href='{0}' target='{1}'>{2}</a></li>",
                                         string.IsNullOrEmpty(Convert.ToString(dr3Child["Url"])) ? "#" : dr3Child["Url"],
                                     string.IsNullOrEmpty(Convert.ToString(dr3Child["IsNewWindow"])) || Convert.ToString(dr3Child["IsNewWindow"]) == "0" ? "_self" : "_blank",
                                     dr3Child["Title"]);
                                }
                                strBuilder.AppendLine("</ul>");
                            }
                            else
                            {
                                //build level 2 menu with no level3
                                strBuilder.AppendFormat("<li><a href='{0}' target='{1}'>{2}</a>",
                                  string.IsNullOrEmpty(Convert.ToString(drChild["Url"])) ? "#" : drChild["Url"],
                                  string.IsNullOrEmpty(Convert.ToString(drChild["IsNewWindow"])) || Convert.ToString(drChild["IsNewWindow"]) == "0" ? "_self" : "_blank",
                                  drChild["Title"]);
                            }
                            strBuilder.AppendLine("</li>");
                        }
                        strBuilder.AppendLine("</ul></div>");
                    }
                    strBuilder.Append("</div>");
                    //increase the index
                    i++;
                }
                //bind script sections 
                strBuilder.AppendLine("<script type='text/javascript'>$(document).ready(function() {");
                for (int j = 0; j < i; j++)
                {
                    strBuilder.AppendFormat("$('#{0}_{1}').metisMenu({{cookieName: 'MetisMenuState1'}});", ltrMenu.ClientID, j);
                    strBuilder.AppendLine();
                }
                strBuilder.AppendLine("});</script>");
                //bind menu
                ltrMenu.Text = strBuilder.ToString();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("UC", "BindMenuData", ex.Message);

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
        public String ParentMenuID
        {
            get { return _parentMenuID; }
            set { _parentMenuID = value; }
        }

        public string TieuDeMenu   
        {
            get
            {
                return _Title;
            }

            set
            {
                _Title = value;
            }
        }

        public bool MultiMenuLeve1
        {
            get
            {
                return _MultiMenuLeve1;
            }

            set
            {
                _MultiMenuLeve1 = value;
            }
        }

        public string Language
        {
            get
            {
                return _Language;
            }

            set
            {
                _Language = value;
            }
        }

        private string _Title = string.Empty;
        private Boolean _MultiMenuLeve1 = true;

    }
}
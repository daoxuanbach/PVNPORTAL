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
    public partial class ucMenuTop : System.Web.UI.UserControl
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
                CMS_MenuDA objBL = new CMS_MenuDA();
                StringBuilder strBuilder = new StringBuilder();
                StringBuilder strBuilderMenuMobile = new StringBuilder();
                DataTable dt = objBL.GetTreeByLanguagePosition(CurrentLanguage,
                        MenuPosition,//Top
                        true,//No Recursive
                        string.IsNullOrEmpty(ParentMenuID) ? (Guid?)null : new Guid(ParentMenuID));
                if (dt == null || dt.Rows.Count <= 0)
                    return;
                //build menu
                var drParents = dt.Select(string.Format("ParentMenuID = '{0}'", ParentMenuID));
                foreach (DataRow dr in drParents)
                {
                    //build child menu if any
                    var drChilds = dt.Select(string.Format("ParentMenuID = '{0}'", dr["MenuID"]));
                    if (drChilds != null && drChilds.Length > 0)
                    {
                        //1.append level 1
                        strBuilder.AppendFormat("<li id='menu-item-{0}' class='menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-{1}'><a href='{2}' target='{3}' >{4}<span class='caret'></span></a>",
                            dr["MenuID"], dr["MenuID"], string.IsNullOrEmpty(Convert.ToString(dr["Url"])) ? "#" : dr["Url"],
                            string.IsNullOrEmpty(Convert.ToString(dr["IsNewWindow"])) || Convert.ToString(dr["IsNewWindow"]) == "0" ? "_self" : "_blank",
                            dr["Title"]);
                        strBuilderMenuMobile.AppendFormat("<li id='menu-item-{0}' class='menu-item menu-item-type-post_type menu-item-object-page menu-item-has-children menu-item-{1}'><a  href='{2}' target='{3}'>{4}<span class='caret'></span></a>",
                            dr["MenuID"], dr["MenuID"], string.IsNullOrEmpty(Convert.ToString(dr["Url"])) ? "#" : dr["Url"],
                            string.IsNullOrEmpty(Convert.ToString(dr["IsNewWindow"])) || Convert.ToString(dr["IsNewWindow"]) == "0" ? "_self" : "_blank",
                            dr["Title"]);

                        strBuilder.AppendLine("<div class='sub-menu-container'>");
                        strBuilderMenuMobile.AppendLine("<div class='sub-menu-container'>");

                        //2.then level 2
                        strBuilder.AppendLine("<ul class='sub-menu'>");
                        strBuilderMenuMobile.AppendLine("<ul class='sub-menu'>");
                        foreach (DataRow drChild in drChilds)
                        {
                            //build level 2 menu  <li><a href="#">Link</a></li>
                            strBuilder.AppendFormat("<li id='menu-item-{0}' class='menu-item menu-item-type-post_type menu-item-object-page menu-item-{1}'><a href='{2}'  target='{3}'>{4}</a></li>"
                                , drChild["MenuID"], drChild["MenuID"], string.IsNullOrEmpty(Convert.ToString(drChild["Url"])) ? "#" : drChild["Url"],
                                    string.IsNullOrEmpty(Convert.ToString(drChild["IsNewWindow"])) || Convert.ToString(drChild["IsNewWindow"]) == "0" ? "_self" : "_blank",
                                    drChild["Title"]);
                            strBuilderMenuMobile.AppendFormat("<li id='menu-item-{0}' class='menu-item menu-item-type-post_type menu-item-object-page menu-item-{1}'><a href='{2}'  target='{3}'>{4}</a></li>",
                                 drChild["MenuID"], drChild["MenuID"], string.IsNullOrEmpty(Convert.ToString(drChild["Url"])) ? "#" : drChild["Url"],
                                   string.IsNullOrEmpty(Convert.ToString(drChild["IsNewWindow"])) || Convert.ToString(drChild["IsNewWindow"]) == "0" ? "_self" : "_blank",
                                   drChild["Title"]);
                        }
                        strBuilder.AppendLine("</ul>");
                        strBuilder.AppendLine("</div>");
                        strBuilderMenuMobile.AppendLine("</ul>");
                        strBuilderMenuMobile.AppendLine("</div>");
                    }
                    else
                    {
                        //1.only level 1
                        strBuilder.AppendFormat("<li id='menu-item-{0}' class='menu-item menu-item-type-post_type menu-item-object-page menu-item-home menu-item-has-children menu-item-{1}'><a href='{2}' target='{3}' >{4}</span></a>",
                        dr["MenuID"], dr["MenuID"], string.IsNullOrEmpty(Convert.ToString(dr["Url"])) ? "#" : dr["Url"],
                        string.IsNullOrEmpty(Convert.ToString(dr["IsNewWindow"])) || Convert.ToString(dr["IsNewWindow"]) == "0" ? "_self" : "_blank",
                        dr["Title"]);

                        strBuilderMenuMobile.AppendFormat("<li id='menu-item-{0}' class='menu-item menu-item-type-post_type menu-item-object-page menu-item-home menu-item-has-children menu-item-{1}'><a  href='{2}' target='{3}'>{4}</a></li>",
                           dr["MenuID"], dr["MenuID"], string.IsNullOrEmpty(Convert.ToString(dr["Url"])) ? "#" : dr["Url"],
                           string.IsNullOrEmpty(Convert.ToString(dr["IsNewWindow"])) || Convert.ToString(dr["IsNewWindow"]) == "0" ? "_self" : "_blank",
                           dr["Title"]);
                    }
                    strBuilder.AppendLine("</li>");
                    strBuilderMenuMobile.AppendLine("</li>");
                }
                //bind menu
                ltrMenu.Text = strBuilder.ToString();
                ltrmenuMobile.Text = strBuilderMenuMobile.ToString();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("UC", "UC", ex.Message);

            }
        }
        #endregion


        #region Custom Web part property
        private string _searchResultLink = "/pages/newsearch.aspx";

        private int _menuPosition = Convert.ToInt32(Resources.Config_MenuTop.MenuPosition);
        private String _parentMenuID = Resources.Config_MenuTop.ParentMenuID;
        private String currentLanguage = Resources.Config_MenuTop.currentLanguage;

        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
        public string SearchResultLink
        {
            get { return _searchResultLink; }
            set { _searchResultLink = value; }
        }
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
        #endregion


    }
}
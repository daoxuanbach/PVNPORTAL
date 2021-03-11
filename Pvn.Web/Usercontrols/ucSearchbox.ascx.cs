using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web.Usercontrols
{
    public partial class ucSearchbox : System.Web.UI.UserControl
    {
        private String _urlDetail;
        private string _siteEnLink;
        private string _siteVNLink;
        /// <summary>
        /// Url detail
        /// </summary>
  
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }

        /// <summary>
        /// Site EN Link
        /// </summary>
    
        public String SiteENLink
        {
            get { return _siteEnLink; }
            set { _siteEnLink = value; }
        }

        /// <summary>
        /// Site VN Link
        /// </summary>
     
        public String SiteVNLink
        {
            get { return _siteVNLink; }
            set { _siteVNLink = value; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                txtSearchBox.Attributes.Add("onKeyPress", "javascript:if (event.keyCode == 13)__doPostBack('" + btnSearch.UniqueID + "','')");
                txtSearchBox.Attributes.Add("onfocus", "if (this.value == '') {this.value = '';}");
                txtSearchBox.Attributes.Add("onblur", "if (this.value == '') {this.value = '';}");
            }  
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtSearchBox.Text.Trim()))
            {
                return;
            }
            Page.Response.Redirect(string.Format("{0}?keyword={1}", UrlDetail, txtSearchBox.Text.Trim()));
        }
    }
}
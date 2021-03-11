using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;

namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpSearchbox : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucSearchbox.ascx";
        ucSearchbox _uc = new ucSearchbox();
        protected override void CreateChildControls()
        {
            _uc = (ucSearchbox)Page.LoadControl(_ascxPath);
            _uc.UrlDetail = this.UrlDetail;
            _uc.SiteENLink = this.SiteENLink;
            _uc.SiteVNLink = this.SiteVNLink;
            this.Controls.Add(_uc);
        }

        private String _urlDetail = "/Pages/newsearch.aspx";
        private string _siteEnLink = "http://english.pvn.vn/";
        private string _siteVNLink = "http://www.pvn.vn/";

        /// <summary>
        /// Url detail
        /// </summary>
         [Browsable(false),
        WebDisplayName("Url detail"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }

        /// <summary>
        /// Site EN Link
        /// </summary>
           [Browsable(false),
        WebDisplayName("Site EN Link"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String SiteENLink
        {
            get { return _siteEnLink; }
            set { _siteEnLink = value; }
        }

        /// <summary>
        /// Site VN Link
        /// </summary>
          [Browsable(false),
        WebDisplayName("Site VN Link"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String SiteVNLink
        {
            get { return _siteVNLink; }
            set { _siteVNLink = value; }
        }
       
    }
}

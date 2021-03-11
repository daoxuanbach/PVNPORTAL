using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpBanner : WebPart
    {
        private const string _ascxPath = @"~/UserControls/ucBanner.ascx";
        ucBanner _uc = new ucBanner();
        protected override void CreateChildControls()
        {
            _uc = (ucBanner)Page.LoadControl(_ascxPath);
            _uc.TotalItems = this.TotalItems;
            _uc.BannerPosition = this.BannerPosition;
            _uc.IsBannerText = this.IsBannerText;
            this.Controls.Add(_uc);
        }

        private short _totalItems=1;
        private short _bannerPosition = 5;
        private bool _isBannerText = false;

        /// <summary>
        /// Number of news item
        /// </summary>
        public short TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }

        /// <summary>
        /// banner position
        /// </summary>
        public short BannerPosition
        {
            get { return _bannerPosition; }
            set { _bannerPosition = value; }
        }

        /// <summary>
        /// banner text
        /// </summary>
        public bool IsBannerText
        {
            get { return _isBannerText; }
            set { _isBannerText = value; }
        }
    }
}

using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using PvnEN.Web.Usercontrols_EN;

namespace Intranet_EN.webpart
{
    [ToolboxItemAttribute(false)]
    public class wpWebEN_Video : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucVideo.ascx";
        ucVideo _uc = new ucVideo();
        protected override void CreateChildControls()
        {
            _uc = (ucVideo)Page.LoadControl(_ascxPath);
            _uc.TotalItems = this.TotalItems;
            _uc.MainImageSize = this.MainImageSize;
            _uc.UrlDetail = this.UrlDetail;
            _uc.MaxLengthTitle = this.MaxLengthTitle;
            _uc.CurrentLanguage = this.CurrentLanguage;
            _uc.OtherImageSize = this.OtherImageSize;
            this.Controls.Add(_uc);
        }


        private int _TotalItems = 20;
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("TotalItems"),
        WebDescription("TotalItems")]
        public int TotalItems {
            
            
            get { return _TotalItems; }
            set { _TotalItems = value; }
}

        private String _mainImageSize;
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("MainImageSize"),
        WebDescription("MainImageSize")]
        public string MainImageSize { 
            get { return _mainImageSize; }
            set { _mainImageSize = value; }}

        private String _UrlDetail;
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("UrlDetail"),
        WebDescription("UrlDetail")]
        public string UrlDetail { get { return _UrlDetail; }
            set { _UrlDetail = value; }}

        private int _MaxLengthTitle;
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("MaxLengthTitle"),
        WebDescription("MaxLengthTitle")]
        public int MaxLengthTitle { get { return _MaxLengthTitle; }
            set { _MaxLengthTitle = value; }}

        private String _OtherImageSize = "C130X80";
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("OtherImageSize"),
        WebDescription("OtherImageSize")]
        public string OtherImageSize { get { return _OtherImageSize; }
            set { _OtherImageSize = value; }}

        private String _CurrentLanguage = "en-US";
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("CurrentLanguage (en-US/vi-VN)"),
        WebDescription("CurrentLanguage")]
        public string CurrentLanguage {  get { return _CurrentLanguage; }
            set { _CurrentLanguage = value; }}
    }
}

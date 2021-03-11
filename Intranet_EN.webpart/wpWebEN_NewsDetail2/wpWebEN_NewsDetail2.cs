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
    public class wpWebEN_NewsDetail2 : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucNewsDetail2.ascx";
        ucNewsDetail2 _uc = new ucNewsDetail2();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsDetail2)Page.LoadControl(_ascxPath);
            _uc.ShowTitle = this.ShowTitle;
            _uc.IsShowRelatedNews = this.IsShowRelatedNews;
            _uc.IsShowOtherNews = this.IsShowOtherNews;
            _uc.UrlDetail = this.UrlDetail;
            _uc.TotalNewsTimeLine = this.TotalNewsTimeLine;
            _uc.TotalOtherNews = this.TotalOtherNews;
            this.Controls.Add(_uc);
        }

        [Category("Extended Settings"),
       Personalizable(PersonalizationScope.Shared),
       WebBrowsable(true),
       WebDisplayName("TotalNewsTimeLine"),
       WebDescription("TotalNewsTimeLine")]
        public int TotalNewsTimeLine
        {
            get { return _totalNewsTimeLine; }
            set { _totalNewsTimeLine = value; }
        }
        [Category("Extended Settings"),
         Personalizable(PersonalizationScope.Shared),
         WebBrowsable(true),
         WebDisplayName("TotalOtherNews"),
         WebDescription("TotalOtherNews")]
        public int TotalOtherNews
        {
            get { return _totalOtherNews; }
            set { _totalOtherNews = value; }
        }
        private int _totalNewsTimeLine = 3;
        private int _totalOtherNews = 5;
        [Category("Extended Settings"),
         Personalizable(PersonalizationScope.Shared),
         WebBrowsable(true),
         WebDisplayName("UrlDetail"),
         WebDescription("UrlDetail")]
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }


        private string _urlDetail = "/sites/en/Pages/detailv4.aspx";

        [Category("Extended Settings"),
         Personalizable(PersonalizationScope.Shared),
         WebBrowsable(true),
         WebDisplayName("IsShowOtherNews"),
         WebDescription("IsShowOtherNews")]
        public bool IsShowOtherNews
        {
            get { return _IsShowOtherNews; }
            set { _IsShowOtherNews = value; }
        }
        private bool _IsShowOtherNews = true;

        [Category("Extended Settings"),
       Personalizable(PersonalizationScope.Shared),
       WebBrowsable(true),
       WebDisplayName("ShowTitle"),
       WebDescription("ShowTitle")]
        public bool ShowTitle
        {
            get
            {
                return _ShowTitle;
            }

            set
            {
                _ShowTitle = value;
            }
        }
        private Boolean _ShowTitle = true;

        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("IsShowRelatedNews"),
      WebDescription("IsShowRelatedNews")]
        public bool IsShowRelatedNews
        {
            get
            {
                return _IsShowRelatedNews;
            }

            set
            {
                _IsShowRelatedNews = value;
            }
        }
        private Boolean _IsShowRelatedNews = true;
    }
}

using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpPhoneBook : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        //private const string _ascxPath = @"~/_CONTROLTEMPLATES/15/Portal.Webpart/wpPhoneBook/wpPhoneBookUserControl.ascx";
        private const string _ascxPath = @"~/UserControls/wpPhoneBookUserControl.ascx";
        wpPhoneBookUserControl _ucPhoneBook = new wpPhoneBookUserControl();
        protected override void CreateChildControls()
        {
            try
            {
                //Control control = Page.LoadControl(_ascxPath);
                //Controls.Add(control);

                _ucPhoneBook = (wpPhoneBookUserControl)Page.LoadControl(_ascxPath);
                _ucPhoneBook.UrlSearchComboBox = this.UrlSearchComboBox;
                _ucPhoneBook.UrlSearchName = this.UrlSearchName;
                _ucPhoneBook.CompanyID = this.CompanyID;
                _ucPhoneBook.CompanyLevelID = this.CompanyLevelID;
                _ucPhoneBook.TenTab = this.TenTab;
                this.Controls.Add(_ucPhoneBook);
            }
            catch (Exception ex)
            {
                HttpContext.Current.Response.Write(string.Format("<!--{0}-->", ex.Message));
            }
        }
        private string strTenTab = "danh bạ điện thoại"; //string.Empty; // Tiêu đề của webpart
        private String _urlSearchComboBox = "/Pages/phonebooksearch.aspx";
        private String _urlSearchName = "/Pages/phonebook.aspx";
        private String _companyLevelID = "29282";
        private String _companyID = "29292";

        [Browsable(true),
        WebDisplayName("Tiêu đề webpart"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public string TenTab
        {
            get { return strTenTab; }
            set { strTenTab = value; }
        }
        /// <summary>
        /// Url search combobox
        /// </summary>
        [Browsable(false),
        WebDisplayName("CompanyLevelID"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String CompanyLevelID
        {
            get { return _companyLevelID; }
            set { _companyLevelID = value; }
        }
        /// <summary>
        /// Url search combobox
        /// </summary>
        [Browsable(false),
       WebDisplayName("CompanyID"),
       WebBrowsable(true),
       Category("Cấu hình webpart"),
       Personalizable(PersonalizationScope.Shared)]
        public String CompanyID
        {
            get { return _companyID; }
            set { _companyID = value; }
        }

        /// <summary>
        /// Url search combobox
        /// </summary>
        [Browsable(false),
        WebDisplayName("link tìm kiếm theo Công ty/ Phòng /Ban"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlSearchComboBox
        {
            get { return _urlSearchComboBox; }
            set { _urlSearchComboBox = value; }
        }

        /// <summary>
        /// Url search by name
        /// </summary>
        [Browsable(false),
        WebDisplayName("link tìm kiếm theo Tên"),
        WebBrowsable(true),
        Category("Cấu hình webpart"),
        Personalizable(PersonalizationScope.Shared)]
        public String UrlSearchName
        {
            get { return _urlSearchName; }
            set { _urlSearchName = value; }
        }
    }
}

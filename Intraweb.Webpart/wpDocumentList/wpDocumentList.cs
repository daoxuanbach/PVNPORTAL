using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;
using System.Collections;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpDocumentList : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols/wpDocumentListUserControl.ascx";
        wpDocumentListUserControl _uc = new wpDocumentListUserControl();

        protected override void CreateChildControls()
        {
            _uc = (wpDocumentListUserControl)Page.LoadControl(_ascxPath);
            _uc.TotalItems = this.TotalItems;
            _uc.UrlDetail = this.UrlDetail;
         
            this.Controls.Add(_uc);
        }
        #region Custom Web part property
        public override object WebBrowsableObject
        {
            get
            {
                return this;
            }
        }
        //Task list name string
        private int _totalItems;
        private String _urlDetail;
        /// <summary>
        /// Number of news item
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public int TotalItems
        {
            get { return _totalItems; }
            set { _totalItems = value; }
        }

        /// <summary>
        /// Url detail
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public String UrlDetail
        {
            get { return _urlDetail; }
            set { _urlDetail = value; }
        }

 
       
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            CustomDocumentListProperties edPart = new CustomDocumentListProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
        #endregion
    }
}

using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;
using System.Collections.Generic;
using System.Collections;

namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpNewsInfo : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols/ucNewsInfo.ascx";
        ucNewsInfo _uc = new ucNewsInfo();

        protected override void CreateChildControls()
        {
            _uc = (ucNewsInfo)Page.LoadControl(_ascxPath);
            _uc.SelectedInfoType = this.SelectedInfoType;
            this.Controls.Add(_uc);
        }

        private Dictionary<string, string> dictionary;
        /// <summary>
        /// Number of news item
        /// </summary>
        [Personalizable(), WebBrowsable(false)]
        public Dictionary<string, string> SelectedInfoType
        {
            get { return dictionary; }
            set { dictionary = value; }
        }
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            NewsInfoProperties edPart = new NewsInfoProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    }
}

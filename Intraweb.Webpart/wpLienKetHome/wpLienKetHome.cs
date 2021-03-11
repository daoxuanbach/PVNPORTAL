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
    public class wpLienKetHome : WebPart
    {
        private DropDownList cboMenuPosition;
        private DropDownList cboMenu;
        private TextBox txtTotalMenuItems;
        private const string _ascxPath = @"~/UserControls/ucLienKetHome.ascx";
        ucLienKetHome _uc = new ucLienKetHome();
        protected override void CreateChildControls()
        {
            _uc = (ucLienKetHome)Page.LoadControl(_ascxPath);
            _uc.MenuPosition = this.MenuPosition;
            _uc.ParentMenuID = this.ParentMenuID;
            this.Controls.Add(_uc);
        }

        //Task list name string

        private int _menuPosition;
        private String _parentMenuID;

        [Personalizable(), WebBrowsable(false)]
        public int MenuPosition
        {
            get { return _menuPosition; }
            set { _menuPosition = value; }
        }
        [Personalizable(), WebBrowsable(false)]
        public String ParentMenuID
        {
            get { return _parentMenuID; }
            set { _parentMenuID = value; }
        }


        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            LienKetHomeProperties edPart = new LienKetHomeProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    }
}

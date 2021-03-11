using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections;
using Pvn.Web;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpMainMenuImgSlide : WebPart
    {
        private DropDownList cboMenuPosition;
        private DropDownList cboMenu;
        private TextBox txtTotalMenuItems;
        private const string _ascxPath = @"~/UserControls/ucMainMenuImgSlide.ascx";
        ucMainMenuImgSlide _uc = new ucMainMenuImgSlide();
        protected override void CreateChildControls()
        {
            _uc = (ucMainMenuImgSlide)Page.LoadControl(_ascxPath);
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
            MainMenuImgSlideProperties edPart = new MainMenuImgSlideProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    }
}

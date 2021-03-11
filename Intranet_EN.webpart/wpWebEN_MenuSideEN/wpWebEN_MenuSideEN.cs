using System;
using System.Collections;
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
    public class wpWebEN_MenuSideEN : WebPart
    {
        private const string _ascxPath = @"~/Usercontrols_EN/ucMenuSideEN.ascx";
        ucMenuSideEN _uc = new ucMenuSideEN();
        protected override void CreateChildControls()
        {
            _uc = (ucMenuSideEN)Page.LoadControl(_ascxPath);
            _uc.TieuDeMenu = this.TieuDeMenu; ;
            _uc.ParentMenuID = this.ParentMenuID;
            _uc.MenuPosition = this.MenuPosition;
            _uc.MultiMenuLeve1 = this.MultiMenuLeve1;
            _uc.Language = this.CurrentLanguage;
            this.Controls.Add(_uc);
        }
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            Toolpart_Side_menu edPart = new Toolpart_Side_menu();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("MultiMenuLeve1"),
        WebDescription("MultiMenuLeve1")]
        public bool MultiMenuLeve1
        {
            get
            {
                return _MultiMenuLeve1;
            }

            set
            {
                _MultiMenuLeve1 = value;
            }
        }
        private Boolean _MultiMenuLeve1 = true;
        
        public string TieuDeMenu
        {
            get
            {
                return _TieuDeMenu;
            }

            set
            {
                _TieuDeMenu = value;
            }
        }
        private string _TieuDeMenu = "";


        private int _menuPosition;
        private String _parentMenuID;

        public int MenuPosition
        {
            get { return _menuPosition; }
            set { _menuPosition = value; }
        }
        public String ParentMenuID
        {
            get { return _parentMenuID; }
            set { _parentMenuID = value; }
        }

        private string currentLanguage = Pvn.Utils.Constants.Language.ENGLISH;
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }
    }
}

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
    public class wpMenuSide : WebPart
    {
        private DropDownList cboMenuPosition;
        private DropDownList cboMenu;
        private TextBox txtTotalMenuItems;
        private const string _ascxPath = @"~/UserControls/webMenuSide.ascx";
        webMenuSide _uc = new webMenuSide();
        protected override void CreateChildControls()
        {
            
            _uc = (webMenuSide)Page.LoadControl(_ascxPath);

            _uc.MenuPosition = this.MenuPosition;
            _uc.ParentMenuID = this.ParentMenuID;
            _uc.TenTab = this.TenTab;
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
        //Task list name string
        private string strTenTab = "Tiêu đề menu cha"; //string.Empty; // Tiêu đề của webpart
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
       
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            MenuSideProperties edPart = new MenuSideProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    }
}

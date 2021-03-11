using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web;
using System.Collections;

namespace Internet.Webpart
{
    //Lien ket trong bai viet
    [ToolboxItemAttribute(false)]
    public class wpMenuAnhLienKet : WebPart
    {
        private DropDownList cboMenuPosition;
        private DropDownList cboMenu;
        private TextBox txtTotalMenuItems;
        private const string _ascxPath = @"~/UserControls/ucMenuAnhLienKet.ascx";
        ucMenuAnhLienKet _uc = new ucMenuAnhLienKet();
        protected override void CreateChildControls()
        {
            _uc = (ucMenuAnhLienKet)Page.LoadControl(_ascxPath);
            _uc.MenuPosition = this.MenuPosition;
            _uc.ParentMenuID = this.ParentMenuID;
            _uc.TenTab = this.TenTab;
            this.Controls.Add(_uc);
        }

        //Task list name string
        private string strTenTab = "Ảnh liên kết"; //string.Empty; // Tiêu đề của webpart
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
            MenuAnhLienKetProperties edPart = new MenuAnhLienKetProperties();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
    
    }
}

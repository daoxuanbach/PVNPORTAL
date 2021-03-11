using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using System.Collections.Generic;
using System.Collections;

namespace Intraweb.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpDocumentMainV2 : WebPart
    {
        private String currentLanguage;
        private String _idLoaiVanBan;
        private String currentDBSource;




        /// <summary>
        /// Url detail
        /// </summary>
        [Personalizable(),
        Category("Cấu hình webpart"),
        WebDisplayName("Ngôn ngữ"), 
        WebBrowsable(false)]
        public String CurrentLanguage
        {
            get { return currentLanguage; }
            set { currentLanguage = value; }
        }

        /// <summary>
        /// Url detail
        /// </summary>
        [Personalizable(),
        Category("Cấu hình webpart"),
        WebDisplayName("Nguồn dữ liệu"),
        WebBrowsable(false)]
        public String CurrentDBSource
        {
            get { return currentDBSource; }
            set { currentDBSource = value; }
        }

        /// <summary>
        /// Url detail
        /// </summary>
        [Personalizable(),
        Category("Cấu hình webpart"),
        WebDisplayName("ID Loại Văn Bản"),
        WebBrowsable(false)]
        public String IDLoaiVanBan
        {
            get { return _idLoaiVanBan; }
            set { _idLoaiVanBan = value; }
        }
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/Usercontrols/wpDocumentMainV2UserControl.ascx";
        wpDocumentMainV2UserControl _ucPhoneBook = new wpDocumentMainV2UserControl();

        protected override void CreateChildControls()
        {
            _ucPhoneBook = (wpDocumentMainV2UserControl)Page.LoadControl(_ascxPath);
            _ucPhoneBook.IDLoaiVanBan = this.IDLoaiVanBan;
            _ucPhoneBook.CurrentDBSource = this.CurrentDBSource;
            _ucPhoneBook.CurrentLanguage = this.CurrentLanguage;
            this.Controls.Add(_ucPhoneBook);
        }

        /// <summary>
        /// Hàm đăng ký toolpart. Đưa các giá tự từ webpart lên toolpart
        /// </summary>
        /// <returns></returns>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// bachdx     27/1/2016      Tạo mới
        /// </Modified>
        public override EditorPartCollection CreateEditorParts()
        {
            ArrayList editorArray = new ArrayList();
            wpDocumentMainV2ToolPart edPart = new wpDocumentMainV2ToolPart();
            edPart.ID = this.ID + "_editorPart";
            editorArray.Add(edPart);
            EditorPartCollection editorParts = new EditorPartCollection(editorArray);
            return editorParts;
        }
      
    }
}

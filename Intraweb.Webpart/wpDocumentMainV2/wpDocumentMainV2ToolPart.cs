using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    public class wpDocumentMainV2ToolPart : EditorPart
    {
        //language
        private DropDownList ddlLanguage;
        private TextBox txtIDLoaiVanBan;
        private DropDownList ddlSource;

        /// <summary>
        /// Hàm khởi tạo controls. thêm các controls điều khiển vào toolpart
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// bachdx     27/1/2016      Tạo mới
        /// </Modified>
        protected override void CreateChildControls()
        {
            ddlLanguage = new DropDownList();
            ddlLanguage.Text = "Ngôn ngữ";
            ddlLanguage.Items.Add(new ListItem("Tiếng việt", "vi-VN"));
            ddlLanguage.Items.Add(new ListItem("English", "en-US"));
            //db source
            ddlSource = new DropDownList();
            ddlSource.Items.Add(new ListItem("Internet", "internet"));
            ddlSource.Items.Add(new ListItem("Intraweb", "intraweb"));

            //add items                 
            txtIDLoaiVanBan = new TextBox();
            this.Controls.Add(ddlLanguage);
            this.Controls.Add(txtIDLoaiVanBan);
            this.Controls.Add(ddlSource);
        }

        /// <summary>
        /// Hàm khi toolpart được mở ra, gán dữ liệu từ webpart vào toolpart
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// bachdx     27/1/2016      Tạo mới
        /// </Modified>
        public override void SyncChanges()
        {
            EnsureChildControls();
            wpDocumentMainV2 mainPart = this.WebPartToEdit as wpDocumentMainV2;
            if (mainPart != null)
            {

                //set current language 
                if (string.IsNullOrEmpty(mainPart.CurrentLanguage))
                {
                    ddlLanguage.SelectedValue = "vi-VN";
                }
                else
                {
                    ddlLanguage.SelectedValue = mainPart.CurrentLanguage;
                }
                //set current source 
                if (string.IsNullOrEmpty(mainPart.CurrentDBSource))
                {
                    ddlSource.SelectedValue = "internet";
                }
                else
                {
                    ddlSource.SelectedValue = mainPart.CurrentDBSource;
                }
                txtIDLoaiVanBan.Text = mainPart.IDLoaiVanBan;
            }
        }
       
        /// <summary>
        /// Hàm khi save toolpart. Gán lại dữ liệu từ toolpart về webpart
        /// </summary>
        /// <Modified>        
        ///	Name		Date		    Comment 
        /// bachdx     27/1/2016      Tạo mới
        /// </Modified>
        /// <returns>trạng thái save</returns>
        public override bool ApplyChanges()
        {
            EnsureChildControls();
            wpDocumentMainV2 mainPart = this.WebPartToEdit as wpDocumentMainV2;
            if (mainPart != null)
            {
                mainPart.CurrentLanguage = ddlLanguage.SelectedValue;
                mainPart.IDLoaiVanBan = txtIDLoaiVanBan.Text;
                mainPart.CurrentDBSource = ddlSource.SelectedValue;

                return true;
            }
            return false;
        }

        /// <summary>
        /// render content
        /// </summary>
        /// <param name="writer"></param>
        protected override void RenderContents(System.Web.UI.HtmlTextWriter writer)
        {

            writer.Write("<strong>Ngôn ngữ</strong>");
            writer.WriteBreak();
            ddlLanguage.RenderControl(writer);
            writer.WriteBreak();
            writer.Write("<strong>ID Loại văn bản</strong>");
            writer.WriteBreak();
            txtIDLoaiVanBan.RenderControl(writer);
            writer.WriteBreak();
            writer.Write("<strong>Nguồn dữ liệu</strong>");
            writer.WriteBreak();
            ddlSource.RenderControl(writer);
        }
    }
}

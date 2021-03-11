using Pvn.DA;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intranet_EN.webpart
{
    class Toolpart_Side_menu : EditorPart
    {
        private DropDownList cboMenuPosition;
        private DropDownList cboMenu;
        private TextBox txtTieuDeMenu;
        //language
        private DropDownList ddlLanguage;
        public Toolpart_Side_menu()
        {
            Title = "Menu right settings";
        }

        protected override void CreateChildControls()
        {
            try
            {
                //Add controls here
                //menu position
                cboMenuPosition = new DropDownList();
                cboMenuPosition.Width = new Unit("90%");
                cboMenuPosition.CssClass = "UserSelect";

                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("MenuPosition");

                cboMenuPosition.DataSource = dt;
                cboMenuPosition.DataTextField = "Note"; //Text hiển thị
                cboMenuPosition.DataValueField = "Value"; //Giá trị khi chọn
                cboMenuPosition.DataBind();

                cboMenuPosition.SelectedIndex = 0;
                cboMenuPosition.AutoPostBack = true;
                cboMenuPosition.SelectedIndexChanged += new EventHandler(cboMenuPosition_SelectedIndexChanged);

                //language

                ddlLanguage = new DropDownList();
                Sys_ParameterDA objNNDA = new Sys_ParameterDA();
                DataTable tbNgonNgu = objNNDA.GetParameterByName("Language");
                Utilities.BindDataToDropDownList(tbNgonNgu, "Value", "Note", Globals.FirstItemCombox.None, ddlLanguage);

                ddlLanguage.SelectedIndex = 0;
                ddlLanguage.AutoPostBack = true;
                ddlLanguage.SelectedIndexChanged += new EventHandler(ddlLanguage_SelectedIndexChanged);

                //menu data
                CMS_MenuDA objMenuDA = new CMS_MenuDA();
                cboMenu = new DropDownList();
                cboMenu.Width = new Unit("90%");
                cboMenu.CssClass = "UserSelect";
                DataTable ds = objMenuDA.GetTreeByLanguagePosition((ddlLanguage.SelectedValue), int.Parse(cboMenuPosition.SelectedValue), true, null);
                Utilities.BindDataToDropDownList(ds, "MenuID", "IndentedTitle", Globals.FirstItemCombox.None, cboMenu);

                //number of items
                txtTieuDeMenu = new TextBox();
                //add items 
                Controls.Add(cboMenuPosition);
                Controls.Add(cboMenu);
                Controls.Add(ddlLanguage);
                Controls.Add(txtTieuDeMenu);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Webpart", "Webpart", ex.Message);

            }
            base.CreateChildControls();
            this.ChildControlsCreated = true;
        }

        /// <summary>
        /// Get value from Webpart to editor part
        /// </summary>
        public override void SyncChanges()
        {
            EnsureChildControls();
            wpWebEN_MenuSideEN rightPart = this.WebPartToEdit as wpWebEN_MenuSideEN;
            if (rightPart != null)
            {
                txtTieuDeMenu.Text = Convert.ToString(rightPart.TieuDeMenu);
                cboMenuPosition.SelectedValue = Convert.ToString(rightPart.MenuPosition);
                cboMenu.SelectedValue = rightPart.ParentMenuID;
                //set current language 
                if (string.IsNullOrEmpty(rightPart.CurrentLanguage))
                {
                    ddlLanguage.SelectedValue = "vi-VN";
                }
                else
                {
                    ddlLanguage.SelectedValue = rightPart.CurrentLanguage;
                }
            }
        }

        /// <summary>
        /// Save changes 
        /// </summary>
        /// <returns></returns>
        public override bool ApplyChanges()
        {
            EnsureChildControls();
            wpWebEN_MenuSideEN rightPart = this.WebPartToEdit as wpWebEN_MenuSideEN;
            if (rightPart != null)
            {
                rightPart.TieuDeMenu = txtTieuDeMenu.Text;
                //set menu position
                rightPart.MenuPosition = Convert.ToInt32(cboMenuPosition.SelectedValue);
                //set parent menu id
                rightPart.ParentMenuID = cboMenu.SelectedValue;

                rightPart.CurrentLanguage = ddlLanguage.SelectedValue;

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
            writer.Write("<strong>Vị trí:</strong>");
            writer.WriteBreak();
            cboMenuPosition.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();

            writer.Write("<strong>Ngôn ngữ:</strong>");
            writer.WriteBreak();
            ddlLanguage.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();

            writer.Write("<strong>Menu cha:</strong>");
            writer.WriteBreak();
            cboMenu.RenderControl(writer);
            writer.WriteBreak();

            writer.Write("<strong>Tiêu đề menu:</strong>");
            writer.WriteBreak();
            txtTieuDeMenu.RenderControl(writer);
            writer.WriteBreak();
        }


        #region "Helper methods"
        /// <summary>
        /// Handler when change menu position
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cboMenuPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CMS_MenuDA objDA = new CMS_MenuDA();
                DataTable ds = objDA.GetTreeByLanguagePosition(ddlLanguage.SelectedValue, int.Parse(cboMenuPosition.SelectedValue), true, null);
                Utilities.BindDataToDropDownList(ds, "MenuID", "IndentedTitle", Globals.FirstItemCombox.None, cboMenu);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Webpart", "Webpart", ex.Message);

            }
        }
        private void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CMS_MenuDA objDA = new CMS_MenuDA();
                DataTable ds = objDA.GetTreeByLanguagePosition(ddlLanguage.SelectedValue, int.Parse(cboMenuPosition.SelectedValue), true, null);
                Utilities.BindDataToDropDownList(ds, "MenuID", "IndentedTitle", Globals.FirstItemCombox.None, cboMenu);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Webpart", "Webpart", ex.Message);

            }
        }
        #endregion
    }
}

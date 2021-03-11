using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Internet.Webpart
{
    class ChuyenDeDauKhiProperties: EditorPart
    {
         private DropDownList cboMenuPosition;
        private DropDownList cboMenu;
        private TextBox txtTotalMenuItems;




        public ChuyenDeDauKhiProperties()
        {
            Title = "MenuSide settings";
        }
        protected override void CreateChildControls()
        {
            //Add controls here
            //menu position
            cboMenuPosition = new DropDownList();
            cboMenuPosition.Width = new Unit("90%");
            cboMenuPosition.CssClass = "UserSelect";
            foreach (int value in Enum.GetValues(typeof(Pvn.Utils.Parameter.MenuPosition)))
            {
                cboMenuPosition.Items.Add(new ListItem(Enum.GetName(typeof(Pvn.Utils.Parameter.MenuPosition), value), value.ToString()));
            }
            cboMenuPosition.SelectedIndex = 0;
            cboMenuPosition.AutoPostBack = true;
            cboMenuPosition.SelectedIndexChanged += new EventHandler(cboMenuPosition_SelectedIndexChanged);
            //menu data
            cboMenu = new DropDownList();
            cboMenu.Width = new Unit("90%");
            cboMenu.CssClass = "UserSelect";
            CMS_MenuBL objBL = new CMS_MenuBL();
            List<CMS_MenuET> lstCMS_MenuET = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Pvn.Utils.Constants.Language.VIETNAMESE, int.Parse(cboMenuPosition.SelectedValue));
            cboMenu.DataSource = lstCMS_MenuET;
            cboMenu.DataTextField = "Title";
            cboMenu.DataValueField = "MenuID";
            cboMenu.DataBind();

        

            //add items 
            Controls.Add(cboMenuPosition);
            Controls.Add(cboMenu);
          

        }
        /// <summary>
        /// Get value from Webpart to editor part
        /// </summary>
        public override void SyncChanges()
        {
            EnsureChildControls();
            wpChuyenDeDauKhi rightPart = this.WebPartToEdit as wpChuyenDeDauKhi;
            if (rightPart != null)
            {
                cboMenuPosition.SelectedValue = Convert.ToString(rightPart.MenuPosition);
                cboMenu.SelectedValue = rightPart.ParentMenuID;
            }
        }

        /// <summary>
        /// Save changes 
        /// </summary>
        /// <returns></returns>
        public override bool ApplyChanges()
        {
            EnsureChildControls();
            wpChuyenDeDauKhi rightPart = this.WebPartToEdit as wpChuyenDeDauKhi;
            if (rightPart != null)
            {
                //set menu position
                rightPart.MenuPosition = Convert.ToInt32(cboMenuPosition.SelectedValue);
                //set parent menu id
                rightPart.ParentMenuID = cboMenu.SelectedValue;
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
            //writer.Write("<strong>Số lượng hiển thị:</strong>");
            //writer.WriteBreak();
            //txtTotalMenuItems.RenderControl(writer);
            //writer.WriteBreak();
            //writer.WriteBreak();
            writer.Write("<strong>Vị trí menu:</strong>");
            writer.WriteBreak();
            cboMenuPosition.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Menu cha:</strong>");
            writer.WriteBreak();
            cboMenu.RenderControl(writer);
            writer.WriteBreak();
        }
        private void cboMenuPosition_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                CMS_MenuBL objBL = new CMS_MenuBL();
                List<CMS_MenuET> lstCMS_MenuET = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Pvn.Utils.Constants.Language.VIETNAMESE, int.Parse(cboMenuPosition.SelectedValue));
                cboMenu.DataSource = lstCMS_MenuET;
                cboMenu.DataTextField = "Title";
                cboMenu.DataValueField = "MenuID";
                cboMenu.DataBind();
            }
            catch (Exception ex)
            {
               // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
    }
}

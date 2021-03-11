using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Internet.Webpart
{
    class NewsInfoProperties: EditorPart
    {
        private CheckBoxList chkListInfoType;

        public NewsInfoProperties()
        {
            Title = "NewsInfo";
        }

        protected override void CreateChildControls()
        {
            try
            {
                //Add controls here
                //menu position
                chkListInfoType = new CheckBoxList();
                chkListInfoType.Width = new Unit("90%");
                chkListInfoType.CssClass = "UserSelect";
                NewsInfoBL objBL = new NewsInfoBL();
                var table = objBL.GetNewsInfoType();

                chkListInfoType.DataValueField = "InfoTypeID";
                chkListInfoType.DataTextField = "Title";
                chkListInfoType.DataSource = table;
                chkListInfoType.DataBind();

                Controls.Add(chkListInfoType);
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
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
            wpNewsInfo rightPart = this.WebPartToEdit as wpNewsInfo;
            if (rightPart != null && rightPart.SelectedInfoType != null)
            {
                Dictionary<string, string> dicSelected = rightPart.SelectedInfoType;
                for (int i = 0; i < chkListInfoType.Items.Count; i++)                
                {
                    if (dicSelected.ContainsKey(chkListInfoType.Items[i].Value)) {
                        chkListInfoType.Items[i].Selected = true;
                    }
                }
                rightPart.SelectedInfoType = dicSelected;
            }
        }

        /// <summary>
        /// Save changes 
        /// </summary>
        /// <returns></returns>
        public override bool ApplyChanges()
        {
            EnsureChildControls();
            wpNewsInfo rightPart = this.WebPartToEdit as wpNewsInfo;
            if (rightPart != null)
            {
                Dictionary<string, string> dicSelected = new Dictionary<string, string>();
                for (int i = 0; i < chkListInfoType.Items.Count; i++)
                {
                    ListItem tempItem = chkListInfoType.Items[i];
                    if (tempItem.Selected)
                    {
                        dicSelected.Add(tempItem.Value, tempItem.Text);
                    }
                }
                rightPart.SelectedInfoType = dicSelected;
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
            writer.Write("<strong>Loại thông tin:</strong>");
            writer.WriteBreak();
            chkListInfoType.RenderControl(writer);            
        }
    }
}

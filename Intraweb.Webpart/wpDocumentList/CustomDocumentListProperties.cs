using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Intraweb.Webpart
{
    class CustomDocumentListProperties : EditorPart
    {
        private TextBox txtTotalItems;        
        private TextBox txtUrlDetail;   


        public CustomDocumentListProperties()
        {
            Title = "Document list settings";
        }

        protected override void CreateChildControls()
        {
            try
            {
                //Add controls here 
                //number of main items
                txtTotalItems = new TextBox();
                //url detail
                txtUrlDetail = new TextBox();                

                //add items                 
                Controls.Add(txtTotalItems);                
                Controls.Add(txtUrlDetail);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CustomDocumentListProperties", "CreateChildControls", ex.Message);
               
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
            wpDocumentList mainPart = this.WebPartToEdit as wpDocumentList;
            if (mainPart != null)
            {
                //set total news
                if (string.IsNullOrEmpty(Convert.ToString(mainPart.TotalItems)))
                {
                    txtTotalItems.Text = "10";
                }
                else
                {
                    txtTotalItems.Text = Convert.ToString(mainPart.TotalItems);
                }                
                //set url detail
                if (string.IsNullOrEmpty(mainPart.UrlDetail))
                {
                    txtUrlDetail.Text = "/Pages/documentdetail.aspx";
                }
                else { 
                    txtUrlDetail.Text = mainPart.UrlDetail;
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
            wpDocumentList mainPart = this.WebPartToEdit as wpDocumentList;
            if (mainPart != null)
            {
                //set total main items
                int _parseValue = 0;
                if (!int.TryParse(txtTotalItems.Text, out _parseValue))
                {
                    _parseValue = 10;
                }
                mainPart.TotalItems = _parseValue;                             
                //set url detail
                if (string.IsNullOrEmpty(txtUrlDetail.Text))
                {
                    mainPart.UrlDetail = "/Pages/documentdetail.aspx";
                }
                else
                {
                    mainPart.UrlDetail = txtUrlDetail.Text;
                }                
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
            writer.Write("<strong>Số lượng văn bản sẽ hiển thị:</strong>");
            writer.WriteBreak();
            txtTotalItems.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();           
            writer.Write("<strong>Đường dẫn link trang chi tiết</strong>");
            writer.WriteBreak();
            txtUrlDetail.RenderControl(writer);                       
        }
    }
}

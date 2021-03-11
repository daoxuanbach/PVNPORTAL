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
    class NewsListProperties : EditorPart
    {
        private TextBox txtTotalNews;
        private TextBox txtTotalOtherNews;
        private TextBox txtUrlDetail;
        private TextBox txtUrlList;
        private TextBox txtMainImageSize;
        private TextBox txtOtherImageSize;
        private TextBox txtMaxLengthTitle;
        private TextBox txtMaxLengthSummary;
        //language
        private DropDownList ddlLanguage;

       
        public NewsListProperties()
        {
            Title = "NewsList settings";
        }

        protected override void CreateChildControls()
        {
            try
            {
                //Add controls here 
                //number of main items
                txtTotalNews = new TextBox();
                //url detail
                txtUrlDetail = new TextBox();
                //number of other items
                txtTotalOtherNews = new TextBox();               
                //main image size
                txtMainImageSize = new TextBox();
                //other image size
                txtOtherImageSize = new TextBox();
                //url list
                txtUrlList = new TextBox();
                //max length title
                txtMaxLengthTitle = new TextBox();
                //max length summary
                txtMaxLengthSummary = new TextBox();

                //language
                ddlLanguage = new DropDownList();
                ddlLanguage.Items.Add(new ListItem("Tiếng việt", "vi-VN"));
                ddlLanguage.Items.Add(new ListItem("English", "en-US"));

                //add items                 
                Controls.Add(txtTotalNews);
                Controls.Add(txtTotalOtherNews);
                Controls.Add(txtUrlDetail);                
                Controls.Add(txtMainImageSize);
                Controls.Add(txtOtherImageSize);
                Controls.Add(txtUrlList);
                Controls.Add(txtMaxLengthSummary);
                Controls.Add(txtMaxLengthTitle);
                Controls.Add(ddlLanguage);
            }
            catch (Exception ex)
            {
              //  CommonLib.Common.Info.Instance.WriteToLog(ex);
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
            wpNewsList mainPart = this.WebPartToEdit as wpNewsList;
            if (mainPart != null)
            {
                //set total news
                if (string.IsNullOrEmpty(Convert.ToString(mainPart.TotalNews)))
                {
                    txtTotalNews.Text = "10";
                }
                else
                {
                    txtTotalNews.Text = Convert.ToString(mainPart.TotalNews);
                }
                //set total other news
                if (string.IsNullOrEmpty(Convert.ToString(mainPart.TotalOtherNews)))
                {
                    txtTotalOtherNews.Text = "5";
                }
                else
                {
                    txtTotalOtherNews.Text = Convert.ToString(mainPart.TotalOtherNews);
                }
                //set url detail
                if (string.IsNullOrEmpty(mainPart.UrlDetail))
                {
                    txtUrlDetail.Text = "/Pages/detail.aspx";
                }
                else { 
                    txtUrlDetail.Text = mainPart.UrlDetail;
                }
                //set url list
                if (string.IsNullOrEmpty(mainPart.UrlList))
                {
                    txtUrlList.Text = "/Pages/list.aspx";
                }
                else
                {
                    txtUrlList.Text = mainPart.UrlList;
                }                  
                //set main image size
                if (string.IsNullOrEmpty(mainPart.MainImageSize))
                {
                    txtMainImageSize.Text = "C254x172";
                }
                else
                {
                    txtMainImageSize.Text = mainPart.MainImageSize;
                }
                //set other image size
                if (string.IsNullOrEmpty(mainPart.OtherImageSize))
                {
                    txtOtherImageSize.Text = "C150x86";
                }
                else
                {
                    txtOtherImageSize.Text = mainPart.MainImageSize;
                }
                txtMaxLengthSummary.Text = Convert.ToString(mainPart.MaxLengthSummary);
                txtMaxLengthTitle.Text = Convert.ToString(mainPart.MaxLengthTitle);
                //set current language 
                if (string.IsNullOrEmpty(mainPart.CurrentLanguage))
                {
                    ddlLanguage.SelectedValue = "vi-VN";
                }
                else
                {
                    ddlLanguage.SelectedValue = mainPart.CurrentLanguage;
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
            wpNewsList mainPart = this.WebPartToEdit as wpNewsList;
            if (mainPart != null)
            {
                //set total main items
                int _parseValue = 0;
                if (!int.TryParse(txtTotalNews.Text, out _parseValue))
                {
                    _parseValue = 10;
                }
                mainPart.TotalNews = _parseValue;
                //set total other items                
                if (!int.TryParse(txtTotalOtherNews.Text, out _parseValue))
                {
                    _parseValue = 5;
                }
                mainPart.TotalOtherNews = _parseValue;                
                //set url detail
                if (string.IsNullOrEmpty(txtUrlDetail.Text))
                {
                    mainPart.UrlDetail = "/Pages/detail.aspx";
                }
                else
                {
                    mainPart.UrlDetail = txtUrlDetail.Text;
                }
                //set url list
                if (string.IsNullOrEmpty(txtUrlList.Text))
                {
                    mainPart.UrlList = "/Pages/list.aspx";
                }
                else
                {
                    mainPart.UrlList = txtUrlList.Text;
                }
                //set main image size
                if (string.IsNullOrEmpty(txtMainImageSize.Text))
                {
                    mainPart.MainImageSize = "C254x172";
                }
                else
                {
                    mainPart.MainImageSize = txtMainImageSize.Text;
                }
                //set other image size
                if (string.IsNullOrEmpty(txtOtherImageSize.Text))
                {
                    mainPart.OtherImageSize = "C150x86";
                }
                else
                {
                    mainPart.OtherImageSize = txtOtherImageSize.Text;
                }
                //set max length title                
                if (!int.TryParse(txtMaxLengthTitle.Text, out _parseValue))
                {
                    _parseValue = 100;
                }
                mainPart.MaxLengthTitle = _parseValue;
                //set max length summary                
                if (!int.TryParse(txtMaxLengthSummary.Text, out _parseValue))
                {
                    _parseValue = 100;
                }
                mainPart.MaxLengthSummary = _parseValue;
                mainPart.CurrentLanguage = ddlLanguage.SelectedValue;
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
            writer.Write("<strong>Số lượng tin chính sẽ hiển thị:</strong>");
            writer.WriteBreak();
            txtTotalNews.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Số lượng tin khác sẽ hiển thị:</strong>");
            writer.WriteBreak();
            txtTotalOtherNews.RenderControl(writer);            
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Đường dẫn link trang chi tiết</strong>");
            writer.WriteBreak();
            txtUrlDetail.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Đường dẫn link trang chuyên mục</strong>");
            writer.WriteBreak();
            txtUrlList.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Kích thước ảnh chính</strong>");
            writer.WriteBreak();
            txtMainImageSize.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Kích thước ảnh khác</strong>");
            writer.WriteBreak();
            txtOtherImageSize.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Độ dài của tiêu đề tin</strong>");
            writer.WriteBreak();
            txtMaxLengthTitle.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Độ dài của tóm tắt tin</strong>");
            writer.WriteBreak();
            txtMaxLengthSummary.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Ngôn ngữ</strong>");
            writer.WriteBreak();
            ddlLanguage.RenderControl(writer);
        }
    }
}

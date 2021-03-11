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
    class Toolpart_NewsListMain : EditorPart
    {
        private DropDownList cboNewsPriority;
        private DropDownList cboCategory;
        private DropDownList cboNgonNgu;

        private TextBox txtTotalNews;
        private TextBox txtUrlDetail;
        private TextBox txtUrlList;
        private TextBox txtMaxLengthTitle;
        private TextBox txtMaxLengthSummary;
        private TextBox txtMainImageSize;
        private TextBox txtOtherImageSize;


        public Toolpart_NewsListMain()
        {
            Title = "NewsMain settings";
        }

        protected override void CreateChildControls()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("PriorityPublishing");

                //Add controls here
                //news priority
                cboNewsPriority = new DropDownList();
                cboNewsPriority.CssClass = "UserSelect";
                Utilities.BindDataToDropDownList(dt, "Value", "Note", Globals.FirstItemCombox.AllItem, cboNewsPriority);

                //news category
                cboCategory = new DropDownList();
                cboCategory.CssClass = "UserSelect";
                CMS_CategoryDA objCategoryDA = new CMS_CategoryDA();
                DataTable dtCategory = objCategoryDA.GetTreeByLanguage(Constants.Language.VIETNAMESE,true, null);
                Utilities.BindDataToDropDownList(dtCategory, "CategoryID", "IndentedTitle", Globals.FirstItemCombox.AllItem, cboCategory);

                cboNgonNgu = new DropDownList();
                cboNgonNgu.CssClass = "UserSelect";
                DataTable tbNgonNgu = objDA.GetParameterByName("Language");
                Utilities.BindDataToDropDownList(tbNgonNgu, "Value", "Note", Globals.FirstItemCombox.None, cboNgonNgu);
                
                //number of items
                txtTotalNews = new TextBox();
                //url detail
                txtUrlDetail = new TextBox();
                //url list
                txtUrlList = new TextBox();
                //max length title
                txtMaxLengthTitle = new TextBox();
                //max length summary
                txtMaxLengthSummary = new TextBox();
                //main image size
                txtMainImageSize = new TextBox();
                //other image size
                txtOtherImageSize = new TextBox();

                //add items 
                Controls.Add(cboNewsPriority);
                Controls.Add(cboCategory);
                Controls.Add(cboNgonNgu);

                
                Controls.Add(txtTotalNews);
                Controls.Add(txtUrlList);
                Controls.Add(txtUrlDetail);
                Controls.Add(txtMaxLengthSummary);
                Controls.Add(txtMaxLengthTitle);
                Controls.Add(txtMainImageSize);
                Controls.Add(txtOtherImageSize);
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
            wpWebEN_NewsListMain mainPart = this.WebPartToEdit as wpWebEN_NewsListMain;
            if (mainPart != null)
            {
                //set total news
                txtTotalNews.Text = Convert.ToString(mainPart.TotalNews);
                cboNewsPriority.SelectedValue = Convert.ToString(mainPart.NewsPriority);
                cboCategory.SelectedValue = mainPart.CategoryID;
                cboNgonNgu.SelectedValue = mainPart.CurrentLanguage;

                
                txtMaxLengthSummary.Text = Convert.ToString(mainPart.MaxLengthSummary);
                txtMaxLengthTitle.Text = Convert.ToString(mainPart.MaxLengthTitle);
                //set url detail
                if (string.IsNullOrEmpty(mainPart.UrlDetail))
                {
                    txtUrlDetail.Text = "/Pages/detail.aspx";
                }
                else
                {
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
                    txtMainImageSize.Text = "C500x310";
                }
                else
                {
                    txtMainImageSize.Text = mainPart.MainImageSize;
                }
                //set other image size
                if (string.IsNullOrEmpty(mainPart.OtherImageSize))
                {
                    txtOtherImageSize.Text = "C116x76";
                }
                else
                {
                    txtOtherImageSize.Text = mainPart.OtherImageSize;
                }
                if (string.IsNullOrEmpty(mainPart.CurrentLanguage))
                {
                    cboNgonNgu.SelectedValue = "vi-VN";
                }
                else
                {
                    cboNgonNgu.SelectedValue = mainPart.CurrentLanguage;
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
            wpWebEN_NewsListMain mainPart = this.WebPartToEdit as wpWebEN_NewsListMain;
            if (mainPart != null)
            {
                //set total menu items
                int _parseValue = 0;
                if (!int.TryParse(txtTotalNews.Text, out _parseValue))
                {
                    _parseValue = 5;
                }
                mainPart.TotalNews = _parseValue;
                
                //set news priority
                mainPart.NewsPriority = Convert.ToInt32(cboNewsPriority.SelectedValue);
                //set category
                mainPart.CategoryID = cboCategory.SelectedValue;
                mainPart.CurrentLanguage = cboNgonNgu.SelectedValue;
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
                    mainPart.MainImageSize = "C325x221";
                }
                else
                {
                    mainPart.MainImageSize = txtMainImageSize.Text;
                }
                //set other image size
                if (string.IsNullOrEmpty(txtOtherImageSize.Text))
                {
                    mainPart.OtherImageSize = "C150x100";
                }
                else
                {
                    mainPart.OtherImageSize = txtOtherImageSize.Text;
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
            writer.Write("<strong>Ngôn ngữ:</strong>");
            writer.WriteBreak();
            cboNgonNgu.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Số lượng tin chính sẽ hiển thị:</strong>");
            writer.WriteBreak();
            txtTotalNews.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Loại tin ưu tiên của tin chính:</strong>");
            writer.WriteBreak();
            cboNewsPriority.RenderControl(writer);
            writer.WriteBreak();
            writer.Write("<strong>Số lượng tin khách sẽ hiển thị:</strong>");
            writer.WriteBreak();
            writer.Write("<strong>Chuyên mục:</strong>");
            writer.WriteBreak();
            cboCategory.RenderControl(writer);
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
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Độ dài của tiêu đề tin khác</strong>");
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
        }
    }
}

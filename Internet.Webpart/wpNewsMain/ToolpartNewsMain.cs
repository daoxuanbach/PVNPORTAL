using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Internet.Webpart
{
    class ToolpartNewsMain : EditorPart
    {
        private DropDownList cboNewsPriority;
        private DropDownList cboOtherNewsPriority;
        private DropDownList cboCategory;
        private TextBox txtTotalNews;
        private TextBox txtOtherTotalNews;
        private TextBox txtUrlDetail;
        private TextBox txtUrlList;
        private TextBox txtMaxLengthTitle;
        private TextBox txtMaxLengthOtherTitle;
        private TextBox txtMaxLengthSummary;
        private TextBox txtMainImageSize;
        private TextBox txtOtherImageSize;
        private TextBox txtTieuDe;
        //language
        private DropDownList ddlLanguage;

        public ToolpartNewsMain()
        {
            Title = "NewsMain settings";
        }

        protected override void CreateChildControls()
        {
            try
            {
                //Add controls here
                //news priority
                cboNewsPriority = new DropDownList();
                cboNewsPriority.CssClass = "UserSelect";
                cboNewsPriority.Items.Add(new ListItem("Tin Thường", "4"));
                cboNewsPriority.Items.Add(new ListItem("Tin mới", "3"));
                cboNewsPriority.Items.Add(new ListItem("Tin hót", "2"));


                //other news priority
                //news priority
                cboOtherNewsPriority = new DropDownList();
                cboOtherNewsPriority.CssClass = "UserSelect";
                cboOtherNewsPriority.Items.Add(new ListItem("Tin Thường", "4"));
                cboOtherNewsPriority.Items.Add(new ListItem("Tin mới", "3"));
                cboOtherNewsPriority.Items.Add(new ListItem("Tin hót", "2"));

                //news category
                cboCategory = new DropDownList();
                cboCategory.CssClass = "UserSelect";
                CMS_CategoryBL objBL = new CMS_CategoryBL();
                //DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Pvn.Utils.Constants.Language.VIETNAMESE);
                DataTable dtCategory = objBL.GetTreeByLanguage(Pvn.Utils.Constants.Language.VIETNAMESE, true, null);
                cboCategory.DataSource = dtCategory;
                cboCategory.DataTextField = "IndentedTitle";
                cboCategory.DataValueField = "CategoryID";
                cboCategory.DataBind();

                //language
                ddlLanguage = new DropDownList();
                ddlLanguage.Items.Add(new ListItem("Tiếng việt", "vi-VN"));
                ddlLanguage.Items.Add(new ListItem("English", "en-US"));

                txtTieuDe = new TextBox();
                //number of items
                txtTotalNews = new TextBox();
                //number of items
                txtOtherTotalNews = new TextBox();
                //url detail
                txtUrlDetail = new TextBox();
                //url list
                txtUrlList = new TextBox();
                //max length title
                txtMaxLengthTitle = new TextBox();
                //max length other title
                txtMaxLengthOtherTitle = new TextBox();
                //max length summary
                txtMaxLengthSummary = new TextBox();
                //main image size
                txtMainImageSize = new TextBox();
                //other image size
                txtOtherImageSize = new TextBox();

                //add items 

                Controls.Add(txtTieuDe);
                Controls.Add(cboNewsPriority);
                Controls.Add(cboOtherNewsPriority);
                Controls.Add(cboCategory);
                Controls.Add(ddlLanguage);
                
                Controls.Add(txtTotalNews);
                Controls.Add(txtOtherTotalNews);
                Controls.Add(txtUrlList);
                Controls.Add(txtUrlDetail);
                Controls.Add(txtMaxLengthSummary);
                Controls.Add(txtMaxLengthTitle);
                Controls.Add(txtMainImageSize);
                Controls.Add(txtOtherImageSize);
                Controls.Add(txtMaxLengthOtherTitle);
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
            wpNewsMain mainPart = this.WebPartToEdit as wpNewsMain;
            if (mainPart != null)
            {
                //set total news

                txtTieuDe.Text = Convert.ToString(mainPart.TieuDe);
                txtTotalNews.Text = Convert.ToString(mainPart.TotalNews);
                txtOtherTotalNews.Text = Convert.ToString(mainPart.OtherTotalNews);
                cboNewsPriority.SelectedValue = Convert.ToString(mainPart.NewsPriority);
                cboOtherNewsPriority.SelectedValue = Convert.ToString(mainPart.OtherNewsPriority);
                cboCategory.SelectedValue = mainPart.CategoryID;
                //set current language 
                if (string.IsNullOrEmpty(mainPart.CurrentLanguage))
                {
                    ddlLanguage.SelectedValue = "vi-VN";
                }
                else
                {
                    ddlLanguage.SelectedValue = mainPart.CurrentLanguage;
                }
                txtMaxLengthSummary.Text = Convert.ToString(mainPart.MaxLengthSummary);
                txtMaxLengthTitle.Text = Convert.ToString(mainPart.MaxLengthTitle);
                txtMaxLengthOtherTitle.Text = Convert.ToString(mainPart.MaxLengthOtherTitle);
                //set url detail
                if (string.IsNullOrEmpty(mainPart.UrlDetail))
                {
                    txtUrlDetail.Text = "/Pages"; // "/Pages/detail.aspx";
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
            }
        }

        /// <summary>
        /// Save changes 
        /// </summary>
        /// <returns></returns>
        public override bool ApplyChanges()
        {
            EnsureChildControls();
            wpNewsMain mainPart = this.WebPartToEdit as wpNewsMain;
            if (mainPart != null)
            {
                //set total menu items
                if (string.IsNullOrEmpty(txtTieuDe.Text))
                {
                    mainPart.TieuDe = "TIN NỔI BẬT";
                }
                else
                {
                    mainPart.TieuDe = txtTieuDe.Text;
                }

                int _parseValue = 0;
                if (!int.TryParse(txtTotalNews.Text, out _parseValue))
                {
                    _parseValue = 5;
                }
                mainPart.TotalNews = _parseValue;
                //set total other news
                if (!int.TryParse(txtOtherTotalNews.Text, out _parseValue))
                {
                    _parseValue = 5;
                }
                mainPart.OtherTotalNews = _parseValue;

                //set news priority
                mainPart.NewsPriority = Convert.ToInt32(cboNewsPriority.SelectedValue);
                //set other news priority
                mainPart.OtherNewsPriority = Convert.ToInt32(cboOtherNewsPriority.SelectedValue);
                //set category
                mainPart.CategoryID = cboCategory.SelectedValue;
                //set max length title                
                if (!int.TryParse(txtMaxLengthTitle.Text, out _parseValue))
                {
                    _parseValue = 100;
                }
                mainPart.MaxLengthTitle = _parseValue;
                //set max length other title                
                if (!int.TryParse(txtMaxLengthOtherTitle.Text, out _parseValue))
                {
                    _parseValue = 100;
                }
                mainPart.MaxLengthOtherTitle = _parseValue;
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
            writer.Write("<strong> Tiêu đề hiển thị:</strong>");
            writer.WriteBreak();
            txtTieuDe.RenderControl(writer);
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
            txtOtherTotalNews.RenderControl(writer);
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Loại tin ưu tiên của tin khác:</strong>");
            writer.WriteBreak();
            cboOtherNewsPriority.RenderControl(writer);
            writer.WriteBreak();
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
            txtMaxLengthOtherTitle.RenderControl(writer);
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

            writer.Write("<strong>Ngôn ngữ</strong>");
            writer.WriteBreak();
            ddlLanguage.RenderControl(writer);
        }
    }
}

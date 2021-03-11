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
    class Toolpart_NewList : EditorPart
    {
        private TextBox txtTotalNews;
        private TextBox txtTotalOtherNews;
        private TextBox txtUrlDetail;
        private TextBox txtUrlList;
        private TextBox txtMainImageSize;
        private TextBox txtOtherImageSize;
        //language
        private DropDownList ddlLanguage;


        public Toolpart_NewList()
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

                //language
                ddlLanguage = new DropDownList();
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable tbNgonNgu = objDA.GetParameterByName("Language");
                Utilities.BindDataToDropDownList(tbNgonNgu, "Value", "Note", Globals.FirstItemCombox.AllItem, ddlLanguage);

                //add items                 
                Controls.Add(txtTotalNews);
                Controls.Add(txtTotalOtherNews);
                Controls.Add(txtUrlDetail);
                Controls.Add(txtMainImageSize);
                Controls.Add(txtOtherImageSize);
                Controls.Add(txtUrlList);
                Controls.Add(ddlLanguage);
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
            wpWebEN_NewsList mainPart = this.WebPartToEdit as wpWebEN_NewsList;
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
                    txtUrlDetail.Text = "/sites/en/Pages/detail.aspx";
                }
                else
                {
                    txtUrlDetail.Text = mainPart.UrlDetail;
                }
                //set url list
                if (string.IsNullOrEmpty(mainPart.UrlList))
                {
                    txtUrlList.Text = "/sites/en/Pages/list.aspx";
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
            wpWebEN_NewsList mainPart = this.WebPartToEdit as wpWebEN_NewsList;
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
                    mainPart.UrlDetail = "/sites/en/Pages/detail.aspx";
                }
                else
                {
                    mainPart.UrlDetail = txtUrlDetail.Text;
                }
                //set url list
                if (string.IsNullOrEmpty(txtUrlList.Text))
                {
                    mainPart.UrlList = "/sites/en/Pages/list.aspx";
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

            writer.Write("<strong>Ngôn ngữ</strong>");
            writer.WriteBreak();
            ddlLanguage.RenderControl(writer);
        }
    }
}

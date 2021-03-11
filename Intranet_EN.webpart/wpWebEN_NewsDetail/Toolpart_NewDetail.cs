using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
namespace Intranet_EN.webpart
{
    class Toolpart_NewDetail : EditorPart
    {
        private TextBox txtTotalNewsTimeLine;
        private TextBox txtTotalOtherNews;
        private TextBox txtUrlDetail;
        private TextBox txtUrlList;
        private TextBox txtUrlSearchList;
        private CheckBox isShowBreadcum;
        private CheckBox isShowTitle;
        private CheckBox isShowSummary;
        private CheckBox isShowRelatedNews;
        private CheckBox isShowTags;
        private CheckBox isShowOtherNews;
        private CheckBox isShowNewsInSubject;


        public Toolpart_NewDetail()
        {
            Title = "NewsDetail settings";
        }

        protected override void CreateChildControls()
        {
            try
            {
                //Add controls here 
                //number of main items
                txtTotalNewsTimeLine = new TextBox();
                //number of other items
                txtTotalOtherNews = new TextBox();
                //url detail
                txtUrlDetail = new TextBox();
                //url list
                txtUrlList = new TextBox();
                //url search 
                txtUrlSearchList = new TextBox();
                //show breadcum
                isShowBreadcum = new CheckBox();
                isShowBreadcum.Checked = true;
                //show title
                isShowTitle = new CheckBox();
                isShowTitle.Checked = true;
                //show summary
                isShowSummary = new CheckBox();
                isShowSummary.Checked = true;
                //show related news
                isShowRelatedNews = new CheckBox();
                isShowRelatedNews.Checked = true;
                //show tags
                isShowTags = new CheckBox();
                isShowTags.Checked = true;
                //show other news
                isShowOtherNews = new CheckBox();
                isShowOtherNews.Checked = true;
                //show news in subject
                isShowNewsInSubject = new CheckBox();
                isShowNewsInSubject.Checked = true;


                //add items                 
                Controls.Add(txtTotalNewsTimeLine);
                Controls.Add(txtTotalOtherNews);
                Controls.Add(txtUrlDetail);
                Controls.Add(txtUrlList);
                Controls.Add(txtUrlSearchList);
                Controls.Add(isShowBreadcum);
                Controls.Add(isShowTitle);
                Controls.Add(isShowSummary);
                Controls.Add(isShowRelatedNews);
                Controls.Add(isShowTags);
                Controls.Add(isShowOtherNews);
                Controls.Add(isShowNewsInSubject);

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
            wpWebEN_NewsDetail detailPart = this.WebPartToEdit as wpWebEN_NewsDetail;
            if (detailPart != null)
            {
                //set total news
                if (string.IsNullOrEmpty(Convert.ToString(detailPart.TotalNewsTimeLine)))
                {
                    txtTotalNewsTimeLine.Text = "3";
                }
                else
                {
                    txtTotalNewsTimeLine.Text = Convert.ToString(detailPart.TotalNewsTimeLine);
                }
                //set total other news
                if (string.IsNullOrEmpty(Convert.ToString(detailPart.TotalOtherNews)))
                {
                    txtTotalOtherNews.Text = "5";
                }
                else
                {
                    txtTotalOtherNews.Text = Convert.ToString(detailPart.TotalOtherNews);
                }
                //set url detail
                if (string.IsNullOrEmpty(detailPart.UrlDetail))
                {
                    txtUrlDetail.Text = "/sites/en/Pages/detail.aspx";
                }
                else
                {
                    txtUrlDetail.Text = detailPart.UrlDetail;
                }
                //set url list
                if (string.IsNullOrEmpty(detailPart.UrlList))
                {
                    txtUrlList.Text = "/sites/en/Pages/list.aspx";
                }
                else
                {
                    txtUrlList.Text = detailPart.UrlList;
                }
                //set url search list
                if (string.IsNullOrEmpty(detailPart.UrlSearchList))
                {
                    txtUrlSearchList.Text = "/sites/en/Pages/newssearch.aspx";
                }
                else
                {
                    txtUrlSearchList.Text = detailPart.UrlSearchList;
                }
                //show breadcumb
                isShowBreadcum.Checked = detailPart.IsShowBreadcum;
                //show title
                isShowTitle.Checked = detailPart.IsShowTitle;
                //show summary
                isShowSummary.Checked = detailPart.IsShowSummary;
                //show related news
                isShowRelatedNews.Checked = detailPart.IsShowRelatedNews;
                //show tags
                isShowTags.Checked = detailPart.IsShowTags;
                //show other news
                isShowOtherNews.Checked = detailPart.IsShowOtherNews;
                //show news in a subject
                isShowNewsInSubject.Checked = detailPart.IsShowNewsInSubject;

            }
        }

        /// <summary>
        /// Save changes 
        /// </summary>
        /// <returns></returns>
        public override bool ApplyChanges()
        {
            EnsureChildControls();
            wpWebEN_NewsDetail detailPart = this.WebPartToEdit as wpWebEN_NewsDetail;
            if (detailPart != null)
            {
                //set total news timeline
                int _parseValue = 0;
                if (!int.TryParse(txtTotalNewsTimeLine.Text, out _parseValue))
                {
                    _parseValue = 10;
                }
                detailPart.TotalNewsTimeLine = _parseValue;
                //set total other items                
                if (!int.TryParse(txtTotalOtherNews.Text, out _parseValue))
                {
                    _parseValue = 5;
                }
                detailPart.TotalOtherNews = _parseValue;
                //set url detail
                if (string.IsNullOrEmpty(txtUrlDetail.Text))
                {
                    detailPart.UrlDetail = "/sites/en/Pages/detail.aspx";
                }
                else
                {
                    detailPart.UrlDetail = txtUrlDetail.Text;
                }
                //set url list
                if (string.IsNullOrEmpty(txtUrlList.Text))
                {
                    detailPart.UrlList = "/sites/en/Pages/list.aspx";
                }
                else
                {
                    detailPart.UrlList = txtUrlList.Text;
                }
                //set url list
                if (string.IsNullOrEmpty(txtUrlSearchList.Text))
                {
                    detailPart.UrlSearchList = "/sites/en/Pages/list.aspx";
                }
                else
                {
                    detailPart.UrlSearchList = txtUrlSearchList.Text;
                }
                //show breadcumb
                detailPart.IsShowBreadcum = isShowBreadcum.Checked;
                //show title
                detailPart.IsShowTitle = isShowTitle.Checked;
                //show summary
                detailPart.IsShowSummary = isShowSummary.Checked;
                //show related news
                detailPart.IsShowRelatedNews = isShowRelatedNews.Checked;
                //show tags
                detailPart.IsShowTags = isShowTags.Checked;
                //show other news
                detailPart.IsShowOtherNews = isShowOtherNews.Checked;
                //show news in a subject
                detailPart.IsShowNewsInSubject = isShowNewsInSubject.Checked;
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
            writer.Write("<strong>Số lượng tin sự kiện sẽ hiển thị:</strong>");
            writer.WriteBreak();
            txtTotalNewsTimeLine.RenderControl(writer);
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
            writer.Write("<strong>Đường dẫn link kết quả tìm kiếm</strong>");
            writer.WriteBreak();
            txtUrlSearchList.RenderControl(writer);
            //show breadcumb
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị BreadCumb</strong>");
            writer.WriteBreak();
            isShowBreadcum.RenderControl(writer);
            //show title
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị tiêu đề tin</strong>");
            writer.WriteBreak();
            isShowTitle.RenderControl(writer);
            //show summary
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị tóm tắt tin</strong>");
            writer.WriteBreak();
            isShowSummary.RenderControl(writer);
            //show related news
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị tin liên quan</strong>");
            writer.WriteBreak();
            isShowRelatedNews.RenderControl(writer);
            //show tags
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị tags</strong>");
            writer.WriteBreak();
            isShowTags.RenderControl(writer);
            //show other news
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị tin khác</strong>");
            writer.WriteBreak();
            isShowOtherNews.RenderControl(writer);
            //show news in a subject
            writer.WriteBreak();
            writer.WriteBreak();
            writer.Write("<strong>Hiển thị tin theo chủ đề</strong>");
            writer.WriteBreak();
            isShowNewsInSubject.RenderControl(writer);
        }
    }
}

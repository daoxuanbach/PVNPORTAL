using Pvn.DA;
using Pvn.Web.Codes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Pvn.Web.Usercontrols
{
    public partial class ucNewsDetailComment : System.Web.UI.UserControl
    {
        public Int32 TotalNewsTimeLine { get; set; }
        public Int32 TotalOtherNews { get; set; }
        public string UrlDetail { get; set; }
        public string UrlList { get; set; }
        public string UrlSearchList { get; set; }
        
        public Pvn.Utils.Parameter.Languages LanguageProperties { get; set; }
        public string HitsText { get; set; }
        public string OtherNewsText { get; set; }
        public string NewsTimelineText { get; set; }
        public string YKienBanDocText { get; set; }
        public string PagingNextButtonText { get; set; }
        public string PagingPrevButtonText { get; set; }
        public string SendCommentButtonText { get; set; }
        public string CommentText { get; set; }
        public string CommentNameText { get; set; }
        public string CommentEmailText { get; set; }
        public string CommentCaptchaText { get; set; }
        public string CommentNameMessage { get; set; }
        public string CommentEmailMessage { get; set; }
        public string CommentEmailWrongMessage { get; set; }
        public string CommentCaptchaMessage { get; set; }
        public string CommentContentMessage { get; set; }
        public string CommentSendContentSuccessMessage { get; set; }
        public string CommentSendContentFailureMessage { get; set; }

        private Guid _categoryID;
        private Guid _newsID;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                try
                {
                    //localize
                    LocalizeCommentControls();
                    BindData();
                }
                catch (Exception exc)
                {
                    //Module failed to load 
                    //CommonLib.Common.Info.Instance.WriteToLog(exc);
                }
            }
        }


        /// <summary>
        /// bind news detail data
        /// </summary>
        private void BindData()
        {
            try
            {
                NewsDetailDA objDA = new NewsDetailDA();
                if (NewsID == Guid.Empty)
                {
                    return;
                }
                string categoryName = string.Empty;
                string language = "vi-VN";
                if (LanguageProperties == Pvn.Utils.Parameter.Languages.English)
                {
                    language = "en-US";
                }
                DataSet ds = objDA.GetNewsDetailData(language, TotalOtherNews,
                    NewsID, TotalOtherNews, TotalNewsTimeLine, ref categoryName);

                if (ds == null || ds.Tables.Count == 0)
                    return;

                BindMainNews(ds.Tables[0]);

                //bind other news
                rptOtherNews.DataSource = ds.Tables[1];
                rptOtherNews.DataBind();

                //bind related news
                rptRelatedNews.DataSource = ds.Tables[3];
                rptRelatedNews.DataBind();

                //show keywords
                DataTable dtKeyWords = ds.Tables[4];
                if (dtKeyWords != null && dtKeyWords.Rows.Count > 0)
                {
                    //bind keywords
                    rptKeywords.DataSource = ds.Tables[4];
                    rptKeywords.DataBind();
                }
                else
                {
                    pnlTags.Visible = false;
                }
                //show news in subject
                if (ds.Tables[5] != null && ds.Tables[5].Rows.Count > 0)
                {
                    //show timline
                    rptTimeline.DataSource = ds.Tables[5];
                    rptTimeline.DataBind();
                }
                else
                {
                    pnlTimeline.Visible = false;
                }

            }
            catch (Exception exc)
            {
                //Module failed to load 
               // CommonLib.Common.Info.Instance.WriteToLog(exc);
            }
        }

        /// <summary>
        /// Bind main news information
        /// </summary>
        /// <param name="dtMainNews"></param>
        private void BindMainNews(DataTable dtMainNews)
        {
            if (dtMainNews != null && dtMainNews.Rows.Count > 0)
            {
                //title 
                ltrTitle.Text = Convert.ToString(dtMainNews.Rows[0]["Title"]);

                ltrTitle.Text = Convert.ToString(dtMainNews.Rows[0]["Title"]);
                DateTime _beginDate = Convert.ToDateTime(dtMainNews.Rows[0]["BeginDate"]);
                //set time
                ltrTime.Text = _beginDate.ToString("hh:mm");
                //set date
                ltrDate.Text = _beginDate.ToString("dd/MM/yyyy");
                //set hits
                ltrHits.Text = Convert.ToString(dtMainNews.Rows[0]["Hits"]);

                //set summary
                ltrSummary.Text = Convert.ToString(dtMainNews.Rows[0]["Summary"]);
                //set information
                string content = Page.Server.HtmlDecode(Convert.ToString(dtMainNews.Rows[0]["Information"]));
                //cap nhat cac thuoc tinh phu
                content = RenderNewsContent.ProcessRender(content);
                ltrInformation.Text = content;
            }
        }

        #region "Properties"
        /// <summary>
        /// CategoryID
        /// </summary>        
        public Guid CategoryID
        {
            get
            {
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["CatID"], out _categoryID))
                {
                    _categoryID = Guid.Empty;
                }
                return _categoryID;
            }
        }
        /// <summary>
        /// NewsID
        /// </summary>        
        public Guid NewsID
        {
            get
            {
                if (!Pvn.Utils.Utilities.IsGuid(this.Page.Request.QueryString["NewsID"], out _newsID))
                {
                    _newsID = Guid.Empty;
                }
                return _newsID;
            }
        }
        #endregion

        #region "Localize comment controls"
        private void LocalizeCommentControls()
        {
            //ContentComment
            Literal ltrYKBD = ContentComment.FindControl("ltrYKBD") as Literal;
            if (ltrYKBD != null)
            {
                ltrYKBD.Text = YKienBanDocText;
            }
            AspNetPager pgControl = ContentComment.FindControl("pgMain") as AspNetPager;
            if (pgControl != null)
            {
                pgControl.PrevPageText = PagingPrevButtonText;
                pgControl.NextPageText = PagingNextButtonText;
            }

            //comment controls
            Literal ltrComment = Comment.FindControl("ltrComment") as Literal;
            if (ltrComment != null)
            {
                ltrComment.Text = CommentText;
            }

            //finupdate panel
            UpdatePanel udpComment = Comment.FindControl("udpComment") as UpdatePanel;
            if (udpComment != null)
            {
                //name literal
                Literal ltrName = udpComment.FindControl("ltrName") as Literal;
                if (ltrName != null)
                {
                    ltrName.Text = CommentNameText;
                }
                //email
                Literal ltrEmail = udpComment.FindControl("ltrEmail") as Literal;
                if (ltrEmail != null)
                {
                    ltrEmail.Text = CommentEmailText;
                }
                //captcha
                Literal ltrCaptcha = udpComment.FindControl("ltrCaptcha") as Literal;
                if (ltrCaptcha != null)
                {
                    ltrCaptcha.Text = CommentCaptchaText;
                }
                //send button
                LinkButton btnSend = udpComment.FindControl("btnSend") as LinkButton;
                if (btnSend != null)
                {
                    btnSend.Text = SendCommentButtonText;
                }
                //messages                
                HiddenField hdfHotenMess = udpComment.FindControl("hdfHotenMess") as HiddenField;
                if (hdfHotenMess != null)
                {
                    hdfHotenMess.Value = CommentNameMessage;
                }
                HiddenField hdfEnamilMess = udpComment.FindControl("hdfEnamilMess") as HiddenField;
                if (hdfEnamilMess != null)
                {
                    hdfEnamilMess.Value = CommentEmailMessage;
                }
                HiddenField hdfEmailCompareMess = udpComment.FindControl("hdfEmailCompareMess") as HiddenField;
                if (hdfEmailCompareMess != null)
                {
                    hdfEmailCompareMess.Value = CommentEmailWrongMessage;
                }
                HiddenField hdfMaMess = udpComment.FindControl("hdfMaMess") as HiddenField;
                if (hdfMaMess != null)
                {
                    hdfMaMess.Value = CommentCaptchaMessage;
                }
                HiddenField hdfNoiDungMess = udpComment.FindControl("hdfNoiDungMess") as HiddenField;
                if (hdfNoiDungMess != null)
                {
                    hdfNoiDungMess.Value = CommentContentMessage;
                }
                HiddenField hdfPostSuccess = udpComment.FindControl("hdfPostSuccess") as HiddenField;
                if (hdfPostSuccess != null)
                {
                    hdfPostSuccess.Value = CommentSendContentSuccessMessage;
                }
                HiddenField hdfPostFail = udpComment.FindControl("hdfPostFail") as HiddenField;
                if (hdfPostFail != null)
                {
                    hdfPostFail.Value = CommentSendContentFailureMessage;
                }

            }
        }
        #endregion
    }
}
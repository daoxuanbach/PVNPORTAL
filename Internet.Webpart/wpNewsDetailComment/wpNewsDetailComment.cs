using System;
using System.ComponentModel;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using Microsoft.SharePoint;
using Microsoft.SharePoint.WebControls;
using Pvn.Web.Usercontrols;
namespace Internet.Webpart
{
    [ToolboxItemAttribute(false)]
    public class wpNewsDetailComment : WebPart
    {
        // Visual Studio might automatically update this path when you change the Visual Web Part project item.
        private const string _ascxPath = @"~/UserControls/ucNewsDetailComment.ascx";
        ucNewsDetailComment _uc = new ucNewsDetailComment();
        protected override void CreateChildControls()
        {
            _uc = (ucNewsDetailComment)Page.LoadControl(_ascxPath);
            _uc.TotalNewsTimeLine = this.TotalNewsTimeLine;
            _uc.TotalOtherNews = this.TotalOtherNews;
            _uc.UrlDetail = this.UrlDetail;
            _uc.UrlList = this.UrlList;
            _uc.UrlSearchList = this.UrlSearchList;
            _uc.LanguageProperties = this.LanguageProperties;
            _uc.HitsText = this.HitsText;
            _uc.OtherNewsText = this.OtherNewsText;
            _uc.NewsTimelineText = this.NewsTimelineText;
            _uc.YKienBanDocText = this.YKienBanDocText;
            _uc.PagingNextButtonText = this.PagingNextButtonText;
            _uc.PagingPrevButtonText = this.PagingPrevButtonText;
            _uc.SendCommentButtonText = this.SendCommentButtonText;
            _uc.CommentText = this.CommentText;
            _uc.CommentNameText = this.CommentNameText;
            _uc.CommentEmailText = this.CommentEmailText;
            _uc.CommentCaptchaText = this.CommentCaptchaText;
            _uc.CommentNameMessage = this.CommentNameMessage;
            _uc.CommentEmailMessage = this.CommentEmailMessage;
            _uc.CommentEmailWrongMessage = this.CommentEmailWrongMessage;
            _uc.CommentCaptchaMessage = this.CommentCaptchaMessage;
            _uc.CommentContentMessage = this.CommentContentMessage;
            _uc.CommentSendContentSuccessMessage = this.CommentSendContentSuccessMessage;
            _uc.CommentSendContentFailureMessage = this.CommentSendContentFailureMessage;
            this.Controls.Add(_uc);
        }
        private Int32 _TotalNewsTimeLine = 3;
        [Category("Extended Settings"),
       Personalizable(PersonalizationScope.Shared),
       WebBrowsable(true),
       WebDisplayName("Số lượng tin sự kiện sẽ hiển thị"),
       WebDescription("Số lượng tin sự kiện sẽ hiển thị")]
        public Int32 TotalNewsTimeLine
        {
            get { return _TotalNewsTimeLine; }
            set { _TotalNewsTimeLine = value; }
        }
        private Int32 _TotalOtherNews = 10;
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Số lượng tin khác sẽ hiển thị"),
        WebDescription("Số lượng tin khác sẽ hiển thị")]
        public Int32 TotalOtherNews
        {
            get { return _TotalOtherNews; }
            set { _TotalOtherNews = value; }
        }
        private string _UrlDetail = "/Pages";
        [Category("Extended Settings"),
        Personalizable(PersonalizationScope.Shared),
        WebBrowsable(true),
        WebDisplayName("Đường dẫn link trang chi tiết"),
        WebDescription("Đường dẫn link trang chi tiết")]
        public string UrlDetail
        {
            get { return _UrlDetail; }
            set { _UrlDetail = value; }
        }
        private string _UrlList = "/Pages/list.aspx";

        [Category("Extended Settings"),
       Personalizable(PersonalizationScope.Shared),
       WebBrowsable(true),
       WebDisplayName("Đường dẫn link trang chuyên mục"),
       WebDescription("Đường dẫn link trang chuyên mục")]
        public string UrlList
        {
            get { return _UrlList; }
            set { _UrlList = value; }
        }
        private string _UrlSearchList = "/Pages/newssearch.aspx";

        [Category("Extended Settings"),
       Personalizable(PersonalizationScope.Shared),
       WebBrowsable(true),
       WebDisplayName("Đường dẫn link kết quả tìm kiếm"),
       WebDescription("Đường dẫn link kết quả tìm kiếm")]
        public string UrlSearchList
        {
            get { return _UrlSearchList; }
            set { _UrlSearchList = value; }
        }


        private Pvn.Utils.Parameter.Languages _LanguageProperties = Pvn.Utils.Parameter.Languages.Vietnam;
        [
        Category("Extended Settings"),
        WebBrowsable(true),
        WebDisplayName("Ngôn ngữ"),
        Personalizable(PersonalizationScope.Shared)
        ]
        public Pvn.Utils.Parameter.Languages LanguageProperties
        {
            get { return _LanguageProperties; }
            set { _LanguageProperties = value; }
        }
        private string _HitsText = "Lượt xem";
        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("Lượt xem text"),
      WebDescription("Lượt xem text")]
        public string HitsText
        {
            get { return _HitsText; }
            set { _HitsText = value; }
        }
        private string _OtherNewsText = "Tin khác";
        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("Tin khác text"),
      WebDescription("Tin khác text")]
        public string OtherNewsText
        {
            get { return _OtherNewsText; }
            set { _OtherNewsText = value; }
        }
        private string _NewsTimelineText = "Sự kiện";
        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Sự kiện text"),
    WebDescription("Sự kiện text")]
        public string NewsTimelineText
        {
            get { return _NewsTimelineText; }
            set { _NewsTimelineText = value; }
        }
        private string _YKienBanDocText = "Ý kiến bạn đọc";
        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("Ý kiến bạn đọc text"),
      WebDescription("Ý kiến bạn đọc text")]
        public string YKienBanDocText
        {
            get { return _YKienBanDocText; }
            set { _YKienBanDocText = value; }
        }
        private string _PagingNextButtonText = "Sau >>";
        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("Paging next button text"),
      WebDescription("Paging next button text")]
        public string PagingNextButtonText
        {
            get { return _PagingNextButtonText; }
            set { _PagingNextButtonText = value; }
        }
        private string _PagingPrevButtonText = "<< Trước";
        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("Paging prev button text"),
      WebDescription("Paging prev button text")]
        public string PagingPrevButtonText
        {
            get { return _PagingPrevButtonText; }
            set { _PagingPrevButtonText = value; }
        }
        private string _SendCommentButtonText = "Gửi bình luận";

        [Category("Extended Settings"),
      Personalizable(PersonalizationScope.Shared),
      WebBrowsable(true),
      WebDisplayName("Nút gửi bình luận text"),
      WebDescription("Nút gửi bình luận text")]
        public string SendCommentButtonText
        {
            get { return _SendCommentButtonText; }
            set { _SendCommentButtonText = value; }
        }
        private string _CommentText = "Bình luận";

        [Category("Extended Settings"),
     Personalizable(PersonalizationScope.Shared),
     WebBrowsable(true),
     WebDisplayName("Bình luận text"),
     WebDescription("Bình luận text")]
        public string CommentText
        {
            get { return _CommentText; }
            set { _CommentText = value; }
        }
        private string _CommentNameText = "Họ tên";

        [Category("Extended Settings"),
     Personalizable(PersonalizationScope.Shared),
     WebBrowsable(true),
     WebDisplayName("Họ tên bình luận text"),
     WebDescription("Họ tên bình luận text")]
        public string CommentNameText
        {
            get { return _CommentNameText; }
            set { _CommentNameText = value; }
        }
        private string _CommentEmailText = "Email";

        [Category("Extended Settings"),
     Personalizable(PersonalizationScope.Shared),
     WebBrowsable(true),
     WebDisplayName("Email bình luận text"),
     WebDescription("Email bình luận text")]
        public string CommentEmailText
        {
            get { return _CommentEmailText; }
            set { _CommentEmailText = value; }
        }
        private string _CommentCaptchaText = "Mã xác nhận";

        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Captcha bình luận text"),
    WebDescription("Captcha bình luận text")]
        public string CommentCaptchaText
        {
            get { return _CommentCaptchaText; }
            set { _CommentCaptchaText = value; }
        }
        //comments message
        private string _CommentNameMessage = "Họ tên";

        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Họ tên message text"),
    WebDescription("Họ tên message text")]
        public string CommentNameMessage
        {
            get { return _CommentNameMessage; }
            set { _CommentNameMessage = value; }
        }
        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Email message text"),
    WebDescription("Email message text")]
        public string CommentEmailMessage
        {
            get;
            set;
        }
        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Email sai message text"),
    WebDescription("Email sai message text")]
        public string CommentEmailWrongMessage
        {
            get;
            set;
        }

        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Captcha message text"),
    WebDescription("Captcha message text")]
        public string CommentCaptchaMessage
        {
            get;
            set;
        }
        [Category("Extended Settings"),
    Personalizable(PersonalizationScope.Shared),
    WebBrowsable(true),
    WebDisplayName("Content message text"),
    WebDescription("Content message text")]
        public string CommentContentMessage
        {
            get;
            set;
        }

        [Category("Extended Settings"),
   Personalizable(PersonalizationScope.Shared),
   WebBrowsable(true),
   WebDisplayName("Send content success message text"),
   WebDescription("Send content success message text")]
        public string CommentSendContentSuccessMessage
        {
            get;
            set;
        }

        [Category("Extended Settings"),
   Personalizable(PersonalizationScope.Shared),
   WebBrowsable(true),
   WebDisplayName("Send content failure message text"),
   WebDescription("Send content failure message text")]
        public string CommentSendContentFailureMessage
        {
            get;
            set;
        }
    }
}

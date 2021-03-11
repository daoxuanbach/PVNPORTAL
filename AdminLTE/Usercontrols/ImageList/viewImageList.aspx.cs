using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.ImageList
{
    public partial class viewImageList : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Code = String.Empty;
        public Int16 UsedState = 0;
        public Int16 PublishedState = 2;
        public string Desscription = String.Empty;
        public Guid? ImageCategoryID;
        public DateTime? FromDate;
        public DateTime? ToDate;
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
        DataTable category = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Quản lý hệ thống";
                RequestPage();
                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                    BindComboBox();
                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void BindData()
        {
            HttpCookie myLanguage = new HttpCookie("Language");
            myLanguage = Request.Cookies["Language"];
            if (myLanguage != null && myLanguage.Value != "")
            {
                Language = (string)(myLanguage.Value);
            }

            HttpCookie myCategoryID = new HttpCookie("ImageCategoryID");
            myCategoryID = Request.Cookies["ImageCategoryID"];
            if (myCategoryID != null && myCategoryID.Value != "")
            {
                ImageCategoryID = new Guid(myCategoryID.Value);
            }
            HttpCookie mySearch = new HttpCookie("txtSearch");
            mySearch = Request.Cookies["txtSearch"];
            if (mySearch != null && mySearch.Value != "")
            {
                KeyWord = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myDesscription = new HttpCookie("txtDesscription");
            myDesscription = Request.Cookies["txtDesscription"];
            if (myDesscription != null && myDesscription.Value != "")
            {
                Desscription = Server.UrlDecode((myDesscription.Value)).Trim();
            }


            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }
            HttpCookie myFromDate = new HttpCookie("FromDate");
            myFromDate = Request.Cookies["FromDate"];
            if (myFromDate != null && myFromDate.Value != "")
            {
                DateTime dt;
                DateTime.TryParseExact(myFromDate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                if (dt.Year > 1)
                {
                    FromDate = dt;
                }
            }
            HttpCookie myToDate = new HttpCookie("ToDate");
            myToDate = Request.Cookies["ToDate"];
            if (myToDate != null && myToDate.Value != "")
            {
                DateTime dt;
                DateTime.TryParseExact(myToDate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                if (dt.Year > 1)
                {
                    ToDate = dt;
                }

            }
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }

            HttpCookie myPublishedState = new HttpCookie("PublishedState");
            myPublishedState = Request.Cookies["PublishedState"];
            if (myPublishedState != null && myPublishedState.Value != "")
            {
                PublishedState = Convert.ToInt16(myPublishedState.Value);
            }
            
            CMS_ImageBL objBL = new CMS_ImageBL();
            DataTable category = objBL.GetSearchPaging(
                    Pvn.Utils.Constants.Language.VIETNAMESE,
                    "[CreatedDate] DESC",
                    (CurPage - 1),
                    RowPerPage,
                    out totalRows,
                    ImageCategoryID,
                    KeyWord,
                    Desscription,
                    Language,
                    UsedState,
                    null,//(short)Core.Web.Common.Parameter.RatingState.ChoPhepHienThiDanhGia,
                    PublishedState,//(short)Core.Web.Common.Parameter.PublishedState.ChoPhepXuatBan,
                    //!string.IsNullOrEmpty(cboRatingState.SelectedValue) ? Convert.ToInt16(cboRatingState.SelectedValue) : (short?)null,
                    //!string.IsNullOrEmpty(cboPublishedState.SelectedValue) ? Convert.ToInt16(cboPublishedState.SelectedValue) : (short?)null,
                    "",//txtAuthor.Text,
                   "",// txtReference.Text,
                    null,
                    null,
                    FromDate,
                    ToDate
                );
            rptDatabind.DataSource = category;
            rptDatabind.DataBind();

            if (totalRows == 0)
                litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
            else
            {
                var paging = new PagingUtil();
                litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP);
            }

        }
        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rpttUnit.DataSource = lstNgonNguET;
                rpttUnit.DataBind();

                CMS_ImageCategoryBL objBL = new CMS_ImageCategoryBL();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Pvn.Utils.Constants.Language.VIETNAMESE);
                rptImageCategoryID.DataSource = category;
                rptImageCategoryID.DataBind();

                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ImageCategoryList", "BindComboBox", ex.Message);
            }
        }
    }
}
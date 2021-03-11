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

namespace AdminLTE.Usercontrols.VideoList
{
    public partial class viewVideoList : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Code = String.Empty;
        public Int16 UsedState = 0;
        public Int16 PublishedState = 2;
        public string Desscription = String.Empty;
        public Guid? VideoCategoryID = null;
        public DateTime? FromDate;
        public DateTime? ToDate;
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
        DataTable category = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Resources.vi.viewImageCategoryList;
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

            HttpCookie myVideoCategoryID = new HttpCookie("VideoCategoryID");
            myVideoCategoryID = Request.Cookies["VideoCategoryID"];
            if (myVideoCategoryID != null && myVideoCategoryID.Value != "")
            {
                VideoCategoryID = new Guid(myVideoCategoryID.Value);
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

            CMS_VideoBL objBL = new CMS_VideoBL();
            DataTable category = objBL.GetSearchPaging(
                   Pvn.Utils.Constants.Language.VIETNAMESE,
                    "[CreatedDate] DESC",
                    (CurPage - 1),
                    RowPerPage,
                    out totalRows,
                    VideoCategoryID,
                    KeyWord,
                    Desscription,
                    Language,
                    UsedState,
                    2,//(short)Core.Web.Common.Parameter.RatingState.ChoPhepHienThiDanhGia,
                    PublishedState, // !string.IsNullOrEmpty(cboPublishedState.SelectedValue) ? Convert.ToInt16(cboPublishedState.SelectedValue) : (short?)null,//(short)Core.Web.Common.Parameter.PublishedState.ChoPhepXuatBan,
                    "",//txtAuthor.Text,
                    "",
                    null,
                    null,
                    null,
                    null);
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
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();
                System.Data.DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
               

                Sys_ParameterDA objNNDA = new Sys_ParameterDA();
                DataTable lstNgonNguET = objNNDA.GetParameterByName("Language");

                rptLanguage.DataSource = lstNgonNguET;
                rptLanguage.DataBind();


                CMS_VideoCategoryBL objBL = new CMS_VideoCategoryBL();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Pvn.Utils.Constants.Language.VIETNAMESE);
                rptVideoCategoryID.DataSource = category;
                rptVideoCategoryID.DataBind();


            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ImageCategoryList", "BindComboBox", ex.Message);
            }
        }
    }
}
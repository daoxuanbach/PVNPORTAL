using Pvn.BL;
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

namespace AdminLTE.Usercontrols.NewsList
{
    public partial class viewNewsList : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Summary = string.Empty;
        public Int16 UsedState = 0;
        //public Guid CategoryID = Guid.Empty;
        public Guid? categoryID = null;
        public DateTime? CreatedDateFrom;
        public DateTime? CreatedDateTo;
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
        DataTable category = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Resources.vi.viewNewsList;
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

            HttpCookie myCategoryID = new HttpCookie("CategoryID");
            myCategoryID = Request.Cookies["CategoryID"];
            if (myCategoryID != null && myCategoryID.Value != "")
            {
                categoryID = new Guid(myCategoryID.Value);
            }
            HttpCookie mySearch = new HttpCookie("txtSearch");
            mySearch = Request.Cookies["txtSearch"];
            if (mySearch != null && mySearch.Value != "")
            {
                KeyWord = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie mytxtSummary = new HttpCookie("txtSummary2");
            mytxtSummary = Request.Cookies["txtSummary2"];
            if (mytxtSummary != null && mytxtSummary.Value != "")
            {
                Summary = Server.UrlDecode((mytxtSummary.Value)).Trim();
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
                    CreatedDateFrom = dt;
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
                    CreatedDateTo = dt;
                }
            }
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }


            CMS_NewsBL objBL = new CMS_NewsBL();
            int userID = new Sys_UserBL().GetUserLogin(); ;

            category = objBL.GetAll_CMS_News_Paging(
                        Pvn.Utils.Constants.Language.VIETNAMESE,
                        "[BeginDate] DESC",
                        (CurPage - 1),
                        RowPerPage,
                        out totalRows,
                        0,//IsAdmin? 0 : int.Parse(UserID),
                        1,//Tin khong theo quy trinh
                        categoryID,
                        null,//(short?)Core.Web.Common.Parameter.DataAccess.ChoPhepNguoiDocTruyCap,
                        null,//(short?)Core.Web.Common.Parameter.RatingState.ChoKiemDuyetDanhGia,
                        UsedState,
                        KeyWord,
                        Summary,
                        Language,
                        string.Empty,
                        string.Empty,
                        0,//IsAdmin? 0 : int.Parse(UserID),
                        null,
                        CreatedDateFrom,
                        CreatedDateTo
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
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rpttUnit.DataSource = lstNgonNguET;
                rpttUnit.DataBind();
                CMS_CategoryBL objBL = new CMS_CategoryBL();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Language);
                rptParentCategoryID.DataSource = category;
                rptParentCategoryID.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewNewsList", "BindComboBox", ex.Message);
            }
        }
        public string SplitBR(object name)
        {
            try
            {
                if (Convert.ToString(name) == "")
                    return "";
                else
                    return Convert.ToString(name).Replace("$#", "<br />");
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SplitBR", "SplitBR", ex.Message);
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return Convert.ToString(name);
            }

        }
    }
}
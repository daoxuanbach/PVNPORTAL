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

namespace AdminLTE.Usercontrols.LoaiVanBan
{
    public partial class viewLoaiVanBan : BasePage
    {
        public long totalRows = 0;
        public string txtMa = String.Empty;
        public string txtTen = String.Empty;
        public Int16? UsedState ;
        public DateTime? CreatedDateFrom;
        public DateTime? CreatedDateTo;
        public Guid? LoaiVanBanID;
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
                Pvn.Utils.LogFile.WriteLogFile("viewLoaiVanBan", "SubString", ex.Message);
            }
        }
        private void BindData()
        {
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }
            HttpCookie mySearch = new HttpCookie("txtTen");
            mySearch = Request.Cookies["txtTen"];
            if (mySearch != null && mySearch.Value != "")
            {
                txtTen = Server.UrlDecode((mySearch.Value));
            }
            HttpCookie myCode = new HttpCookie("txtMa");
            myCode = Request.Cookies["txtMa"];
            if (myCode != null && myCode.Value != "")
            {
                txtMa = Server.UrlDecode((myCode.Value));
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
                DateTime datetime;
                DateTime.TryParseExact(Server.UrlDecode(myFromDate.Value), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);
                if (datetime.Year > 1)
                {
                    CreatedDateFrom = datetime;
                }
            }
            HttpCookie myLoaiVanBanID = new HttpCookie("LoaiVanBanID");
            myLoaiVanBanID = Request.Cookies["LoaiVanBanID"];
            if (myLoaiVanBanID != null && myLoaiVanBanID.Value != "")
            {
                LoaiVanBanID = new Guid(myLoaiVanBanID.Value);
            }
            HttpCookie myToDate = new HttpCookie("ToDate");
            myToDate = Request.Cookies["ToDate"];
            if (myToDate != null && myToDate.Value != "")
            {
                DateTime datetime;
                DateTime.TryParseExact(Server.UrlDecode(myToDate.Value), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out datetime);
                if (datetime.Year > 1)
                {
                    CreatedDateTo = datetime;
                }
            }
            Doc_LoaiVanBanDA objDA = new Doc_LoaiVanBanDA();
            DataTable dt = objDA.GetSearchPaging(
                   Globals.CurrentLanguage,
                   null,
                  (CurPage - 1),
                    RowPerPage,
                   out totalRows,
                   //cboNgonNgu.SelectedValue,
                   Pvn.Utils.Constants.Language.VIETNAMESE,
                   txtMa.Trim(),
                   txtTen.Trim(),
                   null,
                   null,
                   UsedState,
                   null,
                   CreatedDateFrom,
                   null,
                   CreatedDateTo,
                   null,
                   LoaiVanBanID);
            rptDatabind.DataSource = dt;
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
                Doc_LoaiVanBanDA objDao = new Doc_LoaiVanBanDA();
                DataTable tb = objDao.GetAllItemTree();
                DataRow row = tb.NewRow();
                row["IndentedTitle"] = "--- Tất cả ---";
                row["LoaiVanBanID"] = Guid.Empty;
                tb.Rows.InsertAt(row, 0);
                rptLoaiVanBan.DataSource = tb;
                rptLoaiVanBan.DataBind();

                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
    }
}
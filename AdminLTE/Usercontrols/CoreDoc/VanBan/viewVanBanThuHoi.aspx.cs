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

namespace AdminLTE.Usercontrols.VanBan
{
    public partial class viewVanBanThuHoi : BasePage
    {
        public long totalRows = 0;
        public Guid? LoaiVanBanID;
        public Guid? LinhVucID;
        public string txtTieuDe = String.Empty;
        public string txtSoVanBan = String.Empty;
        public int? UsedState;
        public DateTime? CreatedDateFrom;
        public DateTime? CreatedDateTo;
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
                Pvn.Utils.LogFile.WriteLogFile("viewVanBanThuHoi", "Page_Load", ex.Message);
            }
        }
        private void BindData()
        {
            string TrangThaiVanBan=  string.Concat((short)Pvn.Utils.Common.Parameter.DocumentState.XuatBan);
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }
            HttpCookie mytxtSoVanBan = new HttpCookie("txtSoVanBan");
            mytxtSoVanBan = Request.Cookies["txtSoVanBan"];
            if (mytxtSoVanBan != null && mytxtSoVanBan.Value != "")
            {
                txtSoVanBan = Server.UrlDecode((mytxtSoVanBan.Value));
            }
            HttpCookie myTieuDe = new HttpCookie("txtTieuDe");
            myTieuDe = Request.Cookies["txtTieuDe"];
            if (myTieuDe != null && myTieuDe.Value != "")
            {
                txtTieuDe = Server.UrlDecode((myTieuDe.Value));
            }
            
            HttpCookie myLoaiVanBanID = new HttpCookie("LoaiVanBanID");
            myLoaiVanBanID = Request.Cookies["LoaiVanBanID"];
            if (myLoaiVanBanID != null && myLoaiVanBanID.Value != "")
            {
                LoaiVanBanID = new Guid(myLoaiVanBanID.Value);
            }
            HttpCookie myLinhVucID = new HttpCookie("LinhVucID");
            myLinhVucID = Request.Cookies["LinhVucID"];
            if (myLinhVucID != null && myLinhVucID.Value != "")
            {
                LinhVucID = new Guid(myLinhVucID.Value);
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
            Doc_VanBanDA objDA = new Doc_VanBanDA();
            DataTable dt = objDA.GetSearchPagingWithDocStates(
                    Globals.CurrentLanguage,
                    null,
                    (CurPage - 1),
                    RowPerPage, 
                    out totalRows,
                    Globals.CurrentLanguage,
                    txtSoVanBan.Trim(),
                    (Int16?)null,
                     TrangThaiVanBan,
                    LoaiVanBanID,
                    LinhVucID,
                    null,
                    CreatedDateFrom,
                    null,
                    null,
                    txtTieuDe.Trim(),
                    null,
                    string.Empty,
                    null,
                    null,
                    null,
                    null,
                    string.Empty,
                    string.Empty,
                    null,
                    string.Empty,
                    null,
                    string.Empty,
                    CreatedDateTo,
                    null
                    );

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
                Doc_LinhVucVanBanDA objLinhVucDA = new Doc_LinhVucVanBanDA();
                rptLinhVuc.DataSource = objLinhVucDA.GetAllData();
                rptLinhVuc.DataBind();
                Doc_LoaiVanBanDA objDao = new Doc_LoaiVanBanDA();
                DataTable tb = objDao.GetAllItemTree();
                DataRow row = tb.NewRow();
                row["IndentedTitle"] = "--- Chọn  ---";
                row["LoaiVanBanID"] = Guid.Empty;
                tb.Rows.InsertAt(row, 0);
                rptLoaiVanBan.DataSource = tb;
                rptLoaiVanBan.DataBind();

             }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
    }
}
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

namespace AdminLTE.Usercontrols.Worker
{
    public partial class viewWorker : BasePage
    {
        public long totalRows = 0;
        public string FirstName = String.Empty;
        public string LastName = string.Empty;
        public int? CompanyID;
        public Int16? UsedState;
        public DateTime? FromDate;
        public DateTime? ToDate;
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
                Pvn.Utils.LogFile.WriteLogFile("viewWorker", "Page_Load", ex.Message);

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
            HttpCookie mySearch = new HttpCookie("FirstName");
            mySearch = Request.Cookies["FirstName"];
            if (mySearch != null && mySearch.Value != "")
            {
                FirstName = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myLastName = new HttpCookie("LastName");
            myLastName = Request.Cookies["LastName"];
            if (myLastName != null && myLastName.Value != "")
            {
                LastName = Server.UrlDecode((myLastName.Value)).Trim();
            }
            HttpCookie myCompanyID = new HttpCookie("CompanyID");
            myCompanyID = Request.Cookies["CompanyID"];
            if (myCompanyID != null && myCompanyID.Value != "")
            {
                CompanyID = Convert.ToInt32(myCompanyID.Value);
            }
            HttpCookie myFromDate = new HttpCookie("FromDate");
            myFromDate = Request.Cookies["FromDate"];
            if (myFromDate != null && myFromDate.Value != "")
            {
                DateTime date;
                DateTime.TryParseExact(Server.UrlDecode(myFromDate.Value.Trim()), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                if (date.Year > 1)
                {
                    FromDate = date;
                }
            }
            HttpCookie myToDate = new HttpCookie("ToDate");
            myToDate = Request.Cookies["ToDate"];
            if (myToDate != null && myToDate.Value != "")
            {
                DateTime date;
                DateTime.TryParseExact(Server.UrlDecode(myToDate.Value.Trim()), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out date);
                if (date.Year > 1)
                {
                    ToDate = date;
                }
            }
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }

            CMS_WorkerDA objDA = new CMS_WorkerDA();
            DataTable dt;
            dt = objDA.GetSearchPaging(
                        Globals.CurrentLanguage,
                        string.Empty,
                          (CurPage - 1),
                        RowPerPage,
                        out totalRows,
                        FirstName,
                       LastName,
                        FromDate, 
                       ToDate,
                        null,// _isActive,
                       CompanyID,
                        null, //JobTitle
                       UsedState,
                       string.Empty, //ContactDetail
                        null, null, null, null, null
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
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("UsedState");
                rptUsedState.DataSource = dt;
                rptUsedState.DataBind();
                CMS_CompanyDA objCompanyDA = new CMS_CompanyDA();

                rptCompany.DataSource = objCompanyDA.GetAllCompanybyParent(null);
                rptCompany.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewCompany", "BindComboBox", ex.Message);
            }
        }
    }
}
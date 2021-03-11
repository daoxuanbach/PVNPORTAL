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

namespace AdminLTE.Usercontrols.Schedules
{
    public partial class viewSchedules : BasePage
    {
        public int totalRows = 0;
        public string txtSearch = String.Empty;
        public string Description = String.Empty;
        public string FromAddress = String.Empty;
        public DateTime? FromBeginDate;
        public DateTime? ToBeginDate;
        public Int16? UsedState;
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
                Pvn.Utils.LogFile.WriteLogFile("viewSchedules", "Page_Load", ex.Message);

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
            HttpCookie mySearch = new HttpCookie("txtSearch");
            mySearch = Request.Cookies["txtSearch"];
            if (mySearch != null && mySearch.Value != "")
            {
                txtSearch = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myDescription = new HttpCookie("Description");
            myDescription = Request.Cookies["Description"];
            if (myDescription != null && myDescription.Value != "")
            {
                Description = Server.UrlDecode((myDescription.Value)).Trim();
            }
            HttpCookie myFromAddress = new HttpCookie("Description");
            myFromAddress = Request.Cookies["Description"];
            if (myFromAddress != null && myFromAddress.Value != "")
            {
                Description = Server.UrlDecode((myFromAddress.Value)).Trim();
            }
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }

            CMS_SchedulesDA objDA = new CMS_SchedulesDA();
            DataTable dt;

            dt = objDA.GetSearchPaging(
                    Globals.CurrentLanguage,
                    string.Empty,
                    (CurPage - 1),
                    RowPerPage,
                    ref totalRows,
                    txtSearch,
                    Description,
                    FromBeginDate, ToBeginDate,
                    null,//FromEndDate
                    null,//ToEndDate,
                    FromAddress,
                    null,//ToAddress,
                    null, null, null, null
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
                //Sys_ParameterDA objDA = new Sys_ParameterDA();
                //DataTable dt = objDA.GetParameterByName("UsedState");
                //rptUsedState.DataSource = dt;
                //rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }

        public string SubString(object name)
        {
            try
            {
                if (Convert.ToString(name) == "")
                    return "";
                else
                    return Convert.ToString(name).Remove(Convert.ToString(name).Length - 1, 1);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewSchedules", "SubString", ex.Message);
                return Convert.ToString(name);
            }

        }
    }
}
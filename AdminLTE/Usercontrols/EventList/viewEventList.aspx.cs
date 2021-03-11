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

namespace AdminLTE.Usercontrols.EventList
{
    public partial class viewEventList : BasePage
    {
        public long totalRows = 0;
        public string EventName;
        public short? EventType;
        public int cbEstiomae;
        public DateTime? FromBeginDate;
        public DateTime? ToBeginDate;
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
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
            HttpCookie myEventName = new HttpCookie("txtEventName");
            myEventName = Request.Cookies["txtEventName"];
            if (myEventName != null && myEventName.Value != "")
            {
                EventName = Server.UrlDecode((myEventName.Value)).Trim();
            }
            HttpCookie myEventType = new HttpCookie("cboEventType");
            myEventType = Request.Cookies["cboEventType"];
            if (myEventType != null && myEventType.Value != "")
            {
                EventType = Convert.ToInt16(myEventType.Value);
            }
            HttpCookie myEstiomae = new HttpCookie("cboEstiomae");
            myEstiomae = Request.Cookies["cboEstiomae"];
            if (myEstiomae != null && myEstiomae.Value != "")
            {
                cbEstiomae = Convert.ToInt16(myEstiomae.Value);
            }

            HttpCookie myFromDate = new HttpCookie("FromDate");
            myFromDate = Request.Cookies["FromDate"];
            if (myFromDate != null && myFromDate.Value != "")
            {
                DateTime dt;
                DateTime.TryParseExact(myFromDate.Value, "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                if (dt.Year > 1)
                {
                    FromBeginDate = dt;
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
                    ToBeginDate = dt;
                }
            }
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value);
            }


            CMS_EventDA objDA = new CMS_EventDA();
            bool? estimate = null;
            if (cbEstiomae == 1) estimate = true;
            else if (cbEstiomae == 2) estimate = false;
            DataTable data = objDA.GetSearchPaging(
                        Globals.CurrentLanguage,
                        string.Empty,
                       (CurPage - 1),
                        RowPerPage,
                        out totalRows,
                        EventName,
                        false,
                        EventType,
                       FromBeginDate, ToBeginDate, null, null,
                        null, null, null, null, estimate
                        );
            rptDatabind.DataSource = data;
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
                DataTable dt = objDA.GetParameterByName("EventType");
                rptEventType.DataSource = dt;
                rptEventType.DataBind();
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
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

namespace AdminLTE.Usercontrols.Meeting
{
    public partial class viewMeeting : BasePage
    {
        public int totalRows = 0;
        public string Title = String.Empty;
        public string RoomName = string.Empty;
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
                Pvn.Utils.LogFile.WriteLogFile("viewMeeting", "Page_Load", ex.Message);
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
            HttpCookie mySearch = new HttpCookie("Title");
            mySearch = Request.Cookies["Title"];
            if (mySearch != null && mySearch.Value != "")
            {
                Title = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myRoomName = new HttpCookie("RoomName");
            myRoomName = Request.Cookies["RoomName"];
            if (myRoomName != null && myRoomName.Value != "")
            {
                RoomName = Server.UrlDecode((myRoomName.Value)).Trim();
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
            bool? _isActive = null;
            CMS_MeetingDA objDA = new CMS_MeetingDA();
            DataTable dt;
            dt = objDA.GetSearchPaging(
                        Globals.CurrentLanguage,
                        string.Empty,
                        (CurPage - 1),
                        RowPerPage,
                        ref totalRows,
                        FromDate,
                        ToDate,
                        RoomName,
                        null,
                        Title,
                        string.Empty,
                        _isActive,
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
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("MeetingState");
                rptUsedState.DataSource = dt;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
    }
}
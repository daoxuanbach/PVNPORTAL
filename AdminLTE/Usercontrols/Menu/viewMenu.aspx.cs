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

namespace AdminLTE.Usercontrols.Menu
{
    public partial class viewMenu : BasePage
    {
        public int totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Code = String.Empty;
        public string  txtURL = String.Empty;
        public string txtTitle = String.Empty;
        public short? MenuPosition;
        public short? UsedState;
        public string ObjectType;
        public Guid? ParentMenuID = null;
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
                RequestCookiePage();
                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindComboBox();
                    BindData();

                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void RequestCookiePage()
        {
           
            HttpCookie myLanguage = new HttpCookie("Language");
            myLanguage = Request.Cookies["Language"];
            if (myLanguage != null && myLanguage.Value != "")
            {
               Language=  (string)(myLanguage.Value.Trim());
            }
            HttpCookie mytxtCode = new HttpCookie("txtCode");
            mytxtCode = Request.Cookies["txtCode"];
            if (mytxtCode != null && mytxtCode.Value != "")
            {
                Code = Server.UrlDecode(mytxtCode.Value.Trim());
            }
            HttpCookie mytxtTitle = new HttpCookie("txtTitle");
            mytxtTitle = Request.Cookies["txtTitle"];
            if (mytxtTitle != null && mytxtTitle.Value != "")
            {
                txtTitle =Server.UrlDecode(mytxtTitle.Value.Trim());
            }
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value!="")
            {
                UsedState = Convert.ToInt16(myUsedState.Value.Trim());
            }

            HttpCookie mytxtURL = new HttpCookie("txtURL");
            mytxtURL = Request.Cookies["txtURL"];
            if (mytxtURL != null && mytxtURL.Value != "")
            {
                txtURL = Server.UrlDecode(mytxtURL.Value.Trim());
            }
            HttpCookie myMenuPosition = new HttpCookie("MenuPosition");
            myMenuPosition = Request.Cookies["MenuPosition"];
            if (myMenuPosition != null && myMenuPosition.Value != "")
            {
                MenuPosition = Convert.ToInt16(myMenuPosition.Value.Trim());
            }
            HttpCookie myParentMenuID = new HttpCookie("ParentMenuID");
            myParentMenuID = Request.Cookies["ParentMenuID"];
            if (myParentMenuID != null && myParentMenuID.Value != "")
            {
                ParentMenuID =new Guid(myParentMenuID.Value.Trim());
            }
            HttpCookie myObjectType = new HttpCookie("ObjectType");
            myObjectType = Request.Cookies["ObjectType"];
            if (myObjectType != null && myObjectType.Value != "")
            {
                ObjectType = (string)(myObjectType.Value.Trim());
            }
            HttpCookie myFromDate = new HttpCookie("FromDate");
            myFromDate = Request.Cookies["FromDate"];
            if (myFromDate != null && myFromDate.Value != "")
            {
                DateTime dt;
                DateTime.TryParseExact(myFromDate.Value.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
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
                DateTime.TryParseExact(myToDate.Value.Trim(), "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                if (dt.Year > 1)
                {
                    ToDate = dt;
                }

            }
            HttpCookie myCurPage = new HttpCookie("CurPage");
            myCurPage = Request.Cookies["CurPage"];
            if (myCurPage != null && myCurPage.Value != "")
            {
                CurPage = Convert.ToInt32(myCurPage.Value.Trim());
            }
            

        }
        #region RequestUrlPage Khoong su dung
        private void RequestUrlPage()
        {
            if (!string.IsNullOrEmpty(Request["Language"]))
            {
                Language = Request["Language"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["txtCode"]))
            {
                Code = Convert.ToString(Request["txtCode"].Trim());
            }
            if (!string.IsNullOrEmpty(Request["txtTitle"])) //txtTitle
            {
                txtTitle = Request["txtTitle"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["UsedState"]))
            {
                UsedState = Convert.ToInt16(Request["UsedState"]);
            }
            if (!string.IsNullOrEmpty(Request["txtURL"]))
            {
                txtURL = Request["txtURL"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["MenuPosition"]))
            {
                MenuPosition = Convert.ToInt16(Request["MenuPosition"]);
            }
            if (!string.IsNullOrEmpty(Request["ParentMenuID"]))
            {
                ParentMenuID = new Guid(Request["ParentMenuID"].Trim());
            }
            if (!string.IsNullOrEmpty(Request["ObjectType"]))
            {
                ObjectType = Request["ObjectType"];
            }

            if (!string.IsNullOrEmpty(Request["FromDate"]))
            {
                DateTime dt;
                DateTime.TryParseExact(Request["FromDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                if (dt.Year > 1)
                {
                    FromDate = dt;
                }

                //CreatedDateFrom = DateTime.ParseExact(Request["FromDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture); // Convert.ToDateTime(Request["FromDate"].Trim(), dtfi);
            }
            if (!string.IsNullOrEmpty(Request["ToDate"]))
            {
                DateTime dt;
                DateTime.TryParseExact(Request["ToDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
                if (dt.Year > 1)
                {
                    ToDate = dt;
                }

            }
        }
        #endregion RequestUrlPage Khoong su dung
      
        private void BindData()
        {
            //RequestUrlPage()
           
            

            CMS_MenuBL objBL = new CMS_MenuBL();
            string UserID = new Sys_UserBL().GetUserLogin().ToString();
            int userID = Convert.ToInt32(UserID.ToString());

            DataTable category = objBL.GetSearchPaging(
                       Pvn.Utils.Constants.Language.VIETNAMESE,
                        "[Ordinal]",
                         (CurPage - 1),
                        RowPerPage,
                        ref totalRows,
                        Code,//Mã chuyên mục
                        txtTitle,//Tiêu đề chuyên mục
                        string.Empty,//Tóm tắt của chuyên mục
                        UsedState,//Trạng thái sử dụng
                        MenuPosition,//MenuPosition
                        0,//DataAccess,//Trạng thái truy nhập dữ liệu
                        Language,//Ngôn ngữ sử dụng
                        ParentMenuID,//Chuyên mục cha
                        null,//Số thứ tự hiển thị trong chuyên mục cha
                        ObjectType,//ObjectType
                        null,//ObjectID
                        txtURL,//URL
                        string.Empty,//Ảnh hiển thị
                        string.Empty,//Tiêu đề ảnh hiển thị
                        string.Empty,//Note
                        FromDate,//Ngày tạo
                        null,//Người tạo
                        ToDate,//Ngày sửa
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
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();


                DataTable lstNgonNguET = objDA.GetParameterByName("Language");

                rptLanguage.DataSource = lstNgonNguET;
                rptLanguage.DataBind();

                CMS_MenuBL objMenu = new CMS_MenuBL();
                int Position = 0;
                List<CMS_MenuET> lstCMS_MenuET = objMenu.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Language, Position);
                rptParentMenuID.DataSource = lstCMS_MenuET;
                rptParentMenuID.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
    }
}
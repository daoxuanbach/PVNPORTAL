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

namespace AdminLTE.Usercontrols.LoaiLienHe
{
    public partial class viewLoaiLienHe : BasePage
    {
        public long totalRows = 0;
        public string ContactType = String.Empty;
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
                Pvn.Utils.LogFile.WriteLogFile("viewLoaiLienHe", "Page_Load", ex.Message); 
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
            HttpCookie mySearch = new HttpCookie("ContactType");
            mySearch = Request.Cookies["ContactType"];
            if (mySearch != null && mySearch.Value != "")
            {
                ContactType = Server.UrlDecode((mySearch.Value)).Trim();
            }
           
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }
            
            CMS_ContactTypeDA objDA = new CMS_ContactTypeDA();
            DataTable dt;

            dt = objDA.GetSearchPaging(
                Globals.CurrentLanguage,
                "OrderNumber",
                (CurPage - 1),
                RowPerPage,
                out totalRows,
                ContactType,
                (int?)null, //!string.IsNullOrEmpty(OrderNumber.Text.Trim()) ? int.Parse(txtOrderNumber.Text.Trim()) : 
                UsedState,
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
                DataTable dt = objDA.GetParameterByName("UsedState");
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
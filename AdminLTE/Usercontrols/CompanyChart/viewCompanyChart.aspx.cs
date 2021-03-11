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

namespace AdminLTE.Usercontrols.CompanyChart
{
    public partial class viewCompanyChart : BasePage
    {
        public int totalRows = 0;
        public string Name = String.Empty;
        public Int16? UsedState;
        public Int16? CompanyType;

        
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
                Pvn.Utils.LogFile.WriteLogFile("viewCompanyChart", "Page_Load", ex.Message);
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
            HttpCookie mySearch = new HttpCookie("Name");
            mySearch = Request.Cookies["Name"];
            if (mySearch != null && mySearch.Value != "")
            {
                Name = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myCompanyType = new HttpCookie("CompanyType");
            myCompanyType = Request.Cookies["CompanyType"];
            if (myCompanyType != null && myCompanyType.Value != "")
            {
                CompanyType = Convert.ToInt16(myCompanyType.Value);
            }
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }

            CMS_CompanyChartDA objDA = new CMS_CompanyChartDA();
            DataTable dt;

            dt = objDA.GetSearchPaging(
                    Globals.CurrentLanguage,
                    string.Empty,
                    (CurPage - 1),
                     RowPerPage,
                    ref totalRows,
                    Name,
                    CompanyType,
                    UsedState
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
                DataTable dt = objDA.GetParameterByNameLanguage("UsedState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dt;
                rptUsedState.DataBind();

                DataTable dtCompanyType = objDA.GetParameterByNameLanguage("CompanyType",  Pvn.Utils.Constants.Language.VIETNAMESE);
                rptCompanyType.DataSource = dtCompanyType;
                rptCompanyType.DataBind();
                
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewCompanyChart", "BindComboBox", ex.Message);
            }
        }
    }
}
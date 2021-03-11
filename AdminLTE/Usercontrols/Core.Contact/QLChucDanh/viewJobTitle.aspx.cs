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

namespace AdminLTE.Usercontrols.QLChucDanh
{
    public partial class viewJobTitle : BasePage
    {
        public long totalRows = 0;
        public string JobTitle = String.Empty;
        public Int16? UsedState;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                RequestPage();
                Page.Title = "Quản lý hệ thống";
                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                    BindComboBox();
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewJobTitle", "Page_Load", ex.Message);

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
            HttpCookie mySearch = new HttpCookie("JobTitle");
            mySearch = Request.Cookies["JobTitle"];
            if (mySearch != null && mySearch.Value != "")
            {
                JobTitle = Server.UrlDecode((mySearch.Value)).Trim();
            }
           
            HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }
            
            CMS_JobTitleDA objDA = new CMS_JobTitleDA();
            DataTable dt;

            dt = objDA.GetSearchPaging(
                Globals.CurrentLanguage,
                string.Empty,
               (CurPage - 1),
                RowPerPage,
                out totalRows,
                JobTitle,
                 (int?)null,//!string.IsNullOrEmpty(txtOrderNumber.Text.Trim()) ? int.Parse(txtOrderNumber.Text.Trim()) :
                (short?)null,//!string.IsNullOrEmpty(cboCompanyLevel.SelectedValue) ? short.Parse(cboCompanyLevel.SelectedValue) : 
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
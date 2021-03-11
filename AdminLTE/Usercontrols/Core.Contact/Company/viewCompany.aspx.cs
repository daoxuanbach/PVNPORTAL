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

namespace AdminLTE.Usercontrols.Company
{
    public partial class viewCompany : BasePage
    {
        public long totalRows = 0;
        public string CompanyName = String.Empty;
        public string ShortName = string.Empty;
        public int? ParentCompany;
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
                Pvn.Utils.LogFile.WriteLogFile("viewCompany", "Page_Load", ex.Message);
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
            HttpCookie mySearch = new HttpCookie("CompanyName");
            mySearch = Request.Cookies["CompanyName"];
            if (mySearch != null && mySearch.Value != "")
            {
                CompanyName = Server.UrlDecode((mySearch.Value)).Trim();
            }
            HttpCookie myShortName = new HttpCookie("ShortName");
            myShortName = Request.Cookies["ShortName"];
            if (myShortName != null && myShortName.Value != "")
            {
                ShortName = Server.UrlDecode((myShortName.Value)).Trim();
            }
            HttpCookie myParentCompany = new HttpCookie("ParentCompany");
            myParentCompany = Request.Cookies["ParentCompany"];
            if (myParentCompany != null && myParentCompany.Value != "")
            {
                ParentCompany = Convert.ToInt32(myParentCompany.Value);
            }
            
             HttpCookie myUsedState = new HttpCookie("UsedState");
            myUsedState = Request.Cookies["UsedState"];
            if (myUsedState != null && myUsedState.Value != "")
            {
                UsedState = Convert.ToInt16(myUsedState.Value);
            }
            
            CMS_CompanyDA objDA = new CMS_CompanyDA();
            DataTable dt;

            dt = objDA.GetSearchPaging(
                        Globals.CurrentLanguage,
                        string.Empty,
                         (CurPage - 1),
                        RowPerPage,
                        out totalRows,
                        CompanyName,
                        string.Empty,//InternationalName,
                        ShortName,
                        (int?)null, //!string.IsNullOrEmpty(txtOrderNumber.Text.Trim()) ? int.Parse(txtOrderNumber.Text.Trim()) : 
                        ParentCompany,
                        (short?)null,//!string.IsNullOrEmpty(cboCompanyLevel.SelectedValue) ? short.Parse(cboCompanyLevel.SelectedValue) :
                        UsedState,
                        string.Empty,//!string.IsNullOrEmpty(txtContactDetail.Text.Trim()) ? txtContactDetail.Text.Trim() :
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
                CMS_CompanyDA objCompanyDA = new CMS_CompanyDA();
                
                rptParentCompany.DataSource= objCompanyDA.GetAllCompanybyParent(null);
                rptParentCompany.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewCompany", "BindComboBox", ex.Message);
            }
        }
    }
}
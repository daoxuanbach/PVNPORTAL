using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.Company
{
    public partial class fCompany : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public CMS_CompanyET objItemET = new CMS_CompanyET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            BindComboBox();
            if (action.ToUpper() == "edit".ToUpper())
            {
                hidAction.Value = "upd";
                bindingData(ItemID);
            }
        }
        protected void ProcessRequest()
        {
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                action = Request["action"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["ItemID"]))
            {
                ItemID = Request["ItemID"].Trim();
            }
        }
        #region Bidingdata
        private void bindingData(string ItemID)
        {
            CMS_CompanyDA objDA = new CMS_CompanyDA();
            objItemET = objDA.GetInfo(Convert.ToInt32(ItemID));
            CMS_ContactDetailDA objDetailDA = new CMS_ContactDetailDA();
            rptDatabind.DataSource= objDetailDA.GetAll_CMS_ContactDetailByContactbyID(objItemET.CompanyID, 1);
            rptDatabind.DataBind();
        }
        private void BindComboBox()
        {
            try
            {
                CMS_CompanyDA objCompanyDA = new CMS_CompanyDA();
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("UsedState");
                rptUsedState.DataSource = dt;
                rptUsedState.DataBind();

                DataTable dtCompanyLevel = objDA.GetParameterByName("CompanyLevel");
                rptCompanyLevel.DataSource = dtCompanyLevel;
                rptCompanyLevel.DataBind();
                

                rptParentCompany.DataSource= objCompanyDA.GetAllCompanybyParent(null);
                rptParentCompany.DataBind();


                CMS_ContactTypeDA objCTDA = new CMS_ContactTypeDA();
                DataTable table = objCTDA.GetAll_CMS_ContactType();
                rptContactType.DataSource = table;
                rptContactType.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
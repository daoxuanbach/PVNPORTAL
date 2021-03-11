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

namespace AdminLTE.Usercontrols.Worker
{
    public partial class fWorker : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public CMS_WorkerET objItemET = new CMS_WorkerET();
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
            CMS_WorkerDA objDA = new CMS_WorkerDA();
            objItemET = objDA.GetInfo(Convert.ToInt32(ItemID));


            CMS_ContactDetailDA objDetailDA = new CMS_ContactDetailDA();
            rptDatabind.DataSource= objDetailDA.GetAll_CMS_ContactDetailByContactbyID(objItemET.WorkerID, 2);
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
                CMS_JobTitleDA objJob = new CMS_JobTitleDA();
                DataTable dtJobTitle = objJob.GetAll_CMS_JobTitle();
                rptJobTitle.DataSource = dtJobTitle;
                rptJobTitle.DataBind();


                rptCompany.DataSource= objCompanyDA.GetAllCompanybyParent(null);
                rptCompany.DataBind();


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
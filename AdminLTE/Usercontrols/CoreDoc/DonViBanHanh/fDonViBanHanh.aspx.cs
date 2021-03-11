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

namespace AdminLTE.Usercontrols.DonViBanHanh
{
    public partial class fDonViBanHanh : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Doc_DonViBanHanhET objItemET = new Doc_DonViBanHanhET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            BindComboBox();
            if (action.ToUpper() == "edit".ToUpper())
            {
                hidAction.Value = "upd";
                Page.Title = Resources.vi.fSysFunctionEdit;
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
            Guid GuidID = new Guid(ItemID);
            Doc_DonViBanHanhDA objDA = new Doc_DonViBanHanhDA();
            objItemET = objDA.GetInfo(GuidID);
        }

        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
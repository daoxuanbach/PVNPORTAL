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

namespace AdminLTE.Usercontrols.FunctionList
{
    public partial class fFunctionList : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Sys_FunctionET objItemET = new Sys_FunctionET();
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
            Sys_FunctionBL objBL = new Sys_FunctionBL();
            objItemET = objBL.GetInfo(GuidID);
        }

        private void BindComboBox()
        {
            try
            {
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rptNgonNgu.DataSource = lstNgonNguET;
                rptNgonNgu.DataBind();

                Sys_FunctionBL objFunctionBL = new Sys_FunctionBL();
                rptNhomChucNang.DataSource = objFunctionBL.GetAll_Tree_Sys_FunctionByLanguage_UsedState(Pvn.Utils.Constants.Language.VIETNAMESE, 1);
                rptNhomChucNang.DataBind();

                Sys_PageBL objPageBL = new Sys_PageBL();
                rptSysPage.DataSource = objPageBL.GetAll_Sys_Page();
                rptSysPage.DataBind();

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
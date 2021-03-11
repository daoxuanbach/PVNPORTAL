using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysGroup
{
    public partial class fSysGroup : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Sys_GroupET objItemET = new Sys_GroupET();
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
            Sys_GroupBL objBL = new Sys_GroupBL();
            objItemET = objBL.GetInfo(GuidID);
        }

        private void BindComboBox()
        {
            try
            {
                rptRolePermission.DataSource = typeof(EnumET.EnumRole).ToList<int>();
                rptRolePermission.DataBind();
                Sys_UnitBL objUnitBL =new  Sys_UnitBL();
                List<Sys_UnitET> lstsysUnitET= objUnitBL.GetAll_Sys_Unit();

                rptSysUnit.DataSource = lstsysUnitET;
                rptSysUnit.DataBind();


                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();
                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysGroup", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
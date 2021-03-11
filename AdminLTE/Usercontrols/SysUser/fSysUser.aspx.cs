using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysUser
{
    public partial class fSysUser : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Sys_UserET objItemET = new Sys_UserET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
          
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
            Sys_UserBL objBL = new Sys_UserBL();
            objItemET = objBL.GetInfo(ItemID);
        }

        private void BindComboBox()
        {
            try
            {
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();
                System.Data.DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
                Sys_UnitBL objUnitBL =new  Sys_UnitBL();
                List<Sys_UnitET> lstsysUnitET= objUnitBL.GetAll_Sys_Unit();

                rptSysUnit.DataSource = lstsysUnitET;
                rptSysUnit.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUser", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysUnit
{
    public partial class fSysUnit : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Sys_UnitET objItemET = new Sys_UnitET();
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
            Sys_UnitBL objBL = new Sys_UnitBL();
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

                Sys_Group_UnitBL objGroupUnitBL = new Sys_Group_UnitBL();
                List<Sys_Group_UnitET> listGroupUnit=  objGroupUnitBL.GetAll_Sys_Group_Unit();
                rptGroupUnit.DataSource = listGroupUnit;
                rptGroupUnit.DataBind();
                Sys_UnitBL objUnitBL =new  Sys_UnitBL();
                List<Sys_UnitET> lstsysUnitET= objUnitBL.GetAll_Sys_Unit();


                rptParentUnit.DataSource = lstsysUnitET;
                rptParentUnit.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
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
    public partial class ucUserEditSP : BaseUserControls
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            BindComboBox();
        }

        private void BindComboBox()
        {
            try
            {

                Sys_UnitBL objUnitBL = new Sys_UnitBL();
                List<Sys_UnitET> lstsysUnitET = objUnitBL.GetAll_Sys_Unit();

                rptSysUnit.DataSource = lstsysUnitET;
                rptSysUnit.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ucUserEditSP", "BindComboBox", ex.Message);
            }
        }
    }
}
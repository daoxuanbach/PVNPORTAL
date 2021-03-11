using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysGroupUser
{
    public partial class fSysGroupUser : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Guid GroupID = Guid.Empty;
        
        public Sys_GroupET objItemET = new Sys_GroupET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            BindComboBox();
        }
        protected void ProcessRequest()
        {
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                action = Request["action"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["GroupID"]))
            {
                GroupID = new Guid(Request["GroupID"].Trim());
            }
           
        }
        #region Bidingdata
       
        private void BindComboBox()
        {
            try
            {
                Sys_UserBL objUserBL = new Sys_UserBL();
                List<Sys_UserET> lstsysUserET = objUserBL.GetAll_Sys_User();

                rptSysUser.DataSource = lstsysUserET;
                rptSysUser.DataBind();


                Sys_GroupBL objBL = new Sys_GroupBL();
                List<Sys_GroupET> listPageAll = objBL.GetAll_Sys_Group();

                rptGroup.DataSource = listPageAll;
                rptGroup.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysGroup", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
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


namespace AdminLTE.Usercontrols.SysRole
{
    public partial class fSysRole : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string RoleID = string.Empty;
        public SysRoleET objSysRoleET = new SysRoleET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = "Thêm mới";

            bindingCombo();

            switch (action)
            {
                case "edit":
                    hidAction.Value = "upd";
                    bindingData(RoleID);
                    break;
                case "addbytem":
                    hidAction.Value = "add";
                    bindingData(RoleID);
                    break;
                default:
                    break;
            }
            //if (action.ToUpper() == "edit".ToUpper())
            //{
            //    hidAction.Value = "upd";
            //    Page.Title = "Sửa";
            //    bindingData(RoleID);
            //}
        }
        private void bindingCombo()
        {
            Sys_FunctionBL objFnBl = new Sys_FunctionBL();
            DataTable FnData = objFnBl.GetAll_Sys_FunctionByUsedState(1);
            rptFuntion.DataSource = FnData;
            rptFuntion.DataBind();
            rptPosition.DataSource = typeof(Pvn.Utils.EnumET.PositionView).ToList<int>();
            rptPosition.DataBind();

            rptQuyTrinh.DataSource = typeof(Pvn.Utils.EnumET.QuyTrinh).ToList<int>();
            rptQuyTrinh.DataBind();
           
        }
        private void bindingData(string RoleID)
        {
            SysRoleBL objBL = new SysRoleBL();
            objSysRoleET = objBL.GetInfo(Convert.ToInt32(RoleID));
        }
        protected void ProcessRequest()
        {
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                action = Request["action"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["RoleID"]))
            {
                RoleID = Request["RoleID"].Trim();

            }
        }
    }
}
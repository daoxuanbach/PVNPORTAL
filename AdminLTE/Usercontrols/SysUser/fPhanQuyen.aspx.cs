using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysUser
{
    public partial class fPhanQuyen : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string loginName = String.Empty;
        public int UsedState = 1;
        public int UserID;
        public string ListFunction = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Resources.vi.viewSysUnit;
                RequestPage();

                if (!IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void BindData()
        {
             JavaScriptSerializer js = new JavaScriptSerializer();
            if (!string.IsNullOrEmpty(Request["UserName"]))
            {
                UserNameId.Text = Request["UserName"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["UserID"]))
            {
                UserID = Convert.ToInt32(Request["UserID"].Trim());
            }
            SysUserFunctionBL objBL = new SysUserFunctionBL();

            List<SysUserFunctionET> listAll = objBL.GetAll_Function_Tree_ByUserPermission(UserID, Language, UsedState);
            rptDatabind.DataSource = listAll;
            rptDatabind.DataBind();
            ListFunction = js.Serialize(listAll);
        }

        protected void rptDatabind_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string Chucnang = string.Empty;
            SysUserRoleBL objRoleBL = new SysUserRoleBL();
            Literal ltlChucNang = (Literal)e.Item.FindControl("ltlChucNang");
            SysUserFunctionET objFunctionET = (SysUserFunctionET)e.Item.DataItem;
            if (ltlChucNang!=null)
            {
             List<SysUserRoleET> lstCN =   objRoleBL.GetAll_SysUserRole_Where(objFunctionET.FunctionID, UserID);
             foreach (SysUserRoleET item in lstCN)
                {
                    Chucnang += String.Format("<input  class='flat-red' type = 'checkbox' id = 'input-{0}' value='{1};{2}' {3} ><label for= 'input-{4}' > <span class='cslchucnang' >{5}</span></label>", 
                                                    item.RoleID, objFunctionET.FunctionID,item.RoleID, item.CheckGroupRole, item.RoleID, item.Title);
                }
                ltlChucNang.Text = Chucnang;
            }
        }
    }
}
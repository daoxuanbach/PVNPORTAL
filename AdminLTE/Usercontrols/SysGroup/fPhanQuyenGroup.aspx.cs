using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysGroup
{
    public partial class fPhanQuyenGroup : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string loginName = String.Empty;
        public int UsedState = 1;
        public Guid GroupID;
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
            if (!string.IsNullOrEmpty(Request["GroupName"]))
            {
                GroupName.Text = Request["GroupName"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["GroupID"]))
            {
                GroupID = new Guid(Request["GroupID"].Trim());
            }
            SysGroupFunctionBL objBL = new SysGroupFunctionBL();

            List<SysGroupFunctionET> listAll = objBL.GetAllET_SysGroupFunction_By_GroupID(GroupID, Language, UsedState);
            rptDatabind.DataSource = listAll;
            rptDatabind.DataBind();
        }

        protected void rptDatabind_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            string Chucnang = string.Empty;
            SysGroupRoleBL objBL = new SysGroupRoleBL();
            Literal ltlChucNang = (Literal)e.Item.FindControl("ltlChucNang");
            SysGroupFunctionET objFunctionET = (SysGroupFunctionET)e.Item.DataItem;
            if (ltlChucNang != null)
            {
                if (objFunctionET.CheckGroupFunction== "checked")
                {
                    List<SysGroupRoleET> lstCN = objBL.GetAll_SysGroupRole_Where(objFunctionET.FunctionID, GroupID);
                    foreach (SysGroupRoleET item in lstCN)
                    {
                        Chucnang += String.Format("<input  class='flat-red' type = 'checkbox' id = 'input-{0}' value='{1};{2}' {3} ><label for= 'input-{4}' > <span class='cslchucnang' >{5}</span></label>",
                                                    item.RoleID, objFunctionET.FunctionID, item.RoleID, item.CheckGroupRole, item.RoleID, item.Title);
                    }
                    ltlChucNang.Text = Chucnang;
                }
                
              
            }
        }
    }
}
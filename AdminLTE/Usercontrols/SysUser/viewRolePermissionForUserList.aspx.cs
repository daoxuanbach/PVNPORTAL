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
    public partial class viewRolePermissionForUserList : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string loginName = String.Empty;
        public int UsedState = 1;
        public Guid UnitID = Guid.Empty;
        public Sys_UserET objUserET = new Sys_UserET();
        public string jsonList = string.Empty;
        public int   p;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Resources.vi.viewSysUnit;
                RequestPage();
                p = CurPage;
                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                    BindComboBox();
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewRolePermissionForUserList", "Page_Load", ex.Message);
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void BindData()
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            if (!string.IsNullOrEmpty(Request["txtSearch"]))
            {
                KeyWord = Request["txtSearch"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["LoginName"]))
            {
                loginName = Request["LoginName"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["UsedState"]))
            {
                UsedState = Convert.ToInt32(Request["UsedState"].Trim());
            }
            if (!string.IsNullOrEmpty(Request["UnitID"]))
            {
                UnitID = new Guid(Request["UnitID"].Trim());
            }
            Sys_UserBL objBL = new Sys_UserBL();
            string UserID = USERID.ToString();
            List<Sys_UserET> listPageAll = objBL.GetAll_Sys_User_Paging(USERID, KeyWord, loginName, UnitID, UsedState, (CurPage - 1), RowPerPage, out totalRows);
            jsonList = js.Serialize(listPageAll);
            rptDatabind.DataSource = listPageAll;
            rptDatabind.DataBind();
            if (totalRows == 0)
                litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
            else
            {
                var paging = new PagingUtil();
               // litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP, "#");
                litMsg.Text = paging.getHtmlPagingJSCustomAll(Pvn.Utils.Constants.PAGE_STEP, CurPage, RowPerPage, (int)totalRows, "LoadContentPagging",
               string.Format("'/UserControls/SysUser/viewRolePermissionForUserList.aspx?txtSearch={0}&loginName={1}&UnitID={2}&UsedState={3}'", KeyWord, loginName, UnitID, UsedState));
            }
        }
        private void BindComboBox()
        {
            try
            {

                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();
                System.Data.DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();

                Sys_UnitBL objUnitBL = new Sys_UnitBL();
                List<Sys_UnitET> lstsysUnitET = objUnitBL.GetAll_Sys_Unit();

                rpttUnit.DataSource = lstsysUnitET;
                rpttUnit.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }

        protected void rptDatabind_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater rptRolePermission = (Repeater)e.Item.FindControl("rptRolePermission");
            if (rptRolePermission != null)
            {
                rptRolePermission.DataSource = typeof(EnumET.EnumRole).ToList<int>();
                rptRolePermission.DataBind();
            }
        }
    }
}
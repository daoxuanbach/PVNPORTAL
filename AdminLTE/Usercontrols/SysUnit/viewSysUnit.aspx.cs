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

namespace AdminLTE.Usercontrols.SysUnit
{
    public partial class viewSysUnit : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Code = String.Empty;
        public int UsedState = 1;
        public Guid ParentUnitID = Guid.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Resources.vi.viewSysUnit;
                RequestPage();

                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                    BindComboBox();
                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void BindData()
        {

            if (!string.IsNullOrEmpty(Request["txtSearch"]))
            {
                KeyWord = Request["txtSearch"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["Code"]))
            {
                Code = Request["Code"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["Language"]))
            {
                Language = Request["Language"].Trim();
            }

            if (!string.IsNullOrEmpty(Request["ParentUnitID"]))
            {
                ParentUnitID = new Guid(Request["ParentUnitID"].Trim());
            }
            Sys_UnitBL objBL = new Sys_UnitBL();
            string UserID= new Sys_UserBL().GetUserLogin().ToString();
            List<Sys_UnitET> listPageAll = objBL.GetAll_Sys_Unit_Paging(Language, Code, KeyWord, ParentUnitID, true, (CurPage - 1), RowPerPage, out totalRows);
            rptDatabind.DataSource = listPageAll;
            rptDatabind.DataBind();
            if (totalRows == 0)
                litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
            else
            {
                var paging = new PagingUtil();
                //litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP, "#");
                litMsg.Text = paging.getHtmlPagingJSCustomAll(Pvn.Utils.Constants.PAGE_STEP, CurPage, RowPerPage, (int)totalRows, "LoadContentPagging",
               string.Format("'/UserControls/SysUnit/viewSysUnit.aspx?txtSearch={0}&Language={1}&Code={2}&ParentUnitID={3}'", KeyWord, Language, Code, ParentUnitID));
            }
        }
        private void BindComboBox()
        {
            try
            {
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();
                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rptNgonNgu.DataSource = lstNgonNguET;
                rptNgonNgu.DataBind();

                //Sys_UnitBL objFunctionBL = new Sys_UnitBL();
                //rptNhomChucNang.DataSource = objFunctionBL.GetAll_Tree_Sys_FunctionByLanguage_UsedState(Pvn.Utils.Constants.Language.VIETNAMESE, 1);
                //rptNhomChucNang.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
    }
}
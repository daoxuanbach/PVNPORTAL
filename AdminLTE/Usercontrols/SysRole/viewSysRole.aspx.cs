using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pvn.Utils;
using System.Data;

namespace AdminLTE.Usercontrols.SysRole
{
    public partial class viewSysRole : BasePage
    {
        public long totalRows = 0;
        public Guid? FunctionID ;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title =Resources.vi.ViewSysPage;
                RequestPage();

                HttpCookie mySearch = new HttpCookie("txtSearch");
                mySearch = Request.Cookies["txtSearch"];
                if (mySearch != null && mySearch.Value != "")
                {
                    KeyWord = Server.UrlDecode((mySearch.Value));
                }
                if (!string.IsNullOrEmpty(Request["FunctionID"]))
                {
                    FunctionID = new Guid( Request["FunctionID"].Trim());
                }
                Sys_FunctionBL objFnBl = new Sys_FunctionBL();
                DataTable FnData = objFnBl.GetAll_Sys_FunctionByUsedState(1);
                rptFuntion.DataSource = FnData;
                rptFuntion.DataBind();

                //ShowWorkRemind();
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
        private void BindData(){
            SysRoleBL objBL = new SysRoleBL();
            List<SysRoleET> listPageAll = objBL.GetAll_SysRole_Paging(KeyWord, FunctionID, (CurPage-1), RowPerPage, out totalRows);
           rptDatabind.DataSource = listPageAll;
           rptDatabind.DataBind();
           if (totalRows == 0)
               litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
           else
           {
              // var paging = new PagingUtil();
              //// litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP, "#");
              // litMsg.Text = paging.getHtmlPagingJSCustomAll(Pvn.Utils.Constants.PAGE_STEP, CurPage, RowPerPage, (int)totalRows, "LoadContentPagging",
              //string.Format("'/UserControls/SysRole/viewSysRole.aspx?txtSearch={0}&FunctionID={1}'", KeyWord, FunctionID));

                var paging = new PagingUtil();
                litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP);
            }
              
        }
    }
}
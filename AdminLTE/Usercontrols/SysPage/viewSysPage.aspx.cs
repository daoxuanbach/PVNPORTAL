using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Pvn.Utils;
namespace AdminLTE.Usercontrols.SysPage
{
    public partial class viewSysPage : BasePage
    {
        public long totalRows = 0;
        private Guid? FunctionID = Guid.Empty;
        public string ChucNang = string.Empty;
      
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title =Resources.vi.ViewSysPage;
                RequestPage();
                if (!string.IsNullOrEmpty(Request["txtSearch"]))
                {
                    KeyWord = Request["txtSearch"].Trim();
                }
                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewSysPage", "Page_Load", ex.Message);
            }

        }
        private void BindData(){
            Sys_PageBL objBL = new Sys_PageBL();
            List<Sys_PageET> listPageAll = objBL.GetAll_Sys_Paging(KeyWord, null, (CurPage-1), RowPerPage, out totalRows);
           rptDatabind.DataSource = listPageAll;
           rptDatabind.DataBind();
           if (totalRows == 0)
               litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
           else
           {
              // var paging = new PagingUtil();
              //// litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP, "#");

              // litMsg.Text = paging.getHtmlPagingJSCustomAll(Pvn.Utils.Constants.PAGE_STEP, CurPage, RowPerPage, (int)totalRows, "LoadContentPagging",
              //string.Format("'{0}{1}'", "/UserControls/SysPage/viewSysPage.aspx?txtSearch=", KeyWord));

                var paging = new PagingUtil();
                litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP);
            }
              
        }
    }
}
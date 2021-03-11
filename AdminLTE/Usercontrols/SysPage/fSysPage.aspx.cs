using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysPage
{
    public partial class fSysPage : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string PageID = string.Empty;
        public Sys_PageET objPageET = new Sys_PageET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysPageAdd;
           
            if (action.ToUpper()=="edit".ToUpper())
            {
                hidAction.Value = "upd";
                Page.Title = Resources.vi.fSysPageEdit;
                bindingData(PageID);
            }

        }
        private void bindingData(string PageID)
        {
            Guid gPageID = new Guid(PageID);
            Sys_PageBL objBL = new Sys_PageBL();
            objPageET = objBL.GetInfo(gPageID);
        }
        protected void ProcessRequest()
        {
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                action = Request["action"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["PageID"]))
            {
                PageID = Request["PageID"].Trim();

            }
        }
    }
}
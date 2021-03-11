using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysUser
{
    public partial class ResetPassword : BasePage
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public Sys_UserET objItemET = new Sys_UserET();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(Request["ItemID"]))
            {
                ItemID = Request["ItemID"].Trim();
            }
        }
    }
}
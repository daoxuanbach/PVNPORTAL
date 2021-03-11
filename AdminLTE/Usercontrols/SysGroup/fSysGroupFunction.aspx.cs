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
    public partial class fSysGroupFunction : BasePage
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

            DataTable listAll = objBL.GetAll_SysGroupFunction_By_GroupID(GroupID, Language, UsedState);
            rptDatabind.DataSource = listAll;
            rptDatabind.DataBind();
        }
    }
}
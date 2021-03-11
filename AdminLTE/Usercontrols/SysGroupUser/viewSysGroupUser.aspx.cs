using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysGroupUser
{
    public partial class viewSysGroupUser : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public Guid GroupID = Guid.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = Resources.vi.viewSysGroup;
                RequestPage();
                if (!IsPostBack)
                {
                    BindComboBox();
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
            try
            {
                if (!string.IsNullOrEmpty(Request["GroupID"]))
                {
                    GroupID = new Guid(Request["GroupID"].Trim());
                }

                Sys_Group_UserBL objBL = new Sys_Group_UserBL();
                string UserID =  new Sys_UserBL().GetUserLogin().ToString();
                List<Sys_Group_UserET> listPageAll = objBL.GetAll_Sys_Group_User_Paging(GroupID, (CurPage - 1), RowPerPage, out totalRows);
                rptDatabind.DataSource = listPageAll;
                rptDatabind.DataBind();
                if (totalRows == 0)
                    litMsg.Text = Resources.vi.KHONG_CO_DU_LIEU;
                else
                {
                    var paging = new PagingUtil();
                    litMsg.Text = paging.RenderPaged(totalRows, RowPerPage, CurPage, Pvn.Utils.Constants.PAGE_STEP);
                }
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("viewSysGroupUser", "BindData", ex.Message);
            }

        }
        private void BindComboBox()
        {
            try
            {

                Sys_GroupBL objBL = new Sys_GroupBL();

                List<Sys_GroupET> listPageAll = objBL.GetAll_Sys_Group();

                if (string.IsNullOrEmpty(Request["GroupID"]))
                {
                    GroupID = listPageAll.FirstOrDefault().GroupID;
                }
                rptGroup.DataSource = listPageAll;
                rptGroup.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("viewSysGroupUser", "BindComboBox", ex.Message);
            }
        }
    }
}
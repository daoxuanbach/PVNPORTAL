using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.Schedules
{
    public partial class fSchedules : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public CMS_SchedulesET objItemET = new CMS_SchedulesET();
        public string lstManagerIDJSon =string.Empty;
        public long? lanhdao = null;
        public long? chutri = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            BindComboBox();
            if (action.ToUpper() == "edit".ToUpper())
            {
                hidAction.Value = "upd";
                bindingData(ItemID);
            }
        }
        protected void ProcessRequest()
        {
            if (!string.IsNullOrEmpty(Request["action"]))
            {
                action = Request["action"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["ItemID"]))
            {
                ItemID = Request["ItemID"].Trim();
            }
        }
        #region Bidingdata
        private void bindingData(string ItemID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            CMS_SchedulesDA objDA = new CMS_SchedulesDA();
            objItemET = objDA.GetInfo(Convert.ToInt32(ItemID));

            if (objItemET.Active != null) chkActive.Checked = (bool)objItemET.Active;
            if (objItemET.Private != null) chkPrivate.Checked = (bool)objItemET.Private;

            CMS_ScheduleManagerDA objSMDA = new CMS_ScheduleManagerDA();

            DataSet ds= objSMDA.GetManagerbyScheduleID(Convert.ToInt32(ItemID), null);

            DataTable tbIn = new DataTable();
            DataTable tbNotIn = new DataTable();
            tbIn = ds.Tables[1];
            tbNotIn= ds.Tables[0];
            List<string> lstManagerID = new List<string>();
            for (int i = 0; i < tbIn.Rows.Count; i++)
            {
                if (tbIn.Rows[i]["SheduleRole"] != DBNull.Value && Convert.ToInt16(tbIn.Rows[i]["SheduleRole"]) == 1)
                {
                    lanhdao = Convert.ToInt64(tbIn.Rows[i]["ManagerID"]);
                }
                else
                {
                    if (tbIn.Rows[i]["SheduleRole"] != DBNull.Value && Convert.ToInt16(tbIn.Rows[i]["SheduleRole"]) == 2)
                    {
                        chutri = Convert.ToInt64(tbIn.Rows[i]["ManagerID"]);
                    }
                    else
                    {
                        if (tbIn.Rows[i]["ManagerID"] != DBNull.Value)
                        {
                            lstManagerID.Add(Convert.ToString(tbIn.Rows[i]["ManagerID"]));
                        }
                    }
                }
            }
            lstManagerIDJSon = js.Serialize(lstManagerID);
        }

        private void BindComboBox()
        {
            try
            {
                CMS_ListManagerDA objDA = new CMS_ListManagerDA();
                DataTable dt = objDA.GetAll_CMS_ListManager();
                rptLanhDao.DataSource = dt;
                rptLanhDao.DataBind();

                rptChuTri.DataSource = dt;
                rptChuTri.DataBind();

                rptLanhDaoThamGia.DataSource = dt;
                rptLanhDaoThamGia.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSchedules", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
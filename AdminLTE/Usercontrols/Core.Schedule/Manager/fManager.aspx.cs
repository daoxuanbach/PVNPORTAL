using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.Manager
{
    public partial class fManager : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public CMS_ListManagerET objItemET = new CMS_ListManagerET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = "Quản trị hệ thống";
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
            CMS_ListManagerDA objDA = new CMS_ListManagerDA();
            objItemET = objDA.GetInfo(Convert.ToInt32(ItemID));

            //Load Manager
            DataTable dt = objDA.GetAllByManagerID(objItemET.ManagerID);
            chkHDTV.Checked = false;
            chkTGD.Checked = false;
            if (dt != null && dt.Rows.Count > 0)
            {

                for (int j = 0; j < dt.Rows.Count; j++)
                {
                    if (dt.Rows[j]["ManagerType"] != DBNull.Value && Convert.ToInt16(dt.Rows[j]["ManagerType"]) == 1)
                    {
                        chkHDTV.Checked = true;
                        txtTitleHDTV.Text = Convert.ToString(dt.Rows[j]["JobTitleName"]);
                        txtHDTVOrdinal.Text = Convert.ToString(dt.Rows[j]["Ordinal"]);

                    }
                    else if (dt.Rows[j]["ManagerType"] != DBNull.Value && Convert.ToInt16(dt.Rows[j]["ManagerType"]) == 2)
                    {
                        chkTGD.Checked = true;
                        txtTitleTGD.Text = Convert.ToString(dt.Rows[j]["JobTitleName"]);
                        txtTGDOrdinal.Text = Convert.ToString(dt.Rows[j]["Ordinal"]);

                    }
                }

            }
        }

        private void BindComboBox()
        {
            try
            {
                //Sys_ParameterDA objDA = new Sys_ParameterDA();
                //DataTable dt = objDA.GetParameterByName("ManagerType");
                //rptManagerType.DataSource = dt;
                //rptManagerType.DataBind();
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("UsedState");
                rptUsedState.DataSource = dt;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
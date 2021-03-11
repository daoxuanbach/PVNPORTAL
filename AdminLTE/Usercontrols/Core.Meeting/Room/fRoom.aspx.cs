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

namespace AdminLTE.Usercontrols.Room
{
    public partial class fRoom : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public CMS_RoomET objItemET = new CMS_RoomET();
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
            CMS_RoomDA objDA = new CMS_RoomDA();
            objItemET = objDA.GetInfo(Convert.ToInt32(ItemID));
        }

        private void BindComboBox()
        {
            try
            {
                //Sys_ParameterDA objDA = new Sys_ParameterDA();
                //DataTable dt = objDA.GetParameterByName("UsedState");
                //rptUsedState.DataSource = dt;
                //rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fFunctionList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
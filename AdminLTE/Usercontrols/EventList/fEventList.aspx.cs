using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.EventList
{
    public partial class fEventList : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public int UserID;
        
        public CMS_EventET objItemET = new CMS_EventET();
        public string ListCategoryJSon = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            BindComboBox();
            if (action.ToUpper() == "edit".ToUpper())
            {
                Page.Title = Resources.vi.fSysFunctionEdit;
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
            UserID = new Sys_UserBL().GetUserLogin();
        }
        #region Bidingdata
        private void bindingData(string ItemID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            CMS_EventDA objBL = new CMS_EventDA();
            objItemET = objBL.GetInfo(Convert.ToInt32(ItemID));
        }

        private void BindComboBox()
        {
            try
            {

               
                Sys_ParameterDA objDA = new Sys_ParameterDA();
                DataTable dt = objDA.GetParameterByName("EventType");
                rptEventType.DataSource = dt;
                rptEventType.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("NewsList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
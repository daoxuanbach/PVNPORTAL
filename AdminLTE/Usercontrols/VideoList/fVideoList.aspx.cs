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

namespace AdminLTE.Usercontrols.VideoList
{
    public partial class fVideoList : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        private string NgonNgu = Pvn.Utils.Constants.Language.VIETNAMESE;
        public CMS_VideoET objItemET = new CMS_VideoET();
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            Page.Title = Resources.vi.fSysFunctionAdd;
            if (action.ToUpper() == "edit".ToUpper())
            {
                hidAction.Value = "upd";
                Page.Title = Resources.vi.fSysFunctionEdit;
                bindingData(ItemID);
            }
            BindComboBox();
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
            Guid GuidID = new Guid(ItemID);
            CMS_VideoBL objBL = new CMS_VideoBL();
            objItemET = objBL.GetInfo(GuidID);
            NgonNgu = objItemET.Language;
        }

        private void BindComboBox()
        {
            try
            {
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();
                System.Data.DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
             
                Sys_ParameterDA objNNDA = new Sys_ParameterDA();
                DataTable lstNgonNguET = objNNDA.GetParameterByName("Language");
                rptLanguage.DataSource = lstNgonNguET;
                rptLanguage.DataBind();
                CMS_VideoCategoryBL objBL = new CMS_VideoCategoryBL();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Pvn.Utils.Constants.Language.VIETNAMESE);
                rptParentCategoryID.DataSource = category;
                rptParentCategoryID.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Categorylist", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
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

namespace AdminLTE.Usercontrols.ImageList
{
    public partial class fImageList : System.Web.UI.Page
    {
        private string NgonNgu = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public CMS_ImageET objItemET = new CMS_ImageET();
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
            CMS_ImageBL objBL = new CMS_ImageBL();
            objItemET = objBL.GetInfo(GuidID);
            NgonNgu = objItemET.Language;
        }

        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rptLanguage.DataSource = lstNgonNguET;
                rptLanguage.DataBind();
                CMS_ImageCategoryBL objBL = new CMS_ImageCategoryBL();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, NgonNgu);
                rptImageCategoryID.DataSource = category;
                rptImageCategoryID.DataBind();

                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Categorylist", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
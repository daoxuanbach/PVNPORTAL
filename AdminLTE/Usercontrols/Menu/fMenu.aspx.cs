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

namespace AdminLTE.Usercontrols.Menu
{
    public partial class fMenu : System.Web.UI.Page
    {
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string action = string.Empty;
        public string ItemID = string.Empty;
        
        public CMS_MenuET objItemET = new CMS_MenuET();
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
            CMS_MenuBL objBL = new CMS_MenuBL();
            objItemET = objBL.GetInfo(GuidID);
            Language = objItemET.Language;
        }

        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rptLanguage.DataSource = lstNgonNguET;
                rptLanguage.DataBind();
                
                CMS_MenuBL objMenu = new CMS_MenuBL();
                int Position = 0;
                List<CMS_MenuET> lstCMS_MenuET = objMenu.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Language, Position);
                rptParentMenuID.DataSource = lstCMS_MenuET;
                rptParentMenuID.DataBind();


                DataTable dt = objDA.GetParameterByNameLanguage("ObjectType", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptObjectType.DataSource = dt;
                rptObjectType.DataBind();

                DataTable dtMenuPosition = objDA.GetParameterByNameLanguage("MenuPosition", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptMenuPosition.DataSource = dtMenuPosition;
                rptMenuPosition.DataBind();

                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();

                CMS_CategoryBL objBL = new CMS_CategoryBL();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, Language);
                rptParentCategoryID.DataSource = category;
                rptParentCategoryID.DataBind();
                CMS_NewsDA objNewDA = new CMS_NewsDA();
                if (objItemET.ObjectID!=null)
                {
                    DataTable tb = objNewDA.GetAll_CMS_NewsPublichByChuyenMuc(Language, objItemET.ObjectID);
                    rptNewsPublishingID.DataSource = tb;
                    rptNewsPublishingID.DataBind();
                    
                }
                
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Categorylist", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
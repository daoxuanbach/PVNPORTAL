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

namespace AdminLTE.Usercontrols.NewsList
{
    public partial class fNewsList : System.Web.UI.Page
    {
        public string action = string.Empty;
        public string ItemID = string.Empty;
        public string btnUpdateAnd = string.Empty;
        public int UserID;
        private string NgonNgu = Pvn.Utils.Constants.Language.VIETNAMESE;
        public CMS_NewsET objItemET= new CMS_NewsET();
        public string ListCategoryJSon = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            ProcessRequest();
            btnUpdateAnd = Resources.vi.UpdateAndPublishing;
            if (action.ToUpper() == "edit".ToUpper())
            {
               
                Page.Title = Resources.vi.fSysFunctionEdit;
                bindingData(ItemID);
            }
            BindComboBox();

            //Add the Comment to Placeholder
            ucChucNang uctop = LoadControl("~/Usercontrols/ucChucNang.ascx") as ucChucNang;
            if (uctop != null)
            {
                uctop.ViTri = Convert.ToInt16(Pvn.Utils.EnumET.PositionView.Detail);
                plhChucNangTop.Controls.Add(uctop);
            }
            ucChucNang ucBottom = LoadControl("~/Usercontrols/ucChucNang.ascx") as ucChucNang;
            if (ucBottom != null)
            {
                ucBottom.ViTri = Convert.ToInt16(Pvn.Utils.EnumET.PositionView.Detail);
                plhChucNangBottom.Controls.Add(ucBottom);
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
            Guid GuidID = new Guid(ItemID);
            CMS_NewsBL objBL = new CMS_NewsBL();
            objItemET = objBL.GetInfo(GuidID);
            NgonNgu = objItemET.Language;
            btnUpdateAnd = Resources.vi.UpdateUnPublish;
            if (objItemET.NewsState ==(short)Pvn.Utils.Parameter.NewsState.TinDangChoXuatBan)
            {
                btnUpdateAnd = Resources.vi.UpdateAndPublishing;
            }
            ListCategoryJSon = js.Serialize(objItemET.ListCategory);
        }

        private void BindComboBox()
        {
            try
            {
                Pvn.DA.Sys_ParameterDA objDA = new Pvn.DA.Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rptLanguage.DataSource = lstNgonNguET;
                rptLanguage.DataBind();
                //Chuyên mục
                CMS_CategoryDA objBL = new CMS_CategoryDA();
                DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, NgonNgu, null);
                rptCategoryID.DataSource = category;
                rptCategoryID.DataBind();
                //Danh sách chuyên mục
                rptListCategory.DataSource = category;
                rptListCategory.DataBind();
                DataTable dt = objDA.GetParameterByName("PriorityPublishing");
                rptPriorityPublishing.DataSource = dt;
                rptPriorityPublishing.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("NewsList", "BindComboBox", ex.Message);
            }
        }
        #endregion
    }
}
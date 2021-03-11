using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.ImageCategoryList
{
    public partial class viewImageCategoryList : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Code = String.Empty;
        public Int16 UsedState = 1;
        public Guid ParentCategoryID = Guid.Empty;
        public DateTime? CreatedDateFrom;
        public DateTime? CreatedDateTo;
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
        DataTable category = new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                Page.Title = "Quản lý hệ thống";
                RequestPage();
                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                    BindComboBox();
                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }
        private void BindData()
        {
            if (!string.IsNullOrEmpty(Request["Language"]))
            {
                Language = Request["Language"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["UsedState"]))
            {
                UsedState = Convert.ToInt16(Request["UsedState"]);
            }

            CMS_ImageCategoryBL objBL = new CMS_ImageCategoryBL();
            DataTable category = objBL.GetTreeAdmin(Pvn.Utils.Constants.Language.VIETNAMESE, Language, UsedState);
            rptDatabind.DataSource = category;
            rptDatabind.DataBind();

        }
        private void BindComboBox()
        {
            try
            {
                Sys_ParameterDA objDA = new Sys_ParameterDA();

                DataTable lstNgonNguET = objDA.GetParameterByName("Language");
                rpttUnit.DataSource = lstNgonNguET;
                rpttUnit.DataBind();

                DataTable dtUseState = objDA.GetParameterByNameLanguage("UseState", Pvn.Utils.Constants.Language.VIETNAMESE);
                rptUsedState.DataSource = dtUseState;
                rptUsedState.DataBind();
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ImageCategoryList", "BindComboBox", ex.Message);
            }
        }
    }
}
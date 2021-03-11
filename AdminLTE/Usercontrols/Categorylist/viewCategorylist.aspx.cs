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

namespace AdminLTE.Usercontrols.Categorylist
{
    public partial class viewCategorylist : BasePage
    {
        public long totalRows = 0;
        public string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
        public string Code = String.Empty;
        public int UsedState = 0;
        public Guid ?ParentCategoryID ;
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
                Pvn.Utils.LogFile.WriteLogFile("ImageHelper", "ImageHelper", ex.Message);
            }
        }
        private void BindData()
        {
            if (!string.IsNullOrEmpty(Request["Language"]))
            {
                Language = Request["Language"].Trim();
            }
            if (!string.IsNullOrEmpty(Request["ParentCategoryID"])& Request["ParentCategoryID"]!="null")
            {
                ParentCategoryID =new Guid(Request["ParentCategoryID"].Trim());
            }
            CMS_CategoryDA objBL = new CMS_CategoryDA();
            string UserID = new Sys_UserBL().GetUserLogin().ToString();
            int userID = Convert.ToInt32(UserID.ToString());

            DataTable category = objBL.GetTreeAdmin_UsedState(Pvn.Utils.Constants.Language.VIETNAMESE, Language, ParentCategoryID, UsedState);
            rptDatabind.DataSource = category;
            rptDatabind.DataBind();
          
        }
        private void BindComboBox()
        {
            try
            {
               
                Sys_ParameterDA objNNDA = new Sys_ParameterDA();
                DataTable lstNgonNguET = objNNDA.GetParameterByName("Language");

                rpttUnit.DataSource = lstNgonNguET;
                rpttUnit.DataBind();
                CMS_CategoryDA objda = new CMS_CategoryDA();
             
                DataTable category = objda.GetTreeAdmin_UsedState(Pvn.Utils.Constants.Language.VIETNAMESE, Language, null, UsedState);
                rptParentCategoryID.DataSource = category;
                rptParentCategoryID.DataBind();

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("fSysUnit", "BindComboBox", ex.Message);
            }
        }
    }
}
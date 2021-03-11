using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols
{
    public partial class uc_Side_menu : BaseUserControls
    {
        public bool checkradtree = false;
        private Guid FunctionID = Guid.Empty;
        protected void Page_PreInit(object sender, EventArgs e)
        {
            PAGEACCESSLEVEL = 0; //no require login
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
              
                if (Request.QueryString["FunctionID"] != null && !string.IsNullOrEmpty(Request.QueryString["FunctionID"].ToString()))
                {
                    checkradtree = true;
                    FunctionID = new Guid(Request.QueryString["FunctionID"]);
                }
                else
                    checkradtree = false;

                //ShowWorkRemind();
                if (!IsPostBack)
                {
                    BindData();
                }
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
            }
        }

        private void BindData()
        {
            try
            {
                Sys_FunctionBL objBL = new Sys_FunctionBL();
                string UserID = new Sys_UserBL().GetUserLogin().ToString();
                string strMenu = objBL.GetMenuByUser(UserID, Pvn.Utils.Constants.Language.VIETNAMESE, 1, FunctionID);
                ShowMenu.Text = strMenu;
                if (checkradtree == true)
                {

                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("uc_Side_menu", "BindData", ex.Message);
            }
        }

       

    }
}
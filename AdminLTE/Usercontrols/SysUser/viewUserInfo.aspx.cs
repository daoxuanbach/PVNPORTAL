using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols.SysUser
{
    public partial class viewUserInfo : BasePage
    {
        public string action = string.Empty;
        public Sys_UserET objItemET = new Sys_UserET();
        public string FileServerJson;
        public string FileServer;
        public bool checkFile=false;

        protected void Page_PreInit(object sender, EventArgs e)
        {
            PAGEACCESSLEVEL = 1; //no require login
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            bindingData(USERID);
        }
        #region Bidingdata
        private void bindingData(int ItemID)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            Sys_UserBL objBL = new Sys_UserBL();
            objItemET = objBL.GetInfo(ItemID.ToString());

            if (!string.IsNullOrEmpty(objItemET.ImagePath))
            {
                List<FileAttachForm> lstDataFile = new List<FileAttachForm>();
                List<FileAttachForm> ltsFileForm = js.Deserialize<List<FileAttachForm>>(objItemET.ImagePath);
                if (ltsFileForm.Count > 0)
                {
                    FileServer = "/UserControls/Upload/Images/"+ltsFileForm.FirstOrDefault().FileServer;
                    FileServerJson = js.Serialize(ltsFileForm.FirstOrDefault());
                    checkFile = true;
                }

            }
        }
        #endregion
    }
}
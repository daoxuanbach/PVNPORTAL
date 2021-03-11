using Pvn.BL;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Menu
{
    /// <summary>
    /// Summary description for GetParentMenu
    /// </summary>
    public class GetParentMenu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
           string NgonNgu =Pvn.Utils.Constants.Language.VIETNAMESE;
            int Position =0;
            Int32.TryParse(context.Request["Position"], out Position);
            if (!string.IsNullOrEmpty(context.Request["NgonNgu"]))
                NgonNgu = (context.Request["NgonNgu"]);
            string strListMenuParen = "<option value=''>---Chọn---</value>";
           
            CMS_MenuBL objMenu = new CMS_MenuBL();
            List<CMS_MenuET> lstCMS_MenuET = objMenu.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, NgonNgu, Position);
            foreach (var item in lstCMS_MenuET)
            {
                strListMenuParen += string.Format("<option value='{0}'>{1}</option>", item.MenuID, item.Title);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(strListMenuParen);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
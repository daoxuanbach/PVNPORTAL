using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Menu
{
    /// <summary>
    /// Summary description for getChuyenMucByNgonNgu
    /// </summary>
    public class getChuyenMucByNgonNgu : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string NgonNgu = Pvn.Utils.Constants.Language.VIETNAMESE;
            if (!string.IsNullOrEmpty(context.Request["NgonNgu"]))
                NgonNgu = (context.Request["NgonNgu"]);
            string strListMenuParen = "<option value=''>---Chọn---</value>";
            CMS_CategoryBL objBL = new CMS_CategoryBL();
            DataTable category = objBL.GetTree(Pvn.Utils.Constants.Language.VIETNAMESE, NgonNgu);
            for (int i = 0; i < category.Rows.Count; i++)
            {
                DataRow oReader = category.Rows[i];
                strListMenuParen += string.Format("<option value='{0}'>{1}</option>", new Guid(Convert.ToString(oReader["CategoryID"])), Convert.ToString(oReader["IndentedTitle"]));
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
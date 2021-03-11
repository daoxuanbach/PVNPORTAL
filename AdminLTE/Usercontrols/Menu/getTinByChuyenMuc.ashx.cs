using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Menu
{
    /// <summary>
    /// Summary description for getTinByChuyenMuc
    /// </summary>
    public class getTinByChuyenMuc : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            string NgonNgu = Pvn.Utils.Constants.Language.VIETNAMESE;
            Guid? CategoryID;
            if (!string.IsNullOrEmpty(context.Request["NgonNgu"]))
                NgonNgu = (context.Request["NgonNgu"]);
            string strListMenuParen = "<option value=''>---Chọn---</value>";
            CMS_NewsDA objDA = new CMS_NewsDA();
            if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
            {
                CategoryID = new Guid(context.Request["CategoryID"]);
                DataTable tb = objDA.GetAll_CMS_NewsPublichByChuyenMuc(NgonNgu, CategoryID);
                for (int i = 0; i < tb.Rows.Count; i++)
                {
                    DataRow oReader = tb.Rows[i];
                    strListMenuParen += string.Format("<option value='{0}'>{1}</option>", new Guid(Convert.ToString(oReader["NewsPublishingID"])), Convert.ToString(oReader["Title"]));
                }
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
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Pvn.Web.Usercontrols.WebService
{
    /// <summary>
    /// Summary description for GetNewsByCateID
    /// </summary>
    public class GetNewsByCateID : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer js = new JavaScriptSerializer();
            int Top = 10;
            string json = string.Empty;
            Guid CateID;
            if (!string.IsNullOrEmpty(context.Request["CateID"]))
                CateID = new Guid (context.Request["CateID"]);
             if (!string.IsNullOrEmpty(context.Request["Top"]))
                Top = Convert.ToInt32 (context.Request["Top"]);
            CMS_NewsDA objDA = new CMS_NewsDA();
            int totalRows = 0;
            Guid _cate;
            if (Utilities.IsGuid(context.Request["CateID"], out _cate))
            {
                List<CMS_NewsPubET> lst = objDA.get_CMS_News_ByCateID(Pvn.Utils.Constants.Language.VIETNAMESE, 0, Top, ref totalRows, _cate);
                json = js.Serialize(lst);
            }
            context.Response.ContentType = "text/plain";
            context.Response.Write(json);
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
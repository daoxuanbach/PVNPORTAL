using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.SessionState;

namespace Pvn.Utils
{
    public class SessionUtil: IReadOnlySessionState
    {
        public static int USERID
        {
            get
            {
                if (HttpContext.Current.Session["USERID"] != null)
                {
                    return Convert.ToInt32(HttpContext.Current.Session["USERID"].ToString());
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                HttpContext.Current.Session["USERID"] = value;
            }
        }
        public static string USERNAME
        {
            get
            {
                if (HttpContext.Current.Session["USERNAME"] != null)
                {
                    return HttpContext.Current.Session["USERNAME"].ToString();
                }
                else
                {

                    return "";
                }
            }
            set
            {
                HttpContext.Current.Session["USERNAME"] = value;
            }
        }
    }
}

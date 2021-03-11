using Pvn.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Usercontrols
{
    public partial class ClearCache : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServerCache.RemoveAll();
        }
    }
}
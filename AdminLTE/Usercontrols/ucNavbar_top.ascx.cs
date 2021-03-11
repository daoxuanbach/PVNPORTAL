using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AdminLTE.Manage.Usercontrols
{
    public partial class ucNavbar_top : BaseUserControls
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void Page_PreInit(object sender, EventArgs e)
        {
            PAGEACCESSLEVEL = 0; //no require login
        }
    }
}
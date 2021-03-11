using System;
using System.IO;

namespace AdminLTE.Usercontrols.Common.ActionUpload
{
    public partial class DeleteFileImage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Clear();
            //this.Page.Response.ContentType = "application/json";
            if (!string.IsNullOrEmpty(Page.Request.Form["del"]))
            {

                string fileDelete = Server.MapPath("/UserControls/Upload/Avartar/" + Page.Request.Form["del"]);
                if (File.Exists(fileDelete))
                    File.Delete(fileDelete);
                this.Page.Response.Write("{success:true}");
            }
            else
            {
                this.Page.Response.Write("{success:false}");
            }
            this.Response.End();
        }
    }
}
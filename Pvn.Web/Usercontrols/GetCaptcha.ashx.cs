using System;
using System.Web;
using System.Text;
using System.Drawing.Imaging;
using System.Drawing;
using System.Web.SessionState;
using Pvn.Web.Codes;


namespace Pvn.Web.Usercontrols
{
    /// <summary>
    /// Summary description for GetCaptcha
    /// </summary>
    public class GetCaptcha : IHttpHandler, IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            //CommonLib.Common.Info.Instance.Initialize();
            //try
            //{
            HttpApplication app = context.ApplicationInstance;

            context.Response.ContentType = "image/jpeg";
            CaptchaHelper captcha = new CaptchaHelper();
            string str = captcha.DrawNumbers(6);

            string captchaID = CaptchaHelper.SESSION_CAPTCHA;
            //if (app.Request.QueryString["captchaId"] != null)
            //{
            //    captchaID = app.Request.QueryString["captchaId"];
            //}

            //CommonLib.Common.Info.Instance.WriteToLog(string.Format("Catcha\r\nKey={0};Value={1}", captchaID, str));
            if (context.Session[captchaID] == null)
                context.Session.Add(captchaID, str);
            else
            {
                context.Session[captchaID] = str;
            }
            Bitmap bmp = captcha.Result;
            bmp.Save(context.Response.OutputStream, System.Drawing.Imaging.ImageFormat.Jpeg);
            //}
            //catch (Exception ex)
            //{
            //    CommonLib.Common.Info.Instance.WriteToLog(ex);
            //}
        }

        public bool IsReusable
        {
            get
            {
                return true;
            }
        }
    }
}
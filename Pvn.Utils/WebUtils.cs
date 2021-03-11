using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pvn.Utils
{
    public class WebUtils
    {
        public static string[] dayOfWeekVN = { "Chủ nhật", "Thứ hai", "Thứ ba", "Thứ tư", "Thứ năm", "Thứ sáu", "Thứ bảy" };
        public static int[] DaySequeue = { 1, 2, 3, 4, 5, 6, 0 };
        public static bool[] weekendList = { true, false, false, false, false, false, true };
        public const string formatDate = "dd/MM/yyyy";
        public const string formatTime = "HH:mm:ss";
        public const string formatTime_Date = "HH:mm:ss dd/MM/yyyy";
        public const string formatDate_Time_minute = "dd/MM/yyyy HH:mm";
        public static void AttachFile(HttpContext context, byte[] data, string contentType, string attachmentFileName)
        {
            context.Response.ContentType = contentType;
            context.Response.AppendHeader("content-disposition", "attachment; filename=" + attachmentFileName);
            context.Response.BinaryWrite(data);
        }

        public static string GetTimeDescription(DateTime date)
        {
            if (date.Minute != 0) return string.Format("{0} giờ, {1} phút", date.Hour, date.Minute);
            else return string.Format("{0} giờ", date.Hour);
        }
        private static float getInternetExplorerVersion(HttpRequest Request)
        {
            // Returns the version of Internet Explorer or a -1
            // (indicating the use of another browser).
            float rv = -1;
            System.Web.HttpBrowserCapabilities browser = Request.Browser;
            if (browser.Browser == "IE")
                rv = (float)(browser.MajorVersion + browser.MinorVersion);
            return rv;
        }

        public static bool CheckCompatibleBrowser(HttpRequest Request)
        {
            float ver = getInternetExplorerVersion(Request);
            if (ver >= 0.0f) // replace with your check
            {
                return ver >= 7.0f;
            }
            return true;
        }

        /// <summary>
        /// Create script for displaying meeting on big screen
        /// </summary>
        /// <param name="strType"></param>
        /// <param name="intCount"></param>
        /// <param name="intTimeScroll"></param>
        /// <param name="blAutoStart"></param>
        /// <returns></returns>
        public static string CreateScript(string strType, int intCount, int intTimeScroll, bool blAutoStart)
        {
            string strJScript = "<script language='JavaScript'>\n";
            strJScript += "var lth_Rotator_" + strType + "= new CYBERAKT_Rotator();\n";
            strJScript += "lth_Rotator_" + strType + ".GlobalID = 'lth_Rotator_" + strType + "';\n";
            strJScript += "lth_Rotator_" + strType + ".ElementID = 'Rotator_" + strType + "';\n";
            strJScript += "lth_Rotator_" + strType + ".ContainerID = 'Rotator_" + strType + "_SlideContainer';\n";
            strJScript += "lth_Rotator_" + strType + ".ContainerRowID = 'Rotator_" + strType + "_ContainerRow';\n";
            strJScript += "lth_Rotator_" + strType + ".RotationType = 'SmoothScroll';\n"; //ContentScroll, SmoothScroll
            strJScript += "lth_Rotator_" + strType + ".ScrollDirection  = 'up';\n";
            strJScript += "lth_Rotator_" + strType + ".SlidePause  = '" + intTimeScroll.ToString() + "';\n";
            strJScript += "lth_Rotator_" + strType + ".ScrollInterval  = '10';\n";

            if (blAutoStart == true)
            {
                strJScript += "lth_Rotator_" + strType + ".AutoStart  = true;\n";
            }
            else
            {
                strJScript += "lth_Rotator_" + strType + ".AutoStart  = false;\n";
            }

            strJScript += "lth_Rotator_" + strType + ".Slides = new Array();\n";

            for (int i = 0; i < intCount; i++)
            {
                strJScript += "lth_Rotator_" + strType + ".Slides[" + i.ToString() + "] = 'Rotator_" + strType + "_slide_" + i.ToString() + "';\n";
            }

            strJScript += "if (lth_Rotator_" + strType + ".AutoStart)\n";
            strJScript += "rcr_Start(lth_Rotator_" + strType + ");\n";
            strJScript += "</script>\n";

            return strJScript;
        }
    }
}

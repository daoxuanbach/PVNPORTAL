using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using Pvn.Web.Codes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Pvn.Web
{
    public partial class ExportScheduleForManagerWeek : System.Web.UI.Page
    {
        HSSFWorkbook hssfworkbook;
        protected void Page_Load(object sender, EventArgs e)
        {
            Export();
        }
        public void Export()
        {
            ReportLichCongtac report = new ReportLichCongtac();
            DateTime FromDate = DateTime.Now.AddDays(-15);
            DateTime ToDate = DateTime.Now;
            int ManagerID = 0;
            if (!string.IsNullOrEmpty(Context.Request["FromDate"]))
            {
                FromDate = DateTime.ParseExact(Context.Request["FromDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            }
            if (!string.IsNullOrEmpty(Context.Request["ToDate"]))
            {
                ToDate = DateTime.ParseExact(Context.Request["ToDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            }
            if (!string.IsNullOrEmpty(Context.Request["ManagerID"]))
            {
                try
                {
                    ManagerID = Convert.ToInt32(Context.Request["ManagerID"]);
                }
                catch (Exception)
                {

                    ManagerID = 0;
                }
               
            }
            report.ExportWeek(FromDate, ToDate, ManagerID);

        }


    }
}
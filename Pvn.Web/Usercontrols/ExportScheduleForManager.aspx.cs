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
    public partial class ExportScheduleForManager : System.Web.UI.Page
    {
        HSSFWorkbook hssfworkbook;
        protected void Page_Load(object sender, EventArgs e)
        {
            Export();
        }
        public void Export()
        {
            ReportLichCongtac report = new ReportLichCongtac();
            DateTime ReportDate = DateTime.Now;
            if (!string.IsNullOrEmpty(Context.Request["ReportDate"]))
            {
                ReportDate = DateTime.ParseExact(Context.Request["ReportDate"], "dd/MM/yyyy", CultureInfo.InvariantCulture); ;
            }
            report.Export_Day(Context.Response, ReportDate);

        }


    }
}
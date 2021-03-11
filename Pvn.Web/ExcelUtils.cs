using NPOI.HSSF.UserModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pvn.Web
{
    public class ExcelUtils
    {
        public static HSSFWorkbook InitializeWorkbook(string template)
        {
            FileStream file = new FileStream(template, FileMode.Open, FileAccess.Read);

            HSSFWorkbook hssfworkbook = new HSSFWorkbook(file);
            return hssfworkbook;
        }
        public static void WriteToFile(HSSFWorkbook hssfworkbook, string fileName)
        {
            FileStream file = new FileStream(fileName, FileMode.Create);
            hssfworkbook.Write(file);
            file.Close();
        }
        public static MemoryStream GetExcelStream(HSSFWorkbook hssfworkbook)
        {
            MemoryStream file = new MemoryStream();
            hssfworkbook.Write(file);
            return file;
        }
        public static void GenFileDownload(HSSFWorkbook hssfworkbook, string fileName)
        {
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            HttpContext.Current.Response.Clear();

            GetExcelStream(hssfworkbook).WriteTo(HttpContext.Current.Response.OutputStream);
            HttpContext.Current.Response.End();
        }
        public static void GenFileDownload(HttpResponse Response, HSSFWorkbook hssfworkbook, string fileName)
        {
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("Content-Disposition", string.Format("attachment;filename={0}", fileName));
            Response.Clear();
            GetExcelStream(hssfworkbook).WriteTo(Response.OutputStream);
            Response.End();
        }
        public static void GenExcelToDownload(string HTML, string fileName)
        {
            HttpContext.Current.Response.AppendHeader("content-disposition", string.Format("attachment;filename={0}", fileName));
            HttpContext.Current.Response.Charset = "";
            HttpContext.Current.Response.Cache.SetCacheability(HttpCacheability.NoCache);
            HttpContext.Current.Response.ContentType = "application/vnd.ms-excel";
            HttpContext.Current.Response.Write(HTML);
            HttpContext.Current.Response.End();
        }
    }
}

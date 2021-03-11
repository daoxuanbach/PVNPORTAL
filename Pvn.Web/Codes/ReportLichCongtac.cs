using NPOI.HSSF.UserModel;
using NPOI.HSSF.Util;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using NPOI.XSSF.UserModel;
using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;

namespace Pvn.Web.Codes
{
    public class ReportLichCongtac
    {
        HSSFWorkbook hssfworkbook;
       
        public DateTime FromDate
        {
            get;
            private set;
        }

        public DateTime ToDate
        {
            get;
            private set;
        }

        public ReportLichCongtac()
        {
           
        }


        public void Export_Day(HttpResponse Response, DateTime ReportDate)
        {
            ScheduleBL objScheduleBL = new ScheduleBL();
            //SPContext.Current.Web.CurrentUser.ID
            string userid = string.Empty;
            try
            {
                var applicationInfo = new CommonLib.Application.ApplicationInfo();                //userid

                if (applicationInfo != null)
                {
                    userid = applicationInfo.LoginUserUserID;
                }
            }
            catch (Exception ex)
            {
                userid = string.Empty;
            }

            //string fullpathTemp = Context.Server.MapPath(tempURL);
            //using (XLWorkbook wb = new XLWorkbook(fullpathTemp))
            //using (System.IO.MemoryStream stream = new System.IO.MemoryStream())
            loadTemplate("ExportScheduleForManager.xls");   
            #region FomatExcel
            var fontBOLD = hssfworkbook.CreateFont();
            fontBOLD.FontHeightInPoints = 13;
            fontBOLD.FontName = "Times New Roman";
            fontBOLD.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

            var fontNORMAL = hssfworkbook.CreateFont();
            fontNORMAL.FontHeightInPoints = 11;
            fontNORMAL.FontName = "Times New Roman";
            fontNORMAL.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.NORMAL;

            ICellStyle NoneBorderHeader = hssfworkbook.CreateCellStyle();
            NoneBorderHeader.SetFont(fontBOLD);
            NoneBorderHeader.WrapText = true;
            NoneBorderHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            NoneBorderHeader.VerticalAlignment = VerticalAlignment.CENTER;


            ICellStyle NoneBorder = hssfworkbook.CreateCellStyle();
            NoneBorder.SetFont(fontNORMAL);
            NoneBorder.WrapText = true;
            NoneBorder.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            NoneBorder.VerticalAlignment = VerticalAlignment.CENTER;

            ICellStyle blackBorderHeader = hssfworkbook.CreateCellStyle();
            blackBorderHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BottomBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.LeftBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.RightBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.TopBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.SetFont(fontBOLD);
            blackBorderHeader.WrapText = true;
            blackBorderHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;

            ICellStyle blackBorder = hssfworkbook.CreateCellStyle();
            blackBorder.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BottomBorderColor = HSSFColor.BLACK.index;
            blackBorder.LeftBorderColor = HSSFColor.BLACK.index;
            blackBorder.RightBorderColor = HSSFColor.BLACK.index;
            blackBorder.TopBorderColor = HSSFColor.BLACK.index;
            blackBorder.WrapText = true;
            blackBorder.SetFont(fontNORMAL);
            blackBorder.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            blackBorder.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;

            ICellStyle dateTimeFormat = hssfworkbook.CreateCellStyle();
            dateTimeFormat.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BottomBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.LeftBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.RightBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.TopBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            dateTimeFormat.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");

            ICellStyle numberFormat = hssfworkbook.CreateCellStyle();
            numberFormat.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BottomBorderColor = HSSFColor.BLACK.index;
            numberFormat.LeftBorderColor = HSSFColor.BLACK.index;
            numberFormat.RightBorderColor = HSSFColor.BLACK.index;
            numberFormat.TopBorderColor = HSSFColor.BLACK.index;
            numberFormat.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            numberFormat.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
            #endregion fomatExcel
            ISheet sheet0 = hssfworkbook.GetSheetAt(0);
            //sheet0.AddMergedRegion(CellRangeAddress.ValueOf("B1:F1"));

            //sheet0.CreateRow(0).CreateCell(1).SetCellValue("LỊCH HOẠT ĐỘNG CỦA LÃNH ĐẠO TẬP ĐOÀN DẦU KHÍ QUỐC GIA VIỆT NAM ");
            //sheet0.GetRow(0).Height = (short)700;
            //sheet0.GetRow(0).GetCell(1).CellStyle = NoneBorderHeader;

            sheet0.AddMergedRegion(CellRangeAddress.ValueOf("B2:F2"));
            sheet0.CreateRow(1).CreateCell(1).SetCellValue(string.Format("Ngày: {0}", ReportDate.ToString("dd/MM/yyyy")));
            sheet0.GetRow(1).GetCell(1).CellStyle = NoneBorder;
            DataTable dtLichCT = objScheduleBL.GetScheduleForManager(ReportDate, userid);
            if (dtLichCT != null)
            {
                List<ScheduleForManagerET> listScheduleForManagerET = new List<ScheduleForManagerET>();
                listScheduleForManagerET = PaicExtensions.ConvertDataTable<ScheduleForManagerET>(dtLichCT);
                //Số lãnh đạo
                List<long> listManagerID = listScheduleForManagerET.Select(p => p.ManagerID).Distinct().ToList();

                int rowv = 2;
                for (int i = 0; i < listManagerID.Count; i++)
                {
                    List<ScheduleForManagerET> listTem = listScheduleForManagerET.Where(p => p.ManagerID == listManagerID[i]).ToList();
                    if (listTem != null && listTem.Count > 0)
                    {
                        int countManager = listTem.Count();
                        for (int j = 0; j < countManager; j++)
                        {
                            rowv++;
                            sheet0.CreateRow(rowv).CreateCell(1).SetCellValue(listTem[j].STT);
                            sheet0.GetRow(rowv).CreateCell(2).SetCellValue(listTem[j].Name);
                            sheet0.GetRow(rowv).CreateCell(3).SetCellValue(listTem[j].Descriptions);

                            string timestr = "";
                            DateTime BeginDate = Convert.ToDateTime(listTem[j].BeginDate);
                            if (BeginDate.Year == ReportDate.Year && BeginDate.Month == ReportDate.Month && BeginDate.Date == ReportDate.Date)
                                timestr =string.IsNullOrEmpty(listTem[j].Title) ? string.Empty : string.Format("Từ {0}", ((DateTime)listTem[j].BeginDate).ToString("HH:mm"));

                            sheet0.GetRow(rowv).CreateCell(4).SetCellValue(timestr);
                            sheet0.GetRow(rowv).CreateCell(5).SetCellValue(listTem[j].ToAddress);
                            //sheet0.GetRow(rowv).CreateCell(6).SetCellValue(rowv);

                            sheet0.GetRow(rowv).GetCell(1).CellStyle = blackBorder;
                            sheet0.GetRow(rowv).GetCell(2).CellStyle = blackBorder;
                            sheet0.GetRow(rowv).GetCell(3).CellStyle = blackBorder;
                            sheet0.GetRow(rowv).GetCell(4).CellStyle = blackBorder;
                            sheet0.GetRow(rowv).GetCell(5).CellStyle = blackBorder;
                            //sheet0.GetRow(rowv).GetCell(6).CellStyle = blackBorder;
                        }
                        if (countManager > 1)
                        {
                            sheet0.AddMergedRegion(CellRangeAddress.ValueOf("B" + (rowv - countManager + 2) + ":B" + (rowv + 1)));
                            sheet0.AddMergedRegion(CellRangeAddress.ValueOf("C" + (rowv - countManager + 2) + ":C" + (rowv + 1)));
                            //sheet0.GetRow(rowv).CreateCell(7).SetCellValue((rowv - countManager + 2));
                            //sheet0.GetRow(rowv).CreateCell(8).SetCellValue((rowv +1));
                        }

                    }
                }
            }
            try
            {
                string filename = string.Format("Lichhoatdong_ngay_{0}.xls", ReportDate.ToString("dd_MM_yyyy"));
                ExcelUtils.GenFileDownload(Response, hssfworkbook, filename);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ReportLichCongtac", "OnProvisionImage", ex.Message);
            }
        }

        /// <summary>
        /// Export to excel by day
        /// </summary>
        /// <param name="Context"></param>
        public void ExportWeek(DateTime FromDate, DateTime ToDate, int ManagerID)
        {
            ScheduleBL objScheduleBL = new ScheduleBL();
            //SPContext.Current.Web.CurrentUser.ID
            string userid = string.Empty;
            try
            {
                var applicationInfo = new CommonLib.Application.ApplicationInfo();                //userid

                if (applicationInfo != null)
                {
                    userid = applicationInfo.LoginUserUserID;
                }
            }
            catch (Exception ex)
            {
                userid = string.Empty;
            }

            //string fullpathTemp = Context.Server.MapPath(tempURL);
            //using (XLWorkbook wb = new XLWorkbook(fullpathTemp))
            //using (System.IO.MemoryStream stream = new System.IO.MemoryStream())

            loadTemplate("ExportScheduleForManagerWeek.xls");
            #region fomatcell
            var fontBOLD = hssfworkbook.CreateFont();
            fontBOLD.FontHeightInPoints = 13;
            fontBOLD.FontName = "Times New Roman";
            fontBOLD.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.BOLD;

            var fontNORMAL = hssfworkbook.CreateFont();
            fontNORMAL.FontHeightInPoints = 11;
            fontNORMAL.FontName = "Times New Roman";
            fontNORMAL.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.NORMAL;

           
            var fontNORMALColor = hssfworkbook.CreateFont();
            fontNORMALColor.FontHeightInPoints = 11;
            fontNORMALColor.FontName = "Times New Roman";
            fontNORMALColor.Boldweight = (short)NPOI.SS.UserModel.FontBoldWeight.NORMAL;
            fontNORMALColor.Color = HSSFColor.RED.index;

            ICellStyle NoneBorderHeader = hssfworkbook.CreateCellStyle();
            NoneBorderHeader.SetFont(fontBOLD);
            NoneBorderHeader.WrapText = true;
            NoneBorderHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            NoneBorderHeader.VerticalAlignment = VerticalAlignment.CENTER;

           
            ICellStyle NoneBorder = hssfworkbook.CreateCellStyle();
            NoneBorder.SetFont(fontNORMAL);
            NoneBorder.WrapText = true;
            NoneBorder.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            NoneBorder.VerticalAlignment = VerticalAlignment.CENTER;

            ICellStyle blackBorderHeader = hssfworkbook.CreateCellStyle();
            blackBorderHeader.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderHeader.BottomBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.LeftBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.RightBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.TopBorderColor = HSSFColor.BLACK.index;
            blackBorderHeader.SetFont(fontBOLD);
            blackBorderHeader.WrapText = true;
            blackBorderHeader.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;

            ICellStyle blackBorder = hssfworkbook.CreateCellStyle();
            blackBorder.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorder.BottomBorderColor = HSSFColor.BLACK.index;
            blackBorder.LeftBorderColor = HSSFColor.BLACK.index;
            blackBorder.RightBorderColor = HSSFColor.BLACK.index;
            blackBorder.TopBorderColor = HSSFColor.BLACK.index;
            blackBorder.WrapText = true;
            blackBorder.SetFont(fontNORMAL);
            blackBorder.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            blackBorder.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;


            //byte[] rgb = new byte[3] { 192, 0, 0 };
            //XSSFCellStyle HeaderCellStyle1 = (XSSFCellStyle)hssfworkbook.CreateCellStyle();
            //HeaderCellStyle1.SetFillForegroundColor(new XSSFColor(rgb));

            ICellStyle blackBorderColorBlue = hssfworkbook.CreateCellStyle();
            blackBorderColorBlue.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderColorBlue.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderColorBlue.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderColorBlue.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            blackBorderColorBlue.BottomBorderColor = HSSFColor.BLACK.index;
            blackBorderColorBlue.LeftBorderColor = HSSFColor.BLACK.index;
            blackBorderColorBlue.RightBorderColor = HSSFColor.BLACK.index;
            blackBorderColorBlue.TopBorderColor = HSSFColor.BLACK.index;

            blackBorderColorBlue.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.CORNFLOWER_BLUE.index;
            blackBorderColorBlue.FillPattern = FillPatternType.BIG_SPOTS;
            blackBorderColorBlue.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.CORNFLOWER_BLUE.index;

            blackBorderColorBlue.SetFont(fontNORMAL);
            blackBorderColorBlue.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            //blackBorderColorBlue.VerticalAlignment = NPOI.SS.UserModel.VerticalAlignment.CENTER;


            ICellStyle dateTimeFormat = hssfworkbook.CreateCellStyle();
            dateTimeFormat.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            dateTimeFormat.BottomBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.LeftBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.RightBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.TopBorderColor = HSSFColor.BLACK.index;
            dateTimeFormat.Alignment = NPOI.SS.UserModel.HorizontalAlignment.CENTER;
            dateTimeFormat.DataFormat = HSSFDataFormat.GetBuiltinFormat("m/d/yy h:mm");

            ICellStyle numberFormat = hssfworkbook.CreateCellStyle();
            numberFormat.BorderBottom = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BorderLeft = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BorderRight = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BorderTop = NPOI.SS.UserModel.BorderStyle.THIN;
            numberFormat.BottomBorderColor = HSSFColor.BLACK.index;
            numberFormat.LeftBorderColor = HSSFColor.BLACK.index;
            numberFormat.RightBorderColor = HSSFColor.BLACK.index;
            numberFormat.TopBorderColor = HSSFColor.BLACK.index;
            numberFormat.Alignment = NPOI.SS.UserModel.HorizontalAlignment.LEFT;
            numberFormat.DataFormat = HSSFDataFormat.GetBuiltinFormat("0");
            #endregion fomatCell
            ISheet sheet0 = hssfworkbook.GetSheetAt(0);


            //ICellStyle style1 = hssfworkbook.CreateCellStyle();
            //style1.FillForegroundColor = NPOI.HSSF.Util.HSSFColor.YELLOW.index;
            //style1.FillPattern = FillPatternType.LEAST_DOTS;
            //style1.FillBackgroundColor = NPOI.HSSF.Util.HSSFColor.YELLOW.index;
            //sheet0.CreateRow(0).CreateCell(0).CellStyle = style1;
            //YELLOW

            //sheet0.AddMergedRegion(CellRangeAddress.ValueOf("B2:F2"));
            //sheet0.CreateRow(1).CreateCell(1).SetCellValue(string.Format("Ngày: {0}", ToDate.ToString("dd/MM/yyyy")));
            //sheet0.GetRow(1).GetCell(1).CellStyle = NoneBorder;
            List<ScheduleInfo> lstScheduleInfo = objScheduleBL.GetSearchPaging2(ManagerID, FromDate, ToDate, userid);
            int rowv = 1;
            foreach (ScheduleInfo item in lstScheduleInfo)
            {
                rowv++;
                sheet0.CreateRow(rowv).CreateCell(1).SetCellValue(item.Ngay);
                sheet0.GetRow(rowv).CreateCell(5).SetCellValue("");
                sheet0.GetRow(rowv).GetCell(1).CellStyle = blackBorderColorBlue;
                sheet0.GetRow(rowv).GetCell(5).CellStyle = blackBorderColorBlue;
                sheet0.AddMergedRegion(CellRangeAddress.ValueOf("B" + (rowv + 1) + ":F" + (rowv + 1)));
                foreach (ScheduleInfoDetail itemDetail in item.ListScheduleDetail)
                {
                    rowv++;
                    sheet0.CreateRow(rowv).CreateCell(1).SetCellValue(Convert.ToInt32(itemDetail.STT));
                    sheet0.GetRow(rowv).CreateCell(2).SetCellValue(itemDetail.ThoiGianRange);
                    sheet0.GetRow(rowv).CreateCell(3).SetCellValue(itemDetail.NoiDung);
                    sheet0.GetRow(rowv).CreateCell(4).SetCellValue(itemDetail.LanhDao);
                    sheet0.GetRow(rowv).CreateCell(5).SetCellValue(itemDetail.DiaDiem);

                    sheet0.GetRow(rowv).GetCell(1).CellStyle = blackBorder;
                    sheet0.GetRow(rowv).GetCell(2).CellStyle = blackBorder;
                    sheet0.GetRow(rowv).GetCell(3).CellStyle = blackBorder;
                    sheet0.GetRow(rowv).GetCell(4).CellStyle = blackBorder;
                    sheet0.GetRow(rowv).GetCell(5).CellStyle = blackBorder;
                }

            }
            try
            {
                string filename = string.Format("Lichhoatdong_ngay_{0}.xls", ToDate.ToString("dd_MM_yyyy"));
                ExcelUtils.GenFileDownload(hssfworkbook, filename);
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ReportLichCongtac", "OnProvisionImage", ex.Message);
            }
        }
        private void loadTemplate(string tem)
        {
            FileStream file = new FileStream(HttpContext.Current.Server.MapPath("/ReportTemp/" + tem), FileMode.Open, FileAccess.Read);
            hssfworkbook = new HSSFWorkbook(file);
        }
    }
}
using Pvn.DA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.BL
{
    public class DocumentBL
    {
        DocumentDA objDA;
         public DocumentBL()
        {
            objDA = new DocumentDA();
        }
        /// <summary>
        /// Get top latest document
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="numberDocument"></param>
        /// <returns></returns>
        public DataTable GetTop(string currentLanguage, int numberDocument)
        {
            try
            {
                DataTable dt = objDA.GetTop(currentLanguage, numberDocument);

                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        /// <summary>
        /// Get search paging doc_vanban
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="rowsInPage"></param>
        /// <param name="totalRecords"></param>
        /// <param name="language"></param>
        /// <param name="soVanBan"></param>
        /// <param name="trichYeu"></param>
        /// <param name="loaiVanBanID"></param>
        /// <param name="linhVucID"></param>
        /// <param name="donViBanHanhID"></param>
        /// <param name="ngayBanHanhFrom"></param>
        /// <param name="ngayBanHanhTo"></param>
        /// <returns></returns>
        public DataTable GetSearchPaging(int pageIndex, int rowsInPage, ref int totalRecords, string language, string soVanBan, string trichYeu,
            Guid? loaiVanBanID, Guid? linhVucID, Guid? donViBanHanhID, DateTime? ngayBanHanhFrom, DateTime? ngayBanHanhTo)
        {
            try
            {
                DataTable dt = objDA.GetSearchPaging(pageIndex, rowsInPage, ref totalRecords, language, soVanBan, trichYeu,
                loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo);

                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRecords = 0;
                return null;
            }
        }
        public DataTable GetSearchPagingSort(int pageIndex, int rowsInPage, ref int totalRecords, string language, string soVanBan, string trichYeu,
            Guid? loaiVanBanID, Guid? linhVucID, Guid? donViBanHanhID, DateTime? ngayBanHanhFrom, DateTime? ngayBanHanhTo, string OrderByColumn)
        {
            try
            {
                DataTable dt = objDA.GetSearchPagingSort(pageIndex, rowsInPage, ref totalRecords, language, soVanBan, trichYeu,
                loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo,OrderByColumn);

                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRecords = 0;
                return null;
            }
        }
        public DataTable GetDocBaoPagingSort(int pageIndex, int rowsInPage, ref int totalRecords, Guid? loaiVanBanID)
        {
            try
            {
                DataTable dt = objDA.GetDocBaoPagingSort(pageIndex, rowsInPage, ref totalRecords, loaiVanBanID);

                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRecords = 0;
                return null;
            }
        }
        /// <summary>
        /// Get search paging doc_vanban
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="rowsInPage"></param>
        /// <param name="totalRecords"></param>
        /// <param name="language"></param>
        /// <param name="soVanBan"></param>
        /// <param name="trichYeu"></param>
        /// <param name="loaiVanBanID"></param>
        /// <param name="linhVucID"></param>
        /// <param name="donViBanHanhID"></param>
        /// <param name="ngayBanHanhFrom"></param>
        /// <param name="ngayBanHanhTo"></param>
        /// <returns></returns>
        public DataTable GetSearchPagingV3(int pageIndex, int rowsInPage, ref int totalRecords, string language, string soVanBan, string trichYeu,
            string loaiVanBanID, Guid? linhVucID, Guid? donViBanHanhID, DateTime? ngayBanHanhFrom, DateTime? ngayBanHanhTo)
        {
            try
            {
                DataTable dt = objDA.GetSearchPagingV3(pageIndex, rowsInPage, ref  totalRecords, language, soVanBan, trichYeu,
            loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo);

             
                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRecords = 0;
                return null;
            }
        }
        /// <summary>
        /// Get search paging doc_vanban
        /// </summary>
        /// <param name="pageIndex"></param>
        /// <param name="rowsInPage"></param>
        /// <param name="totalRecords"></param>
        /// <param name="language"></param>
        /// <param name="soVanBan"></param>
        /// <param name="trichYeu"></param>
        /// <param name="loaiVanBanID"></param>
        /// <param name="linhVucID"></param>
        /// <param name="donViBanHanhID"></param>
        /// <param name="ngayBanHanhFrom"></param>
        /// <param name="ngayBanHanhTo"></param>
        /// <returns></returns>
        public DataTable GetSearchPagingV2(int pageIndex, int rowsInPage, ref int totalRecords, string language, string soVanBan, string trichYeu,
            string loaiVanBanID, Guid? linhVucID, Guid? donViBanHanhID, DateTime? ngayBanHanhFrom, DateTime? ngayBanHanhTo)
        {
            try
            {
                DataTable dt = objDA.GetSearchPagingV2(pageIndex, rowsInPage, ref totalRecords, language, soVanBan, trichYeu,
                loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }

                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                totalRecords = 0;
                return null;
            }
        }
        /// <summary>
        /// Get loai van ban and don vi ban hanh
        /// </summary>
        /// <returns></returns>
        public DataSet GetLoaiVanBanAndDonViBanHanh()
        {
            try
            {
                DataSet ds = objDA.GetLoaiVanBanAndDonViBanHanh();
                return ds;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

    }
}

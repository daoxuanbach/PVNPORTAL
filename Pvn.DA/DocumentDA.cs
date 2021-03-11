using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
   public class DocumentDA: Pvn.DA.DataProvider
    {
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
                DataTable dt = GetTableByProcedure("sp_Presentation_Doc_VanBan_GetTop",
                     currentLanguage
                    , numberDocument);

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetTop", ex.Message);      

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
                DataTable dt = GetTableByProcedure("sp_Presentation_Doc_VanBan_GetPagingV3",
                     pageIndex, rowsInPage, language, soVanBan, trichYeu, loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetSearchPagingV3", ex.Message);      

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
                DataTable dt = GetTableByProcedure("sp_Presentation_Doc_VanBan_GetPagingV2",
                     pageIndex, rowsInPage, language, soVanBan, trichYeu, loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetSearchPagingV2", ex.Message);      

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
                DataSet ds = GetDatasetByProcedure("sp_Presenation_GetLVB_DVBH");
                return ds;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetLoaiVanBanAndDonViBanHanh", ex.Message);      

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
                DataTable dt = GetTableByProcedure("sp_Presentation_Doc_VanBan_GetPaging",
                     pageIndex, rowsInPage, language, soVanBan, trichYeu, loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetSearchPaging", ex.Message);
                totalRecords = 0;
                return null;
            }
        }
        public DataTable GetSearchPagingSort(int pageIndex, int rowsInPage, ref int totalRecords, string language, string soVanBan, string trichYeu,
             Guid? loaiVanBanID, Guid? linhVucID, Guid? donViBanHanhID, DateTime? ngayBanHanhFrom, DateTime? ngayBanHanhTo, string OrderByColumn)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Doc_VanBan_GetPaging_Sort",
                     pageIndex, rowsInPage, language, soVanBan, trichYeu, loaiVanBanID, linhVucID, donViBanHanhID, ngayBanHanhFrom, ngayBanHanhTo, OrderByColumn);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetSearchPaging", ex.Message);
                totalRecords = 0;
                return null;
            }
        }
        public DataTable GetDocBaoPagingSort(int pageIndex, int rowsInPage, ref int totalRecords,Guid? loaiVanBanID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_DocBao_GetPaging_Sort", pageIndex, rowsInPage, loaiVanBanID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }

                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("DocumentDA", "GetSearchPaging", ex.Message);
                totalRecords = 0;
                return null;
            }
        }
       
    }
}

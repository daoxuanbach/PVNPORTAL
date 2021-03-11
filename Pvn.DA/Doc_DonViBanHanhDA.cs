using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pvn.Entity;
using Pvn.Utils;

namespace Pvn.DA
{
    public class Doc_DonViBanHanhDA : Pvn.DA.DataProvider
    {
        
        ///<summary>
		///Hàm set giá trị cho Entity
		///</summary>
		///<param name="oReader">Item cần set giá trị</param>
		///<returns>Entity</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		11/04/2017		Tạo mới
		///</Modified>
		private Doc_DonViBanHanhET setProperties(DataRow oReader)
        {
            try
            {
                Doc_DonViBanHanhET objDoc_DonViBanHanhET = new Doc_DonViBanHanhET();
                if (oReader["DonViBanHanhID"] != DBNull.Value)
                    objDoc_DonViBanHanhET.DonViBanHanhID = new Guid(Convert.ToString(oReader["DonViBanHanhID"]));
                if (oReader["NgonNgu"] != DBNull.Value)
                    objDoc_DonViBanHanhET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                if (oReader["Ma"] != DBNull.Value)
                    objDoc_DonViBanHanhET.Ma = Convert.ToString(oReader["Ma"]);
                if (oReader["Ten"] != DBNull.Value)
                    objDoc_DonViBanHanhET.Ten = Convert.ToString(oReader["Ten"]);
                if (oReader["TenVietTat"] != DBNull.Value)
                    objDoc_DonViBanHanhET.TenVietTat = Convert.ToString(oReader["TenVietTat"]);
                if (oReader["TenTiengAnh"] != DBNull.Value)
                    objDoc_DonViBanHanhET.TenTiengAnh = Convert.ToString(oReader["TenTiengAnh"]);
                if (oReader["TrangThaiSuDung"] != DBNull.Value)
                    objDoc_DonViBanHanhET.TrangThaiSuDung = Convert.ToInt32(oReader["TrangThaiSuDung"]);
                if (oReader["GhiChu"] != DBNull.Value)
                    objDoc_DonViBanHanhET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                if (oReader["NgayTao"] != DBNull.Value)
                    objDoc_DonViBanHanhET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objDoc_DonViBanHanhET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["NgaySua"] != DBNull.Value)
                    objDoc_DonViBanHanhET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objDoc_DonViBanHanhET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["DonViBanHanhGroup"] != DBNull.Value)
                    objDoc_DonViBanHanhET.DonViBanHanhGroup = Convert.ToInt32(oReader["DonViBanHanhGroup"]);
                return objDoc_DonViBanHanhET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", "setProperties", ex.Message);
                throw ex;
            }
        }

        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Doc_DonViBanHanhET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		11/04/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(Doc_DonViBanHanhET objDoc_DonViBanHanhET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_Doc_DonViBanHanh"
                        , objDoc_DonViBanHanhET.DonViBanHanhID
                        , objDoc_DonViBanHanhET.NgonNgu
                        , objDoc_DonViBanHanhET.Ma
                        , objDoc_DonViBanHanhET.Ten
                        , objDoc_DonViBanHanhET.TenVietTat
                        , objDoc_DonViBanHanhET.TenTiengAnh
                        , objDoc_DonViBanHanhET.TrangThaiSuDung
                        , objDoc_DonViBanHanhET.GhiChu
                        , objDoc_DonViBanHanhET.NgayTao
                        , objDoc_DonViBanHanhET.CreatedBy
                        , objDoc_DonViBanHanhET.NgaySua
                        , objDoc_DonViBanHanhET.ModifiedBy
                        , objDoc_DonViBanHanhET.DonViBanHanhGroup
                 ))
                {
                    if (oReader.Read())
                        if (oReader[0] != DBNull.Value)
                        {
                            objMsg.Error = true;
                            objMsg.Message = Convert.ToString(oReader[0]);
                        }
                }
                return objMsg;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", " GetLoaiVanBanAndDonViBanHanh", ex.Message);
                return null;
            }
        }

        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Doc_DonViBanHanhET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		11/04/2017Tạo mới
        ///</Modified>
        public bool Insert(Doc_DonViBanHanhET objDoc_DonViBanHanhET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Doc_DonViBanHanh", "DonViBanHanhID"
                         , objDoc_DonViBanHanhET.NgonNgu
                         , objDoc_DonViBanHanhET.Ma
                         , objDoc_DonViBanHanhET.Ten
                         , objDoc_DonViBanHanhET.TenVietTat
                         , objDoc_DonViBanHanhET.TenTiengAnh
                         , objDoc_DonViBanHanhET.TrangThaiSuDung
                         , objDoc_DonViBanHanhET.GhiChu
                         , objDoc_DonViBanHanhET.NgayTao
                         , objDoc_DonViBanHanhET.CreatedBy
                         , objDoc_DonViBanHanhET.NgaySua
                         , objDoc_DonViBanHanhET.ModifiedBy
                         , objDoc_DonViBanHanhET.DonViBanHanhGroup
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_DonViBanHanhET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		11/04/2017		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_Doc_DonViBanHanh", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_DonViBanHanhET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		11/04/2017		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Doc_DonViBanHanh", GuidID))
                {
                    if (oReader.Read())
                        if (oReader[0] != DBNull.Value)
                        {
                            objMsg.Error = true;
                            objMsg.Message = Convert.ToString(oReader[0]);
                        }
                }
                return objMsg;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }

        ///<summary>
        ///Hàm trả về đối tượng Entity
        ///</summary>
        ///<param name="intItemID">ID</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		11/04/2017Tạo mới
        ///</Modified>
        public Doc_DonViBanHanhET GetInfo(Guid intItemID)
        {
            try
            {
                Doc_DonViBanHanhET objDoc_DonViBanHanhET = new Doc_DonViBanHanhET();
                DataTable tblDoc_DonViBanHanhET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Doc_DonViBanHanh", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["DonViBanHanhID"] != DBNull.Value)
                            objDoc_DonViBanHanhET.DonViBanHanhID = new Guid(Convert.ToString(oReader["DonViBanHanhID"]));
                        if (oReader["NgonNgu"] != DBNull.Value)
                            objDoc_DonViBanHanhET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                        if (oReader["Ma"] != DBNull.Value)
                            objDoc_DonViBanHanhET.Ma = Convert.ToString(oReader["Ma"]);
                        if (oReader["Ten"] != DBNull.Value)
                            objDoc_DonViBanHanhET.Ten = Convert.ToString(oReader["Ten"]);
                        if (oReader["TenVietTat"] != DBNull.Value)
                            objDoc_DonViBanHanhET.TenVietTat = Convert.ToString(oReader["TenVietTat"]);
                        if (oReader["TenTiengAnh"] != DBNull.Value)
                            objDoc_DonViBanHanhET.TenTiengAnh = Convert.ToString(oReader["TenTiengAnh"]);
                        if (oReader["TrangThaiSuDung"] != DBNull.Value)
                            objDoc_DonViBanHanhET.TrangThaiSuDung = Convert.ToInt32(oReader["TrangThaiSuDung"]);
                        if (oReader["GhiChu"] != DBNull.Value)
                            objDoc_DonViBanHanhET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                        if (oReader["NgayTao"] != DBNull.Value)
                            objDoc_DonViBanHanhET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objDoc_DonViBanHanhET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["NgaySua"] != DBNull.Value)
                            objDoc_DonViBanHanhET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objDoc_DonViBanHanhET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["DonViBanHanhGroup"] != DBNull.Value)
                            objDoc_DonViBanHanhET.DonViBanHanhGroup = Convert.ToInt32(oReader["DonViBanHanhGroup"]);
                        return objDoc_DonViBanHanhET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Search + Paging + Sort 
        /// </summary>
        /// <param name="currentLanguage">"vi-VN"</param>
        /// <param name="orderByColumn">
        ///  "[CreatedDate]" 
        ///  "[CreatedDate] DESC" 
        ///</param>
        /// <param name="pageIndex">0</param>
        /// <param name="rowsInPage">20</param>
        /// <param name="totalRows"></param>
        /// <example>
        /// GetSearchPaging("vi-VN",0,20,ref totalRows, "[CreatedDate] DESC");
        /// </example>     
        /// <returns>DataTable + TotalRows</returns>
        public DataTable GetSearchPaging(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows)
        {
            try
            {
                return GetSearchPaging(
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    out totalRows,
                    string.Empty,//NgonNgu
                    string.Empty,//Ma
                    string.Empty,//Ten
                    string.Empty,//TenVietTat
                    string.Empty,//TenTiengAnh
                    null,//TrangThaiSuDung
                    string.Empty,//GhiChu
                    null,//NgayTao
                    string.Empty,//CreatedBy
                    null,//NgaySua
                    string.Empty,
                    null);

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_MenuDA", "setProperties", ex.Message);
                totalRows = 0;
                return null;
            }
        }

        public Doc_DonViBanHanhET GetItemByPK(Guid guidID)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Search + Paging + Sort 
        /// </summary>
        /// <param name="currentLanguage">"vi-VN"</param>
        /// <param name="orderByColumn">
        ///  "[CreatedDate]" 
        ///  "[CreatedDate] DESC" 
        ///</param>
        /// <param name="pageIndex">0</param>
        /// <param name="rowsInPage">20</param>
        /// <param name="totalRows"></param>        
        /// <param name="ngonNgu"> NgonNgu</param>
        /// <param name="ma"> Ma</param>
        /// <param name="ten"> Ten</param>
        /// <param name="tenVietTat"> TenVietTat</param>
        /// <param name="tenTiengAnh"> TenTiengAnh</param>
        /// <param name="trangThaiSuDung"> TrangThaiSuDung</param>
        /// <param name="ghiChu"> GhiChu</param>
        /// <param name="ngayTao"> NgayTao</param>
        /// <param name="createdBy"> CreatedBy</param>
        /// <param name="ngaySua"> NgaySua</param>
        /// <param name="modifiedBy"> ModifiedBy</param>
        /// <returns>DataTable + TotalRows</returns>
        public DataTable GetSearchPaging(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    string ngonNgu,
                    string ma,
                    string ten,
                    string tenVietTat,
                    string tenTiengAnh,
                    short? trangThaiSuDung,
                    string ghiChu,
                    DateTime? ngayTao,
                    string createdBy,
                    DateTime? ngaySua,
                    string modifiedBy,
                    short? donViBanHanhGroup)
        {
            DataTable dt;
            try
            {
                totalRows = 0;
                dt = GetTableByProcedure("sp_Doc_DonViBanHanh_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    ngonNgu,
                    ma,
                    ten,
                    tenVietTat,
                    tenTiengAnh,
                    trangThaiSuDung,
                    ghiChu,
                    ngayTao,
                    createdBy,
                    ngaySua,
                    modifiedBy,
                    donViBanHanhGroup);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = Convert.ToInt64(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", "GetSearchPaging", ex.Message);
                totalRows = 0;
                return null;
            }
        }


        public DataTable GetAllData()
        {
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_GetAll_Doc_DonViBanHanh");
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", "GetAllData", ex.Message);
                return null;
            }
        }

    }
}

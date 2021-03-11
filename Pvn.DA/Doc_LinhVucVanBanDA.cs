using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class Doc_LinhVucVanBanDA : Pvn.DA.DataProvider
    {
        ///<summary>
		///Hàm set giá trị cho Entity
		///</summary>
		///<param name="oReader">Item cần set giá trị</param>
		///<returns>Entity</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		12/04/2017		Tạo mới
		///</Modified>
		private Doc_LinhVucVanBanET setProperties(DataRow oReader)
        {
            try
            {
                Doc_LinhVucVanBanET objDoc_LinhVucVanBanET = new Doc_LinhVucVanBanET();
                if (oReader["LinhVucID"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.LinhVucID = new Guid(Convert.ToString(oReader["LinhVucID"]));
                if (oReader["NgonNgu"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                if (oReader["Ma"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.Ma = Convert.ToString(oReader["Ma"]);
                if (oReader["Ten"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.Ten = Convert.ToString(oReader["Ten"]);
                if (oReader["TenTiengAnh"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.TenTiengAnh = Convert.ToString(oReader["TenTiengAnh"]);
                if (oReader["TrangThaiSuDung"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.TrangThaiSuDung = Convert.ToInt32(oReader["TrangThaiSuDung"]);
                if (oReader["GhiChu"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                if (oReader["NgayTao"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["NgaySua"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objDoc_LinhVucVanBanET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                return objDoc_LinhVucVanBanET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucVanBanDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        ///<summary>
		///Hàm trả về đối tượng Entity
		///</summary>
		///<param name="intItemID">ID</param>
		///<returns>Entity</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		12/04/2017Tạo mới
		///</Modified>
		public Doc_LinhVucVanBanET GetInfo(Guid intItemID)
        {
            try
            {
                Doc_LinhVucVanBanET objDoc_LinhVucVanBanET = new Doc_LinhVucVanBanET();
                DataTable tblDoc_LinhVucVanBanET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Doc_LinhVuc", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["LinhVucID"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.LinhVucID = new Guid(Convert.ToString(oReader["LinhVucID"]));
                        if (oReader["NgonNgu"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                        if (oReader["Ma"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.Ma = Convert.ToString(oReader["Ma"]);
                        if (oReader["Ten"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.Ten = Convert.ToString(oReader["Ten"]);
                        if (oReader["TenTiengAnh"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.TenTiengAnh = Convert.ToString(oReader["TenTiengAnh"]);
                        if (oReader["TrangThaiSuDung"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.TrangThaiSuDung = Convert.ToInt32(oReader["TrangThaiSuDung"]);
                        if (oReader["GhiChu"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                        if (oReader["NgayTao"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["NgaySua"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objDoc_LinhVucVanBanET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        return objDoc_LinhVucVanBanET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucVanBanDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="Doc_LinhVucVanBanET">Entity</param>
		///<returns>MessageUtil</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		12/04/2017Tạo mới
		///</Modified>
		public MessageUtil Update(Doc_LinhVucVanBanET objDoc_LinhVucVanBanET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_Doc_LinhVuc"
                        , objDoc_LinhVucVanBanET.LinhVucID
                        , objDoc_LinhVucVanBanET.NgonNgu
                        , objDoc_LinhVucVanBanET.Ma
                        , objDoc_LinhVucVanBanET.Ten
                        , objDoc_LinhVucVanBanET.TenTiengAnh
                        , objDoc_LinhVucVanBanET.TrangThaiSuDung
                        , objDoc_LinhVucVanBanET.GhiChu
                        , objDoc_LinhVucVanBanET.NgayTao
                        , objDoc_LinhVucVanBanET.CreatedBy
                        , objDoc_LinhVucVanBanET.NgaySua
                        , objDoc_LinhVucVanBanET.ModifiedBy
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucVanBanDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Doc_LinhVucVanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017Tạo mới
        ///</Modified>
        public bool Insert(Doc_LinhVucVanBanET objDoc_LinhVucVanBanET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Doc_LinhVuc", "LinhVucID"
                         , objDoc_LinhVucVanBanET.NgonNgu
                         , objDoc_LinhVucVanBanET.Ma
                         , objDoc_LinhVucVanBanET.Ten
                         , objDoc_LinhVucVanBanET.TenTiengAnh
                         , objDoc_LinhVucVanBanET.TrangThaiSuDung
                         , objDoc_LinhVucVanBanET.GhiChu
                         , objDoc_LinhVucVanBanET.NgayTao
                         , objDoc_LinhVucVanBanET.CreatedBy
                         , objDoc_LinhVucVanBanET.NgaySua
                         , objDoc_LinhVucVanBanET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucVanBanDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_LinhVucVanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_Doc_LinhVuc", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucVanBanDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_LinhVucVanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Doc_LinhVuc", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucVanBanDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
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
                    string.Empty,//TenTiengAnh
                    null,//TrangThaiSuDung
                    string.Empty,//GhiChu
                    null,//NgayTao
                    string.Empty,//CreatedBy
                    null,//NgaySua
                    string.Empty);

            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LinhVucDA", "setProperties", ex.Message);

                totalRows = 0;
                return null;
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
        /// <param name="ngonNgu"> NgonNgu</param>
        /// <param name="ma"> Ma</param>
        /// <param name="ten"> Ten</param>
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
                    string tenTiengAnh,
                    short? trangThaiSuDung,
                    string ghiChu,
                    DateTime? ngayTao,
                    string createdBy,
                    DateTime? ngaySua,
                    string modifiedBy)
        {
            DataTable dt;
            totalRows = 0;
            try
            {

                dt = GetTableByProcedure("sp_Doc_LinhVuc_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    ngonNgu,
                    ma,
                    ten,
                    tenTiengAnh,
                    trangThaiSuDung,
                    ghiChu,
                    ngayTao,
                    createdBy,
                    ngaySua,
                    modifiedBy);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", "setProperties", ex.Message);
                totalRows = 0;
                return null;
            }
        }

        public DataTable GetAllData()
        {
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_GetAll_Doc_LinhVuc");
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_DonViBanHanhDA", "setProperties", ex.Message);
                return null;
            }
        }
    }
}

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
    public class Doc_LoaiVanBanDA : Pvn.DA.DataProvider
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
		private Doc_LoaiVanBanET setProperties(DataRow oReader)
        {
            try
            {
                Doc_LoaiVanBanET objDoc_LoaiVanBanET = new Doc_LoaiVanBanET();
                if (oReader["LoaiVanBanID"] != DBNull.Value)
                    objDoc_LoaiVanBanET.LoaiVanBanID = new Guid(Convert.ToString(oReader["LoaiVanBanID"]));
                if (oReader["LoaiVanBanChaID"] != DBNull.Value)
                    objDoc_LoaiVanBanET.LoaiVanBanChaID = new Guid(Convert.ToString(oReader["LoaiVanBanChaID"]));
                if (oReader["NgonNgu"] != DBNull.Value)
                    objDoc_LoaiVanBanET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                if (oReader["Ma"] != DBNull.Value)
                    objDoc_LoaiVanBanET.Ma = Convert.ToString(oReader["Ma"]);
                if (oReader["Ten"] != DBNull.Value)
                    objDoc_LoaiVanBanET.Ten = Convert.ToString(oReader["Ten"]);
                if (oReader["TenTiengAnh"] != DBNull.Value)
                    objDoc_LoaiVanBanET.TenTiengAnh = Convert.ToString(oReader["TenTiengAnh"]);
                if (oReader["LoaiVanBanChiTiet"] != DBNull.Value)
                    objDoc_LoaiVanBanET.LoaiVanBanChiTiet = Convert.ToInt32(oReader["LoaiVanBanChiTiet"]);
                if (oReader["TrangThaiSuDung"] != DBNull.Value)
                    objDoc_LoaiVanBanET.TrangThaiSuDung = Convert.ToInt32(oReader["TrangThaiSuDung"]);
                if (oReader["ThuTu"] != DBNull.Value)
                    objDoc_LoaiVanBanET.ThuTu = Convert.ToInt32(oReader["ThuTu"]);
                if (oReader["GhiChu"] != DBNull.Value)
                    objDoc_LoaiVanBanET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                if (oReader["NgayTao"] != DBNull.Value)
                    objDoc_LoaiVanBanET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objDoc_LoaiVanBanET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                if (oReader["NgaySua"] != DBNull.Value)
                    objDoc_LoaiVanBanET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objDoc_LoaiVanBanET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                return objDoc_LoaiVanBanET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", "setProperties", ex.Message);
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
		public Doc_LoaiVanBanET GetInfo(Guid intItemID)
        {
            try
            {
                Doc_LoaiVanBanET objDoc_LoaiVanBanET = new Doc_LoaiVanBanET();
                DataTable tblDoc_LoaiVanBanET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Doc_LoaiVanBan", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["LoaiVanBanID"] != DBNull.Value)
                            objDoc_LoaiVanBanET.LoaiVanBanID = new Guid(Convert.ToString(oReader["LoaiVanBanID"]));
                        if (oReader["LoaiVanBanChaID"] != DBNull.Value)
                            objDoc_LoaiVanBanET.LoaiVanBanChaID = new Guid(Convert.ToString(oReader["LoaiVanBanChaID"]));
                        if (oReader["NgonNgu"] != DBNull.Value)
                            objDoc_LoaiVanBanET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                        if (oReader["Ma"] != DBNull.Value)
                            objDoc_LoaiVanBanET.Ma = Convert.ToString(oReader["Ma"]);
                        if (oReader["Ten"] != DBNull.Value)
                            objDoc_LoaiVanBanET.Ten = Convert.ToString(oReader["Ten"]);
                        if (oReader["TenTiengAnh"] != DBNull.Value)
                            objDoc_LoaiVanBanET.TenTiengAnh = Convert.ToString(oReader["TenTiengAnh"]);
                        if (oReader["LoaiVanBanChiTiet"] != DBNull.Value)
                            objDoc_LoaiVanBanET.LoaiVanBanChiTiet = Convert.ToInt32(oReader["LoaiVanBanChiTiet"]);
                        if (oReader["TrangThaiSuDung"] != DBNull.Value)
                            objDoc_LoaiVanBanET.TrangThaiSuDung = Convert.ToInt32(oReader["TrangThaiSuDung"]);
                        if (oReader["ThuTu"] != DBNull.Value)
                            objDoc_LoaiVanBanET.ThuTu = Convert.ToInt32(oReader["ThuTu"]);
                        if (oReader["GhiChu"] != DBNull.Value)
                            objDoc_LoaiVanBanET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                        if (oReader["NgayTao"] != DBNull.Value)
                            objDoc_LoaiVanBanET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objDoc_LoaiVanBanET.CreatedBy = Convert.ToInt32(oReader["CreatedBy"]);
                        if (oReader["NgaySua"] != DBNull.Value)
                            objDoc_LoaiVanBanET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objDoc_LoaiVanBanET.ModifiedBy = Convert.ToInt32(oReader["ModifiedBy"]);
                        return objDoc_LoaiVanBanET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", " GetInfo", ex.Message);
                throw ex;
            }
        }

        ///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="Doc_LoaiVanBanET">Entity</param>
		///<returns>MessageUtil</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		12/04/2017Tạo mới
		///</Modified>
		public MessageUtil Update(Doc_LoaiVanBanET objDoc_LoaiVanBanET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_Doc_LoaiVanBan"
                        , objDoc_LoaiVanBanET.LoaiVanBanID
                        , objDoc_LoaiVanBanET.LoaiVanBanChaID
                        , objDoc_LoaiVanBanET.NgonNgu
                        , objDoc_LoaiVanBanET.Ma
                        , objDoc_LoaiVanBanET.Ten
                        , objDoc_LoaiVanBanET.TenTiengAnh
                        , objDoc_LoaiVanBanET.LoaiVanBanChiTiet
                        , objDoc_LoaiVanBanET.TrangThaiSuDung
                        , objDoc_LoaiVanBanET.ThuTu
                        , objDoc_LoaiVanBanET.GhiChu
                        , objDoc_LoaiVanBanET.NgayTao
                        , objDoc_LoaiVanBanET.CreatedBy
                        , objDoc_LoaiVanBanET.NgaySua
                        , objDoc_LoaiVanBanET.ModifiedBy
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Doc_LoaiVanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017Tạo mới
        ///</Modified>
        public bool Insert(Doc_LoaiVanBanET objDoc_LoaiVanBanET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Doc_LoaiVanBan", "LoaiVanBanID"
                         , objDoc_LoaiVanBanET.LoaiVanBanChaID
                         , objDoc_LoaiVanBanET.NgonNgu
                         , objDoc_LoaiVanBanET.Ma
                         , objDoc_LoaiVanBanET.Ten
                         , objDoc_LoaiVanBanET.TenTiengAnh
                         , objDoc_LoaiVanBanET.LoaiVanBanChiTiet
                         , objDoc_LoaiVanBanET.TrangThaiSuDung
                         , objDoc_LoaiVanBanET.ThuTu
                         , objDoc_LoaiVanBanET.GhiChu
                         , objDoc_LoaiVanBanET.NgayTao
                         , objDoc_LoaiVanBanET.CreatedBy
                         , objDoc_LoaiVanBanET.NgaySua
                         , objDoc_LoaiVanBanET.ModifiedBy
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_LoaiVanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_Doc_LoaiVanBan", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_LoaiVanBanET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Doc_LoaiVanBan", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", " Delete", ex.Message);
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
                    null,//LoaiVanBanChiTiet
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", "setProperties", ex.Message);
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
        /// <param name="loaiVanBanChiTiet"> LoaiVanBanChiTiet</param>
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
                    short? loaiVanBanChiTiet,
                    short? trangThaiSuDung,
                    string ghiChu,
                    DateTime? ngayTao,
                    string createdBy,
                    DateTime? ngaySua,
                    string modifiedBy,
                    Guid? loaiVanBanChaID)
        {
            DataTable dt;
            try
            {
                totalRows = 0;
                dt = GetTableByProcedure("sp_Doc_LoaiVanBan_SearchPaging",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    ngonNgu,
                    ma,
                    ten,
                    tenTiengAnh,
                    loaiVanBanChiTiet,
                    trangThaiSuDung,
                    ghiChu,
                    ngayTao,
                    createdBy,
                    ngaySua,
                    modifiedBy,
                    loaiVanBanChaID);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = Int64.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_LoaiVanBanDA", "setProperties", ex.Message);
                totalRows = 0;
                return null;
            }
        }

        public DataTable GetAllItem()
        {
            try
            {
                DataTable dt;
                dt = GetTableByProcedure("sp_GetAll_Doc_LoaiVanBan");
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
        public DataTable GetAllItemTree()
        {
            try
            {
                DataTable dt;
                dt = GetTableByProcedure("sp_GetAll_Doc_LoaiVanBan_Tree");
                return dt;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}

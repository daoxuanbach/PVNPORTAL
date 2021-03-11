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
    public class Doc_VanBanDA : Pvn.DA.DataProvider
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
		private Doc_VanBanET setProperties(DataRow oReader)
        {
            try
            {
                Doc_VanBanET objDoc_VanBanET = new Doc_VanBanET();
                if (oReader["VanBanID"] != DBNull.Value)
                    objDoc_VanBanET.VanBanID = new Guid(Convert.ToString(oReader["VanBanID"]));
                if (oReader["NgonNgu"] != DBNull.Value)
                    objDoc_VanBanET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                if (oReader["SoVanBan"] != DBNull.Value)
                    objDoc_VanBanET.SoVanBan = Convert.ToString(oReader["SoVanBan"]);
                if (oReader["KieuVanBan"] != DBNull.Value)
                    objDoc_VanBanET.KieuVanBan = Convert.ToInt32(oReader["KieuVanBan"]);
                if (oReader["TrangThaiVanBan"] != DBNull.Value)
                    objDoc_VanBanET.TrangThaiVanBan = Convert.ToInt32(oReader["TrangThaiVanBan"]);
                if (oReader["LoaiVanBanID"] != DBNull.Value)
                    objDoc_VanBanET.LoaiVanBanID = new Guid(Convert.ToString(oReader["LoaiVanBanID"]));
                if (oReader["LinhVucID"] != DBNull.Value)
                    objDoc_VanBanET.LinhVucID = new Guid(Convert.ToString(oReader["LinhVucID"]));
                if (oReader["NgayBanHanh"] != DBNull.Value)
                    objDoc_VanBanET.NgayBanHanh = Convert.ToDateTime(oReader["NgayBanHanh"]);
                if (oReader["NgayHetHan"] != DBNull.Value)
                    objDoc_VanBanET.NgayHetHan = Convert.ToDateTime(oReader["NgayHetHan"]);
                if (oReader["NgayThuHoi"] != DBNull.Value)
                    objDoc_VanBanET.NgayThuHoi = Convert.ToDateTime(oReader["NgayThuHoi"]);
                if (oReader["NgayDangCongBao"] != DBNull.Value)
                    objDoc_VanBanET.NgayDangCongBao = Convert.ToDateTime(oReader["NgayDangCongBao"]);
                if (oReader["TieuDe"] != DBNull.Value)
                    objDoc_VanBanET.TieuDe = Convert.ToString(oReader["TieuDe"]);
                if (oReader["PhamVi"] != DBNull.Value)
                    objDoc_VanBanET.PhamVi = Convert.ToInt32(oReader["PhamVi"]);
                if (oReader["PhamViVanBan"] != DBNull.Value)
                    objDoc_VanBanET.PhamViVanBan = Convert.ToString(oReader["PhamViVanBan"]);
                if (oReader["NguonTrich"] != DBNull.Value)
                    objDoc_VanBanET.NguonTrich = Convert.ToString(oReader["NguonTrich"]);
                if (oReader["NgayHieuLuc"] != DBNull.Value)
                    objDoc_VanBanET.NgayHieuLuc = Convert.ToDateTime(oReader["NgayHieuLuc"]);
                if (oReader["NgayHetHieuLuc"] != DBNull.Value)
                    objDoc_VanBanET.NgayHetHieuLuc = Convert.ToDateTime(oReader["NgayHetHieuLuc"]);
                if (oReader["NgayApDung"] != DBNull.Value)
                    objDoc_VanBanET.NgayApDung = Convert.ToDateTime(oReader["NgayApDung"]);
                if (oReader["LyDoHetHieuLuc"] != DBNull.Value)
                    objDoc_VanBanET.LyDoHetHieuLuc = Convert.ToString(oReader["LyDoHetHieuLuc"]);
                if (oReader["PhanHetHieuLuc"] != DBNull.Value)
                    objDoc_VanBanET.PhanHetHieuLuc = Convert.ToString(oReader["PhanHetHieuLuc"]);
                if (oReader["ToanVanVanBan"] != DBNull.Value)
                    objDoc_VanBanET.ToanVanVanBan = (byte[])(oReader["ToanVanVanBan"]);
                if (oReader["NoiDungVanBan"] != DBNull.Value)
                    objDoc_VanBanET.NoiDungVanBan = Convert.ToString(oReader["NoiDungVanBan"]);
                if (oReader["DuongDanVanBan"] != DBNull.Value)
                    objDoc_VanBanET.DuongDanVanBan = Convert.ToString(oReader["DuongDanVanBan"]);
                if (oReader["GhiChu"] != DBNull.Value)
                    objDoc_VanBanET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                if (oReader["NgayTao"] != DBNull.Value)
                    objDoc_VanBanET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                if (oReader["CreatedBy"] != DBNull.Value)
                    objDoc_VanBanET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                if (oReader["NgaySua"] != DBNull.Value)
                    objDoc_VanBanET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                if (oReader["ModifiedBy"] != DBNull.Value)
                    objDoc_VanBanET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                if (oReader["DonViBanHanhID"] != DBNull.Value)
                    objDoc_VanBanET.DonViBanHanhID = new Guid(Convert.ToString(oReader["DonViBanHanhID"]));
                if (oReader["NguoiKy"] != DBNull.Value)
                    objDoc_VanBanET.NguoiKy = Convert.ToString(oReader["NguoiKy"]);
                if (oReader["ChucDanh"] != DBNull.Value)
                    objDoc_VanBanET.ChucDanh = Convert.ToString(oReader["ChucDanh"]);
                return objDoc_VanBanET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", "setProperties", ex.Message);
                throw ex;
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
                Pvn.Utils.LogFile.WriteLogFile("DA", "", ex.Message);

                totalRecords = 0;
                return null;
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
        public Doc_VanBanET GetInfo(Guid intItemID)
        {
            try
            {
                Doc_VanBanET objDoc_VanBanET = new Doc_VanBanET();
                DataTable tblDoc_VanBanET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Doc_VanBan", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["VanBanID"] != DBNull.Value)
                            objDoc_VanBanET.VanBanID = new Guid(Convert.ToString(oReader["VanBanID"]));
                        if (oReader["NgonNgu"] != DBNull.Value)
                            objDoc_VanBanET.NgonNgu = Convert.ToString(oReader["NgonNgu"]);
                        if (oReader["SoVanBan"] != DBNull.Value)
                            objDoc_VanBanET.SoVanBan = Convert.ToString(oReader["SoVanBan"]);
                        if (oReader["KieuVanBan"] != DBNull.Value)
                            objDoc_VanBanET.KieuVanBan = Convert.ToInt32(oReader["KieuVanBan"]);
                        if (oReader["TrangThaiVanBan"] != DBNull.Value)
                            objDoc_VanBanET.TrangThaiVanBan = Convert.ToInt32(oReader["TrangThaiVanBan"]);
                        if (oReader["LoaiVanBanID"] != DBNull.Value)
                            objDoc_VanBanET.LoaiVanBanID = new Guid(Convert.ToString(oReader["LoaiVanBanID"]));
                        if (oReader["LinhVucID"] != DBNull.Value)
                            objDoc_VanBanET.LinhVucID = new Guid(Convert.ToString(oReader["LinhVucID"]));
                        if (oReader["NgayBanHanh"] != DBNull.Value)
                            objDoc_VanBanET.NgayBanHanh = Convert.ToDateTime(oReader["NgayBanHanh"]);
                        if (oReader["NgayHetHan"] != DBNull.Value)
                            objDoc_VanBanET.NgayHetHan = Convert.ToDateTime(oReader["NgayHetHan"]);
                        if (oReader["NgayThuHoi"] != DBNull.Value)
                            objDoc_VanBanET.NgayThuHoi = Convert.ToDateTime(oReader["NgayThuHoi"]);
                        if (oReader["NgayDangCongBao"] != DBNull.Value)
                            objDoc_VanBanET.NgayDangCongBao = Convert.ToDateTime(oReader["NgayDangCongBao"]);
                        if (oReader["TieuDe"] != DBNull.Value)
                            objDoc_VanBanET.TieuDe = Convert.ToString(oReader["TieuDe"]);
                        if (oReader["PhamVi"] != DBNull.Value)
                            objDoc_VanBanET.PhamVi = Convert.ToInt32(oReader["PhamVi"]);
                        if (oReader["PhamViVanBan"] != DBNull.Value)
                            objDoc_VanBanET.PhamViVanBan = Convert.ToString(oReader["PhamViVanBan"]);
                        if (oReader["NguonTrich"] != DBNull.Value)
                            objDoc_VanBanET.NguonTrich = Convert.ToString(oReader["NguonTrich"]);
                        if (oReader["NgayHieuLuc"] != DBNull.Value)
                            objDoc_VanBanET.NgayHieuLuc = Convert.ToDateTime(oReader["NgayHieuLuc"]);
                        if (oReader["NgayHetHieuLuc"] != DBNull.Value)
                            objDoc_VanBanET.NgayHetHieuLuc = Convert.ToDateTime(oReader["NgayHetHieuLuc"]);
                        if (oReader["NgayApDung"] != DBNull.Value)
                            objDoc_VanBanET.NgayApDung = Convert.ToDateTime(oReader["NgayApDung"]);
                        if (oReader["LyDoHetHieuLuc"] != DBNull.Value)
                            objDoc_VanBanET.LyDoHetHieuLuc = Convert.ToString(oReader["LyDoHetHieuLuc"]);
                        if (oReader["PhanHetHieuLuc"] != DBNull.Value)
                            objDoc_VanBanET.PhanHetHieuLuc = Convert.ToString(oReader["PhanHetHieuLuc"]);
                        if (oReader["ToanVanVanBan"] != DBNull.Value)
                            objDoc_VanBanET.ToanVanVanBan = (byte[])(oReader["ToanVanVanBan"]);
                        if (oReader["NoiDungVanBan"] != DBNull.Value)
                            objDoc_VanBanET.NoiDungVanBan = Convert.ToString(oReader["NoiDungVanBan"]);
                        if (oReader["DuongDanVanBan"] != DBNull.Value)
                            objDoc_VanBanET.DuongDanVanBan = Convert.ToString(oReader["DuongDanVanBan"]);
                        if (oReader["GhiChu"] != DBNull.Value)
                            objDoc_VanBanET.GhiChu = Convert.ToString(oReader["GhiChu"]);
                        if (oReader["NgayTao"] != DBNull.Value)
                            objDoc_VanBanET.NgayTao = Convert.ToDateTime(oReader["NgayTao"]);
                        if (oReader["CreatedBy"] != DBNull.Value)
                            objDoc_VanBanET.CreatedBy = Convert.ToString(oReader["CreatedBy"]);
                        if (oReader["NgaySua"] != DBNull.Value)
                            objDoc_VanBanET.NgaySua = Convert.ToDateTime(oReader["NgaySua"]);
                        if (oReader["ModifiedBy"] != DBNull.Value)
                            objDoc_VanBanET.ModifiedBy = Convert.ToString(oReader["ModifiedBy"]);
                        if (oReader["DonViBanHanhID"] != DBNull.Value)
                            objDoc_VanBanET.DonViBanHanhID = new Guid(Convert.ToString(oReader["DonViBanHanhID"]));
                        if (oReader["NguoiKy"] != DBNull.Value)
                            objDoc_VanBanET.NguoiKy = Convert.ToString(oReader["NguoiKy"]);
                        if (oReader["ChucDanh"] != DBNull.Value)
                            objDoc_VanBanET.ChucDanh = Convert.ToString(oReader["ChucDanh"]);
                        return objDoc_VanBanET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="Doc_VanBanET">Entity</param>
		///<returns>MessageUtil</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		12/04/2017Tạo mới
		///</Modified>
		public MessageUtil Update(Doc_VanBanET objDoc_VanBanET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_Doc_VanBan"
                        , objDoc_VanBanET.VanBanID
                        , objDoc_VanBanET.NgonNgu
                        , objDoc_VanBanET.SoVanBan
                        , objDoc_VanBanET.KieuVanBan
                        , objDoc_VanBanET.TrangThaiVanBan
                        , objDoc_VanBanET.LoaiVanBanID
                        , objDoc_VanBanET.LinhVucID
                        , objDoc_VanBanET.NgayBanHanh
                        , objDoc_VanBanET.NgayHetHan
                        , objDoc_VanBanET.NgayThuHoi
                        , objDoc_VanBanET.NgayDangCongBao
                        , objDoc_VanBanET.TieuDe
                        , objDoc_VanBanET.PhamVi
                        , objDoc_VanBanET.PhamViVanBan
                        , objDoc_VanBanET.NguonTrich
                        , objDoc_VanBanET.NgayHieuLuc
                        , objDoc_VanBanET.NgayHetHieuLuc
                        , objDoc_VanBanET.NgayApDung
                        , objDoc_VanBanET.LyDoHetHieuLuc
                        , objDoc_VanBanET.PhanHetHieuLuc
                        , objDoc_VanBanET.ToanVanVanBan
                        , objDoc_VanBanET.NoiDungVanBan
                        , objDoc_VanBanET.DuongDanVanBan
                        , objDoc_VanBanET.GhiChu
                        , objDoc_VanBanET.NgayTao
                        , objDoc_VanBanET.CreatedBy
                        , objDoc_VanBanET.NgaySua
                        , objDoc_VanBanET.ModifiedBy
                        , objDoc_VanBanET.DonViBanHanhID
                        //, objDoc_VanBanET.NguoiKy
                        //, objDoc_VanBanET.ChucDanh
                        ,objDoc_VanBanET.ThuTu
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        public MessageUtil Approved(Doc_VanBanET objDoc_VanBanET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_Approved_Doc_VanBan"
                        , objDoc_VanBanET.VanBanID
                        , objDoc_VanBanET.TrangThaiVanBan
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Doc_VanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017Tạo mới
        ///</Modified>
        public bool Insert(Doc_VanBanET objDoc_VanBanET)
        {
            try
            {
                ExecuteNonQueryOutToGuid("sp_Add_Doc_VanBan", "VanBanID",
                                        objDoc_VanBanET.NgonNgu,
                                        objDoc_VanBanET.SoVanBan,
                                        objDoc_VanBanET.KieuVanBan,
                                        objDoc_VanBanET.TrangThaiVanBan,
                                        objDoc_VanBanET.LoaiVanBanID,
                                        objDoc_VanBanET.LinhVucID,
                                        objDoc_VanBanET.NgayBanHanh,
                                        objDoc_VanBanET.NgayHetHan,
                                        objDoc_VanBanET.NgayThuHoi,
                                        objDoc_VanBanET.NgayDangCongBao,
                                        objDoc_VanBanET.TieuDe,
                                        objDoc_VanBanET.PhamVi,
                                        objDoc_VanBanET.PhamViVanBan,
                                        objDoc_VanBanET.NguonTrich,
                                        objDoc_VanBanET.NgayHieuLuc,
                                        objDoc_VanBanET.NgayHetHieuLuc,
                                        objDoc_VanBanET.NgayApDung,
                                        objDoc_VanBanET.LyDoHetHieuLuc,
                                        objDoc_VanBanET.PhanHetHieuLuc,
                                        objDoc_VanBanET.ToanVanVanBan,
                                        objDoc_VanBanET.NoiDungVanBan,
                                        objDoc_VanBanET.DuongDanVanBan,
                                        objDoc_VanBanET.GhiChu,
                                        objDoc_VanBanET.NgayTao,
                                        objDoc_VanBanET.CreatedBy,
                                        objDoc_VanBanET.NgaySua,
                                        objDoc_VanBanET.ModifiedBy,
                                        objDoc_VanBanET.DonViBanHanhID,
                                        //, objDoc_VanBanET.NguoiKy
                                        //, objDoc_VanBanET.ChucDanh
                                        objDoc_VanBanET.ThuTu
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_VanBanET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		12/04/2017		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_Doc_VanBan", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", " Delete", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Doc_VanBanET">Entity</param>
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
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_Doc_VanBan", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("Doc_VanBanDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        /// <summary>
        /// Search paging doc_vanban with trangthaivanban
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="orderByColumn"></param>
        /// <param name="pageIndex"></param>
        /// <param name="rowsInPage"></param>
        /// <param name="totalRows"></param>
        /// <param name="ngonNgu"></param>
        /// <param name="soVanBan"></param>
        /// <param name="kieuVanBan"></param>
        /// <param name="trangThaiVanBan"></param>
        /// <param name="loaiVanBanID"></param>
        /// <param name="linhVucID"></param>
        /// <param name="ngayBanHanh"></param>
        /// <param name="ngayHetHan"></param>
        /// <param name="ngayThuHoi"></param>
        /// <param name="ngayDangCongBao"></param>
        /// <param name="tieuDe"></param>
        /// <param name="phamVi"></param>
        /// <param name="phamViVanBan"></param>
        /// <param name="ngayHieuLuc"></param>
        /// <param name="ngayHetHieuLuc"></param>
        /// <param name="ngayApDung"></param>
        /// <param name="toanVanVanBan"></param>
        /// <param name="duongDanVanBan"></param>
        /// <param name="ghiChu"></param>
        /// <param name="ngayTao"></param>
        /// <param name="createdBy"></param>
        /// <param name="ngaySua"></param>
        /// <param name="modifiedBy"></param>
        /// <param name="ngayBanHanhTo"></param>
        /// <param name="ngayHetHanTo"></param>
        /// <returns></returns>
        public DataTable GetSearchPagingWithDocStates(
                    string currentLanguage,
                    string orderByColumn,
                    int pageIndex,
                    int rowsInPage,
                    out long totalRows,
                    string ngonNgu,
                    string soVanBan,
                    short? kieuVanBan,
                    string trangThaiVanBan,
                    Guid? loaiVanBanID,
                    Guid? linhVucID,
                    DateTime? ngayBanHanh,
                    DateTime? ngayHetHan,
                    DateTime? ngayThuHoi,
                    DateTime? ngayDangCongBao,
                    string tieuDe,
                    short? phamVi,
                    string phamViVanBan,
                    DateTime? ngayHieuLuc,
                    DateTime? ngayHetHieuLuc,
                    DateTime? ngayApDung,
                    byte?[] toanVanVanBan,
                    string duongDanVanBan,
                    string ghiChu,
                    DateTime? ngayTao,
                    string createdBy,
                    DateTime? ngaySua,
                    string modifiedBy,
                    DateTime? ngayBanHanhTo,
                    DateTime? ngayHetHanTo)
        {
            totalRows = 0;
            DataTable dt;
            try
            {
                dt = GetTableByProcedure("sp_Doc_VanBan_SearchPagingWithDocStates",
                    currentLanguage,
                    orderByColumn,
                    pageIndex,
                    rowsInPage,
                    ngonNgu,
                    soVanBan,
                    kieuVanBan,
                    trangThaiVanBan,
                    loaiVanBanID,
                    linhVucID,
                    ngayBanHanh,
                    ngayHetHan,
                    ngayThuHoi,
                    ngayDangCongBao,
                    tieuDe,
                    phamVi,
                    phamViVanBan,
                    ngayHieuLuc,
                    ngayHetHieuLuc,
                    ngayApDung,
                    toanVanVanBan,
                    duongDanVanBan,
                    ghiChu,
                    ngayTao,
                    createdBy,
                    ngaySua,
                    modifiedBy,
                    ngayBanHanhTo,
                    ngayHetHanTo);

                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncement", ex.Message);
                totalRows = 0;
                return null;
            }
        }

    }
}

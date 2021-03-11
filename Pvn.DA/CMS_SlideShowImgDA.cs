using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_SlideShowImgDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018		Tạo mới
        ///</Modified>
        private CMS_SlideShowImgET setProperties(DataRow oReader)
        {
            try
            {
                CMS_SlideShowImgET objCMS_SlideShowImgET = new CMS_SlideShowImgET();
                if (oReader["Id"] != DBNull.Value)
                    objCMS_SlideShowImgET.Id = Convert.ToInt32(oReader["Id"]);
                if (oReader["TieuDe"] != DBNull.Value)
                    objCMS_SlideShowImgET.TieuDe = Convert.ToString(oReader["TieuDe"]);
                if (oReader["NoiDung"] != DBNull.Value)
                    objCMS_SlideShowImgET.NoiDung = Convert.ToString(oReader["NoiDung"]);
                if (oReader["LinkChiTiet"] != DBNull.Value)
                    objCMS_SlideShowImgET.LinkChiTiet = Convert.ToString(oReader["LinkChiTiet"]);
                if (oReader["STT"] != DBNull.Value)
                    objCMS_SlideShowImgET.STT = Convert.ToInt32(oReader["STT"]);
                if (oReader["TuNgay"] != DBNull.Value)
                    objCMS_SlideShowImgET.TuNgay = Convert.ToDateTime(oReader["TuNgay"]);
                if (oReader["DenNgay"] != DBNull.Value)
                    objCMS_SlideShowImgET.DenNgay = Convert.ToDateTime(oReader["DenNgay"]);
                if (oReader["HienThi"] != DBNull.Value)
                    objCMS_SlideShowImgET.HienThi = Convert.ToBoolean(oReader["HienThi"]);
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_SlideShowImgET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                return objCMS_SlideShowImgET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<param name="p_search">Keyword Search</param>
        ///<param name="rownum">Số bản ghi trên trang</param>
        ///<param name="page">Trang cần lấy</param>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018		Tạo mới
        ///</Modified>
        public List<CMS_SlideShowImgET> GetAll_CMS_SlideShowImg_PagingET(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_SlideShowImgET> lstCMS_SlideShowImgET = new List<CMS_SlideShowImgET>();
                DataTable tblCMS_SlideShowImgET = GetTableByProcedurePaging("sp_CMS_SlideShowImg_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_SlideShowImgET.Rows.Count; i++)
                {
                    lstCMS_SlideShowImgET.Add(setProperties(tblCMS_SlideShowImgET.Rows[i]));
                }
                return lstCMS_SlideShowImgET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng  Datatable
        ///</summary>
        ///<param name="p_search">Keyword Search</param>
        ///<param name="rownum">Số bản ghi trên trang</param>
        ///<param name="page">Trang cần lấy</param>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_SlideShowImg_Paging(string orderByColumn, string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                DataTable dt = GetTableByProcedurePaging("sp_CMS_SlideShowImg_SearchPaging", new object[] { orderByColumn, p_search, page, rownum, 0 }, out totalRows);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_SlideShowImg(bool HienThi)
        {
            try
            {
                DataTable tblCMS_SlideShowImgET = GetTableByProcedure("sp_GetAll_CMS_SlideShowImg", HienThi);
                return tblCMS_SlideShowImgET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " GetAll_..", ex.Message);
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
        ///Bachdx		22/02/2018Tạo mới
        ///</Modified>
        public CMS_SlideShowImgET GetInfo(int intItemID)
        {
            try
            {
                CMS_SlideShowImgET objCMS_SlideShowImgET = new CMS_SlideShowImgET();
                DataTable tblCMS_SlideShowImgET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_SlideShowImg", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["Id"] != DBNull.Value)
                            objCMS_SlideShowImgET.Id = Convert.ToInt32(oReader["Id"]);
                        if (oReader["TieuDe"] != DBNull.Value)
                            objCMS_SlideShowImgET.TieuDe = Convert.ToString(oReader["TieuDe"]);
                        if (oReader["NoiDung"] != DBNull.Value)
                            objCMS_SlideShowImgET.NoiDung = Convert.ToString(oReader["NoiDung"]);
                        if (oReader["LinkChiTiet"] != DBNull.Value)
                            objCMS_SlideShowImgET.LinkChiTiet = Convert.ToString(oReader["LinkChiTiet"]);
                        if (oReader["STT"] != DBNull.Value)
                            objCMS_SlideShowImgET.STT = Convert.ToInt32(oReader["STT"]);
                        if (oReader["TuNgay"] != DBNull.Value)
                            objCMS_SlideShowImgET.TuNgay = Convert.ToDateTime(oReader["TuNgay"]);
                        if (oReader["DenNgay"] != DBNull.Value)
                            objCMS_SlideShowImgET.DenNgay = Convert.ToDateTime(oReader["DenNgay"]);
                        if (oReader["HienThi"] != DBNull.Value)
                            objCMS_SlideShowImgET.HienThi = Convert.ToBoolean(oReader["HienThi"]);
                        if (oReader["ImageURL"] != DBNull.Value)
                            objCMS_SlideShowImgET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                        return objCMS_SlideShowImgET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_SlideShowImgET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_SlideShowImgET objCMS_SlideShowImgET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_SlideShowImg"
                         , objCMS_SlideShowImgET.Id
                         , objCMS_SlideShowImgET.TieuDe
                         , objCMS_SlideShowImgET.NoiDung
                         , objCMS_SlideShowImgET.LinkChiTiet
                         , objCMS_SlideShowImgET.STT
                         , objCMS_SlideShowImgET.TuNgay
                         , objCMS_SlideShowImgET.DenNgay
                         , objCMS_SlideShowImgET.HienThi
                         , objCMS_SlideShowImgET.ImageURL
                ))
                {
                    if (oReader.Read())
                        if (oReader[0] != DBNull.Value)
                        {
                            {
                                objMsg.Error = true;
                                objMsg.Message = Convert.ToString(oReader[0]);
                            }
                        }
                }
                return objMsg;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_SlideShowImgET">Entity</param>
        ///<returns>int</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018Tạo mới
        ///</Modified>
        public int Insert(CMS_SlideShowImgET objCMS_SlideShowImgET)
        {
            try
            {
                return ExecuteNonQueryOut("sp_Add_CMS_SlideShowImg", "Id"
                         , objCMS_SlideShowImgET.TieuDe
                         , objCMS_SlideShowImgET.NoiDung
                         , objCMS_SlideShowImgET.LinkChiTiet
                         , objCMS_SlideShowImgET.STT
                         , objCMS_SlideShowImgET.TuNgay
                         , objCMS_SlideShowImgET.DenNgay
                         , objCMS_SlideShowImgET.HienThi
                         , objCMS_SlideShowImgET.ImageURL
                );
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_SlideShowImgET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/02/2018		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int ItemID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_SlideShowImg", ItemID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_SlideShowImgDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}


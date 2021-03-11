using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class CMS_BannerQuangCaoDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/11/2017		Tạo mới
        ///</Modified>
        private CMS_BannerQuangCaoET setProperties(DataRow oReader)
        {
            try
            {
                CMS_BannerQuangCaoET objCMS_BannerQuangCaoET = new CMS_BannerQuangCaoET();
                if (oReader["Id"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.Id = Convert.ToInt32(oReader["Id"]);
                if (oReader["TocDo"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.TocDo = Convert.ToInt32(oReader["TocDo"]);
                if (oReader["NoiDung"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.NoiDung = Convert.ToString(oReader["NoiDung"]);
                if (oReader["STT"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.STT = Convert.ToInt32(oReader["STT"]);
                if (oReader["TuNgay"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.TuNgay = Convert.ToDateTime(oReader["TuNgay"]);
                if (oReader["DenNgay"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.DenNgay = Convert.ToDateTime(oReader["DenNgay"]);
                if (oReader["HienThi"] != DBNull.Value)
                    objCMS_BannerQuangCaoET.HienThi = Convert.ToBoolean(oReader["HienThi"]);
                return objCMS_BannerQuangCaoET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", "setProperties", ex.Message);
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
        ///Bachdx		22/11/2017		Tạo mới
        ///</Modified>
        public List<CMS_BannerQuangCaoET> GetAll_CMS_BannerQuangCao_PagingET(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<CMS_BannerQuangCaoET> lstCMS_BannerQuangCaoET = new List<CMS_BannerQuangCaoET>();
                DataTable tblCMS_BannerQuangCaoET = GetTableByProcedurePaging("sp_CMS_BannerQuangCao_SearchPaging", new object[] { p_search, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblCMS_BannerQuangCaoET.Rows.Count; i++)
                {
                    lstCMS_BannerQuangCaoET.Add(setProperties(tblCMS_BannerQuangCaoET.Rows[i]));
                }
                return lstCMS_BannerQuangCaoET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " GetAll_.._Paging", ex.Message);
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
        ///Bachdx		22/11/2017		Tạo mới
        ///</Modified>
        public DataTable GetAll_CMS_BannerQuangCao_Paging(string orderByColumn, string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                DataTable dt = GetTableByProcedurePaging("sp_CMS_BannerQuangCao_SearchPaging", new object[] { orderByColumn, p_search, page, rownum, 0 }, out totalRows);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRows = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/11/2017		Tạo mới
        ///</Modified>
        public List<CMS_BannerQuangCaoET> GetAll_CMS_BannerQuangCao()
        {
            try
            {
                List<CMS_BannerQuangCaoET> lstCMS_BannerQuangCaoET = new List<CMS_BannerQuangCaoET>();
                DataTable tblCMS_BannerQuangCaoET = GetTableByProcedure("sp_GetAll_CMS_BannerQuangCao");
                for (int i = 0; i < tblCMS_BannerQuangCaoET.Rows.Count; i++)
                {
                    lstCMS_BannerQuangCaoET.Add(setProperties(tblCMS_BannerQuangCaoET.Rows[i]));
                }
                return lstCMS_BannerQuangCaoET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " GetAll_..", ex.Message);
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
        ///Bachdx		22/11/2017Tạo mới
        ///</Modified>
        public CMS_BannerQuangCaoET GetInfo(int intItemID)
        {
            try
            {
                CMS_BannerQuangCaoET objCMS_BannerQuangCaoET = new CMS_BannerQuangCaoET();
                DataTable tblCMS_BannerQuangCaoET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_CMS_BannerQuangCao", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["Id"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.Id = Convert.ToInt32(oReader["Id"]);
                        if (oReader["TocDo"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.TocDo = Convert.ToInt32(oReader["TocDo"]);
                        if (oReader["NoiDung"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.NoiDung = Convert.ToString(oReader["NoiDung"]);
                        if (oReader["STT"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.STT = Convert.ToInt32(oReader["STT"]);
                        if (oReader["TuNgay"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.TuNgay = Convert.ToDateTime(oReader["TuNgay"]);
                        if (oReader["DenNgay"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.DenNgay = Convert.ToDateTime(oReader["DenNgay"]);
                        if (oReader["HienThi"] != DBNull.Value)
                            objCMS_BannerQuangCaoET.HienThi = Convert.ToBoolean(oReader["HienThi"]);
                        return objCMS_BannerQuangCaoET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        public string GetAllSumNoiDungRunning()
        {
            try
            {
                string Noidung = string.Empty;
                using (IDataReader oReader = GetIDataReader("sp_GetSumAll_CMS_BannerQuangCao_Running"))
                {
                    if (oReader.Read())
                    {
                        if (oReader["NoiDung"] != DBNull.Value)
                            Noidung = Convert.ToString(oReader["NoiDung"]);
                    }
                    return Noidung;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }
        
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_BannerQuangCaoET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/11/2017Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_BannerQuangCaoET objCMS_BannerQuangCaoET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_CMS_BannerQuangCao"
                         , objCMS_BannerQuangCaoET.Id
                         , objCMS_BannerQuangCaoET.TocDo
                         , objCMS_BannerQuangCaoET.NoiDung
                         , objCMS_BannerQuangCaoET.STT
                         , objCMS_BannerQuangCaoET.TuNgay
                         , objCMS_BannerQuangCaoET.DenNgay
                         , objCMS_BannerQuangCaoET.HienThi
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_BannerQuangCaoET">Entity</param>
        ///<returns>int</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/11/2017Tạo mới
        ///</Modified>
        public int Insert(CMS_BannerQuangCaoET objCMS_BannerQuangCaoET)
        {
            try
            {
                return ExecuteNonQueryOut("sp_Add_CMS_BannerQuangCao", "Id"
                         , objCMS_BannerQuangCaoET.TocDo
                         , objCMS_BannerQuangCaoET.NoiDung
                         , objCMS_BannerQuangCaoET.STT
                         , objCMS_BannerQuangCaoET.TuNgay
                         , objCMS_BannerQuangCaoET.DenNgay
                         , objCMS_BannerQuangCaoET.HienThi
                );
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " Insert", ex.Message);
                return 0;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_BannerQuangCaoET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		22/11/2017		Tạo mới
        ///</Modified>
        public MessageUtil Delete(int GuidID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_CMS_BannerQuangCao", GuidID))
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
                Pvn.Utils.LogFile.WriteLogFile("CMS_BannerQuangCaoDA", " Delete", ex.Message);
                objMsg.Error = true; objMsg.Message = ex.Message; return objMsg;
            }
        }
    }
}

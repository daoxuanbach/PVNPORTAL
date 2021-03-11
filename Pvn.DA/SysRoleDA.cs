using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using Pvn.Utils;
namespace Pvn.DA
{
    public class SysRoleDA : Pvn.DA.DataProvider
    {
        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        private SysRoleET setProperties(DataRow oReader)
        {
            try
            {
                SysRoleET objSysRoleET = new SysRoleET();
                if (oReader["RoleID"] != DBNull.Value)
                    objSysRoleET.RoleID = Convert.ToInt32(oReader["RoleID"]);
                if (oReader["Name"] != DBNull.Value)
                    objSysRoleET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["Title"] != DBNull.Value)
                    objSysRoleET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["ClassView"] != DBNull.Value)
                    objSysRoleET.ClassView = Convert.ToString(oReader["ClassView"]);
                if (oReader["IconView"] != DBNull.Value)
                    objSysRoleET.IconView = Convert.ToString(oReader["IconView"]);
                if (oReader["FunctionID"] != DBNull.Value)
                    objSysRoleET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                if (oReader.Table.Columns.Contains("FunctionName") && oReader["FunctionName"] != DBNull.Value)
                    objSysRoleET.FunctionName = (Convert.ToString(oReader["FunctionName"]));
                if (oReader["ViTri"] != DBNull.Value)
                    objSysRoleET.ViTri = (Convert.ToInt16(oReader["ViTri"]));
                if (oReader["QuyTrinh"] != DBNull.Value)
                {
                    objSysRoleET.QuyTrinh = Convert.ToInt16(oReader["QuyTrinh"]);
                }
                if (oReader["KetThuc"] != DBNull.Value)
                    objSysRoleET.KetThuc = Convert.ToBoolean(oReader["KetThuc"]);
                if (oReader["TrangThaiHienThi"] != DBNull.Value)
                    objSysRoleET.TrangThaiHienThi = Convert.ToInt32(oReader["TrangThaiHienThi"]);
                if (oReader["TrangThaiGuiDi"] != DBNull.Value)
                    objSysRoleET.TrangThaiGuiDi = Convert.ToInt32(oReader["TrangThaiGuiDi"]);
                if (oReader["TextTrangThaiGuiDi"] != DBNull.Value)
                    objSysRoleET.TextTrangThaiGuiDi = Convert.ToString(oReader["TextTrangThaiGuiDi"]);
                if (oReader["TrangThaiTraLai"] != DBNull.Value)
                    objSysRoleET.TrangThaiTraLai = Convert.ToInt32(oReader["TrangThaiTraLai"]);
                if (oReader["TextTrangThaiTraLai"] != DBNull.Value)
                    objSysRoleET.TextTrangThaiTraLai = Convert.ToString(oReader["TextTrangThaiTraLai"]);
                if (oReader["ThuTu"] != DBNull.Value)
                    objSysRoleET.ThuTu = Convert.ToInt32(oReader["ThuTu"]);
                if (oReader["TrangThai"] != DBNull.Value)
                    objSysRoleET.TrangThai = (Convert.ToInt16(oReader["TrangThai"]));
                return objSysRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", "setProperties", ex.Message);
                throw ex;
            }
        }

        public List<SysRoleET> GetAll_SysRole_By_QuyTrinh(Guid? FunctionID, int userID, int ViTri, int? TrangThaiQT, int? QuyTrinh)
        {
            try
            {
                List<SysRoleET> lstSysRoleET = new List<SysRoleET>();
                DataTable tblSysRoleET = GetTableByProcedure("[sp_SysRole_By_QuyTrinh]", new object[] { FunctionID, userID, ViTri, TrangThaiQT,QuyTrinh});
                for (int i = 0; i < tblSysRoleET.Rows.Count; i++)
                {
                    lstSysRoleET.Add(setProperties(tblSysRoleET.Rows[i]));
                }
                return lstSysRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " GetAll_SysRole_ByFunction", ex.Message);
                throw ex;
            }
        }
        public List<SysRoleET> GetAll_SysRole_By_default(Guid? FunctionID, int userID, int ViTri)
        {
            try
            {
                List<SysRoleET> lstSysRoleET = new List<SysRoleET>();
                DataTable tblSysRoleET = GetTableByProcedure("[sp_SysRole_By_Function_And_Userid]", new object[] { FunctionID, userID, ViTri});
                for (int i = 0; i < tblSysRoleET.Rows.Count; i++)
                {
                    lstSysRoleET.Add(setProperties(tblSysRoleET.Rows[i]));
                }
                return lstSysRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " GetAll_SysRole_ByFunction", ex.Message);
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
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public List<SysRoleET> GetAll_SysRole_Paging(string p_search, Guid? FunctionID, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<SysRoleET> lstSysRoleET = new List<SysRoleET>();
                DataTable tblSysRoleET = GetTableByProcedurePaging("sp_SysRole_SearchPaging", new object[] { p_search, FunctionID, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSysRoleET.Rows.Count; i++)
                {
                    lstSysRoleET.Add(setProperties(tblSysRoleET.Rows[i]));
                }
                return lstSysRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        public List<SysRoleET> GetAll_SysRole_ByFunction(Guid? FunctionID)
        {
            try
            {
                List<SysRoleET> lstSysRoleET = new List<SysRoleET>();
                DataTable tblSysRoleET = GetTableByProcedure("sp_SysRole_ByFunction", new object[] { FunctionID });
                for (int i = 0; i < tblSysRoleET.Rows.Count; i++)
                {
                    lstSysRoleET.Add(setProperties(tblSysRoleET.Rows[i]));
                }
                return lstSysRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " GetAll_SysRole_ByFunction", ex.Message);
                throw ex;
            }
        }

        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public List<SysRoleET> GetAll_SysRole()
        {
            try
            {
                List<SysRoleET> lstSysRoleET = new List<SysRoleET>();
                DataTable tblSysRoleET = GetTableByProcedure("sp_GetAll_SysRole");
                for (int i = 0; i < tblSysRoleET.Rows.Count; i++)
                {
                    lstSysRoleET.Add(setProperties(tblSysRoleET.Rows[i]));
                }
                return lstSysRoleET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " GetAll_..", ex.Message);
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
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public SysRoleET GetInfo(int intItemID)
        {
            try
            {
                SysRoleET objSysRoleET = new SysRoleET();
                DataTable tblSysRoleET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_SysRole", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["RoleID"] != DBNull.Value)
                            objSysRoleET.RoleID = Convert.ToInt32(oReader["RoleID"]);
                        if (oReader["Name"] != DBNull.Value)
                            objSysRoleET.Name = Convert.ToString(oReader["Name"]);
                        if (oReader["Title"] != DBNull.Value)
                            objSysRoleET.Title = Convert.ToString(oReader["Title"]);
                        if (oReader["IconView"] != DBNull.Value)
                            objSysRoleET.IconView = Convert.ToString(oReader["IconView"]);
                        if (oReader["FunctionID"] != DBNull.Value)
                            objSysRoleET.FunctionID = new Guid(Convert.ToString(oReader["FunctionID"]));
                        if (oReader["ClassView"] != DBNull.Value)
                        {
                            objSysRoleET.ClassView = Convert.ToString(oReader["ClassView"]);
                        }
                        if (oReader["QuyTrinh"] != DBNull.Value)
                        {
                            objSysRoleET.QuyTrinh = Convert.ToInt16(oReader["QuyTrinh"]);
                        }
                       
                        if (oReader["KetThuc"] != DBNull.Value)
                            objSysRoleET.KetThuc = Convert.ToBoolean(oReader["KetThuc"]);
                        if (oReader["TrangThaiHienThi"] != DBNull.Value)
                            objSysRoleET.TrangThaiHienThi = Convert.ToInt32(oReader["TrangThaiHienThi"]);
                        if (oReader["TextTrangThaiHienThi"] != DBNull.Value)
                            objSysRoleET.TextTrangThaiHienThi = Convert.ToString(oReader["TextTrangThaiHienThi"]);
                        if (oReader["TrangThaiGuiDi"] != DBNull.Value)
                            objSysRoleET.TrangThaiGuiDi = Convert.ToInt32(oReader["TrangThaiGuiDi"]);
                        if (oReader["TextTrangThaiGuiDi"] != DBNull.Value)
                            objSysRoleET.TextTrangThaiGuiDi = Convert.ToString(oReader["TextTrangThaiGuiDi"]);
                        if (oReader["TrangThaiTraLai"] != DBNull.Value)
                            objSysRoleET.TrangThaiTraLai = Convert.ToInt32(oReader["TrangThaiTraLai"]);
                        if (oReader["TextTrangThaiTraLai"] != DBNull.Value)
                            objSysRoleET.TextTrangThaiTraLai = Convert.ToString(oReader["TextTrangThaiTraLai"]);
                        if (oReader["ThuTu"] != DBNull.Value)
                            objSysRoleET.ThuTu = Convert.ToInt32(oReader["ThuTu"]);
                        if (oReader["ViTri"] != DBNull.Value)
                            objSysRoleET.ViTri = (Convert.ToInt16(oReader["ViTri"]));
                        if (oReader["TrangThai"] != DBNull.Value)
                            objSysRoleET.TrangThai = (Convert.ToInt16(oReader["TrangThai"]));
                        return objSysRoleET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(SysRoleET objSys_RoleET)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.UpdateSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_UpdateByPK_SysRole"
                        , objSys_RoleET.RoleID
                         , objSys_RoleET.Name
                         , objSys_RoleET.Title
                         , objSys_RoleET.ClassView
                         , objSys_RoleET.IconView
                         , objSys_RoleET.FunctionID
                         , objSys_RoleET.ViTri
                         , objSys_RoleET.QuyTrinh
                         , objSys_RoleET.KetThuc
                         , objSys_RoleET.TrangThaiHienThi
                         , objSys_RoleET.TextTrangThaiHienThi
                         , objSys_RoleET.TrangThaiGuiDi
                         , objSys_RoleET.TextTrangThaiGuiDi
                         , objSys_RoleET.TrangThaiTraLai
                         , objSys_RoleET.TextTrangThaiTraLai
                         , objSys_RoleET.ThuTu
                         , objSys_RoleET.TrangThai
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
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " Update", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public bool Insert(SysRoleET objSys_RoleET)
        {
            try
            {
                int RoleID = ExecuteNonQueryOut("sp_Add_SysRole", "RoleID"
                          , objSys_RoleET.Name
                          , objSys_RoleET.Title
                          , objSys_RoleET.ClassView
                          , objSys_RoleET.IconView
                          , objSys_RoleET.FunctionID
                          , objSys_RoleET.ViTri
                          , objSys_RoleET.QuyTrinh
                          , objSys_RoleET.KetThuc
                          , objSys_RoleET.TrangThaiHienThi
                          , objSys_RoleET.TextTrangThaiHienThi
                          , objSys_RoleET.TrangThaiGuiDi
                          , objSys_RoleET.TextTrangThaiGuiDi
                          , objSys_RoleET.TrangThaiTraLai
                          , objSys_RoleET.TextTrangThaiTraLai
                          , objSys_RoleET.ThuTu
                          , objSys_RoleET.TrangThai
                 );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public bool Delete(Guid GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_SysRole", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " Delete", ex.Message);
                return false;
            }
        }

        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(int RoleID)
        {
            MessageUtil objMsg = new MessageUtil();
            try
            {
                objMsg.Error = false;
                objMsg.Message = Resources.DA_vi.DeleteSuccessfully;
                using (IDataReader oReader = GetIDataReader("sp_RemoveByPK_SysRole", RoleID))
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
                Pvn.Utils.LogFile.WriteLogFile("SysRoleDA", " Delete", ex.Message);
                objMsg.Error = true;
                objMsg.Message = ex.Message;
                return objMsg;
            }
        }
    }
}


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using Pvn.Entity;
using System.Globalization;
namespace Pvn.DA
{
    public class Sys_UserDA : Pvn.DA.DataProvider
    {

        ///<summary>
        ///Hàm set giá trị cho Entity
        ///</summary>
        ///<param name="oReader">Item cần set giá trị</param>
        ///<returns>Entity</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		05/04/2016		Tạo mới
        ///</Modified>
        private Sys_UserET setProperties(DataRow oReader)
        {
            try
            {
                Sys_UserET objSys_UserET = new Sys_UserET();
                if (oReader["UserID"] != DBNull.Value)
                    objSys_UserET.UserID = Convert.ToInt32(oReader["UserID"]);
                if (oReader["UnitID"] != DBNull.Value)
                    objSys_UserET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                if (oReader.Table.Columns.Contains("UnitName") && oReader["UnitName"] != DBNull.Value)
                    objSys_UserET.UnitName = Convert.ToString(oReader["UnitName"]);
                if (oReader["UserName"] != DBNull.Value)
                    objSys_UserET.UserName = Convert.ToString(oReader["UserName"]);
                if (oReader["LoginName"] != DBNull.Value)
                    objSys_UserET.LoginName = Convert.ToString(oReader["LoginName"]);
                if (oReader["LoginNameSP"] != DBNull.Value)
                    objSys_UserET.LoginNameSP = Convert.ToString(oReader["LoginNameSP"]);
                if (oReader["RolePermission"] != DBNull.Value)
                    objSys_UserET.RolePermission = Convert.ToInt32(oReader["RolePermission"]);
                if (oReader["UsedState"] != DBNull.Value)
                    objSys_UserET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                if (oReader["Checksum"] != DBNull.Value)
                    objSys_UserET.Checksum = Convert.ToString(oReader["Checksum"]);
                if (oReader["Tel"] != DBNull.Value)
                    objSys_UserET.Tel = Convert.ToString(oReader["Tel"]);
                if (oReader["Email"] != DBNull.Value)
                    objSys_UserET.Email = Convert.ToString(oReader["Email"]);
                if (oReader["Infor"] != DBNull.Value)
                    objSys_UserET.Infor = Convert.ToString(oReader["Infor"]);
                if (oReader["ImagePath"] != DBNull.Value)
                    objSys_UserET.ImagePath = Convert.ToString(oReader["ImagePath"]);
                if (oReader["Note"] != DBNull.Value)
                    objSys_UserET.Note = Convert.ToString(oReader["Note"]);
                if (oReader["CreatedDate"] != DBNull.Value)
                    objSys_UserET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                if (oReader["ModifiedDate"] != DBNull.Value)
                    objSys_UserET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                return objSys_UserET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", "setProperties", ex.Message);
                throw ex;
            }
        }

        public bool uppPass(Sys_UserET objSys_UserET)
        {
            try
            {
                ExecuteNonQuery("sp_UserUpdatePassByPK_Sys_User"
                         , objSys_UserET.UserID
                         , objSys_UserET.Checksum

                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " uppPass", ex.Message);
                return false;
            }
        }

        public bool UserUpdate(Sys_UserET objSys_UserET)
        {
            try
            {
                ExecuteNonQuery("sp_UserUpdateByPK_Sys_User"
                         , objSys_UserET.UserID
                         , objSys_UserET.UnitID
                         , objSys_UserET.UserName
                         , objSys_UserET.LoginName
                         , objSys_UserET.RolePermission
                         , objSys_UserET.UsedState
                         , objSys_UserET.Checksum
                         , objSys_UserET.Tel
                         , objSys_UserET.Email
                         , objSys_UserET.Infor
                         , objSys_UserET.ImagePath
                         , objSys_UserET.Note
                         , objSys_UserET.CreatedDate
                         , objSys_UserET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " UserUpdate", ex.Message);
                return false;
            }
        }

        public Sys_UserET Login(string TenDangNhap, string MatKhau)
        {
            try
            {
                Sys_UserET objSys_UserET = new Sys_UserET();
                DataTable tblSys_UserET = new DataTable();
                using (IDataReader oReader = GetIDataReader("NguoiDung_Login", TenDangNhap, MatKhau))
                {
                    if (oReader.Read())
                    {
                        if (oReader["UserID"] != DBNull.Value)
                            objSys_UserET.UserID = Convert.ToInt32(oReader["UserID"]);
                        if (oReader["UnitID"] != DBNull.Value)
                            objSys_UserET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                        if (Pvn.Utils.Common.ReaderContainsColumn(oReader, "UnitName") & oReader["UnitName"] != DBNull.Value)
                            objSys_UserET.UnitName = Convert.ToString(oReader["UnitName"]);
                        if (oReader["UserName"] != DBNull.Value)
                            objSys_UserET.UserName = Convert.ToString(oReader["UserName"]);
                        if (oReader["LoginName"] != DBNull.Value)
                            objSys_UserET.LoginName = Convert.ToString(oReader["LoginName"]);
                        if (oReader["LoginNameSP"] != DBNull.Value)
                            objSys_UserET.LoginNameSP = Convert.ToString(oReader["LoginNameSP"]);
                        if (oReader["RolePermission"] != DBNull.Value)
                            objSys_UserET.RolePermission = Convert.ToInt32(oReader["RolePermission"]);
                        if (oReader["UsedState"] != DBNull.Value)
                            objSys_UserET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Checksum"] != DBNull.Value)
                            objSys_UserET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["Tel"] != DBNull.Value)
                            objSys_UserET.Tel = Convert.ToString(oReader["Tel"]);
                        if (oReader["Email"] != DBNull.Value)
                            objSys_UserET.Email = Convert.ToString(oReader["Email"]);
                        if (oReader["Infor"] != DBNull.Value)
                            objSys_UserET.Infor = Convert.ToString(oReader["Infor"]);
                        if (oReader["ImagePath"] != DBNull.Value)
                            objSys_UserET.ImagePath = Convert.ToString(oReader["ImagePath"]);
                        if (oReader["Note"] != DBNull.Value)
                            objSys_UserET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_UserET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_UserET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                            if (oReader["RolePage"] != DBNull.Value)
                                objSys_UserET.RolePage = Convert.ToString(oReader["RolePage"]);
                        return objSys_UserET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " GetInfo", ex.Message);
                throw ex;
            }
        }

        public bool CheckRole(int uSERID, string filename)
        {
            try
            {
                DataTable tblSys_UserET = GetTableByProcedure("sp_CheckRoleUserID_Sys_User", uSERID, filename);
                if (tblSys_UserET.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " GetInfo", ex.Message);
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
        ///Bachdx		05/04/2016		Tạo mới
        ///</Modified> 
        public List<Sys_UserET> GetAll_Sys_User_Paging(int USERID, string KeyWord, string loginName, Guid UnitID, int UsedState, int page, int rownum, out long totalRows)
        {
            try
            {
                totalRows = 0;
                List<Sys_UserET> lstSys_UserET = new List<Sys_UserET>();
                DataTable tblSys_UserET = GetTableByProcedurePaging("sp_Sys_User_SearchPaging", new object[] { USERID, loginName, KeyWord, UsedState, UnitID, page, rownum, 0 }, out totalRows);
                for (int i = 0; i < tblSys_UserET.Rows.Count; i++)
                {
                    lstSys_UserET.Add(setProperties(tblSys_UserET.Rows[i]));
                }
                return lstSys_UserET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " GetAll_.._Paging", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		05/04/2016		Tạo mới
        ///</Modified>
        public List<Sys_UserET> GetAll_Sys_User()
        {
            try
            {
                List<Sys_UserET> lstSys_UserET = new List<Sys_UserET>();
                DataTable tblSys_UserET = GetTableByProcedure("sp_GetAll_Sys_User");
                for (int i = 0; i < tblSys_UserET.Rows.Count; i++)
                {
                    lstSys_UserET.Add(setProperties(tblSys_UserET.Rows[i]));
                }
                return lstSys_UserET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " GetAll_..", ex.Message);
                throw ex;
            }
        }

        public bool CheckAccountLoginName(string LoginName)
        {
            try
            {
                DataTable tblSys_UserET = GetTableByProcedure("sp_CheckAccountLoginName_Sys_User", LoginName);
                if (tblSys_UserET.Rows.Count > 0)
                {
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " GetInfo", ex.Message);
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
        ///Bachdx		05/04/2016Tạo mới
        ///</Modified>
        public Sys_UserET GetInfo(string intItemID)
        {
            try
            {
                Sys_UserET objSys_UserET = new Sys_UserET();
                DataTable tblSys_UserET = new DataTable();
                using (IDataReader oReader = GetIDataReader("sp_GetByPK_Sys_User_New", intItemID))
                {
                    if (oReader.Read())
                    {
                        if (oReader["UserID"] != DBNull.Value)
                            objSys_UserET.UserID = Convert.ToInt32(oReader["UserID"]);
                        if (oReader["UnitID"] != DBNull.Value)
                            objSys_UserET.UnitID = new Guid(Convert.ToString(oReader["UnitID"]));
                        if (Pvn.Utils.Common.ReaderContainsColumn(oReader, "UnitName") && oReader["UnitName"] != DBNull.Value)
                            objSys_UserET.UnitName = Convert.ToString(oReader["UnitName"]);

                        if (oReader["UserName"] != DBNull.Value)
                            objSys_UserET.UserName = Convert.ToString(oReader["UserName"]);
                        if (oReader["LoginName"] != DBNull.Value)
                            objSys_UserET.LoginName = Convert.ToString(oReader["LoginName"]);
                        if (oReader["LoginNameSP"] != DBNull.Value)
                            objSys_UserET.LoginNameSP = Convert.ToString(oReader["LoginNameSP"]);
                        if (oReader["RolePermission"] != DBNull.Value)
                            objSys_UserET.RolePermission = Convert.ToInt32(oReader["RolePermission"]);

                        if (Pvn.Utils.Common.ReaderContainsColumn(oReader, "RolePage") && oReader["RolePage"] != DBNull.Value)
                            objSys_UserET.RolePage = Convert.ToString(oReader["RolePage"]);

                        if (oReader["UsedState"] != DBNull.Value)
                            objSys_UserET.UsedState = Convert.ToInt32(oReader["UsedState"]);
                        if (oReader["Checksum"] != DBNull.Value)
                            objSys_UserET.Checksum = Convert.ToString(oReader["Checksum"]);
                        if (oReader["Tel"] != DBNull.Value)
                            objSys_UserET.Tel = Convert.ToString(oReader["Tel"]);
                        if (oReader["Email"] != DBNull.Value)
                            objSys_UserET.Email = Convert.ToString(oReader["Email"]);
                        if (oReader["Infor"] != DBNull.Value)
                            objSys_UserET.Infor = Convert.ToString(oReader["Infor"]);
                        if (oReader["ImagePath"] != DBNull.Value)
                            objSys_UserET.ImagePath = Convert.ToString(oReader["ImagePath"]);
                        if (oReader["Note"] != DBNull.Value)
                            objSys_UserET.Note = Convert.ToString(oReader["Note"]);
                        if (oReader["CreatedDate"] != DBNull.Value)
                            objSys_UserET.CreatedDate = Convert.ToDateTime(oReader["CreatedDate"]);
                        if (oReader["ModifiedDate"] != DBNull.Value)
                            objSys_UserET.ModifiedDate = Convert.ToDateTime(oReader["ModifiedDate"]);
                        return objSys_UserET;
                    }
                    return null;
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " GetInfo", ex.Message);
                throw ex;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_UserET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		05/04/2016Tạo mới
        ///</Modified>
        public bool Update(Sys_UserET objSys_UserET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateByPK_Sys_User"
                         , objSys_UserET.UserID
                         , objSys_UserET.UnitID
                         , objSys_UserET.UserName
                         , objSys_UserET.LoginName
                         , objSys_UserET.RolePermission
                         , objSys_UserET.UsedState
                         , objSys_UserET.Checksum
                         , objSys_UserET.Tel
                         , objSys_UserET.Email
                         , objSys_UserET.Infor
                         , objSys_UserET.ImagePath
                         , objSys_UserET.Note
                         , objSys_UserET.CreatedDate
                         , objSys_UserET.ModifiedDate
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="Sys_UserET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		05/04/2016Tạo mới
        ///</Modified>
        public bool UpdateRole(Sys_UserET objSys_UserET)
        {
            try
            {
                ExecuteNonQuery("sp_UpdateRoleByPK_Sys_User"
                         , objSys_UserET.UserID
                         , objSys_UserET.RolePermission
                );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " Update", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="Sys_UserET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		05/04/2016Tạo mới
        ///</Modified>
        public bool Insert(Sys_UserET objSys_UserET)
        {
            try
            {
                ExecuteNonQuery("sp_Add_Sys_User",
                            objSys_UserET.UserID,
                            objSys_UserET.UnitID
                            , objSys_UserET.UserName
                            , objSys_UserET.LoginName
                             ,objSys_UserET.LoginNameSP
                            , objSys_UserET.RolePermission
                            , objSys_UserET.UsedState
                            , objSys_UserET.Checksum
                            , objSys_UserET.Tel
                            , objSys_UserET.Email
                            , objSys_UserET.Infor
                            , objSys_UserET.ImagePath
                            , objSys_UserET.Note
                   );
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " Insert", ex.Message);
                return false;
            }
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="Sys_UserET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		05/04/2016		Tạo mới
        ///</Modified>
        public bool Delete(int GuidID)
        {
            try
            {
                ExecuteNonQuery("sp_RemoveByPK_Sys_User", GuidID);
                return true;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Sys_UserDA", " Delete", ex.Message);
                return false;
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.Utils;
using Pvn.DA;
namespace Pvn.BL
{
    public class SysRoleBL
    {
        #region Biến + thuộc tính
        SysRoleDA objDA;
        public SysRoleBL()
        {
            objDA = new SysRoleDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public bool Insert(SysRoleET objSysRoleET)
        {
            try
            {
                return objDA.Insert(objSysRoleET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public List<SysRoleET> GetAll_SysRole_By_default(Guid? FunctionID, int userID, int ViTri)
        {
            return objDA.GetAll_SysRole_By_default(FunctionID, userID, ViTri);
        }

        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(SysRoleET objSysRoleET)
        {
            return objDA.Update(objSysRoleET);
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
                return objDA.Delete(GuidID);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysRoleET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(int RoleID)
        {
            return objDA.DeleteOutMesage(RoleID);
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
                return objDA.GetAll_SysRole_Paging(p_search, FunctionID, page, rownum, out totalRows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SysRoleET> GetAll_SysRole_ByFunction(Guid? functionID)
        {
            try
            {
                return objDA.GetAll_SysRole_ByFunction( functionID );
            }
            catch (Exception ex)
            {
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
                return objDA.GetAll_SysRole();
            }
            catch (Exception ex)
            {
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
                return objDA.GetInfo(intItemID);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion Function
    }
}


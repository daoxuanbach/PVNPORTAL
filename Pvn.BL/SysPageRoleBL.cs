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
    public class SysPageRoleBL
    {
        #region Biến + thuộc tính
        SysPageRoleDA objDA;
        public SysPageRoleBL()
        {
            objDA = new SysPageRoleDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public bool Insert(SysPageRoleET objSysPageRoleET)
        {
            try
            {
                return objDA.Insert(objSysPageRoleET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(SysPageRoleET objSysPageRoleET)
        {
            return objDA.Update(objSysPageRoleET);
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="SysPageRoleET">Entity</param>
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
        ///<param name="SysPageRoleET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public MessageUtil DeleteOutMesage(Guid GuidID)
        {
            return objDA.DeleteOutMesage(GuidID);
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
        public List<SysPageRoleET> GetAll_SysPageRole_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_SysPageRole_Paging(p_search, page, rownum, out totalRows);
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
        public List<SysPageRoleET> GetAll_SysPageRole()
        {
            try
            {
                return objDA.GetAll_SysPageRole();
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
        public SysPageRoleET GetInfo(Guid intItemID)
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


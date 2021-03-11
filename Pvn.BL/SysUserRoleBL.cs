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
	public class SysUserRoleBL
	{
	#region Biến + thuộc tính
	 SysUserRoleDA objDA;
	public SysUserRoleBL()
	{
	   objDA = new SysUserRoleDA();
	}
	#endregion
	#region Function
		///<summary>
		///Thêm mới
		///</summary>
		///<param name="SysUserRoleET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		06/01/2017Tạo mới
		///</Modified>
		public int Insert(SysUserRoleET objSysUserRoleET)
		{
			try
			{
			return objDA.Insert(objSysUserRoleET);
			}
			catch (Exception ex)
			{
			 return 0;
			}
		}
		///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="SysUserRoleET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		06/01/2017Tạo mới
		///</Modified>
		public MessageUtil Update(SysUserRoleET objSysUserRoleET)
		{
			return objDA.Update(objSysUserRoleET);
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="SysUserRoleET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		06/01/2017		Tạo mới
		///</Modified>
		public bool DeleteRoleByUser(int UserID)
		{
			try
			{
			  return objDA.DeleteRoleByUser(UserID);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="SysUserRoleET">Entity</param>
		///<returns>MessageUtil</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		06/01/2017		Tạo mới
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
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public List<SysUserRoleET> GetAll_SysUserRole_Paging(string p_search, int page, int rownum, out long totalRows)
		{
			try
			{
			 return objDA.GetAll_SysUserRole_Paging(p_search, page,rownum, out totalRows);
			}
			catch (Exception ex)
			{
			throw ex;
			}
		}

        public List<SysUserRoleET> GetAll_SysUserRole_Where(Guid? functionID, int userID)
        {
            return objDA.GetAll_SysUserRole_Where(functionID, userID);
        }

        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public List<SysUserRoleET> GetAll_SysUserRole()
		{
			try
			{
			return objDA.GetAll_SysUserRole();			}
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
		///Bachdx		06/01/2017Tạo mới
		///</Modified>
		public SysUserRoleET GetInfo(Guid intItemID)
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


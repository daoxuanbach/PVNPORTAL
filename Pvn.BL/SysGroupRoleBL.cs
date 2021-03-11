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
	public class SysGroupRoleBL
	{
	#region Biến + thuộc tính
	 SysGroupRoleDA objDA;
	public SysGroupRoleBL()
	{
	   objDA = new SysGroupRoleDA();
	}
	#endregion
	#region Function
		///<summary>
		///Thêm mới
		///</summary>
		///<param name="SysGroupRoleET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		09/01/2017Tạo mới
		///</Modified>
		public bool Insert(SysGroupRoleET objSysGroupRoleET)
		{
			try
			{
			return objDA.Insert(objSysGroupRoleET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="SysGroupRoleET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		09/01/2017Tạo mới
		///</Modified>
		public MessageUtil Update(SysGroupRoleET objSysGroupRoleET)
		{
			return objDA.Update(objSysGroupRoleET);
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="SysGroupRoleET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		09/01/2017		Tạo mới
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
		///<param name="SysGroupRoleET">Entity</param>
		///<returns>MessageUtil</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		09/01/2017		Tạo mới
		///</Modified>
		public MessageUtil DeleteOutMesage(Guid GuidID)
		{
			  return objDA.DeleteOutMesage(GuidID);
		}

        public List<SysGroupRoleET> GetAll_SysGroupRole_Where(Guid? functionID, Guid groupID)
        {
            return objDA.GetAll_SysGroupRole_Where(functionID, groupID);
        }

        public bool DeleteRoleByGroup(Guid groupID)
        {
            return objDA.DeleteRoleByGroup(groupID);
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
        ///Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        public List<SysGroupRoleET> GetAll_SysGroupRole_Paging(string p_search, int page, int rownum, out long totalRows)
		{
			try
			{
			 return objDA.GetAll_SysGroupRole_Paging(p_search, page,rownum, out totalRows);
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
		///Bachdx		09/01/2017		Tạo mới
		///</Modified>
		public List<SysGroupRoleET> GetAll_SysGroupRole()
		{
			try
			{
			return objDA.GetAll_SysGroupRole();			}
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
		///Bachdx		09/01/2017Tạo mới
		///</Modified>
		public SysGroupRoleET GetInfo(Guid intItemID)
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


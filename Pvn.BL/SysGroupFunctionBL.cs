using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using Pvn.Utils;
using System.Data;
namespace Pvn.BL
{
	public class SysGroupFunctionBL
	{
	#region Biến + thuộc tính
	 SysGroupFunctionDA objDA;
	public SysGroupFunctionBL()
	{
	   objDA = new SysGroupFunctionDA();
	}
	#endregion
	#region Function
		///<summary>
		///Thêm mới
		///</summary>
		///<param name="SysGroupFunctionET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		26/08/2016Tạo mới
		///</Modified>
		public bool Insert(SysGroupFunctionET objSysGroupFunctionET)
		{
			try
			{
			return objDA.Insert(objSysGroupFunctionET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Sửa thông tin
		///</summary>
		///<param name="SysGroupFunctionET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		26/08/2016Tạo mới
		///</Modified>
		public bool Update(SysGroupFunctionET objSysGroupFunctionET)
		{
			try
			{
			return objDA.Update(objSysGroupFunctionET);
			}
			catch (Exception ex)
			{
			 return false;
			}
		}
		///<summary>
		///Delete
		///</summary>
		///<param name="SysGroupFunctionET">Entity</param>
		///<returns>bool</returns>
		///<Modified>
		///Author		Date		Comment
		///Bachdx		26/08/2016		Tạo mới
		///</Modified>
        public MessageUtil Delete(Guid GuidID)
		{
            return objDA.Delete(GuidID);
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
		///Bachdx		26/08/2016		Tạo mới
		///</Modified>
		public List<SysGroupFunctionET> GetAll_SysGroupFunction_Paging(string p_search, int page, int rownum, out long totalRows)
		{
			try
			{
			 return objDA.GetAll_SysGroupFunction_Paging(p_search, page,rownum, out totalRows);
			}
			catch (Exception ex)
			{
			throw ex;
			}
		}

        public DataTable GetAll_SysGroupFunction_By_GroupID(Guid GroupID, string Language, int UsedState)
        {
            try
            {
                return objDA.GetAll_SysGroupFunction_By_GroupID(GroupID, Language, UsedState);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public List<SysGroupFunctionET> GetAllET_SysGroupFunction_By_GroupID(Guid GroupID, string Language, int UsedState)
        {
            try
            {
                return objDA.GetAllET_SysGroupFunction_By_GroupID(GroupID, Language, UsedState);
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
		///Bachdx		26/08/2016		Tạo mới
		///</Modified>
		public List<SysGroupFunctionET> GetAll_SysGroupFunction()
		{
			try
			{
			return objDA.GetAll_SysGroupFunction();			}
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
		///Bachdx		26/08/2016Tạo mới
		///</Modified>
		public SysGroupFunctionET GetInfo(Guid intItemID)
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


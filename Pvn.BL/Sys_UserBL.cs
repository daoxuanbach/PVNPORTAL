using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using Pvn.Utils;
using Microsoft.SharePoint;

namespace Pvn.BL
{
    public class Sys_UserBL
    {
        #region Biến + thuộc tính
        Sys_UserDA objDA;
        public Sys_UserBL()
        {
            objDA = new Sys_UserDA();
        }
        #endregion
        #region Function

        public Sys_UserET Login(string loginName, string MatKhau)
        {
            try
            {
                return objDA.Login(loginName, MatKhau);
            }
            catch (Exception ex)
            {
                throw ex;
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
                return objDA.Insert(objSys_UserET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool CheckRole(string filename)
        {
            int uSERID = GetUserLogin();
            //return objDA.CheckRole(uSERID, filename);
            if (uSERID != 1)
            {
                return objDA.CheckRole(uSERID, filename);
            }
            else return true;

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
                return objDA.Update(objSys_UserET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool uppPass(Sys_UserET objSys_UserET)
        {
            try
            {
                return objDA.uppPass(objSys_UserET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public bool UserUpdate(Sys_UserET objSys_UserET)
        {
            try
            {
                return objDA.UserUpdate(objSys_UserET);
            }
            catch (Exception ex)
            {
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
        public bool UpdateRole(Sys_UserET objET)
        {
            try
            {
                return objDA.UpdateRole(objET);
            }
            catch (Exception ex)
            {
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
                return objDA.Delete(GuidID);
            }
            catch (Exception ex)
            {
                return false;
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

        public List<Sys_UserET> GetAll_Sys_User_Paging(int UserID, string KeyWord, string loginName, Guid ParentUnitID, int UsedState, int page, int rownum, out long totalRows)
        {
            return objDA.GetAll_Sys_User_Paging(UserID, KeyWord, loginName, ParentUnitID, UsedState, page, rownum, out totalRows);
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
                return objDA.GetAll_Sys_User();
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
        ///Bachdx		05/04/2016Tạo mới
        ///</Modified>
        public Sys_UserET GetInfo(string intItemID)
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
        public bool CheckAccountLoginName(string loginName)
        {
            try
            {
                return objDA.CheckAccountLoginName(loginName);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int GetUserLogin()
        {
            try
            {
                return 1;
                //if (SPContext.Current.Web.UserIsWebAdmin)
                //{
                //    return 1;
                //}
                //else
                //{
                //    if (SPContext.Current.Web.CurrentUser != null)
                //    {
                //        int uSERid = SPContext.Current.Web.CurrentUser.ID;
                //        return uSERid;
                //    }
                //    else
                //    {
                //        return 0;
                //    }
                //}
            }
            catch (Exception)
            {

                return 0;
            }
        }
        public string GetUserLoginName()
        {
            return SessionUtil.USERNAME;
        }


        #endregion Function




    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.Utils;
using Pvn.DA;
using System.Data;
namespace Pvn.BL
{
    public class CMS_VideoCategoryBL
    {
        #region Biến + thuộc tính
        CMS_VideoCategoryDA objDA;
        public CMS_VideoCategoryBL()
        {
            objDA = new CMS_VideoCategoryDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_VideoCategoryET objCMS_VideoCategoryET)
        {
            try
            {
                return objDA.Insert(objCMS_VideoCategoryET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_VideoCategoryET objCMS_VideoCategoryET)
        {
            return objDA.Update(objCMS_VideoCategoryET);
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public MessageUtil Delete(Guid GuidID)
        {
            return objDA.Delete(GuidID);
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_VideoCategoryET">Entity</param>
        ///<returns>MessageUtil</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
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
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_VideoCategoryET> GetAll_CMS_VideoCategory_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_CMS_VideoCategory_Paging(p_search, page, rownum, out totalRows);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable GetTreeAdmin(string currentLanguage, string Language, short UsedState)
        {
            return objDA.GetTreeAdmin(currentLanguage, Language, UsedState);
        }

        public DataTable GetTree(string currentLanguage, string Language)
        {
            return objDA.GetTree(currentLanguage, Language);
        }
        ///<summary>
        ///Hàm lấy danh sách trả về đối tượng List
        ///</summary>
        ///<returns>List</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_VideoCategoryET> GetAll_CMS_VideoCategory()
        {
            try
            {
                return objDA.GetAll_CMS_VideoCategory();
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
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public CMS_VideoCategoryET GetInfo(Guid intItemID)
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


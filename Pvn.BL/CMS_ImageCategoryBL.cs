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
    public class CMS_ImageCategoryBL
    {
        #region Biến + thuộc tính
        CMS_ImageCategoryDA objDA;
        public CMS_ImageCategoryBL()
        {
            objDA = new CMS_ImageCategoryDA();
        }
        #endregion
        #region Function
        ///<summary>
        ///Thêm mới
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public bool Insert(CMS_ImageCategoryET objCMS_ImageCategoryET)
        {
            try
            {
                return objDA.Insert(objCMS_ImageCategoryET);
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        ///<summary>
        ///Sửa thông tin
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
        ///<returns>bool</returns>
        ///<Modified>
        ///Author		Date		Comment
        ///Bachdx		06/09/2016Tạo mới
        ///</Modified>
        public MessageUtil Update(CMS_ImageCategoryET objCMS_ImageCategoryET)
        {
            return objDA.Update(objCMS_ImageCategoryET);
        }
        ///<summary>
        ///Delete
        ///</summary>
        ///<param name="CMS_ImageCategoryET">Entity</param>
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
        ///<param name="CMS_ImageCategoryET">Entity</param>
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
        public List<CMS_ImageCategoryET> GetAll_CMS_ImageCategory_Paging(string p_search, int page, int rownum, out long totalRows)
        {
            try
            {
                return objDA.GetAll_CMS_ImageCategory_Paging(p_search, page, rownum, out totalRows);
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
        ///Bachdx		06/09/2016		Tạo mới
        ///</Modified>
        public List<CMS_ImageCategoryET> GetAll_CMS_ImageCategory()
        {
            try
            {
                return objDA.GetAll_CMS_ImageCategory();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Lay cay chuyen muc anh
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="language"></param>
        /// <param name="usedState"></param>
        /// <returns></returns>
        /// <remarks>
        ///     1. ImageCategoryList.ComboBox
        ///     2. ImageCategoryEdit.ComboBox
        ///     3. ImageEdit.ComboBox
        ///     4. ImageList.ComboBox
        /// </remarks>
        public DataTable GetTree(string currentLanguage, string language)
        {
           
            return objDA.GetTree(currentLanguage, language);
        }
        /// <summary>
        /// Tao cay trong phan quan tri
        /// </summary>
        /// <param name="currentLanguage"></param>
        /// <param name="language"></param>
        /// <param name="usedState"></param>
        /// <returns></returns>
        /// <remarks>
        ///     1. ImageCategoryList.Grid
        /// </remarks>
        public DataTable GetTreeAdmin(string currentLanguage, string language, short? usedState)
        {

            return objDA.GetTreeAdmin(currentLanguage, language, usedState);
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
        public CMS_ImageCategoryET GetInfo(Guid intItemID)
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


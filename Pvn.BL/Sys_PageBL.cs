using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.BL
{
   public class Sys_PageBL
   {
       #region Constructors
       Sys_PageDA objDA;
       public Sys_PageBL()
        {
            objDA = new Sys_PageDA();
        }
       #endregion Constructors
        #region Function
        /// <summary> 
        ///Xóa thông tin quản trị chức năng
        /// </summary> 
        /// <param name="Sys_PageET">Entity quản trị chức năng</param> 
        ///<returns>Trả về giá trị kiểu boolean</returns> 
       public MessageUtil Delete(Guid PageID)
        {
            return objDA.Delete(PageID);
        }
        /// <summary> 
        ///Thêm mới thông tin bảo quản kho
        /// </summary> 
        /// <param name="Sys_PageET">Entity bảo quản kho</param> 
        /// ///<returns>Trả về giá trị kiểu int</returns> 
        public bool Insert(Sys_PageET objSys_PageET)
        {
            return objDA.Insert(objSys_PageET);
        }
        /// <summary> 
        ///Sửa thông tin bảo quản kho
        /// </summary> 
        /// <param name="Sys_PageET">Entity bảo quản kho</param> 
        ///<returns>Trả về giá trị kiểu boolean</returns> 
        public bool Update(Sys_PageET objSys_PageET)
        {
            return objDA.Update(objSys_PageET);
        }
        /// <summary> 
        ///Lấy thông tin bảo quản kho theo id
        /// </summary> 
        /// <param name="ID">Id của bản ghi Sys_PageET</param> 
        /// <returns>Trả về thông tin Sys_PageET </returns> 
        public Sys_PageET GetInfo(Guid ID)
        {
            return objDA.GetInfo(ID);
        }
        /// <summary> 
        ///Lấy toàn bộ thông tin trong bảng Sys_PageET
        /// </summary> 
        /// <returns>Trả về kiểu List Sys_PageET </returns> 
        public List<Sys_PageET> GetAll_Sys_Page()
        {
            return objDA.GetAll_Sys_Page();
        }
        public List<Sys_PageET> GetAll_Sys_Paging(string p_search, Guid? ParentPageID, int page, int rownum, out long totalRows)
        {
            return objDA.GetAll_Sys_Paging(p_search, ParentPageID, page, rownum, out totalRows);
        }

        #endregion Function
   }
}

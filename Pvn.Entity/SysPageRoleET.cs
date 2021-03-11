using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class SysPageRoleET : BaseET
    {
        #region Attributes
        public const String FIELD_Id = "Id";
        public const String FIELD_PageID = "PageID";
        public const String FIELD_RoleId = "RoleId";
        #endregion Attributes
        /// <summary>
        ///Id Id
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }
        /// <summary>
        ///PageID PageID
        /// </summary>
        private Guid? _PageID;
        public Guid? PageID { get { return _PageID; } set { _PageID = value; } }
        /// <summary>
        ///RoleId RoleId
        /// </summary>
        private int? _RoleId;
        public int? RoleId { get { return _RoleId; } set { _RoleId = value; } }
        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		29/12/2016		Tạo mới
        ///</Modified>
        public SysPageRoleET()
        {
            Id = 0;
            PageID = Guid.Empty;
            RoleId = 0;
        }
    }
}


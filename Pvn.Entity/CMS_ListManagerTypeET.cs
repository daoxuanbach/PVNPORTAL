using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_ListManagerTypeET : BaseET
    {
        #region Attributes
        public const String FIELD_ManagerTypeID = "ManagerTypeID";
        public const String FIELD_ManagerID = "ManagerID";
        public const String FIELD_ManagerType = "ManagerType";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_JobTitle = "JobTitle";
        public const String FIELD_JobTitleName = "JobTitleName";
        #endregion Attributes
        /// <summary>
        ///ManagerTypeID ManagerTypeID
        /// </summary>
        private int _ManagerTypeID;
        public int ManagerTypeID { get { return _ManagerTypeID; } set { _ManagerTypeID = value; } }
        /// <summary>
        ///ManagerID ManagerID
        /// </summary>
        private int? _ManagerID;
        public int? ManagerID { get { return _ManagerID; } set { _ManagerID = value; } }
        /// <summary>
        ///ManagerType ManagerType
        /// </summary>
        private int? _ManagerType;
        public int? ManagerType { get { return _ManagerType; } set { _ManagerType = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///JobTitle JobTitle
        /// </summary>
        private int? _JobTitle;
        public int? JobTitle { get { return _JobTitle; } set { _JobTitle = value; } }
        /// <summary>
        ///JobTitleName JobTitleName
        /// </summary>
        private string _JobTitleName;
        public string JobTitleName { get { return _JobTitleName; } set { _JobTitleName = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		10/09/2017		Tạo mới
        ///</Modified>
        public CMS_ListManagerTypeET()
        {
            //ManagerTypeID = 0;
            //ManagerID = 0;
            //ManagerType = 0;
            //Ordinal = 0;
            //JobTitle = 0;
            //JobTitleName = string.Empty;
        }
    }
}

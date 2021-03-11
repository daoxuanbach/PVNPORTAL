using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_ScheduleManagerET : BaseET
    {
        #region Attributes
        public const String FIELD_SheduleManagerID = "SheduleManagerID";
        public const String FIELD_SheduleID = "SheduleID";
        public const String FIELD_ManagerID = "ManagerID";
        public const String FIELD_SheduleRole = "SheduleRole";
        #endregion Attributes
        /// <summary>
        ///SheduleManagerID SheduleManagerID
        /// </summary>
        private int _SheduleManagerID;
        public int SheduleManagerID { get { return _SheduleManagerID; } set { _SheduleManagerID = value; } }
        /// <summary>
        ///SheduleID SheduleID
        /// </summary>
        private int _SheduleID;
        public int SheduleID { get { return _SheduleID; } set { _SheduleID = value; } }
        /// <summary>
        ///ManagerID ManagerID
        /// </summary>
        private int _ManagerID;
        public int ManagerID { get { return _ManagerID; } set { _ManagerID = value; } }
        /// <summary>
        ///SheduleRole SheduleRole
        /// </summary>
        private int? _SheduleRole;
        public int? SheduleRole { get { return _SheduleRole; } set { _SheduleRole = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		12/09/2017		Tạo mới
        ///</Modified>
        public CMS_ScheduleManagerET()
        {
            //SheduleManagerID = 0;
            //SheduleID = 0;
            //ManagerID = 0;
            //SheduleRole = 0;
        }
    }
}

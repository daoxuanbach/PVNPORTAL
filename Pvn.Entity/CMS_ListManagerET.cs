using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_ListManagerET : BaseET
    {
        #region Attributes
        public const String FIELD_ManagerID = "ManagerID";
        public const String FIELD_Code = "Code";
        public const String FIELD_Name = "Name";
        public const String FIELD_ShortName = "ShortName";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_ManagerType = "ManagerType";
        public const String FIELD_IconPath = "IconPath";
        public const String FIELD_Information = "Information";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_WorkerID = "WorkerID";
        #endregion Attributes
        /// <summary>
        ///ManagerID ManagerID
        /// </summary>
        private int _ManagerID;
        public int ManagerID { get { return _ManagerID; } set { _ManagerID = value; } }
        /// <summary>
        ///Code Code
        /// </summary>
        private string _Code;
        public string Code { get { return _Code; } set { _Code = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///ShortName ShortName
        /// </summary>
        private string _ShortName;
        public string ShortName { get { return _ShortName; } set { _ShortName = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///ManagerType ManagerType
        /// </summary>
        private int? _ManagerType;
        public int? ManagerType { get { return _ManagerType; } set { _ManagerType = value; } }
        /// <summary>
        ///IconPath IconPath
        /// </summary>
        private string _IconPath;
        public string IconPath { get { return _IconPath; } set { _IconPath = value; } }
        /// <summary>
        ///Information Information
        /// </summary>
        private string _Information;
        public string Information { get { return _Information; } set { _Information = value; } }
        /// <summary>
        ///CreatedBy CreatedBy
        /// </summary>
        private string _CreatedBy;
        public string CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        /// <summary>
        ///CreatedDate CreatedDate
        /// </summary>
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        /// <summary>
        ///ModifiedBy ModifiedBy
        /// </summary>
        private string _ModifiedBy;
        public string ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        /// <summary>
        ///ModifiedDate ModifiedDate
        /// </summary>
        private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///WorkerID WorkerID
        /// </summary>
        private int? _WorkerID;
        public int? WorkerID { get { return _WorkerID; } set { _WorkerID = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		18/08/2017		Tạo mới
        ///</Modified>
        public CMS_ListManagerET()
        {
            //ManagerID = 0;
            //Code = string.Empty;
            //Name = string.Empty;
            //ShortName = string.Empty;
            //Ordinal = 0;
            //ManagerType = 0;
            //IconPath = string.Empty;
            //Information = string.Empty;
            //UsedState = 0;
            //WorkerID = 0;
        }
    }
}

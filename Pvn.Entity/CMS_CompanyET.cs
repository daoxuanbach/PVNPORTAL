using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_CompanyET : BaseET
    {
        #region Attributes
        public const String FIELD_CompanyID = "CompanyID";
        public const String FIELD_CompanyName = "CompanyName";
        public const String FIELD_InternationalName = "InternationalName";
        public const String FIELD_ShortName = "ShortName";
        public const String FIELD_OrderNumber = "OrderNumber";
        public const String FIELD_ParentCompanyID = "ParentCompanyID";
        public const String FIELD_CompanyLevel = "CompanyLevel";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_Information = "Information";
        public const String FIELD_Note = "Note";
        public const String FIELD_CompanyType = "CompanyType";
        #endregion Attributes
        /// <summary>
        ///CompanyID CompanyID
        /// </summary>
        private int _CompanyID;
        public int CompanyID { get { return _CompanyID; } set { _CompanyID = value; } }
        /// <summary>
        ///CompanyName CompanyName
        /// </summary>
        private string _CompanyName;
        public string CompanyName { get { return _CompanyName; } set { _CompanyName = value; } }
        /// <summary>
        ///InternationalName InternationalName
        /// </summary>
        private string _InternationalName;
        public string InternationalName { get { return _InternationalName; } set { _InternationalName = value; } }
        /// <summary>
        ///ShortName ShortName
        /// </summary>
        private string _ShortName;
        public string ShortName { get { return _ShortName; } set { _ShortName = value; } }
        /// <summary>
        ///OrderNumber OrderNumber
        /// </summary>
        private int? _OrderNumber;
        public int? OrderNumber { get { return _OrderNumber; } set { _OrderNumber = value; } }
        /// <summary>
        ///ParentCompanyID ParentCompanyID
        /// </summary>
        private int? _ParentCompanyID;
        public int? ParentCompanyID { get { return _ParentCompanyID; } set { _ParentCompanyID = value; } }
        /// <summary>
        ///CompanyLevel CompanyLevel
        /// </summary>
        private int? _CompanyLevel;
        public int? CompanyLevel { get { return _CompanyLevel; } set { _CompanyLevel = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///Information Information
        /// </summary>
        private string _Information;
        public string Information { get { return _Information; } set { _Information = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private int? _Note;
        public int? Note { get { return _Note; } set { _Note = value; } }
        /// <summary>
        ///CreatedDate CreatedDate
        /// </summary>
        private DateTime? _CreatedDate;
        public DateTime? CreatedDate { get { return _CreatedDate; } set { _CreatedDate = value; } }
        /// <summary>
        ///CreatedBy CreatedBy
        /// </summary>
        private int? _CreatedBy;
        public int? CreatedBy { get { return _CreatedBy; } set { _CreatedBy = value; } }
        /// <summary>
        ///ModifiedDate ModifiedDate
        /// </summary>
        private DateTime? _ModifiedDate;
        public DateTime? ModifiedDate { get { return _ModifiedDate; } set { _ModifiedDate = value; } }
        /// <summary>
        ///ModifiedBy ModifiedBy
        /// </summary>
        private int? _ModifiedBy;
        public int? ModifiedBy { get { return _ModifiedBy; } set { _ModifiedBy = value; } }
        /// <summary>
        ///CompanyType CompanyType
        /// </summary>
        private int? _CompanyType;
        public int? CompanyType { get { return _CompanyType; } set { _CompanyType = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		24/07/2017		Tạo mới
        ///</Modified>
        public CMS_CompanyET()
        {
            //CompanyID = 0;
            //CompanyName = string.Empty;
            //InternationalName = string.Empty;
            //ShortName = string.Empty;
            //OrderNumber = 0;
            //ParentCompanyID = 0;
            //CompanyLevel = 0;
            //UsedState = 0;
            //Information = string.Empty;
            //Note = 0;
            //CompanyType = 0;
        }
    }
}

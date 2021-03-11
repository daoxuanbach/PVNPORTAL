using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_JobTitleET : BaseET
    {
        #region Attributes
        public const String FIELD_JobTitleID = "JobTitleID";
        public const String FIELD_JobTitle = "JobTitle";
        public const String FIELD_JobTitleEng = "JobTitleEng";
        public const String FIELD_CompanyLevel = "CompanyLevel";
        public const String FIELD_OrderNumber = "OrderNumber";
        public const String FIELD_UsedState = "UsedState";
        #endregion Attributes
        /// <summary>
        ///JobTitleID JobTitleID
        /// </summary>
        private int _JobTitleID;
        public int JobTitleID { get { return _JobTitleID; } set { _JobTitleID = value; } }
        /// <summary>
        ///JobTitle JobTitle
        /// </summary>
        private string _JobTitle;
        public string JobTitle { get { return _JobTitle; } set { _JobTitle = value; } }
        /// <summary>
        ///JobTitleEng JobTitleEng
        /// </summary>
        private string _JobTitleEng;
        public string JobTitleEng { get { return _JobTitleEng; } set { _JobTitleEng = value; } }
        /// <summary>
        ///CompanyLevel CompanyLevel
        /// </summary>
        private int? _CompanyLevel;
        public int? CompanyLevel { get { return _CompanyLevel; } set { _CompanyLevel = value; } }
        /// <summary>
        ///OrderNumber OrderNumber
        /// </summary>
        private int? _OrderNumber;
        public int? OrderNumber { get { return _OrderNumber; } set { _OrderNumber = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
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
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		13/07/2017		Tạo mới
        ///</Modified>
        public CMS_JobTitleET()
        {
            //JobTitleID = 0;
            //JobTitle = string.Empty;
            //JobTitleEng = string.Empty;
            //CompanyLevel = 0;
            //OrderNumber = 0;
            //UsedState = 0;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_CompanyJobTitleET : BaseET
    {
        #region Attributes
        public const String FIELD_CompanyJobID = "CompanyJobID";
        public const String FIELD_CompanyID = "CompanyID";
        public const String FIELD_JobTitleID = "JobTitleID";
        public const String FIELD_WorkerID = "WorkerID";
        public const String FIELD_OrderNumber = "OrderNumber";
        #endregion Attributes
        /// <summary>
        ///CompanyJobID CompanyJobID
        /// </summary>
        private int _CompanyJobID;
        public int CompanyJobID { get { return _CompanyJobID; } set { _CompanyJobID = value; } }
        /// <summary>
        ///CompanyID CompanyID
        /// </summary>
        private int? _CompanyID;
        public int? CompanyID { get { return _CompanyID; } set { _CompanyID = value; } }
        /// <summary>
        ///JobTitleID JobTitleID
        /// </summary>
        private int? _JobTitleID;
        public int? JobTitleID { get { return _JobTitleID; } set { _JobTitleID = value; } }
        /// <summary>
        ///WorkerID WorkerID
        /// </summary>
        private int? _WorkerID;
        public int? WorkerID { get { return _WorkerID; } set { _WorkerID = value; } }
        /// <summary>
        ///OrderNumber OrderNumber
        /// </summary>
        private int? _OrderNumber;
        public int? OrderNumber { get { return _OrderNumber; } set { _OrderNumber = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		17/08/2017		Tạo mới
        ///</Modified>
        public CMS_CompanyJobTitleET()
        {
            //CompanyJobID = 0;
            //CompanyID = 0;
            //JobTitleID = 0;
            //WorkerID = 0;
            //OrderNumber = 0;
        }
    }
}

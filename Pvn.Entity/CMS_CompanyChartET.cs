using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_CompanyChartET : BaseET
    {
        #region Attributes
        public const String FIELD_CompanyChartID = "CompanyChartID";
        public const String FIELD_CompanyTitle = "CompanyTitle";
        public const String FIELD_Ordinal = "Ordinal";
        public const String FIELD_Information = "Information";
        public const String FIELD_CompanyType = "CompanyType";
        public const String FIELD_IconPath = "IconPath";
        public const String FIELD_UsedState = "UsedState";
        #endregion Attributes
        /// <summary>
        ///CompanyChartID CompanyChartID
        /// </summary>
        private int _CompanyChartID;
        public int CompanyChartID { get { return _CompanyChartID; } set { _CompanyChartID = value; } }
        /// <summary>
        ///CompanyTitle CompanyTitle
        /// </summary>
        private string _CompanyTitle;
        public string CompanyTitle { get { return _CompanyTitle; } set { _CompanyTitle = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
        /// <summary>
        ///Information Information
        /// </summary>
        private string _Information;
        public string Information { get { return _Information; } set { _Information = value; } }
        /// <summary>
        ///CompanyType CompanyType
        /// </summary>
        private int? _CompanyType;
        public int? CompanyType { get { return _CompanyType; } set { _CompanyType = value; } }
        /// <summary>
        ///IconPath IconPath
        /// </summary>
        private string _IconPath;
        public string IconPath { get { return _IconPath; } set { _IconPath = value; } }
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
        /// Bachdx		23/08/2017		Tạo mới
        ///</Modified>
        public CMS_CompanyChartET()
        {
            //CompanyChartID = 0;
            //CompanyTitle = string.Empty;
            //Ordinal = 0;
            //Information = string.Empty;
            //CompanyType = 0;
            //IconPath = string.Empty;
            //UsedState = 0;
        }
    }
}

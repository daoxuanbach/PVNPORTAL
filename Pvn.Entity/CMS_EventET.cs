using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_EventET : BaseET
    {
        #region Attributes
        public const String FIELD_EventID = "EventID";
        public const String FIELD_Name = "Name";
        public const String FIELD_Body = "Body";
        public const String FIELD_BeginDate = "BeginDate";
        public const String FIELD_EndDate = "EndDate";
        public const String FIELD_EventType = "EventType";
        public const String FIELD_EventPlace = "EventPlace";
        public const String FIELD_OrgaUnit = "OrgaUnit";
        public const String FIELD_Estimate = "Estimate";
        public const String FIELD_FilePath = "FilePath";
        public const String FIELD_Note = "Note";
        public const String FIELD_Ordinal = "Ordinal";
        #endregion Attributes
        /// <summary>
        ///EventID EventID
        /// </summary>
        private int _EventID;
        public int EventID { get { return _EventID; } set { _EventID = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///Body Body
        /// </summary>
        private string _Body;
        public string Body { get { return _Body; } set { _Body = value; } }
        /// <summary>
        ///BeginDate BeginDate
        /// </summary>
        private DateTime? _BeginDate;
        public DateTime? BeginDate { get { return _BeginDate; } set { _BeginDate = value; } }
        /// <summary>
        ///EndDate EndDate
        /// </summary>
        private DateTime? _EndDate;
        public DateTime? EndDate { get { return _EndDate; } set { _EndDate = value; } }
        /// <summary>
        ///EventType EventType
        /// </summary>
        private int? _EventType;
        public int? EventType { get { return _EventType; } set { _EventType = value; } }
        /// <summary>
        ///EventPlace EventPlace
        /// </summary>
        private string _EventPlace;
        public string EventPlace { get { return _EventPlace; } set { _EventPlace = value; } }
        /// <summary>
        ///OrgaUnit OrgaUnit
        /// </summary>
        private string _OrgaUnit;
        public string OrgaUnit { get { return _OrgaUnit; } set { _OrgaUnit = value; } }
        /// <summary>
        ///Estimate Estimate
        /// </summary>
        private bool? _Estimate;
        public bool? Estimate { get { return _Estimate; } set { _Estimate = value; } }
        /// <summary>
        ///FilePath FilePath
        /// </summary>
        private string _FilePath;
        public string FilePath { get { return _FilePath; } set { _FilePath = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
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
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		16/05/2017		Tạo mới
        ///</Modified>
        public CMS_EventET()
        {
            Ordinal = 0;
        }
    }
}


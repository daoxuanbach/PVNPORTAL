using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_SchedulesET : BaseET
    {
        #region Attributes
        public const String FIELD_ScheduleID = "ScheduleID";
        public const String FIELD_Title = "Title";
        public const String FIELD_Descriptions = "Descriptions";
        public const String FIELD_Note = "Note";
        public const String FIELD_BeginDate = "BeginDate";
        public const String FIELD_BeginTime = "BeginTime";
        public const String FIELD_BeginPMAM = "BeginPMAM";
        public const String FIELD_BeginDayWeek = "BeginDayWeek";
        public const String FIELD_EndDate = "EndDate";
        public const String FIELD_FromAddress = "FromAddress";
        public const String FIELD_ToAddress = "ToAddress";
        public const String FIELD_Active = "Active";
        public const String FIELD_Private = "Private";
        #endregion Attributes
        /// <summary>
        ///ScheduleID ScheduleID
        /// </summary>
        private int _ScheduleID;
        public int ScheduleID { get { return _ScheduleID; } set { _ScheduleID = value; } }
        /// <summary>
        ///Title Title
        /// </summary>
        private string _Title;
        public string Title { get { return _Title; } set { _Title = value; } }
        /// <summary>
        ///Descriptions Descriptions
        /// </summary>
        private string _Descriptions;
        public string Descriptions { get { return _Descriptions; } set { _Descriptions = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
        /// <summary>
        ///BeginDate BeginDate
        /// </summary>
        private DateTime? _BeginDate;
        public DateTime? BeginDate { get { return _BeginDate; } set { _BeginDate = value; } }
        /// <summary>
        ///BeginTime BeginTime
        /// </summary>
        private DateTime? _BeginTime;
        public DateTime? BeginTime { get { return _BeginTime; } set { _BeginTime = value; } }
        /// <summary>
        ///BeginPMAM BeginPMAM
        /// </summary>
        private int? _BeginPMAM;
        public int? BeginPMAM { get { return _BeginPMAM; } set { _BeginPMAM = value; } }
        /// <summary>
        ///BeginDayWeek BeginDayWeek
        /// </summary>
        private int? _BeginDayWeek;
        public int? BeginDayWeek { get { return _BeginDayWeek; } set { _BeginDayWeek = value; } }
        /// <summary>
        ///EndDate EndDate
        /// </summary>
        private DateTime? _EndDate;
        public DateTime? EndDate { get { return _EndDate; } set { _EndDate = value; } }
        /// <summary>
        ///FromAddress FromAddress
        /// </summary>
        private string _FromAddress;
        public string FromAddress { get { return _FromAddress; } set { _FromAddress = value; } }
        /// <summary>
        ///ToAddress ToAddress
        /// </summary>
        private string _ToAddress;
        public string ToAddress { get { return _ToAddress; } set { _ToAddress = value; } }
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
        ///Active Active
        /// </summary>
        private bool? _Active;
        public bool? Active { get { return _Active; } set { _Active = value; } }
        /// <summary>
        ///Private Private
        /// </summary>
        private bool? _Private;
        public bool? Private { get { return _Private; } set { _Private = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		23/08/2017		Tạo mới
        ///</Modified>
        public CMS_SchedulesET()
        {
            //ScheduleID = 0;
            //Title = string.Empty;
            //Descriptions = string.Empty;
            //Note = string.Empty;
            //BeginDate = DateTime.Now;
            //BeginTime = string.Empty;
            //BeginPMAM = 0;
            //BeginDayWeek = 0;
            //EndDate = DateTime.Now;
            //FromAddress = string.Empty;
            //ToAddress = string.Empty;
            Active = false;
            Private = false;
        }
    }
}

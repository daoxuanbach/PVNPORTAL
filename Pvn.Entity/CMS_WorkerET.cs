using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_WorkerET : BaseET
    {
        #region Attributes
        public const String FIELD_WorkerID = "WorkerID";
        public const String FIELD_FirstName = "FirstName";
        public const String FIELD_LastName = "LastName";
        public const String FIELD_Images = "Images";
        public const String FIELD_BornDate = "BornDate";
        public const String FIELD_Sex = "Sex";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_Retire = "Retire";
        public const String FIELD_Note = "Note";
        #endregion Attributes
        /// <summary>
        ///WorkerID WorkerID
        /// </summary>
        private int _WorkerID;
        public int WorkerID { get { return _WorkerID; } set { _WorkerID = value; } }
        /// <summary>
        ///FirstName FirstName
        /// </summary>
        private string _FirstName;
        public string FirstName { get { return _FirstName; } set { _FirstName = value; } }
        /// <summary>
        ///LastName LastName
        /// </summary>
        private string _LastName;
        public string LastName { get { return _LastName; } set { _LastName = value; } }
        /// <summary>
        ///Images Images
        /// </summary>
        private string _Images;
        public string Images { get { return _Images; } set { _Images = value; } }
        /// <summary>
        ///BornDate BornDate
        /// </summary>
        private DateTime? _BornDate;
        public DateTime? BornDate { get { return _BornDate; } set { _BornDate = value; } }
        /// <summary>
        ///Sex Sex
        /// </summary>
        private bool? _Sex;
        public bool? Sex { get { return _Sex; } set { _Sex = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///Retire Retire
        /// </summary>
        private bool? _Retire;
        public bool? Retire { get { return _Retire; } set { _Retire = value; } }
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

        public string TaxCode { get; set; }
        public int CardID { get; set; }
        public string UserName { get; set; }

        public int CompanyJobID { get; set; }
        public int CompanyID { get; set; }
        public int JobTitleID { get; set; }
        public int OrderNumber { get; set; }
        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		24/07/2017		Tạo mới
        ///</Modified>
        public CMS_WorkerET()
        {
            //WorkerID = 0;
            //FirstName = string.Empty;
            //LastName = string.Empty;
            //Images = string.Empty;
            //BornDate = DateTime.Now;
            //Sex = false;
            //UsedState = 0;
            //Retire = false;
            //Note = 0;
        }
    }
}

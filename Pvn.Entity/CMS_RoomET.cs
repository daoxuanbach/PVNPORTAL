using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_RoomET : BaseET
    {
        #region Attributes
        public const String FIELD_RoomID = "RoomID";
        public const String FIELD_RoomCode = "RoomCode";
        public const String FIELD_RoomName = "RoomName";
        public const String FIELD_OrderNumber = "OrderNumber";
        public const String FIELD_Active = "Active";
        public const String FIELD_Deleted = "Deleted";
        public const String FIELD_RoomAddress = "RoomAddress";
        #endregion Attributes
        /// <summary>
        ///RoomID RoomID
        /// </summary>
        private int _RoomID;
        public int RoomID { get { return _RoomID; } set { _RoomID = value; } }
        /// <summary>
        ///RoomCode RoomCode
        /// </summary>
        private string _RoomCode;
        public string RoomCode { get { return _RoomCode; } set { _RoomCode = value; } }
        /// <summary>
        ///RoomName RoomName
        /// </summary>
        private string _RoomName;
        public string RoomName { get { return _RoomName; } set { _RoomName = value; } }
        /// <summary>
        ///OrderNumber OrderNumber
        /// </summary>
        private int? _OrderNumber;
        public int? OrderNumber { get { return _OrderNumber; } set { _OrderNumber = value; } }
        /// <summary>
        ///Active Active
        /// </summary>
        private bool? _Active;
        public bool? Active { get { return _Active; } set { _Active = value; } }
        /// <summary>
        ///Deleted Deleted
        /// </summary>
        private bool? _Deleted;
        public bool? Deleted { get { return _Deleted; } set { _Deleted = value; } }
        /// <summary>
        ///RoomAddress RoomAddress
        /// </summary>
        private string _RoomAddress;
        public string RoomAddress { get { return _RoomAddress; } set { _RoomAddress = value; } }
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
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		18/08/2017		Tạo mới
        ///</Modified>
        public CMS_RoomET()
        {
            //RoomID = 0;
            //RoomCode = string.Empty;
            //RoomName = string.Empty;
            //OrderNumber = 0;
            //Active = false;
            //Deleted = false;
            //RoomAddress = string.Empty;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_ContactDetailET : BaseET
    {
        #region Attributes
        public const String FIELD_ContactDetailID = "ContactDetailID";
        public const String FIELD_Contact = "Contact";
        public const String FIELD_OwnerID = "OwnerID";
        public const String FIELD_OwnerType = "OwnerType";
        public const String FIELD_ContactTypeID = "ContactTypeID";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_Note = "Note";
        #endregion Attributes
        /// <summary>
        ///ContactDetailID ContactDetailID
        /// </summary>
        private int _ContactDetailID;
        public int ContactDetailID { get { return _ContactDetailID; } set { _ContactDetailID = value; } }
        /// <summary>
        ///Contact Contact
        /// </summary>
        private string _Contact;
        public string Contact { get { return _Contact; } set { _Contact = value; } }
        /// <summary>
        ///OwnerID OwnerID
        /// </summary>
        private int _OwnerID;
        public int OwnerID { get { return _OwnerID; } set { _OwnerID = value; } }
        /// <summary>
        ///OwnerType OwnerType
        /// </summary>
        private int _OwnerType;
        public int OwnerType { get { return _OwnerType; } set { _OwnerType = value; } }
        /// <summary>
        ///ContactTypeID ContactTypeID
        /// </summary>
        private int _ContactTypeID;
        public int ContactTypeID { get { return _ContactTypeID; } set { _ContactTypeID = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
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
        /// Bachdx		28/07/2017		Tạo mới
        ///</Modified>
        public CMS_ContactDetailET()
        {
            //ContactDetailID = 0;
            //Contact = string.Empty;
            //OwnerID = 0;
            //OwnerType = 0;
            //ContactTypeID = 0;
            //UsedState = 0;
            //Note = string.Empty;
        }
    }
}

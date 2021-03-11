using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Sys_UserET : BaseET
    {
        #region Attributes
        public const String FIELD_UserID = "UserID";
        public const String FIELD_UnitID = "UnitID";
        public const String FIELD_UserName = "UserName";
        public const String FIELD_LoginName = "LoginName";
        public const String FIELD_RolePermission = "RolePermission";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_Checksum = "Checksum";
        public const String FIELD_Tel = "Tel";
        public const String FIELD_Email = "Email";
        public const String FIELD_Infor = "Infor";
        public const String FIELD_ImagePath = "ImagePath";
        public const String FIELD_Note = "Note";
        #endregion Attributes
        /// <summary>
        ///UserID UserID
        /// </summary>
        private int _UserID;
        public int UserID { get { return _UserID; } set { _UserID = value; } }
        /// <summary>
        ///UnitID UnitID
        /// </summary>
        private Guid? _UnitID;
        public Guid? UnitID { get { return _UnitID; } set { _UnitID = value; } }
        public string UnitName { get; set; }
        /// <summary>
        ///UserName UserName
        /// </summary>
        private string _UserName;
        public string UserName { get { return _UserName; } set { _UserName = value; } }
        /// <summary>
        ///LoginName LoginName
        /// </summary>
        private string _LoginName;
        public string LoginName { get { return _LoginName; } set { _LoginName = value; } }

        private string _LoginNameSP;
        public string LoginNameSP { get { return _LoginNameSP; } set { _LoginNameSP = value; } }
        /// <summary>
        ///RolePermission RolePermission
        /// </summary>
        private int? _RolePermission;
        public int? RolePermission { get { return _RolePermission; } set { _RolePermission = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
        /// <summary>
        ///Checksum Checksum
        /// </summary>
        private string _Checksum;
        public string Checksum { get { return _Checksum; } set { _Checksum = value; } }
        /// <summary>
        ///Tel Tel
        /// </summary>
        private string _Tel;
        public string Tel { get { return _Tel; } set { _Tel = value; } }
        /// <summary>
        ///Email Email
        /// </summary>
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }
        /// <summary>
        ///Infor Infor
        /// </summary>
        private string _Infor;
        public string Infor { get { return _Infor; } set { _Infor = value; } }
        /// <summary>
        ///ImagePath ImagePath
        /// </summary>
        private string _ImagePath;
        public string ImagePath { get { return _ImagePath; } set { _ImagePath = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
        public const String FIELD_CreatedBy = "CreatedBy";
        public const String FIELD_ModifiedBy = "ModifiedBy";
        public const String FIELD_CreatedDate = "CreatedDate";
        public const String FIELD_ModifiedDate = "ModifiedDate";

        private string _CreatedBy = "1";
        private string _ModifiedBy = "1";


        private DateTime _CreatedDate = DateTime.Now;
        private DateTime _ModifiedDate = DateTime.Now;
        /// <summary>
        /// nguoi tao
        /// </summary>
        public string CreatedBy
        {
            get { return _CreatedBy; }
            set { _CreatedBy = value; }
        }
        public string ModifiedBy
        {
            get { return _ModifiedBy; }
            set { _ModifiedBy = value; }
        }
        /// <summary>
        /// ngay tao
        /// </summary>
        public DateTime CreatedDate
        {
            get { return _CreatedDate; }
            set { _CreatedDate = value; }
        }
        /// <summary>
        /// Ngay sua
        /// </summary>
        public DateTime ModifiedDate
        {
            get { return _ModifiedDate; }
            set { _ModifiedDate = value; }
        }

        public string RolePage
        {
            get
            {
                return _RolePage;
            }

            set
            {
                _RolePage = value;
            }
        }

        private string _RolePage;

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		05/04/2016		Tạo mới
        ///</Modified>
        public Sys_UserET()
        {
            UserID = 0;
            UnitID = Guid.Empty;
            UserName = string.Empty;
            LoginName = string.Empty;
            RolePermission = 3; // Quyền xem
            UsedState = 1;
            Checksum = string.Empty;
            Tel = string.Empty;
            Email = string.Empty;
            Infor = string.Empty;
            ImagePath = string.Empty;
            Note = string.Empty;
        }


    }
}

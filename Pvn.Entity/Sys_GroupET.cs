using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Sys_GroupET : BaseET
    {
        #region Attributes
        public const String FIELD_GroupID = "GroupID";
        public const String FIELD_Language = "Language";
        public const String FIELD_Code = "Code";
        public const String FIELD_RolePermission = "RolePermission";
        public const String FIELD_Name = "Name";
        public const String FIELD_UnitID = "UnitID";
        public const String FIELD_UsedState = "UsedState";
        public const String FIELD_Checksum = "Checksum";
        #endregion Attributes
        /// <summary>
        ///GroupID GroupID
        /// </summary>
        private Guid _GroupID;
        public Guid GroupID { get { return _GroupID; } set { _GroupID = value; } }
        /// <summary>
        ///Language Language
        /// </summary>
        private string _Language;
        public string Language { get { return _Language; } set { _Language = value; } }
        /// <summary>
        ///Code Code
        /// </summary>
        private string _Code;
        public string Code { get { return _Code; } set { _Code = value; } }
        /// <summary>
        ///RolePermission RolePermission
        /// </summary>
        private int? _RolePermission;
        public int? RolePermission { get { return _RolePermission; } set { _RolePermission = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///UnitID UnitID
        /// </summary>
        private Guid? _UnitID;
        public Guid? UnitID { get { return _UnitID; } set { _UnitID = value; } }

        public string UnitName { get; set; }
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
        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		10/05/2016		Tạo mới
        ///</Modified>
        public Sys_GroupET()
        {
            GroupID = Guid.Empty;
            Language = "vi-VN";
            UnitName = string.Empty;
            Code = string.Empty;
            RolePermission = 3; // Quyền xem
            UsedState = 1;
            Name = string.Empty;
            UnitID = Guid.Empty;
            Checksum = string.Empty;
        }

    }
}

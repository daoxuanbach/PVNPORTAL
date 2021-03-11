using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Sys_Group_UnitET : BaseET
    {
        #region Attributes
        public const String FIELD_GroupUnitID = "GroupUnitID";
        public const String FIELD_Name = "Name";
        public const String FIELD_Ordinal = "Ordinal";
        #endregion Attributes
        /// <summary>
        ///GroupUnitID GroupUnitID
        /// </summary>
        private Guid _GroupUnitID;
        public Guid GroupUnitID { get { return _GroupUnitID; } set { _GroupUnitID = value; } }
        /// <summary>
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///Ordinal Ordinal
        /// </summary>
        private int? _Ordinal;
        public int? Ordinal { get { return _Ordinal; } set { _Ordinal = value; } }
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
        /// Bachdx		01/04/2016		Tạo mới
        ///</Modified>
        public Sys_Group_UnitET()
        {
            GroupUnitID = Guid.Empty;
            Name = string.Empty;
            Ordinal = 1;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class Sys_Group_UserET : BaseET
	{
	#region Attributes
		 public const String FIELD_Group_UserID = "Group_UserID"; 
		 public const String FIELD_GroupID = "GroupID"; 
		 public const String FIELD_UserID = "UserID"; 
		 public const String FIELD_Checksum = "Checksum"; 
	#endregion Attributes
		/// <summary>
		///Group_UserID Group_UserID
		/// </summary>
		private Guid _Group_UserID; 
		public Guid Group_UserID { get{ return _Group_UserID; } set{ _Group_UserID = value; } }
		/// <summary>
		///GroupID GroupID
		/// </summary>
		private Guid? _GroupID; 
		public Guid? GroupID { get{ return _GroupID; } set{ _GroupID = value; } }
		/// <summary>
		///UserID UserID
		/// </summary>
		private string _UserID; 
		public string UserID { get{ return _UserID; } set{ _UserID = value; } }
		/// <summary>
		///Checksum Checksum
		/// </summary>
		private string _Checksum; 
		public string Checksum { get{ return _Checksum; } set{ _Checksum = value; } }
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
		/// Bachdx		17/05/2016		Tạo mới
		///</Modified>
		public Sys_Group_UserET()
		{
			Group_UserID = Guid.Empty;
			GroupID = Guid.Empty;
			UserID = string.Empty;
			Checksum = string.Empty;
		}

        public string UserName { get; set; }

        public string LoginName { get; set; }
    }
}


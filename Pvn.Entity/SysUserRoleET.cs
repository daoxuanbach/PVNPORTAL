using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class SysUserRoleET : BaseET
	{
	#region Attributes
		 public const String FIELD_User_RoleID = "User_RoleID"; 
		 public const String FIELD_RoleID = "RoleID"; 
		 public const String FIELD_UserID = "UserID"; 
	#endregion Attributes
		/// <summary>
		///User_RoleID User_RoleID
		/// </summary>
		private int _User_RoleID; 
		public int User_RoleID { get{ return _User_RoleID; } set{ _User_RoleID = value; } }
		/// <summary>
		///RoleID RoleID
		/// </summary>
		private int? _RoleID; 
		public int? RoleID { get{ return _RoleID; } set{ _RoleID = value; } }
		/// <summary>
		///UserID UserID
		/// </summary>
		private int? _UserID; 
		public int? UserID { get{ return _UserID; } set{ _UserID = value; } }
        private Guid? _FunctionID;
        public Guid? FunctionID { get { return _FunctionID; } set { _FunctionID = value; } }

        public string CheckGroupRole { get; set; }
        public string Name { get; set; }
        public string Title { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		06/01/2017		Tạo mới
        ///</Modified>
        public SysUserRoleET()
		{
			User_RoleID = 0;
			RoleID = 0;
			UserID = 0;
		}
	}
}


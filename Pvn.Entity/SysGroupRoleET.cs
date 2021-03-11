using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class SysGroupRoleET : BaseET
	{
	#region Attributes
		 public const String FIELD_Group_RoleID = "Group_RoleID"; 
		 public const String FIELD_RoleID = "RoleID"; 
		 public const String FIELD_GroupID = "GroupID"; 
		 public const String FIELD_FunctionID = "FunctionID"; 
	#endregion Attributes
		/// <summary>
		///Group_RoleID Group_RoleID
		/// </summary>
		private int _Group_RoleID; 
		public int Group_RoleID { get{ return _Group_RoleID; } set{ _Group_RoleID = value; } }
		/// <summary>
		///RoleID RoleID
		/// </summary>
		private int? _RoleID; 
		public int? RoleID { get{ return _RoleID; } set{ _RoleID = value; } }
		/// <summary>
		///GroupID GroupID
		/// </summary>
		private Guid? _GroupID; 
		public Guid? GroupID { get{ return _GroupID; } set{ _GroupID = value; } }
		/// <summary>
		///FunctionID FunctionID
		/// </summary>
		private Guid? _FunctionID;
        public string Title;

        public Guid? FunctionID { get{ return _FunctionID; } set{ _FunctionID = value; } }

        public String CheckGroupRole { get; set; }
        public String Name { get; set; }
        public string CheckUserRole { get; set; }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		09/01/2017		Tạo mới
        ///</Modified>
        public SysGroupRoleET()
		{
			Group_RoleID = 0;
			RoleID = 0;
			GroupID = Guid.Empty;
			FunctionID = Guid.Empty;
		}
	}
}


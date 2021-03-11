using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
	public class SysUserFunctionET : BaseET
	{
	#region Attributes
		 public const String FIELD_User_FunctionID = "User_FunctionID"; 
		 public const String FIELD_UserIDType = "UserIDType"; 
		 public const String FIELD_UserID = "UserID"; 
		 public const String FIELD_FunctionID = "FunctionID"; 
		 public const String FIELD_Checksum = "Checksum"; 
	#endregion Attributes
		/// <summary>
		///User_FunctionID User_FunctionID
		/// </summary>
		private Guid _User_FunctionID; 
		public Guid User_FunctionID { get{ return _User_FunctionID; } set{ _User_FunctionID = value; } }
		/// <summary>
		///UserIDType UserIDType
		/// </summary>
		private int? _UserIDType; 
		public int? UserIDType { get{ return _UserIDType; } set{ _UserIDType = value; } }
		/// <summary>
		///UserID UserID
		/// </summary>
		private string _UserID; 
		public string UserID { get{ return _UserID; } set{ _UserID = value; } }
		/// <summary>
		///FunctionID FunctionID
		/// </summary>
		private Guid? _FunctionID; 
		public Guid? FunctionID { get{ return _FunctionID; } set{ _FunctionID = value; } }
		/// <summary>
		///Checksum Checksum
		/// </summary>
		private string _Checksum; 
		public string Checksum { get{ return _Checksum; } set{ _Checksum = value; } }
		/// <summary>
		///CreatedBy CreatedBy
		/// </summary>
		private string _CreatedBy; 
		public string CreatedBy { get{ return _CreatedBy; } set{ _CreatedBy = value; } }
		/// <summary>
		///CreatedDate CreatedDate
		/// </summary>
		private DateTime? _CreatedDate; 
		public DateTime? CreatedDate { get{ return _CreatedDate; } set{ _CreatedDate = value; } }
		/// <summary>
		///ModifiedBy ModifiedBy
		/// </summary>
		private string _ModifiedBy; 
		public string ModifiedBy { get{ return _ModifiedBy; } set{ _ModifiedBy = value; } }
		/// <summary>
		///ModifiedDate ModifiedDate
		/// </summary>
		private DateTime? _ModifiedDate; 
		public DateTime? ModifiedDate { get{ return _ModifiedDate; } set{ _ModifiedDate = value; } }

        private string _FullName;
        public string FullName { get { return _FullName; } set { _FullName = value; } }
        

		/// <summary>
		/// Hàm khởi tạo mặc định
		/// </summary>
		///<Modified>
		/// Author		Date		Comment
		/// Bachdx		26/08/2016		Tạo mới
		///</Modified>
		public SysUserFunctionET()
		{
			User_FunctionID = Guid.Empty;
			UserIDType = 0;
			UserID = string.Empty;
			FunctionID = Guid.Empty;
			Checksum = string.Empty;
            FullName = string.Empty;
		}

        public string CheckUserFunction { get; set; }
    }
}


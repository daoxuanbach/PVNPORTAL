using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class Sys_UnitET : BaseET
    {
        #region Attributes
        public const String FIELD_UnitID = "UnitID";
        public const String FIELD_Language = "Language";
        public const String FIELD_Code = "Code";
        public const String FIELD_Name = "Name";
        public const String FIELD_GroupUnitID = "GroupUnitID";
        public const String FIELD_Address = "Address";
        public const String FIELD_Tel = "Tel";
        public const String FIELD_Fax = "Fax";
        public const String FIELD_Email = "Email";
        public const String FIELD_Website = "Website";
        public const String FIELD_Infor = "Infor";
        public const String FIELD_FileAttach = "FileAttach";
        public const String FIELD_FileName = "FileName";
        public const String FIELD_Note = "Note";
        public const String FIELD_ParentUnitID = "ParentUnitID";
        public const String FIELD_Checksum = "Checksum";
        #endregion Attributes
        /// <summary>
        ///UnitID UnitID
        /// </summary>
        private Guid _UnitID;
        public Guid UnitID { get { return _UnitID; } set { _UnitID = value; } }
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
        ///Name Name
        /// </summary>
        private string _Name;
        public string Name { get { return _Name; } set { _Name = value; } }
        /// <summary>
        ///UnitType UnitType
        /// </summary>
        private Guid? _GroupUnitID;
        public Guid? GroupUnitID { get { return _GroupUnitID; } set { _GroupUnitID = value; } }
        /// <summary>
        ///Address Address
        /// </summary>
        private string _Address;
        public string Address { get { return _Address; } set { _Address = value; } }
        /// <summary>
        ///Tel Tel
        /// </summary>
        private string _Tel;
        public string Tel { get { return _Tel; } set { _Tel = value; } }
        /// <summary>
        ///Fax Fax
        /// </summary>
        private string _Fax;
        public string Fax { get { return _Fax; } set { _Fax = value; } }
        /// <summary>
        ///Email Email
        /// </summary>
        private string _Email;
        public string Email { get { return _Email; } set { _Email = value; } }
        /// <summary>
        ///Website Website
        /// </summary>
        private string _Website;
        public string Website { get { return _Website; } set { _Website = value; } }
        /// <summary>
        ///Infor Infor
        /// </summary>
        private string _Infor;
        public string Infor { get { return _Infor; } set { _Infor = value; } }
        /// <summary>
        ///FileAttach FileAttach
        /// </summary>
        private byte[] _FileAttach;
        public byte[] FileAttach { get { return _FileAttach; } set { _FileAttach = value; } }
        /// <summary>
        ///FileName FileName
        /// </summary>
        private string _FileName;
        public string FileName { get { return _FileName; } set { _FileName = value; } }
        /// <summary>
        ///Note Note
        /// </summary>
        private string _Note;
        public string Note { get { return _Note; } set { _Note = value; } }
        /// <summary>
        ///ParentUnitID ParentUnitID
        /// </summary>
        private Guid? _ParentUnitID;
        public Guid? ParentUnitID { get { return _ParentUnitID; } set { _ParentUnitID = value; } }
      
        /// <summary>
        ///Checksum Checksum
        /// </summary>
        private string _Checksum;
        public string Checksum { get { return _Checksum; } set { _Checksum = value; } }
        public string ParentUnitName { get; set; }
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
        /// Bachdx		31/03/2016		Tạo mới
        ///</Modified>
        public Sys_UnitET()
        {
            UnitID = Guid.Empty;
            Language = "vi-VN";
            Code = string.Empty;
            Name = string.Empty;
            GroupUnitID = Guid.Empty;
            Address = string.Empty;
            Tel = string.Empty;
            Fax = string.Empty;
            Email = string.Empty;
            Website = string.Empty;
            Infor = string.Empty;
            FileAttach = null;
            FileName = string.Empty;
            Note = string.Empty;
            ParentUnitID = Guid.Empty;
            Checksum = string.Empty;
        }

       
    }
}

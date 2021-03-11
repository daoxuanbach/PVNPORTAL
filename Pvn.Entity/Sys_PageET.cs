using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class Sys_PageET : BaseET
    {
        #region Attributes
        public const String FIELD_PageID = "PageID";
        public const String FIELD_URL = "URL";
        public const String FIELD_ParentPageID = "ParentPageID";
        public const String FIELD_Checksum = "Checksum";
       // sp.PageID ,
       //sp.URL ,
       //sp.ParentPageID ,
       //sp.Checksum

        private Guid _PageID = new Guid();
        private string _URL = string.Empty;
        private Guid _ParentPageID = Guid.Empty;
        private string _Checksum = String.Empty;
       
        #endregion
        #region Properties
        public Guid PageID
        {
            get { return _PageID; }
            set { _PageID = value; }
        }
        public string URL
        {
            get { return _URL; }
            set { _URL = value; }
        }
        public Guid ParentPageID
        {
            get { return _ParentPageID; }
            set { _ParentPageID = value; }
        }
        public string Checksum
        {
            get { return _Checksum; }
            set { _Checksum = value; }
        }
        #endregion
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
    }
}

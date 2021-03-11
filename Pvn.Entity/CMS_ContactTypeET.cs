using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_ContactTypeET : BaseET
    {
        /// <summary>
        ///ContactTypeID ContactTypeID
        /// </summary>
        private int _ContactTypeID;
        public int ContactTypeID { get { return _ContactTypeID; } set { _ContactTypeID = value; } }
        /// <summary>
        ///ContactType ContactType
        /// </summary>
        private string _ContactType;
        public string ContactType { get { return _ContactType; } set { _ContactType = value; } }
        /// <summary>
        ///ContactTypeEng ContactTypeEng
        /// </summary>
        private string _ContactTypeEng;
        public string ContactTypeEng { get { return _ContactTypeEng; } set { _ContactTypeEng = value; } }
        /// <summary>
        ///OrderNumber OrderNumber
        /// </summary>
        private int? _OrderNumber;
        public int? OrderNumber { get { return _OrderNumber; } set { _OrderNumber = value; } }
        /// <summary>
        ///UsedState UsedState
        /// </summary>
        private int? _UsedState;
        public int? UsedState { get { return _UsedState; } set { _UsedState = value; } }
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
        /// Bachdx		12/07/2017		Tạo mới
        ///</Modified>
        public CMS_ContactTypeET()
        {
            //ContactTypeID = 0;
            //ContactType = string.Empty;
            //ContactTypeEng = string.Empty;
            //OrderNumber = 0;
            //UsedState = 0;
        }
    }
}

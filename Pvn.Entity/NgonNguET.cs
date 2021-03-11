using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class NgonNguET : BaseET
    {
        #region Attributes
        public const String FIELD_MaNgonNgu = "MaNgonNgu";
        public const String FIELD_TenNgonNgu = "TenNgonNgu";
        public const String FIELD_CoQuocGia = "CoQuocGia";
        public const String FIELD_ThuTu = "ThuTu";
        public const String FIELD_KichHoat = "KichHoat";
        #endregion Attributes
        /// <summary>
        ///MaNgonNgu MaNgonNgu
        /// </summary>
        private string _MaNgonNgu;
        public string MaNgonNgu { get { return _MaNgonNgu; } set { _MaNgonNgu = value; } }
        /// <summary>
        ///TenNgonNgu TenNgonNgu
        /// </summary>
        private string _TenNgonNgu;
        public string TenNgonNgu { get { return _TenNgonNgu; } set { _TenNgonNgu = value; } }
        /// <summary>
        ///CoQuocGia CoQuocGia
        /// </summary>
        private string _CoQuocGia;
        public string CoQuocGia { get { return _CoQuocGia; } set { _CoQuocGia = value; } }
        /// <summary>
        ///ThuTu ThuTu
        /// </summary>
        private int? _ThuTu;
        public int? ThuTu { get { return _ThuTu; } set { _ThuTu = value; } }
        /// <summary>
        ///KichHoat KichHoat
        /// </summary>
        private bool? _KichHoat;
        public bool? KichHoat { get { return _KichHoat; } set { _KichHoat = value; } }
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
        /// Bachdx		25/03/2016		Tạo mới
        ///</Modified>
        public NgonNguET()
        {
            MaNgonNgu = string.Empty;
            TenNgonNgu = "vi-VN";
            CoQuocGia = string.Empty;
            ThuTu = 0;
            KichHoat = false;
        }
    }
}

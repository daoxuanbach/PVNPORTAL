using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_BannerQuangCaoET : BaseET
    {
        #region Attributes
        public const String FIELD_Id = "Id";
        public const String FIELD_TocDo = "TocDo";
        public const String FIELD_NoiDung = "NoiDung";
        public const String FIELD_STT = "STT";
        public const String FIELD_TuNgay = "TuNgay";
        public const String FIELD_DenNgay = "DenNgay";
        public const String FIELD_HienThi = "HienThi";
        #endregion Attributes
        /// <summary>
        ///Id Id 
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }
        /// <summary>
        ///TocDo TocDo
        /// </summary>
        private int? _TocDo;
        public int? TocDo { get { return _TocDo; } set { _TocDo = value; } }
        /// <summary>
        ///NoiDung NoiDung
        /// </summary>
        private string _NoiDung;
        public string NoiDung { get { return _NoiDung; } set { _NoiDung = value; } }
        /// <summary>
        ///STT STT
        /// </summary>
        private int? _STT;
        public int? STT { get { return _STT; } set { _STT = value; } }
        /// <summary>
        ///TuNgay TuNgay
        /// </summary>
        private DateTime? _TuNgay;
        public DateTime ? TuNgay { get { return _TuNgay; } set { _TuNgay = value; } }
        /// <summary>
        ///DenNgay DenNgay
        /// </summary>
        private DateTime? _DenNgay;
        public DateTime? DenNgay { get { return _DenNgay; } set { _DenNgay = value; } }
        /// <summary>
        ///HienThi HienThi
        /// </summary>
        private bool? _HienThi;
        public bool? HienThi { get { return _HienThi; } set { _HienThi = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		22/11/2017		Tạo mới
        ///</Modified>
        public CMS_BannerQuangCaoET()
        {
            Id = 0;
            TocDo = 2;
            NoiDung = string.Empty;
            STT = 1;
            HienThi = false;
        }
    }
}

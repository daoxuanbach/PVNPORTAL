using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Pvn.Entity
{
    public class CMS_SlideShowImgET : BaseET
    {
        #region Attributes
        public const String FIELD_Id = "Id";
        public const String FIELD_TieuDe = "TieuDe";
        public const String FIELD_NoiDung = "NoiDung";
        public const String FIELD_STT = "STT";
        public const String FIELD_TuNgay = "TuNgay";
        public const String FIELD_DenNgay = "DenNgay";
        public const String FIELD_HienThi = "HienThi";
        public const String FIELD_ImageURL = "ImageURL";
        #endregion Attributes
        /// <summary>
        ///Id Id
        /// </summary>
        private int _Id;
        public int Id { get { return _Id; } set { _Id = value; } }
        /// <summary>
        ///TieuDe TieuDe
        /// </summary>
        private string _TieuDe;
        public string TieuDe { get { return _TieuDe; } set { _TieuDe = value; } }
        /// <summary>
        ///NoiDung NoiDung
        /// </summary>
        private string _NoiDung;
        public string NoiDung { get { return _NoiDung; } set { _NoiDung = value; } }
        private string _LinkChiTiet;
        public string LinkChiTiet { get { return _LinkChiTiet; } set { _LinkChiTiet = value; } }
        /// <summary>
        ///STT STT
        /// </summary>
        private int? _STT;
        public int? STT { get { return _STT; } set { _STT = value; } }
        /// <summary>
        ///TuNgay TuNgay
        /// </summary>
        private DateTime ? _TuNgay;
        public DateTime? TuNgay { get { return _TuNgay; } set { _TuNgay = value; } }
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
        ///ImageURL ImageURL
        /// </summary>
        private string _ImageURL;
        public string ImageURL { get { return _ImageURL; } set { _ImageURL = value; } }

        /// <summary>
        /// Hàm khởi tạo mặc định
        /// </summary>
        ///<Modified>
        /// Author		Date		Comment
        /// Bachdx		22/02/2018		Tạo mới
        ///</Modified>
        public CMS_SlideShowImgET()
        {
            Id = 0;
            TieuDe = string.Empty;
            NoiDung = string.Empty;
            STT = 0;
            HienThi = false;
            ImageURL = string.Empty;
        }
    }
}


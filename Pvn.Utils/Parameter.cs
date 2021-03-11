using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Utils
{
    public class Parameter
    {
        public enum Languages
        {
            Vietnam,
            English
        }
        /// <summary>
        /// Kieu WF
        /// </summary>
        public enum WFType
        {
            SoanThao = 1,
            XuatBan = 3
        }
        /// <summary>
        /// Type of Category
        /// </summary>
        public enum CatPublishedType
        {
            TinBinhThuong = 1,
            TinKiemDuyetTheoWorkflow = 2,
        }
        public enum Direction
        {
            TraVe = -1,
            GiuNguyen = 0,
            GuiLen = 1
        }
        /// <summary>
        /// Trang thai Workflow
        /// </summary>
        public enum ProcessType
        {
            ChuaHoanThanh = 1,
            DaGuiLen = 2,
            DaTraVe = 3,
            ChoXuatBan = 4
        }
        /// <summary>
        /// State of Rating
        /// </summary>
        public enum RatingState
        {
            ChoKiemDuyetDanhGia = 1,
            ChoPhepHienThiDanhGia = 2,
            KhongChoPhepHienThiDanhGia = 3,
        }

        /// <summary>
        /// DataAccess of Users
        /// </summary>
        public enum DataAccess
        {
            ChoPhepNguoiDocTruyCap = 1,
            ChoPhepNguoiDocCoTaiKhoanTruyCap = 2,
        }

        /// <summary>
        /// State of News
        /// </summary>
        public enum NewsState
        {
            TinMoiTao,ChuaTungDuocXuatBan = 1,
            TinDangDuocSoanThao = 2,
            TinDangChoKiemDuyet = 3,
            TinDangChoXuatBan = 4,
            TinDangXuatBan = 5,
            TinHetHanXuatBan = 6,
            TinDangXacMinhLaiNoiDung = 7,
        }

        public enum PublishedState
        {
            DangKyXuatBan = 1,
            ChoPhepXuatBan = 2,
            KhongChoPhepXuatBan = 3,
            HuyXuatban = 4,
        }

        public enum UsedState
        {
            DangSuDung = 1,
            KhongHoatDong = 2,
            DaXoaKhoiHeThong = 3
        }

        public enum DocumentState
        {
            DangSoanThao = 1, 
            ChoPheDuyet = 2,
            XuatBan = 3,
            HuyXuatBan = 4,
            HuyPheDuyet = 5
        }

        public enum OwnerType
        {
            Company = 1,
            Employee = 2,
        }
        public enum MenuPosition { Top = 1, Left = 2, Right = 3, Bottom=4 }

    }
}

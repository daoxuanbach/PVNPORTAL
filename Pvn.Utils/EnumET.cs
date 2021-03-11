using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Utils
{
    public static class EnumET
    {
        public  enum PositionView
        {
            [EnumDescription("TopView")]
            Default = 0,
            [EnumDescription("Item")]
            Item = 1,
            [EnumDescription("TopDetail")]
            Detail = 2

        }
       
        public enum QuyTrinh
        {
            [EnumDescription("Hệ thống")]
            Default = 0,
            [EnumDescription("Duyệt gửi lãnh đạo")]
            DuyetGuiLanhDao = 1,
            [EnumDescription("Duyệt và kết thúc")]
            DuyetKetThucQuyTrinh = 2,
            [EnumDescription("Không đồng ý yêu cầu bổ xung")]
            KhongDongYvaYeuCauBoXung = 3,
            [EnumDescription("Không đồng ý")]
            KhongDongYvaHuyYeuCau = 4,
            [EnumDescription("Sử dụng khi dữ liệu đã lock")]
            Lock = 5
        }
        public enum LoaiPhep
        {
            [EnumDescription("Phép của năm")]
            PhepCuaNam = 1,
            [EnumDescription("Nghỉ cưới")]
            NghiCuoi = 2,
            [EnumDescription("Nghỉ ốm")]
            NghiOm= 3,
            [EnumDescription("Nghỉ sinh")]
            NghiSinh = 4,
            [EnumDescription("Nghỉ tang")]
            NghiTang = 5,
            [EnumDescription("Nghỉ con kết hôn")]
            NghiConKetHon = 6,
            [EnumDescription("Nghỉ bù")]
            NghiBu = 7,
            [EnumDescription("Nghỉ không lương")]
            NghiKhongLuong = 8
        }
        public enum TT_DuLieu
        {
            [EnumDescription("Mới tạo")]
            MoiTao = 1,
            [EnumDescription("Không đồng ý")]
            HuyDuyet = 2,
            [EnumDescription("Trả lại yêu cầu bổ xung")]
            YeuCauBoXung = 3,
            [EnumDescription("Đã duyệt")]
            DaDuyet = 4
        }
        public enum EnumRole
        {
            [EnumDescription("Mặc định")]
            Default = 0,
            [EnumDescription("Full Quyền")]
            Custom = 1
        }
        public enum EnumThaoTac
        {
            [EnumDescription("ThemMoi")]
            ThemMoi = 1,
            [EnumDescription("Sửa")]
            Sua = 2,
            [EnumDescription("Xoa")]
            Xoa = 3,
            [EnumDescription("ChoPheDuyet")]
            ChoPheDuyet = 4,
            [EnumDescription("PheDuyet")]
            PheDuyet = 5,
            [EnumDescription("XuatBan")]
            XuatBan = 6,
            [EnumDescription("HuyXuatBan")]
            HuyXuatBan = 7,
            [EnumDescription("HuyPheDuyet")]
            HuyPheDuyet = 8,
            [EnumDescription("ThemMoiAndPublich")]
            ThemMoiAndPublich = 9,
            [EnumDescription("UpdateAndPublich")]
            UpdateAndPublich = 10,
            [EnumDescription("PhanQuyenGroup")]
            PhanQuyenGroup = 11,
            [EnumDescription("ChucNangNhom")]
            ChucNangNhom = 12,
            [EnumDescription("ChucNangNguoiDung")]
            ChucNangNguoiDung = 13,
            [EnumDescription("ChucNangNguoiDung")]
            QuyenNguoiDung = 14,
        }

    }


}

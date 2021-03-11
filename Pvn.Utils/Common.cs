using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace Pvn.Utils
{
    public class Common
    {
        public class Parameter
        {
            public enum CatPublishedType
            {
                TinBinhThuong = 1,
                TinKiemDuyetTheoWorkflow = 2,
            }

            public enum DataAccess
            {
                ChoPhepNguoiDocTruyCap = 1,
                ChoPhepNguoiDocCoTaiKhoanTruyCap = 2,
            }

            public enum Direction
            {
                TraVe = -1,
                GiuNguyen = 0,
                GuiLen = 1,
            }

            public enum DocumentState
            {
                [EnumDescription("Đang soạn thảo")]
                DangSoanThao = 1,
                [EnumDescription("Chờ phê duyệt")]
                ChoPheDuyet = 2,
                [EnumDescription("Xuất bản")]
                XuatBan = 3,
                [EnumDescription("Hủy xuất bản")]
                HuyXuatBan = 4,
                [EnumDescription("Hủy phê duyệt")]
                HuyPheDuyet = 5,
            }

            public enum NewsState
            {
                TinMoiTao = 0,
                ChuaTungDuocXuatBan = 1,
                TinDangDuocSoanThao = 2,
                TinDangChoKiemDuyet = 3,
                TinDangChoXuatBan = 4,
                TinDangXuatBan = 5,
                TinHetHanXuatBan = 6,
                TinDangXacMinhLaiNoiDung = 7,
            }

            public enum OwnerType
            {
                Company = 1,
                Employee = 2,
            }

            public enum ProcessType
            {
                ChuaHoanThanh = 1,
                DaGuiLen = 2,
                DaTraVe = 3,
                ChoXuatBan = 4,
            }

            public enum PublishedState
            {
                DangKyXuatBan = 1,
                ChoPhepXuatBan = 2,
                KhongChoPhepXuatBan = 3,
                HuyXuatban = 4,
            }

            public enum RatingState
            {
                ChoKiemDuyetDanhGia = 1,
                ChoPhepHienThiDanhGia = 2,
                KhongChoPhepHienThiDanhGia = 3,
            }

            public enum UsedState
            {
                DangSuDung = 1,
                KhongHoatDong = 2,
                DaXoaKhoiHeThong = 3,
            }

            public enum WFType
            {
                SoanThao = 1,
                XuatBan = 3,
            }
        }

        public static string ClientIP()
        {
            string clientIP = (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] == null) ?
                HttpContext.Current.Request.UserHostAddress : HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            return clientIP;
        }
        public static bool ReaderContainsColumn(IDataReader reader, string name)
        {
            for (int i = 0; i < reader.FieldCount; i++)
            {
                if (reader.GetName(i).Contains(name)) return true;
            }
            return false;
        }
        public static string ReaderFuntion(string data, string dataid)
        {
            return data.Replace("data-id", "data-id=" + dataid);
         
        }
         

        /// <summary>
        /// take any string and encrypt it using MD5 then
        /// return the encrypted data 
        /// </summary>
        /// <param name="data">input text you will enterd to encrypt it</param>
        /// <returns>return the encrypted text as hexadecimal string</returns>
        public static string GetMD5HashData(string data)
        {
            //create new instance of md5
            MD5 md5 = MD5.Create();

            //convert the input text to array of bytes
            byte[] hashData = md5.ComputeHash(Encoding.Default.GetBytes(data));

            //create new instance of StringBuilder to save hashed data
            StringBuilder returnValue = new StringBuilder();

            //loop for each byte and add it to StringBuilder
            for (int i = 0; i < hashData.Length; i++)
            {
                returnValue.Append(hashData[i].ToString());
            }

            // return hexadecimal string
            return returnValue.ToString();

        }
    }
}

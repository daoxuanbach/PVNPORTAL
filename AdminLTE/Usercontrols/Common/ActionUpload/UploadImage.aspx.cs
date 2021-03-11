using System;
using System.Collections.Generic;
using System.Web;
using System.IO;
using System.Text;
using System.Security.Cryptography;


namespace AdminLTE.Usercontrols.Common.ActionUpload
{
    public partial class UploadImage : System.Web.UI.Page
    {
        private bool CheckFileAllow(string fileExt)
        {
            if (!string.IsNullOrEmpty(Request["img"]) && Request["img"].ToString() == "1")
                return this.ListAllImageAllow().Contains(fileExt);
            else
                return this.ListAllFileAllow().Contains(fileExt);
        }

        private string getFileNameFromClient(string fileNameClient)
        {
            return fileNameClient.Substring(fileNameClient.LastIndexOf('\\') + 1);
        }

        private string GetMd5Sum(string str)
        {
            System.Text.Encoder encoder = Encoding.Unicode.GetEncoder();
            var bytes = new byte[str.Length * 2];
            encoder.GetBytes(str.ToCharArray(), 0, str.Length, bytes, 0, true);
            byte[] buffer2 = new MD5CryptoServiceProvider().ComputeHash(bytes);
            var builder = new StringBuilder();
            for (int i = 0; i < buffer2.Length; i++)
            {
                builder.Append(buffer2[i].ToString("X2"));
            }
            return builder.ToString();
        }

        private List<string> ListAllFileAllow()
        {
            var list = new List<string>();
            list.Add(".jpg");
            list.Add(".jpeg");
            list.Add(".gif");
            list.Add(".bmp");
            list.Add(".png");
            list.Add(".tif");
            list.Add(".flv");
            list.Add(".mp3");
            list.Add(".mp4");
            list.Add(".avi");
            list.Add(".wmv");
            list.Add(".asx");
            list.Add(".wma");
            list.Add(".flac");
            list.Add(".zip");
            list.Add(".rar");
            list.Add(".7z");
            list.Add(".doc");
            list.Add(".docx");
            list.Add(".xls");
            list.Add(".xlsx");
            list.Add(".xml");
            list.Add(".pdf");
            list.Add(".psd");
            list.Add(".ppt");
            list.Add(".pptx");
            list.Add(".txt");
            return list;
        }

        private List<string> ListAllImageAllow()
        {
            var list = new List<string>();
            list.Add(".jpg");
            list.Add(".jpeg");
            list.Add(".gif");
            list.Add(".bmp");
            list.Add(".png");
            list.Add(".tif");
            return list;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Page.Response.Clear();
            if (base.Request.Files["qqfile"] != null)
            {
                this.UploadIe();
            }
            else
            {
                this.UploadFireFox();
            }
            this.Page.Response.End();
        }

        private string uploadFile(Stream serverFileStream, string fileName)
        {
            string path = Server.MapPath("/UserControls/Upload/Avartar/") + fileName;
            try
            {
                int count = 0x100;
                int num2 = 0;
                var buffer = new byte[count];
                using (var stream = new FileStream(path, FileMode.Create))
                {
                    do
                    {
                        num2 = serverFileStream.Read(buffer, 0, count);
                        stream.Write(buffer, 0, num2);
                    }
                    while (num2 == count);
                }
                serverFileStream.Dispose();
                return path;
            }
            catch (Exception exception)
            {
                return exception.Message;
            }
        }

        private void UploadFireFox()
        {
            string path = base.Request["qqfile"];
            var extension = Path.GetExtension(path);
            if (extension != null)
            {
                string fileExt = extension.ToLower();
                if (this.CheckFileAllow(fileExt))
                {
                    string str = DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss:ms") + path;
                    str = this.GetMd5Sum(str) + fileExt;
                    Stream inputStream = base.Request.InputStream;
                    this.uploadFile(inputStream, str);
                    this.Page.Response.Write("{\"upload\":true, \"filename\": \"" + path + "\", \"fileserver\": \"" + str + "\"}");
                }
                else
                {
                    this.Page.Response.Write("{\"upload\":false, \"message\": \"Định dạng " + fileExt + " không được phép upload\"}");
                }
            }
        }

        private void UploadIe()
        {
            HttpPostedFile file = base.Request.Files["qqfile"];
            string path = this.getFileNameFromClient(file.FileName);
            var extension = Path.GetExtension(path);
            if (extension != null)
            {
                string fileExt = extension.ToLower();
                if (this.CheckFileAllow(fileExt))
                {
                    string str = DateTime.Now.ToString("dd:MM:yyyy hh:mm:ss:ms") + path;
                    str = this.GetMd5Sum(str) + fileExt;
                    file.SaveAs(base.Server.MapPath("/Upload/StaffAvatar/TempAvatar/" + str));
                    this.Page.Response.Write("{\"upload\":true, \"filename\": \"" + path + "\", \"fileserver\": \"" + str + "\"}");
                }
                else
                {
                    this.Page.Response.Write("{\"upload\":false, \"message\": \"Định dạng " + fileExt + " không được phép upload\"}");
                }
            }
        }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web;
using System.IO;
using System.Configuration;
namespace Pvn.Utils
{
    public static class Utilities
    {
        /// <summary>
        /// Merge rows cell with the same value
        /// </summary>
        /// <param name="gridView"></param>
        public static void MergeRows(System.Web.UI.WebControls.GridView gridView)
        {
            try
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];

                    for (int i = 0; i < row.Cells.Count; i++)
                    {
                        if (row.Cells[i].Text == previousRow.Cells[i].Text)
                        {
                            row.Cells[i].RowSpan = previousRow.Cells[i].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[i].RowSpan + 1;
                            previousRow.Cells[i].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("Utilities", "MergeRows", ex.Message);

            }

        }
        public static string SplitString(string sText, int ilengh)
        {
            if (string.IsNullOrEmpty(sText))
            {
                return string.Empty;
            }
            if (sText.Length <= ilengh)
            {
                return sText;
            }
            string newString = sText.Substring(0, ilengh);
            string finalString = newString.Substring(0, newString.LastIndexOf(' '));
            return string.Concat(finalString, " ...");
        }
        /// <summary>
        /// Merge rows cell with the same value
        /// </summary>
        /// <param name="gridView"></param>
        public static void MergeRows(System.Web.UI.WebControls.GridView gridView, params int[] cellIndexs)
        {
            try
            {
                for (int rowIndex = gridView.Rows.Count - 2; rowIndex >= 0; rowIndex--)
                {
                    GridViewRow row = gridView.Rows[rowIndex];
                    GridViewRow previousRow = gridView.Rows[rowIndex + 1];
                    for (int i = 0; i < cellIndexs.Length; i++)
                    {
                        if (row.Cells[cellIndexs[i]].Text == previousRow.Cells[cellIndexs[i]].Text)
                        {
                            row.Cells[cellIndexs[i]].RowSpan = previousRow.Cells[cellIndexs[i]].RowSpan < 2 ? 2 :
                                                   previousRow.Cells[cellIndexs[i]].RowSpan + 1;
                            previousRow.Cells[cellIndexs[i]].Visible = false;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                Pvn.Utils.LogFile.WriteLogFile("Utilities", "MergeRows", ex.Message);
            }

        }
        public static bool IsGuid(string candidate, out Guid output)
        {
            Regex isGuid = new Regex(@"^(\{){0,1}[0-9a-fA-F]{8}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{4}\-[0-9a-fA-F]{12}(\}){0,1}$", RegexOptions.Compiled);
            bool isValid = false;
            output = Guid.Empty;

            if (!string.IsNullOrEmpty(candidate))
            {
                if (isGuid.IsMatch(candidate))
                {
                    output = new Guid(candidate);
                    isValid = true;
                }
            }

            return isValid;
        }
        /// <summary>
        /// Tra ve ten file anh + kich co file anh do
        /// </summary>
        /// <param name="objImage">Ten file anh</param>
        /// <param name="ImageSize">Kich co</param>
        /// <returns></returns>
        /// <example>
        ///     ProcessImage("abc.jpg","C45x45") return "abc_C45.jpg"
        ///     ProcessImage("","C45x45") return "~/_layouts/Core.Branding/images/thumbnail_C45.jpg"
        /// </example>
        public static string ProcessImage(object objImage, string ImageSize)
        {
            //if (!((objImage == null) || string.IsNullOrEmpty(objImage.ToString()) || !objImage.ToString().Contains(".")))
            //{
            //    string str = objImage.ToString();
            //    return string.Format("{0}_{1}{2}", str.Substring(0, str.LastIndexOf('.')), ImageSize, str.Substring(str.LastIndexOf('.')));
            //}
            if (!((objImage == null) || string.IsNullOrEmpty(objImage.ToString())))
            {
                return objImage.ToString();
            }

            return string.Format("~/Usercontrols/images/thumbnail_{0}.jpg", ImageSize);
        }
        public static string GetUrlRewite(string UrlDetail, string CategoryName, string Title, string NewsPublishingID)
        {
            string UrlRewite = string.Empty;
            try
            {
                UrlRewite = string.Format("{0}/{1}/{2}/{3}", UrlDetail, Pvn.Utils.Utilities.ConvertUrlRewite(CategoryName), Pvn.Utils.Utilities.ConvertUrlRewite(Title), NewsPublishingID);
                return UrlRewite;
            }
            catch (Exception)
            {
                return UrlRewite;
                throw;
            }

        }
        public static string ConvertUrlRewite(string s)
        {
            string UrlRewite = string.Empty;
            if (!string.IsNullOrEmpty(s))
            {
                UrlRewite = convertToUnSign2(s).Replace(" ", "-");
                UrlRewite = UrlRewite.Replace("\"", "");
                UrlRewite = UrlRewite.Replace("“", "");
                UrlRewite = UrlRewite.Replace("”", "");
                UrlRewite = UrlRewite.Replace("&", "-");
                UrlRewite = UrlRewite.Replace("'", "");
                UrlRewite = UrlRewite.Replace("%", "");
                UrlRewite = UrlRewite.Replace("/", "-");
                UrlRewite = UrlRewite.Replace(";", "-");
                UrlRewite = UrlRewite.Replace("!", "");
                UrlRewite = UrlRewite.Replace("?", "");
                UrlRewite = UrlRewite.Replace("...", "");
                UrlRewite = UrlRewite.Replace(".", "");

                UrlRewite = Regex.Replace(UrlRewite, "[^0-9a-zA-Z]+-", "-");
            }
            if (UrlRewite.Length>20)
            {
                UrlRewite = UrlRewite.Substring(0, 20);
            }
            return UrlRewite.ToLower();
        }
        public static string convertToUnSign2(string s)
        {
            string stFormD = s.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            for (int ich = 0; ich < stFormD.Length; ich++)
            {
                System.Globalization.UnicodeCategory uc = System.Globalization.CharUnicodeInfo.GetUnicodeCategory(stFormD[ich]);
                if (uc != System.Globalization.UnicodeCategory.NonSpacingMark)
                {
                    sb.Append(stFormD[ich]);
                }
            }
            sb = sb.Replace('Đ', 'D');
            sb = sb.Replace('đ', 'd');
            return (sb.ToString().Normalize(NormalizationForm.FormD));
        }
        public static void BindDataToDropDownList(Object dataSource, string valueField, string textField, Globals.FirstItemCombox firstItem, params System.Web.UI.WebControls.DropDownList[] controls)
        {
            bool insertitem = true;
            foreach (var control in controls)
            {
                control.DataSource = dataSource;
                control.DataTextField = textField;
                control.DataValueField = valueField;
                control.DataBind();
                if (insertitem)
                {
                    switch (firstItem)
                    {
                        case Globals.FirstItemCombox.AllItem:
                            control.Items.Insert(0, new ListItem("--Chon--", string.Empty));
                            insertitem = false;
                            break;
                    }
                }

            }
        }
        //public static string SendEmail(string mailTo, string nameTo, string subject, string body, string cc)
        //{
        //    string message = "";

        //    string mailserver = ConfigurationManager.AppSettings["MailServer"];
        //    switch (mailserver)
        //    {
        //        case "GMail":
        //            message = GMailHelper.SendEmail(mailTo, nameTo, subject, body);
        //            break;
        //        case "EWS":
        //            message = EWSHelper.SendEmail(mailTo, nameTo, subject, body, cc);
        //            break;
        //        default:
        //            message = "MailServer not found.";
        //            break;
        //    }

        //    return message;
        //}
    }
}

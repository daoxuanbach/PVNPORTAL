using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pvn.Utils
{
    public static class Globals
    {
        public const string CommonResourceFile = "Core.Web.Controls.Common";

        public const string ConboboxAllItem = "Conbobox.AllItem";
        public const string ConboboxSelectItem = "ComboBox.SelectItem";
        public const string ConboboxRootItem = "ComboBox.RootItem";
        public const string MessageAddError = "Message.AddError";
        public const string MessageAddSuccess = "Message.AddSuccess";
        public const string MessageDeleteError = "Message.DeleteError";
        public const string MessageDeleteSuccess = "Message.DeleteSuccess";
        public const string MessageUpdateError = "Message.UpdateError";
        public const string MessageUpdateSucess = "Message.UpdateSuccess";
        public const string RequiredField = "rfv.ErrorMessage";


        /// <summary>
        /// Url file
        /// </summary>
        public enum DefaultPage
        {
            None,
            Default,
            Dialog
        }

        /// <summary>
        /// First item in combox
        /// </summary>
        public enum FirstItemCombox
        {
            None,
            AllItem,
            SelectItem,
            RootItem
        }

        public enum MessageType
        {
            Success,
            Error,
            Warning
        }
        public static string CurrentLanguage
        {
            get
            {
                string sLanguage = "vi-VN";
                try
                {
                    sLanguage = "vi-VN";
                    //sLanguage = Thread.CurrentThread.CurrentCulture.ToString();
                }
                catch
                {
                  //  sLanguage = CommonLib.XML.Configuration.Instance.GetValue(CommonLib.Common.Info.Instance.ConfigFile, "core.Modules.CoreSys.SharePoint");
                }
                if (string.IsNullOrEmpty(sLanguage))
                    sLanguage = "vi-VN";

                return sLanguage;
            }
        }
    }
}

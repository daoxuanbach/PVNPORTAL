using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.ImageList
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aImageList : IHttpHandler
    {
        CMS_ImageBL objBL = new CMS_ImageBL();
        MessageUtil objMsg = new MessageUtil();
        DateTimeFormatInfo dtfi = new DateTimeFormatInfo { ShortDatePattern = "dd/MM/yyyy" };
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";

            switch (context.Request["hidAction"])
            {
                case "add":
                    Insert(context);
                    break;
                case "upd":
                    Update(context);
                    break;
                case "del":
                    Delete(context);
                    break;

                default:
                    break;
            }
        }

        protected void Delete(HttpContext context)
        {
            string CategoryID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
                CategoryID = (context.Request["CategoryID"]);
            List<string> listStrLineElements = CategoryID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            for (int i = listStrLineElements.Count - 1; i >= 0; i--)
            {
                Guid guiID = new Guid(listStrLineElements[i]);
                objMsg = objBL.DeleteOutMesage(guiID);
                if (objMsg.Error)
                    break;
            }

            #region addLog
            Sys_LogDA objLogDA = new Sys_LogDA();
            Sys_LogET objLog = new Sys_LogET();
            string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
            if (!string.IsNullOrEmpty(FnID))
            {
                Guid FunID = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                {
                    objLog.FunctionID = FunID;
                }
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Xoa;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            CMS_ImageET objET = RequestEntity(context);

            objET.ModifiedBy = new Sys_UserBL().GetUserLogin(); ;
            objET.ModifiedDate = DateTime.Now;

            objMsg = objBL.Update(objET);

            #region addLog
            Sys_LogDA objLogDA = new Sys_LogDA();
            Sys_LogET objLog = new Sys_LogET();
            string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
            if (!string.IsNullOrEmpty(FnID))
            {
                Guid FunID = Guid.Empty;
                if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                {
                    objLog.FunctionID = FunID;
                }
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Sua;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);

        }

        protected void Insert(HttpContext context)
        {
            CMS_ImageET objET = RequestEntity(context);
            objET.CreatedBy = new Sys_UserBL().GetUserLogin(); ;
            objET.CreatedDate = DateTime.Now;

            if (!string.IsNullOrEmpty(context.Request["updateFolder"]) && context.Request["updateFolder"] == "1")
            {
                var Dirpart = Path.GetDirectoryName(objET.ImageURL);
                DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath(Dirpart));//Assuming Test is your Folder
                FileInfo[] Files = d.GetFiles(); //Getting Text files
                int STTFile = 0;
                string TenAnh = objET.Title;
                foreach (FileInfo file in Files)
                {
                    STTFile++;
                    objET.ImageURL = Dirpart + "\\" + file.Name;

                    if (!string.IsNullOrEmpty(context.Request["TenAnh"]) && context.Request["TenAnh"] == "1")
                    {
                        objET.Title = TenAnh + "_" + STTFile.ToString();
                    }
                    else
                    {
                        objET.Title = file.Name.Replace(file.Extension, "");
                    }
                    if (objBL.Insert(objET))
                    {
                        objMsg.Error = false;
                        objMsg.Message = "Thêm mới thành công";

                        #region addLog
                        Sys_LogDA objLogDA = new Sys_LogDA();
                        Sys_LogET objLog = new Sys_LogET();
                        string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
                        if (!string.IsNullOrEmpty(FnID))
                        {
                            Guid FunID = Guid.Empty;
                            if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                            {
                                objLog.FunctionID = FunID;
                            }
                            objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ThemMoi;
                            objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                            objLog.Note = objMsg.Message;
                            objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                        }
                        #endregion
                    }
                    else
                    {
                        objMsg.Error = true;
                        objMsg.Message = "Thêm mới không thành công";
                    }
                }
            }
            else
            {
                if (objBL.Insert(objET))
                {
                    objMsg.Error = false;
                    objMsg.Message = "Thêm mới thành công";

                    #region addLog
                    Sys_LogDA objLogDA = new Sys_LogDA();
                    Sys_LogET objLog = new Sys_LogET();
                    string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
                    if (!string.IsNullOrEmpty(FnID))
                    {
                        Guid FunID = Guid.Empty;
                        if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
                        {
                            objLog.FunctionID = FunID;
                        }
                        objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ThemMoi;
                        objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                        objLog.Note = objMsg.Message;
                        objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                    }
                    #endregion
                }
                else
                {
                    objMsg.Error = true;
                    objMsg.Message = "Thêm mới không thành công";
                }
            }
            objMsg.RenderMessage(objMsg, context);
        }

        private CMS_ImageET RequestEntity(HttpContext context)
        {
            CMS_ImageET objET = new CMS_ImageET();
            if (!string.IsNullOrEmpty(context.Request["ImageID"]))
                objET.ImageID = new Guid(context.Request["ImageID"]);
            if (!string.IsNullOrEmpty(context.Request["ImageCategoryID"]))
                objET.ImageCategoryID = new Guid(context.Request["ImageCategoryID"]);
            if (!string.IsNullOrEmpty(context.Request["PublishedState"]))
                objET.PublishedState = Convert.ToInt32(context.Request["PublishedState"]);
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);

            if (!string.IsNullOrEmpty(context.Request["Desscription"]))
                objET.Desscription = context.Request["Desscription"];
            if (!string.IsNullOrEmpty(context.Request["Note"]))
                objET.Note = context.Request["Note"];

            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
            if (!string.IsNullOrEmpty(context.Request["ImageURL"]))
            {
                objET.ImageURL = context.Request["ImageURL"].Trim();
            }
            if (!string.IsNullOrEmpty(context.Request["Title"]))
            {
                objET.Title = context.Request["Title"].Trim();

            }
            else
            {
                if (!string.IsNullOrEmpty(context.Request["ImageURL"]))
                {
                    DirectoryInfo d = new DirectoryInfo(HttpContext.Current.Server.MapPath(objET.ImageURL));//Assuming Test is your Folder
                    objET.Title = d.Name.Replace(d.Extension, "");
                }
            }
            if (!string.IsNullOrEmpty(context.Request["ImageTitle"]))
                objET.ImageTitle = context.Request["ImageTitle"].Trim();

            if (!string.IsNullOrEmpty(context.Request["Author"]))
                objET.Author = context.Request["Author"];
            if (!string.IsNullOrEmpty(context.Request["Reference"]))
                objET.Reference = context.Request["Reference"];


            return objET;
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}
using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.VideoList
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aVideoList : IHttpHandler
    {
        CMS_VideoBL objBL = new CMS_VideoBL();
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
            for (int i = listStrLineElements.Count-1; i >=0 ; i--)
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
            CMS_VideoET objET = RequestEntity(context);

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
            CMS_VideoET objET = RequestEntity(context);

            objET.CreatedBy = new Sys_UserBL().GetUserLogin(); ;
            objET.CreatedDate = DateTime.Now;


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
            objMsg.RenderMessage(objMsg, context);
        }

        private CMS_VideoET RequestEntity(HttpContext context)
        {
            CMS_VideoET objET = new CMS_VideoET();
            if (!string.IsNullOrEmpty(context.Request["VideoID"]))
                objET.VideoID = new Guid(context.Request["VideoID"]);
            if (!string.IsNullOrEmpty(context.Request["VideoCategoryID"]))
                objET.VideoCategoryID = new Guid(context.Request["VideoCategoryID"]);
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["PublishedState"]))
                objET.PublishedState = Convert.ToInt32(context.Request["PublishedState"]);
            if (!string.IsNullOrEmpty(context.Request["Title"]))
                objET.Title = context.Request["Title"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Desscription"]))
                objET.Desscription = context.Request["Desscription"];
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
            if (!string.IsNullOrEmpty(context.Request["Note"]))
                objET.Note = context.Request["Note"];
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
            if (!string.IsNullOrEmpty(context.Request["ImageURL"]))
                objET.ImageURL = context.Request["ImageURL"].Trim();
            if (!string.IsNullOrEmpty(context.Request["ImageTitle"]))
                objET.ImageTitle = context.Request["ImageTitle"].Trim();
            if (!string.IsNullOrEmpty(context.Request["VideoURL"]))
                objET.VideoURL = context.Request["VideoURL"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Author"]))
                objET.Author = context.Request["Author"];
            if (!string.IsNullOrEmpty(context.Request["Reference"]))
                objET.Reference = context.Request["Reference"];
            objET.RatingState = (int)Pvn.Utils.Parameter.RatingState.ChoPhepHienThiDanhGia;
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
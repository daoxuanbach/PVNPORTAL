using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Categorylist
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aCategorylist : IHttpHandler
    {
        CMS_CategoryBL objBL = new CMS_CategoryBL();
        Sys_LogDA objLogDA = new Sys_LogDA();
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
                objMsg = objBL.Delete(guiID);
                if (objMsg.Error)
                    break;
            }
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
            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            CMS_CategoryET objET = RequestEntity(context);
            if (objBL.Update(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật thành công";

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
                    objLog.ClientIP = Pvn.Utils.Common.ClientIP();
                    objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
                }
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Cập nhật không thành công";
            }
            objMsg.RenderMessage(objMsg, context);
        }

        protected void Insert(HttpContext context)
        {

            CMS_CategoryET objET = RequestEntity(context);
            if (objBL.Insert(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Thêm mới thành công";
                Sys_LogET objLog = new Sys_LogET();
                string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=","");
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
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";
            }
            objMsg.RenderMessage(objMsg, context);
        }

        private CMS_CategoryET RequestEntity(HttpContext context)
        {
            CMS_CategoryET objET = new CMS_CategoryET();
            if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
                objET.CategoryID = new Guid(context.Request["CategoryID"]);
            if (!string.IsNullOrEmpty(context.Request["ParentCategoryID"]))
                objET.ParentCategoryID = new Guid(context.Request["ParentCategoryID"]);
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["Code"]))
                objET.Code = context.Request["Code"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Title"]))
                objET.Title = context.Request["Title"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Summary"]))
                objET.Summary = context.Request["Summary"];
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
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
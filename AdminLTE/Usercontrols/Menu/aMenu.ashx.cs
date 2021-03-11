using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Menu
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aMenu : IHttpHandler
    {
        CMS_MenuBL objBL = new CMS_MenuBL();
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
            foreach (string item in listStrLineElements)
            {
                Guid guiID = new Guid(item);
                objMsg = objBL.Delete(guiID);
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
            CMS_MenuET objET = RequestEntity(context);
            if (objBL.Update(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật thành công";

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
            CMS_MenuET objET = RequestEntity(context);
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

        private CMS_MenuET RequestEntity(HttpContext context)
        {
            CMS_MenuET objET = new CMS_MenuET();
            if (!string.IsNullOrEmpty(context.Request["MenuID"]))
                objET.MenuID = new Guid(context.Request["MenuID"]);
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["Code"]))
                objET.Code = context.Request["Code"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Title"]))
                objET.Title = context.Request["Title"].Trim();
            if (!string.IsNullOrEmpty(context.Request["ParentMenuID"]))
                objET.ParentMenuID = new Guid(context.Request["ParentMenuID"]);
            if (!string.IsNullOrEmpty(context.Request["ObjectType"]))
                 objET.ObjectType = context.Request["ObjectType"];
            if (!string.IsNullOrEmpty(context.Request["MenuPosition"]))
                objET.MenuPosition = Convert.ToInt32(context.Request["MenuPosition"]);
            if (!string.IsNullOrEmpty(context.Request["IsNewWindow"]))
                objET.IsNewWindow = context.Request["IsNewWindow"]=="on";
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal =  Convert.ToInt32(context.Request["Ordinal"]);
            if (!string.IsNullOrEmpty(context.Request["ImageURL"]))
                objET.ImageURL = context.Request["ImageURL"];
            if (!string.IsNullOrEmpty(context.Request["ImageTitle"]))
                objET.ImageTitle = context.Request["ImageTitle"];
            if (!string.IsNullOrEmpty(context.Request["Summary"]))
                objET.Summary = context.Request["Summary"];
            //if (!string.IsNullOrEmpty(context.Request["Note"]))
            //    objET.Note = context.Request["Note"];
            if (!string.IsNullOrEmpty(context.Request["URL"]))
                objET.URL = context.Request["URL"];
            if (!string.IsNullOrEmpty(context.Request["ObjectType"]))
                objET.ObjectType = context.Request["ObjectType"];
            if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
            {
                objET.ObjectID = new Guid(context.Request["CategoryID"]);
            }
            if (objET.ObjectType==Pvn.Utils.Constants.ObjectType.Category)
            {
                if (!string.IsNullOrEmpty(context.Request["CategoryID"]))
                {
                    objET.URL = string.Format("{0}{1}","/pages/list.aspx?catid=", context.Request["CategoryID"]);
                }
            }
            if (objET.ObjectType == Pvn.Utils.Constants.ObjectType.News)
            {
                if (!string.IsNullOrEmpty(context.Request["NewsPublishingID"]))
                {
                    objET.URL = string.Format("{0}{1}", "/Pages/info.aspx?NewsID=", context.Request["NewsPublishingID"]);
                    objET.Note = (context.Request["NewsPublishingID"]);
                }
            }
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
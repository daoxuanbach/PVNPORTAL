using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.EventList
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aEventList : IHttpHandler
    {
        CMS_EventDA objDA = new CMS_EventDA();
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
            string NewsID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["NewsID"]))
                NewsID = (context.Request["NewsID"]);
            List<string> listStrLineElements = NewsID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in listStrLineElements)
            {
                objMsg = objDA.Delete(Convert.ToInt32(item));
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
            CMS_EventET objET = RequestEntity(context);
            objET.CreatedBy = Convert.ToString(new Sys_UserBL().GetUserLogin());
            objET.ModifiedDate = DateTime.Now;
            objMsg = objDA.Update(objET);

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
            CMS_EventET objInfo = RequestEntity(context);
            objInfo.CreatedBy = Convert.ToString(new Sys_UserBL().GetUserLogin());
            objInfo.CreatedDate = DateTime.Now;
            if (objDA.Insert(objInfo))
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

        private CMS_EventET RequestEntity(HttpContext context)
        {
            CMS_EventET objET = new CMS_EventET();
            if (!string.IsNullOrEmpty(context.Request["EventID"]))
                objET.EventID = Convert.ToInt32(context.Request["EventID"]);
            if (!string.IsNullOrEmpty(context.Request["Name"]))
                objET.Name = (string)(context.Request["Name"]);
            if (!string.IsNullOrEmpty(context.Request["Body"]))
                objET.Body = context.Request["Body"];
            if (!string.IsNullOrEmpty(context.Request["BeginDate"]))
            {
                objET.BeginDate = formatUtils.FormatDateTime(context.Request["BeginDate"]);
            }
            if (!string.IsNullOrEmpty(context.Request["EndDate"]))
            {
                objET.EndDate = formatUtils.FormatDateTime(context.Request["EndDate"]);
            }
            if (!string.IsNullOrEmpty(context.Request["EventType"]))
                objET.EventType = Convert.ToInt32(context.Request["EventType"]);
            if (!string.IsNullOrEmpty(context.Request["EventPlace"]))
                objET.EventPlace =(string)(context.Request["EventPlace"]);
            if (!string.IsNullOrEmpty(context.Request["OrgaUnit"]))
                objET.OrgaUnit = (string)(context.Request["OrgaUnit"]);
            if (!string.IsNullOrEmpty(context.Request["FilePath"]))
                objET.FilePath = (string)(context.Request["FilePath"]);
            if (!string.IsNullOrEmpty(context.Request["Note"]))
                objET.Note = (string)(context.Request["Note"]);
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
            objET.Estimate = string.IsNullOrEmpty(context.Request["Estimate"]) ? false : true;
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
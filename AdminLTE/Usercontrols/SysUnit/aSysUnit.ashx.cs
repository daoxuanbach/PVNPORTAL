using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.SysUnit
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aSysUnit : IHttpHandler
    {
        Sys_UnitBL objBL = new Sys_UnitBL();
        MessageUtil objMsg = new MessageUtil();
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
            string PageID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["PageID"]))
                PageID = (context.Request["PageID"]);
            List<string> listStrLineElements = PageID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in listStrLineElements)
            {
                objMsg = objBL.Delete(new Guid(item));
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
            Sys_UnitET objET = RequestEntity(context);
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
            Sys_UnitET objET = RequestEntity(context);
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

        private Sys_UnitET RequestEntity(HttpContext context)
        {
            Sys_UnitET objET = new Sys_UnitET();
            if (!string.IsNullOrEmpty(context.Request["UnitID"]))
                objET.UnitID = new Guid(context.Request["UnitID"]);
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["GroupUnitID"]))
                objET.GroupUnitID = new Guid(context.Request["GroupUnitID"]);
            if (!string.IsNullOrEmpty(context.Request["Code"]))
                objET.Code = context.Request["Code"];
            if (!string.IsNullOrEmpty(context.Request["Name"]))
                objET.Name = context.Request["Name"];
            if (!string.IsNullOrEmpty(context.Request["ParentUnitID"]))
                objET.ParentUnitID = new Guid(context.Request["ParentUnitID"]);
          
            if (!string.IsNullOrEmpty(context.Request["Address"]))
                objET.Address = (string)(context.Request["Address"]);
            if (!string.IsNullOrEmpty(context.Request["Tel"]))
                objET.Tel = (string)(context.Request["Tel"]);
            if (!string.IsNullOrEmpty(context.Request["Fax"]))
                objET.Fax = (string)(context.Request["Fax"]);
            if (!string.IsNullOrEmpty(context.Request["Email"]))
                objET.Email = (string)(context.Request["Email"]);
            if (!string.IsNullOrEmpty(context.Request["Website"]))
                objET.Website = (string)(context.Request["Website"]);
            if (!string.IsNullOrEmpty(context.Request["Note"]))
                objET.Note = (string)(context.Request["Note"]);
            
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
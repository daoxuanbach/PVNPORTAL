using Pvn.BL;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.SysUser
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aSysUserFunction : IHttpHandler
    {
        Sys_FunctionBL objBL = new Sys_FunctionBL();
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

            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            Sys_FunctionET objET = RequestEntity(context);
            if (objBL.Update(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật thành công";
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
            Sys_FunctionET objET = RequestEntity(context);
            if (objBL.Insert(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Thêm mới thành công";
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";
            }
            objMsg.RenderMessage(objMsg, context);
        }

        private Sys_FunctionET RequestEntity(HttpContext context)
        {
            Sys_FunctionET objET = new Sys_FunctionET();
            if (!string.IsNullOrEmpty(context.Request["FunctionID"]))
                objET.FunctionID = new Guid(context.Request["FunctionID"]);
            if (!string.IsNullOrEmpty(context.Request["Language"]))
                objET.Language = context.Request["Language"];
            if (!string.IsNullOrEmpty(context.Request["PageID"]))
                objET.PageID = new Guid(context.Request["PageID"]);
            if (!string.IsNullOrEmpty(context.Request["Name"]))
                objET.Name = context.Request["Name"];
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
            if (!string.IsNullOrEmpty(context.Request["ParentFunctionID"]))
                objET.ParentFunctionID = new Guid(context.Request["ParentFunctionID"]);
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["Checksum"]))
                objET.Checksum = (context.Request["Checksum"]);
            if (!string.IsNullOrEmpty(context.Request["Infor"]))
                objET.Infor = (context.Request["Infor"]);
            if (!string.IsNullOrEmpty(context.Request["ImagePath"]))
                objET.ImagePath = (context.Request["ImagePath"]);
            if (!string.IsNullOrEmpty(context.Request["ImageFileName"]))
                objET.ImageFileName = (context.Request["ImageFileName"]);
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
using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.LinhVucVanBan
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aLinhVucVanBan : IHttpHandler
    {
        Doc_LinhVucVanBanDA objDA = new Doc_LinhVucVanBanDA();
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
                objMsg = objDA.DeleteOutMesage(new Guid(item));
                if (objMsg.Error)
                    break;
            }
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
            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            Doc_LinhVucVanBanET objET = RequestEntity(context);

            objMsg = objDA.Update(objET);

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
            objMsg.RenderMessage(objMsg, context);
        }

        protected void Insert(HttpContext context)
        {
            Doc_LinhVucVanBanET objET = RequestEntity(context);
            if (objDA.Insert(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Thêm mới thành công";

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
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";
            }
            objMsg.RenderMessage(objMsg, context);
        }

        private Doc_LinhVucVanBanET RequestEntity(HttpContext context)
        {
            Doc_LinhVucVanBanET objET = new Doc_LinhVucVanBanET();
            if (!string.IsNullOrEmpty(context.Request["NgonNgu"]))
                objET.NgonNgu = context.Request["NgonNgu"];
            if (!string.IsNullOrEmpty(context.Request["LinhVucID"]))
                objET.LinhVucID = new Guid(context.Request["LinhVucID"]);
            if (!string.IsNullOrEmpty(context.Request["Ma"]))
                objET.Ma = context.Request["Ma"];
            if (!string.IsNullOrEmpty(context.Request["Ten"]))
                objET.Ten = context.Request["Ten"];
            if (!string.IsNullOrEmpty(context.Request["TrangThaiSuDung"]))
                objET.TrangThaiSuDung = Convert.ToInt32(context.Request["TrangThaiSuDung"]);
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
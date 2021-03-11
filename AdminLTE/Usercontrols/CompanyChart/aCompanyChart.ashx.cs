using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.CompanyChart
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aCompanyChart : IHttpHandler
    {
        CMS_CompanyChartDA objDA = new CMS_CompanyChartDA();
        Sys_LogDA objLogDA = new Sys_LogDA();
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
                objMsg = objDA.Delete(Convert.ToInt32(item));
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
            CMS_CompanyChartET objET = RequestEntity(context);
            objMsg = objDA.Update(objET);

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
            CMS_CompanyChartET objET = RequestEntity(context);
            if (objDA.Insert(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Thêm mới thành công";

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

        private CMS_CompanyChartET RequestEntity(HttpContext context)
        {
            CMS_CompanyChartET objET = new CMS_CompanyChartET();
            if (!string.IsNullOrEmpty(context.Request["CompanyChartID"]))
                objET.CompanyChartID = Convert.ToInt32(context.Request["CompanyChartID"]);
            if (!string.IsNullOrEmpty(context.Request["CompanyTitle"]))
                objET.CompanyTitle = context.Request["CompanyTitle"].Trim();
            if (!string.IsNullOrEmpty(context.Request["CompanyType"]))
                objET.CompanyType = Convert.ToInt32(context.Request["CompanyType"]);
            if (!string.IsNullOrEmpty(context.Request["IconPath"]))
                objET.IconPath = context.Request["IconPath"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Information"]))
                objET.Information = context.Request["Information"];
            if (!string.IsNullOrEmpty(context.Request["Ordinal"]))
                objET.Ordinal = Convert.ToInt32(context.Request["Ordinal"]);
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
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
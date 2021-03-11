using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Worker
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aWorker : IHttpHandler
    {
        protected DateTimeFormatInfo dtfi = new DateTimeFormatInfo();
        CMS_WorkerDA objDA = new CMS_WorkerDA();
        MessageUtil objMsg = new MessageUtil();
        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            dtfi.ShortDatePattern = "dd/MM/yyyy";
            dtfi.DateSeparator = "/";
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
            CMS_WorkerET objET = RequestEntity(context);
            objMsg = objDA.Update(objET);

            if (UpdateContactDetail(context, objET.WorkerID))
            {
                objMsg.RenderMessage(objMsg, context);

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
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";

                objMsg.RenderMessage(objMsg, context);
            }
            
        }
        protected bool UpdateContactDetail(HttpContext context, int IDCompany)
        {
            MessageUtil objMsgContactDetail = new MessageUtil();
            //Thêm thông tin liên hệ
            CMS_ContactDetailDA objContactDetailDA = new CMS_ContactDetailDA();
            string lstThongTinLienHe = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["lstThongTinLienHe"]))
                lstThongTinLienHe = (context.Request["lstThongTinLienHe"]);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<CMS_ContactDetailET> lstReturn = oSerializer.Deserialize<List<CMS_ContactDetailET>>(lstThongTinLienHe);
            foreach (var item in lstReturn)
            {
                item.OwnerID = IDCompany;
                item.Contact = context.Server.HtmlDecode(item.Contact.Trim());
                objContactDetailDA.Insert(item);
            }
            // Xóa thông tin liên hệ
            string ThongTinLienHeXoa = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["ThongTinLienHeXoa"]))
                ThongTinLienHeXoa = (context.Request["ThongTinLienHeXoa"]);
            List<string> listStrLineElements = ThongTinLienHeXoa.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in listStrLineElements)
            {
                objMsgContactDetail = objContactDetailDA.Delete(Convert.ToInt32(item));
                if (objMsgContactDetail.Error)
                    return false;
            }
            return true;
        }
        protected void InsertcontactDetail(HttpContext context, int IDCompany)
        {
            //Thêm thông tin liên hệ
            CMS_ContactDetailDA objContactDetailDA = new CMS_ContactDetailDA();
            string lstThongTinLienHe = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["lstThongTinLienHe"]))
                lstThongTinLienHe = (context.Request["lstThongTinLienHe"]);
            var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
            List<CMS_ContactDetailET> lstReturn = oSerializer.Deserialize<List<CMS_ContactDetailET>>(lstThongTinLienHe);
            foreach (var item in lstReturn)
            {
                item.OwnerID = IDCompany;
                item.Contact = context.Server.HtmlDecode(item.Contact.Trim());
                objContactDetailDA.Insert(item);
            }
        }
        protected void Insert(HttpContext context)
        {
            CMS_WorkerET objET = RequestEntity(context);
            int IDWorker = objDA.Insert(objET);
            if (IDWorker > 0)
            {
                InsertcontactDetail(context, IDWorker);
               // CMS_CompanyJobTitle
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

        private CMS_WorkerET RequestEntity(HttpContext context)
        {
            CMS_WorkerET objET = new CMS_WorkerET();
            if (!string.IsNullOrEmpty(context.Request["WorkerID"]))
                objET.WorkerID = Convert.ToInt32(context.Request["WorkerID"]);
            if (!string.IsNullOrEmpty(context.Request["FirstName"]))
                objET.FirstName = Convert.ToString(context.Request["FirstName"]);
            if (!string.IsNullOrEmpty(context.Request["LastName"]))
                objET.LastName = Convert.ToString(context.Request["LastName"]);
            if (!string.IsNullOrEmpty(context.Request["Images"]))
                objET.Images = Convert.ToString(context.Request["Images"]);
            if (!string.IsNullOrEmpty(context.Request["BornDate"]))
            {
                objET.BornDate =Convert.ToDateTime(context.Request["BornDate"], dtfi);
            }
            if (!string.IsNullOrEmpty(context.Request["Sex"]))
            {
                objET.Sex = context.Request["Sex"]=="1";
                
            }

            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["Retire"]))
                objET.Retire = string.IsNullOrEmpty(context.Request["Retire"]) ? false : true;

            if (!string.IsNullOrEmpty(context.Request["CompanyID"]))
                objET.CompanyID = Convert.ToInt32(context.Request["CompanyID"]);
            if (!string.IsNullOrEmpty(context.Request["JobTitleID"]))
                objET.JobTitleID = Convert.ToInt32(context.Request["JobTitleID"]);
            if (!string.IsNullOrEmpty(context.Request["OrderNumber"]))
                objET.OrderNumber = Convert.ToInt32(context.Request["OrderNumber"]);

            if (!string.IsNullOrEmpty(context.Request["TaxCode"]))
                objET.TaxCode = Convert.ToString(context.Request["TaxCode"]);
            if (!string.IsNullOrEmpty(context.Request["CardID"]))
                objET.CardID = Convert.ToInt32(context.Request["CardID"]);
            if (!string.IsNullOrEmpty(context.Request["UserName"]))
                objET.UserName = Convert.ToString(context.Request["UserName"]);
            if (!string.IsNullOrEmpty(context.Request["Note"]))
                objET.Note = Convert.ToInt32(context.Request["Note"]);
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
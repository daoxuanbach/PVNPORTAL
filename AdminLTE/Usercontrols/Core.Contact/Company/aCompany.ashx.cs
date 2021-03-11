using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Company
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aCompany : IHttpHandler
    {
        CMS_CompanyDA objDA = new CMS_CompanyDA();
        MessageUtil objMsg = new MessageUtil();
        Sys_LogDA objLogDA = new Sys_LogDA();
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
            CMS_CompanyET objET = RequestEntity(context);
            objMsg = objDA.Update(objET);

            if (UpdateContactDetail(context, objET.CompanyID))
            {
                objMsg.RenderMessage(objMsg, context);
            }
            else
            {
                objMsg.Error = true;
                objMsg.Message = "Thêm mới không thành công";

                objMsg.RenderMessage(objMsg, context);
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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Sua;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
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
            CMS_CompanyET objET = RequestEntity(context);
            int IDCompany = objDA.Insert(objET);
            if (IDCompany>0)
            {
                InsertcontactDetail(context, IDCompany);

                ////Thêm thông tin liên hệ
                //CMS_ContactDetailDA objContactDetailDA = new CMS_ContactDetailDA();
                //string lstThongTinLienHe = string.Empty;
                //if (!string.IsNullOrEmpty(context.Request["lstThongTinLienHe"]))
                //    lstThongTinLienHe = (context.Request["lstThongTinLienHe"]);
                //var oSerializer = new System.Web.Script.Serialization.JavaScriptSerializer();
                //List<CMS_ContactDetailET> lstReturn = oSerializer.Deserialize<List<CMS_ContactDetailET>>(lstThongTinLienHe);
                //foreach (var item in lstReturn)
                //{
                //    item.OwnerID = IDCompany;
                //    objContactDetailDA.Insert(item);
                //}
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

        private CMS_CompanyET RequestEntity(HttpContext context)
        {
            CMS_CompanyET objET = new CMS_CompanyET();
            if (!string.IsNullOrEmpty(context.Request["CompanyID"]))
                objET.CompanyID = Convert.ToInt32(context.Request["CompanyID"]);
            if (!string.IsNullOrEmpty(context.Request["CompanyName"]))
                objET.CompanyName = Convert.ToString(context.Request["CompanyName"]).Trim();
            if (!string.IsNullOrEmpty(context.Request["InternationalName"]))
                objET.InternationalName = Convert.ToString(context.Request["InternationalName"]).Trim();
            if (!string.IsNullOrEmpty(context.Request["ShortName"]))
                objET.ShortName = Convert.ToString(context.Request["ShortName"]).Trim();
            if (!string.IsNullOrEmpty(context.Request["OrderNumber"]))
                objET.OrderNumber = Convert.ToInt32(context.Request["OrderNumber"]);
            if (!string.IsNullOrEmpty(context.Request["ParentCompanyID"]))
                objET.ParentCompanyID = Convert.ToInt32(context.Request["ParentCompanyID"]);
            if (!string.IsNullOrEmpty(context.Request["CompanyLevel"]))
                objET.CompanyLevel = Convert.ToInt32(context.Request["CompanyLevel"]);
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32(context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["Information"]))
                objET.Information = Convert.ToString(context.Request["Information"]).Trim();
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
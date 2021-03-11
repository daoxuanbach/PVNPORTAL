using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Manager
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aManager : IHttpHandler
    {
        CMS_ListManagerDA objDA = new CMS_ListManagerDA();
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
            CMS_ListManagerET objET = RequestEntity(context);
            objET.ModifiedDate = DateTime.Now;
            objET.ModifiedBy = Convert.ToString(new Sys_UserBL().GetUserLogin());

            objMsg = objDA.Update(objET);

            UpdateListManagerType(context, objET.ManagerID);



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
            CMS_ListManagerET objET = RequestEntity(context);
            int ItemID = 0;
            objET.CreatedDate = DateTime.Now;
            objET.CreatedBy = Convert.ToString(new Sys_UserBL().GetUserLogin()); ;
            ItemID = objDA.Insert(objET);
            if (ItemID>0)
            {
                UpdateListManagerType(context, ItemID);
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
        private void UpdateListManagerType(HttpContext context, int ManagerID)
        {
            CMS_ListManagerTypeDA objMDAO = new CMS_ListManagerTypeDA();
            objMDAO.DeleteByManagerID(ManagerID);
            List<CMS_ListManagerTypeET> lst = new List<CMS_ListManagerTypeET>();
            CMS_ListManagerTypeET objM;
            if (!string.IsNullOrEmpty(context.Request["chkHDTV"]))
            {
                objM = new CMS_ListManagerTypeET();
                objM.ManagerID = ManagerID;
                objM.ManagerType = 1;
                if (!string.IsNullOrEmpty(context.Request["txtTitleHDTV"]))
                    objM.JobTitleName = (context.Request["txtTitleHDTV"]);
                if (!string.IsNullOrEmpty(context.Request["txtHDTVOrdinal"]))
                    objM.Ordinal = Convert.ToInt32(context.Request["txtHDTVOrdinal"]);

                lst.Add(objM);
            }
            if (!string.IsNullOrEmpty(context.Request["chkTGD"])) 
            {
                objM = new CMS_ListManagerTypeET();
                objM.ManagerID = ManagerID;
                objM.ManagerType = 2;
                if (!string.IsNullOrEmpty(context.Request["txtTitleTGD"]))
                    objM.JobTitleName = (context.Request["txtTitleTGD"]);
                if (!string.IsNullOrEmpty(context.Request["txtTGDOrdinal"]))
                    objM.Ordinal = Convert.ToInt32(context.Request["txtTGDOrdinal"]);
                lst.Add(objM);
            }
            if (lst != null && lst.Count > 0)
            {
                string[] sErr = new string[lst.Count];
                foreach (CMS_ListManagerTypeET item in lst)
                {
                    objMDAO.Insert(item);
                }

            }
        }
        private CMS_ListManagerET RequestEntity(HttpContext context)
        {
            CMS_ListManagerET objET = new CMS_ListManagerET();
            if (!string.IsNullOrEmpty(context.Request["ManagerID"]))
                objET.ManagerID = Convert.ToInt32(context.Request["ManagerID"]);
            if (!string.IsNullOrEmpty(context.Request["Code"]))
                objET.Code = context.Request["Code"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Name"]))
                objET.Name = context.Request["Name"].Trim();
            if (!string.IsNullOrEmpty(context.Request["ShortName"]))
                objET.ShortName = context.Request["ShortName"].Trim();
            if (!string.IsNullOrEmpty(context.Request["IconPath"]))
                objET.IconPath = context.Request["IconPath"];
            if (!string.IsNullOrEmpty(context.Request["Information"]))
                objET.Information = (context.Request["Information"].Trim());
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
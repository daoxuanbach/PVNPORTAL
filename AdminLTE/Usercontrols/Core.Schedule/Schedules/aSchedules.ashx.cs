using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Schedules
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aSchedules : IHttpHandler
    {
        CMS_SchedulesDA objDA = new CMS_SchedulesDA();
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
            CMS_SchedulesET objET = RequestEntity(context);
            objMsg = objDA.Update(objET);
            if (!objMsg.Error)
            {
                RemoveAllManager(objET.ScheduleID);
                UpdateListbox(context, objET.ScheduleID);
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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.Sua;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }

            objMsg.RenderMessage(objMsg, context);
        }

        protected void Insert(HttpContext context)
        {
            CMS_SchedulesET objET = RequestEntity(context);
            objET.ScheduleID = objDA.Insert(objET);
            if (objET.ScheduleID > 0)
            {
                RemoveAllManager(objET.ScheduleID);
                UpdateListbox(context, objET.ScheduleID);


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
        void RemoveAllManager(int __scheduleID)
        {
            CMS_ScheduleManagerDA objDAOSM = new CMS_ScheduleManagerDA();
            objDAOSM.RemoveAllManagerByScheduleID(__scheduleID);
        }
        void UpdateListbox(HttpContext context, int _scheduleID)
        {
            List<CMS_ScheduleManagerET> lstSM = new List<CMS_ScheduleManagerET>();
            CMS_ScheduleManagerDA objDAO = new CMS_ScheduleManagerDA();
            CMS_ScheduleManagerET objInfo;

            if (!string.IsNullOrEmpty(context.Request["LanhDaoThamGia"]))
            {
                string LanhDaoThamGia = string.Empty;
                if (!string.IsNullOrEmpty(context.Request["LanhDaoThamGia"]))
                    LanhDaoThamGia = (context.Request["LanhDaoThamGia"]);
                List<string> ListCategory = LanhDaoThamGia.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                foreach (string item in ListCategory)
                {
                    objInfo = new CMS_ScheduleManagerET();
                    objInfo.ManagerID = Convert.ToInt32(item);
                    objInfo.SheduleID = _scheduleID;
                    //objInfo.CreatedBy = useid;
                    //objInfo.CreatedDate = DateTime.Now;
                    lstSM.Add(objInfo);
                }
                

                //objET.ListCategory = context.Request["ListCategory"].Trim();
            }
            if (!string.IsNullOrEmpty(context.Request["ChuTri"]))
            {
                objInfo = new CMS_ScheduleManagerET();
                objInfo.SheduleRole = 2;
                objInfo.ManagerID = Convert.ToInt32(context.Request["ChuTri"]);
                objInfo.SheduleID = _scheduleID;

                lstSM.Add(objInfo);
            }
            if (!string.IsNullOrEmpty(context.Request["LanhDao"]))
            {
                objInfo = new CMS_ScheduleManagerET();
                objInfo.SheduleRole = 1;
                objInfo.ManagerID = Convert.ToInt32(context.Request["LanhDao"]);
                objInfo.SheduleID = _scheduleID;
                lstSM.Add(objInfo);
            }

            if (lstSM.Count > 0)
            {
                foreach (CMS_ScheduleManagerET item in lstSM)
                {
                    objDAO.Insert(item);
                }
            }

        }
        private CMS_SchedulesET RequestEntity(HttpContext context)
        {
            CMS_SchedulesET objET = new CMS_SchedulesET();
            if (!string.IsNullOrEmpty(context.Request["ScheduleID"]))
                objET.ScheduleID = Convert.ToInt32(context.Request["ScheduleID"]);
            if (!string.IsNullOrEmpty(context.Request["Title"]))
                objET.Title = context.Request["Title"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Descriptions"]))
                objET.Descriptions = context.Request["Descriptions"].Trim();
            if (!string.IsNullOrEmpty(context.Request["BeginDate"]))
            {
                objET.BeginDate = formatUtils.FormatDateTime(context.Request["BeginDate"]);
            }
            if (!string.IsNullOrEmpty(context.Request["EndDate"]))
            {
                objET.EndDate = formatUtils.FormatDateTime(context.Request["EndDate"]);
            }
            if (!string.IsNullOrEmpty(context.Request["ToAddress"]))
                objET.ToAddress = (context.Request["ToAddress"].Trim());
            if (!string.IsNullOrEmpty(context.Request["chkActive"]))
                objET.Active = context.Request["chkActive"] == "on";
            if (!string.IsNullOrEmpty(context.Request["chkPrivate"]))
                objET.Private = context.Request["chkPrivate"] == "on";
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
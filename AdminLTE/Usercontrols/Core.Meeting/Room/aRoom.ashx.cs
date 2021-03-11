using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.Room
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aRoom : IHttpHandler
    {
        CMS_RoomDA objDA = new CMS_RoomDA();
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

            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            CMS_RoomET objET = RequestEntity(context);
            objMsg = objDA.Update(objET);
            objMsg.RenderMessage(objMsg, context);
        }

        protected void Insert(HttpContext context)
        {
            CMS_RoomET objET = RequestEntity(context);
            if (objDA.Insert(objET))
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

        private CMS_RoomET RequestEntity(HttpContext context)
        {
            CMS_RoomET objET = new CMS_RoomET();
            if (!string.IsNullOrEmpty(context.Request["RoomID"]))
                objET.RoomID = Convert.ToInt32(context.Request["RoomID"]);
            if (!string.IsNullOrEmpty(context.Request["RoomName"]))
                objET.RoomName = context.Request["RoomName"];
            if (!string.IsNullOrEmpty(context.Request["RoomAddress"]))
                objET.RoomAddress = context.Request["RoomAddress"];
            if (!string.IsNullOrEmpty(context.Request["OrderNumber"]))
                objET.OrderNumber =Convert.ToInt32(context.Request["OrderNumber"]);
            if (!string.IsNullOrEmpty(context.Request["Active"]))
                objET.Active = context.Request["Active"] == "1";
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
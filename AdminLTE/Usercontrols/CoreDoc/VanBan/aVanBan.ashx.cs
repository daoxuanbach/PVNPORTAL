using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.VanBan
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aVanBan : IHttpHandler
    {
        Doc_VanBanDA objDA = new Doc_VanBanDA();
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
                case "viewApproved":
                    ApprovedChoPheDuyet(context);
                    break;
                case "pheduyet":
                    Pheduyet(context);
                    break;
                case "reject":
                    HuyPheDuyet(context);
                    break;
                case "xuatban":
                    XuatBan(context);
                    break;
                case "thuhoi":
                    ThuHoiVanBan(context);
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

            objMsg.RenderMessage(objMsg, context);
        }

        protected void Update(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);

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
        protected void ApprovedChoPheDuyet(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);
            objET.TrangThaiVanBan = (int)Pvn.Utils.Common.Parameter.DocumentState.ChoPheDuyet;
            objMsg = objDA.Approved(objET);

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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ChoPheDuyet;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
        }
        protected void Pheduyet(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);
            objET.TrangThaiVanBan = (int)Pvn.Utils.Common.Parameter.DocumentState.HuyXuatBan;
            objMsg = objDA.Approved(objET);


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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.PheDuyet;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion
            objMsg.RenderMessage(objMsg, context);
        }
        protected void XuatBan(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);
            objET.TrangThaiVanBan = (int)Pvn.Utils.Common.Parameter.DocumentState.XuatBan;
            objMsg = objDA.Approved(objET);

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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.XuatBan;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
        }
        protected void ThuHoiVanBan(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);
            objET.TrangThaiVanBan = (int)Pvn.Utils.Common.Parameter.DocumentState.HuyXuatBan;
            objMsg = objDA.Approved(objET);

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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.HuyXuatBan;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
        }
        protected void HuyPheDuyet(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);
            objET.TrangThaiVanBan = (int)Pvn.Utils.Common.Parameter.DocumentState.HuyPheDuyet;
            objMsg = objDA.Approved(objET);

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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.HuyPheDuyet;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
        }
       
        protected void Insert(HttpContext context)
        {
            Doc_VanBanET objET = RequestEntity(context);
            if (objDA.Insert(objET))
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

        private Doc_VanBanET RequestEntity(HttpContext context)
        {
            Doc_VanBanET objET = new Doc_VanBanET();
            if (!string.IsNullOrEmpty(context.Request["NgonNgu"]))
                objET.NgonNgu = context.Request["NgonNgu"];
            if (!string.IsNullOrEmpty(context.Request["VanBanID"]))
                objET.VanBanID = new Guid(context.Request["VanBanID"]);
            if (!string.IsNullOrEmpty(context.Request["TieuDe"]))
                objET.TieuDe = context.Request["TieuDe"];
            if (!string.IsNullOrEmpty(context.Request["SoVanBan"]))
                objET.SoVanBan = context.Request["SoVanBan"];

            if (!string.IsNullOrEmpty(context.Request["LoaiVanBanID"]))
                objET.LoaiVanBanID =new Guid(context.Request["LoaiVanBanID"]);
            if (!string.IsNullOrEmpty(context.Request["NgayBanHanh"]))
                objET.NgayBanHanh =Convert.ToDateTime(context.Request["NgayBanHanh"], dtfi);
            if (!string.IsNullOrEmpty(context.Request["NgayHieuLuc"]))
                objET.NgayHieuLuc = Convert.ToDateTime(context.Request["NgayHieuLuc"], dtfi);

            if (!string.IsNullOrEmpty(context.Request["LinhVucID"]))
                objET.LinhVucID = new Guid(context.Request["LinhVucID"]);
            if (!string.IsNullOrEmpty(context.Request["DonViBanHanhID"]))
                objET.DonViBanHanhID = new Guid(context.Request["DonViBanHanhID"]);

            if (!string.IsNullOrEmpty(context.Request["listValueFileAttach"]))
            {
                string strListFileAttach = context.Request["listValueFileAttach"];
                objET.DuongDanVanBan = strListFileAttach;
            }
            if (!string.IsNullOrEmpty(context.Request["NoiDungVanBan"]))
                objET.NoiDungVanBan = context.Request["NoiDungVanBan"];
            objET.TrangThaiVanBan =(int)Pvn.Utils.Common.Parameter.DocumentState.DangSoanThao;
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
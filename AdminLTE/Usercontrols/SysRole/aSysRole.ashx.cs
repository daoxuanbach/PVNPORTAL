using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.SysRole
{
    /// <summary>
    /// Summary description for aSysPage
    /// </summary>
    public class aSysRole : IHttpHandler
    {
        SysRoleBL objBL = new SysRoleBL();
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
            string RoleID = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["RoleID"]))
                RoleID = (context.Request["RoleID"]);
            List<string> listStrLineElements = RoleID.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            foreach (string item in listStrLineElements)
            {
                objMsg = objBL.DeleteOutMesage(Convert.ToInt32(item));
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
            SysRoleET objET = RequestEntity(context);
            objMsg = objBL.Update(objET);

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

        protected void Insert(HttpContext context)
        {
            SysRoleET objET = RequestEntity(context);
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

        private SysRoleET RequestEntity(HttpContext context)
        {
            SysRoleET objET = new SysRoleET();
            if (!string.IsNullOrEmpty(context.Request["Name"]))
                objET.Name = context.Request["Name"];
            if (!string.IsNullOrEmpty(context.Request["Title"]))
                objET.Title = context.Request["Title"];
            if (!string.IsNullOrEmpty(context.Request["ClassView"]))
                objET.ClassView = context.Request["ClassView"];
            if (!string.IsNullOrEmpty(context.Request["IconView"]))
                objET.IconView = context.Request["IconView"];
            if (!string.IsNullOrEmpty(context.Request["RoleID"]))
                objET.RoleID = Convert.ToInt32(context.Request["RoleID"]);
            if (!string.IsNullOrEmpty(context.Request["FunctionID"]))
                objET.FunctionID = new Guid(context.Request["FunctionID"]);
            if (!string.IsNullOrEmpty(context.Request["ViTri"]))
                objET.ViTri = Convert.ToInt16(context.Request["ViTri"]);
            if (!string.IsNullOrEmpty(context.Request["TrangThai"]))
                objET.TrangThai = Convert.ToInt16(context.Request["TrangThai"]);
            if (!string.IsNullOrEmpty(context.Request["KetThuc"]))
                objET.KetThuc = context.Request["KetThuc"] == "1";
            if (!string.IsNullOrEmpty(context.Request["ThuTu"]))
                objET.ThuTu = Convert.ToInt16(context.Request["ThuTu"]);

            if (!string.IsNullOrEmpty(context.Request["QuyTrinh"]))
            {
                objET.QuyTrinh = Convert.ToInt16(context.Request["QuyTrinh"]);
            }
            if (!string.IsNullOrEmpty(context.Request["TrangThaiHienThi"]))
                objET.TrangThaiHienThi = Convert.ToInt16(context.Request["TrangThaiHienThi"]);
            if (!string.IsNullOrEmpty(context.Request["TextTrangThaiHienThi"]))
                objET.TextTrangThaiHienThi = (context.Request["TextTrangThaiHienThi"]).Trim();

            if (!string.IsNullOrEmpty(context.Request["TrangThaiGuiDi"]))
                objET.TrangThaiGuiDi = Convert.ToInt16(context.Request["TrangThaiGuiDi"]);
            if (!string.IsNullOrEmpty(context.Request["TrangThaiTraLai"]))
                objET.TrangThaiTraLai = Convert.ToInt16(context.Request["TrangThaiTraLai"]);
            if (!string.IsNullOrEmpty(context.Request["TextTrangThaiGuiDi"]))
                objET.TextTrangThaiGuiDi = context.Request["TextTrangThaiGuiDi"].Trim();
            if (!string.IsNullOrEmpty(context.Request["TextTrangThaiTraLai"]))
                objET.TextTrangThaiTraLai = context.Request["TextTrangThaiTraLai"].Trim();
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
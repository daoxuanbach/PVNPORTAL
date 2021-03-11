using Pvn.BL;
using Pvn.DA;
using Pvn.Entity;
using Pvn.Utils;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace AdminLTE.Usercontrols.SysGroup
{
    /// <summary>
    /// Summary description for aFunctionList
    /// </summary>
    public class aSysGroup : IHttpHandler
    {
        Sys_GroupBL objBL = new Sys_GroupBL();
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
                case "del":
                    Delete(context);
                    break;
                case "updateGroupfn":
                    UpdateGroupFn(context);
                    break;
                case "phanquyen":
                    Phanquyen(context);
                    break;
                default:
                    break;
            }
        }

        protected void Phanquyen(HttpContext context)
        {

            SysGroupRoleBL objBL = new SysGroupRoleBL();
            string lstchucnang = string.Empty;
            Guid GroupID = Guid.Empty;
            string ListFunction = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["lstchucnang"]))
                lstchucnang = (context.Request["lstchucnang"]);
            if (!string.IsNullOrEmpty(context.Request["GroupID"]))
                GroupID = new Guid(context.Request["GroupID"]);
            List<string> listStrLineElements = lstchucnang.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();
            //xóa quyền thuộc Group
            if (objBL.DeleteRoleByGroup(GroupID))
            {
                foreach (string item in listStrLineElements)
                {
                    SysGroupRoleET objET = new SysGroupRoleET();
                    // Add quyền thuộc chức năng
                    List<string> lst = item.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    objET.FunctionID = new Guid(lst[0]);
                    objET.RoleID = Convert.ToInt32(lst[1]);
                    objET.GroupID = GroupID;
                    if (objBL.Insert(objET))
                    {
                        objMsg.Error = false;
                        objMsg.Message = "Cập nhật thành công";
                    }
                    else
                    {
                        objMsg.Error = true;
                        objMsg.Message = "Cập nhật không thành công";
                        break;
                    }

                }
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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.PhanQuyenGroup;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion
            objMsg.RenderMessage(objMsg, context);
        }
        protected void UpdateGroupFn(HttpContext context)
        {
            string Language = Pvn.Utils.Constants.Language.VIETNAMESE;
            int UsedState = 1;
            SysGroupFunctionBL objBL = new SysGroupFunctionBL();
            string listUserFn = string.Empty;
            Guid GroupID=Guid.Empty;
            string ListFunction = string.Empty;
            if (!string.IsNullOrEmpty(context.Request["listuserfn"]))
                listUserFn = (context.Request["listuserfn"]);

            if (!string.IsNullOrEmpty(context.Request["GroupID"]))
                GroupID = new Guid (context.Request["GroupID"]);
            List<string> listStrLineElements = listUserFn.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            List<SysGroupFunctionET> listAll = objBL.GetAllET_SysGroupFunction_By_GroupID(GroupID, Language, UsedState);

            List<SysGroupFunctionET> listUserFnDel = listAll.Where(p => !listStrLineElements.Contains(p.FunctionID.ToString())).ToList();
            List<SysGroupFunctionET> listUserFnAdd = listAll.Where(p => listStrLineElements.Contains(p.FunctionID.ToString())).ToList();
            if (listUserFnDel != null && listUserFnDel.Count > 0)
            {
                List<SysGroupFunctionET> listUserFnDelCheck = listUserFnDel.Where(p => p.CheckGroupFunction == "checked").ToList();
                for (int i = listUserFnDelCheck.Count() - 1; i >= 0; i--)
                {
                    objMsg = objBL.Delete(listUserFnDelCheck[i].Group_FunctionID);
                    if (objMsg.Error)
                        break;
                }

            }
            if (listUserFnAdd != null)
            {
                foreach (SysGroupFunctionET objET in listUserFnAdd.Where(p => p.CheckGroupFunction != "checked"))
                {
                    objET.GroupID = GroupID;
                    if (objBL.Insert(objET))
                    {
                        objMsg.Error = false;
                        objMsg.Message = "Cập nhật thành công";
                    }
                    else
                    {
                        objMsg.Error = true;
                        objMsg.Message = "Cập nhật không thành công";
                    }
                }
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
                objLog.ThaoTac = (int)Pvn.Utils.EnumET.EnumThaoTac.ChucNangNhom;
                objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
                objLog.Note = objMsg.Message;
                objLogDA.Insert(objLog.FunctionID, objLog.ThaoTac, objLog.Note, objLog.ClientIP, objLog.CreatedBy, objLog.CreatedDate);
            }
            #endregion

            objMsg.RenderMessage(objMsg, context);
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
            Sys_GroupET objET = RequestEntity(context);
            if (objBL.Update(objET))
            {
                objMsg.Error = false;
                objMsg.Message = "Cập nhật thành công";

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
            Sys_GroupET objET = RequestEntity(context);
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

        private Sys_GroupET RequestEntity(HttpContext context)
        {
            Sys_GroupET objET = new Sys_GroupET();
            if (!string.IsNullOrEmpty(context.Request["GroupID"]))
                objET.GroupID = new Guid(context.Request["GroupID"]);
            if (!string.IsNullOrEmpty(context.Request["UnitID"]))
                objET.UnitID = new Guid(context.Request["UnitID"]);
            if (!string.IsNullOrEmpty(context.Request["UsedState"]))
                objET.UsedState = Convert.ToInt32( context.Request["UsedState"]);
            if (!string.IsNullOrEmpty(context.Request["Code"]))
                objET.Code = context.Request["Code"].Trim();
            if (!string.IsNullOrEmpty(context.Request["Name"]))
                objET.Name = context.Request["Name"].Trim();
            if (!string.IsNullOrEmpty(context.Request["RolePermission"]))
                objET.RolePermission = Convert.ToInt32(context.Request["RolePermission"]);
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
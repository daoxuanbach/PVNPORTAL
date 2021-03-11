//1:checked colum not exit
//oReader.Table.Columns.Contains("UserName") 
//Pvn.Utils.Common.ReaderContainsColumn(oReader, "UnitName") 
//aThucHien : IHttpHandler, IReadOnlySessionState



//Sys_LogET objLog = new Sys_LogET();
//string FnID = context.Request.UrlReferrer.Query.Replace("?FunctionID=", "");
//                if (!string.IsNullOrEmpty(FnID))
//                {
//                    Guid FunID = Guid.Empty;
//                    if (Pvn.Utils.Utilities.IsGuid(FnID, out FunID))
//                    {
//                        objLog.FunctionID = FunID;
//                    }
//                    objLog.ThaoTac = (int) Pvn.Utils.EnumET.EnumThaoTac.ThemMoi;
//objLog.CreatedBy = new Sys_UserBL().GetUserLogin().ToString();
//objLog.Note = objMsg.Message;
//                    objLogDA.Insert(objLog);
//                }
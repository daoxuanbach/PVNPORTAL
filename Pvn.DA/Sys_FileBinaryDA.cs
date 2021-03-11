using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pvn.Utils;
namespace Pvn.DA
{
    public class Sys_FileBinaryDA : DataProvider
    {
        public void GetItemByPK(ref Sys_FileBinary sfInfo)
        {
            try
            {
                List<Sys_FileBinary> lstEntity = new List<Sys_FileBinary>();
                DataTable dt = GetTableByProcedure("sp_GetByPK_Sys_FileBinary", sfInfo.FileBinaryID);
                lstEntity = PaicExtensions.ConvertDataTable<Sys_FileBinary>(dt);
                sfInfo = lstEntity.FirstOrDefault();
               }
            catch (Exception exx)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleDA", "GetSearchPaging", exx.Message);                
            }
        
        }

    }
}

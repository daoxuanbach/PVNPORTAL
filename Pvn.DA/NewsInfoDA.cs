using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class NewsInfoDA : Pvn.DA.DataProvider
    {
        public NewsInfoDA() { }
        public DataTable GetNewsInfoType()
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetNewsInfoType");
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("NewsInfoDA", "GetEventAnnouncement", ex.Message);
                return null;
            }
        }

        public DataTable GetNewsInfoByType(int infoTypeID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetNewsInfoByType", infoTypeID);
               
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("NewsInfoDA", "GetNewsInfoByType", ex.Message);
                return null;
            }
        }
    }
}

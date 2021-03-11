using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class MeetingDA : Pvn.DA.DataProvider
    {
        /// <summary>
        /// Get meeting
        /// </summary>
        /// <param name="meetingDate"></param>
        /// <returns></returns>
        public DataTable GetSearchPaging(DateTime? meetingDate)
        {
            try
            {
                DataTable dt =GetTableByProcedure("sp_Presentation_Meeting_GetPaging", meetingDate);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("MeetingDA", "GetSearchPaging", ex.Message);
                return null;
            }
        }

        public DataTable GetMeeting_ServiceMobile(DateTime? meetingDate)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Meeting_ServiceMobile", meetingDate);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("MeetingDA", "GetMeeting_ServiceMobile", ex.Message);
                return null;
            }
        }
    }
}

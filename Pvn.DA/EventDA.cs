using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class EventDA : Pvn.DA.DataProvider
    {
        public EventDA() { }

        /// <summary>
        /// Get Event
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventAnnouncement(Guid categoryID, int totalItems)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_EventAnnouncement", categoryID, totalItems);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncement", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get Event search paging
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventAnnouncementSearchPaging(Guid categoryID, int pageIndex, int rowsInPage, ref int totalRecords)
        {
            try
            {
                DataTable dt =GetTableByProcedure("sp_Presentation_EventAnnouncementSearchPaging", categoryID, pageIndex, rowsInPage);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncementSearchPaging", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get Event by time and time
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventByTimeAndType(short eventType, DateTime beginDate, DateTime endDate)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_EventGetByTimeAndType", eventType, beginDate, endDate);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventAnnouncementSearchPaging", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// Get event by id
        /// </summary>
        /// <param name="eventID"></param>
        /// <returns></returns>
        public DataSet GetEventByID(int eventID, int totalOtherItems)
        {
            try
            {
                DataSet dt = GetDatasetByProcedure("dbo.sp_Presentation_EventAnnouncementGetByID", eventID, totalOtherItems);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventByID", ex.Message);
                return null;
            }
        }


        /// <summary>
        /// Get thong cao bao chi by type
        /// </summary>
        /// <param name="EventDate"></param>
        /// <returns></returns>
        public DataTable GetEventByTypeWithSearchPaging(short eventType, int pageIndex, int rowsInPage, ref int totalRecords)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_EventGetByTypeAndPaging",
                    eventType, pageIndex, rowsInPage);
                if (dt != null && dt.Rows.Count > 0)
                {
                    totalRecords = int.Parse(dt.Rows[0]["TotalRows"].ToString());
                }
                return dt;
            }
            catch (Exception ex)
            {
               Pvn.Utils.LogFile.WriteLogFile("EventDA", "GetEventByID", ex.Message);
                return null;
            }
        }
    }
}

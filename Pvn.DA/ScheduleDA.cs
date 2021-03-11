using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.DA
{
    public class ScheduleDA : Pvn.DA.DataProvider
    {
        public ScheduleDA() { }
        /// <summary>
        /// Get Schedule
        /// </summary>
        /// <param name="ScheduleDate"></param>
        /// <returns></returns>
        public DataTable GetSearchPaging(int managerID, DateTime? beginDate, DateTime? endDate, string userID)
        {
            try
            {
                DataTable dt = GetDatasetByProcedure("sp_Presentation_Schedule_GetPaging", managerID, beginDate, endDate, userID).Tables[0];
                  
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleDA", "GetSearchPaging", ex.Message);

                return null;
            }
        }

        /// <summary>
        /// get manager
        /// </summary>
        /// <returns></returns>
        public DataTable GetManager()
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetManagers");
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleDA", "GetManager", ex.Message);

                return null;
            }
        }

        /// <summary>
        /// get schedule by manager type
        /// </summary>
        /// <param name="managerType"></param>
        /// <param name="fromDate">Should be in format dd.MM.yyyy</param>
        /// <param name="toDate">Should be in format dd.MM.yyyy</param>
        /// <returns></returns>
        public DataTable GetByManagerType(int managerType, string fromDate, string toDate)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Schedule_GetByManagerType", managerType, fromDate, toDate);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleDA", "GetByManagerType", ex.Message);
                return null;
            }
        }

        /// <summary>
        /// get schedule for manager
        /// </summary>
        /// <param name="managerType"></param>
        /// <param name="fromDate">Should be in format dd.MM.yyyy</param>
        /// <param name="toDate">Should be in format dd.MM.yyyy</param>
        /// <returns></returns>
        public DataTable GetScheduleForManager(DateTime? currentDate, string userID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_Schedule_GetManagers", currentDate, userID);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleDA", "GetScheduleForManager", ex.Message);
                return null;
            }
        }
        /// <summary>
        /// get schedule for manager
        /// </summary>
        /// <param name="managerType"></param>
        /// <param name="fromDate">Should be in format dd.MM.yyyy</param>
        /// <param name="toDate">Should be in format dd.MM.yyyy</param>
        /// <returns></returns>
        public DataTable GetScheduleForManager_ServiceMobile(DateTime? currentDate, string userID)
        {
            try
            {
                DataTable dt = GetTableByProcedure("sp_Presentation_GetManagers_ServiceMobile", currentDate, userID);
                return dt;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleDA", "GetScheduleForManager", ex.Message);
                return null;
            }
        }
        

    }
}

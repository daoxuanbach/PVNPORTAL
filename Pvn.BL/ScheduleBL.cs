using Pvn.DA;
using Pvn.Entity;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.BL
{
    public class ScheduleBL
    {
        #region Constructors
        ScheduleDA objScheduleDA;
        public ScheduleBL()
        {
            objScheduleDA = new ScheduleDA();
        }

        #endregion Constructors


        /// <summary>
        /// Get Schedule
        /// </summary>
        /// <param name="ScheduleDate"></param>
        /// <returns></returns>
        public DataTable GetSearchPaging(int managerID, DateTime? beginDate, DateTime? endDate, string userID)
        {
            try
            {

                return objScheduleDA.GetSearchPaging(managerID, beginDate, endDate, userID); ;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);                
                return null;
            }
        }
        public List<ScheduleInfo> GetSearchPaging2(int managerID, DateTime? beginDate, DateTime? endDate, string userID)
        {
            try
            {
                DataTable dt = objScheduleDA.GetSearchPaging(managerID, beginDate, endDate, userID);
                List<ScheduleInfo> lstScheduleInfo = ProcessScheduleData(dt, Convert.ToDateTime(endDate));
                return lstScheduleInfo;
                //return objScheduleDA.GetSearchPaging(managerID, beginDate, endDate, userID); ;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleBL", "GetSearchPaging", ex.Message);
                return null;
            }
        }
        public List<ScheduleInfo> ProcessScheduleData(DataTable dt, DateTime dtToDate)
        {
            //get daystart
            List<ScheduleInfo> lstScheduleInfo = new List<ScheduleInfo>();
            try
            {

                if (dt != null && dt.Rows.Count > 0)
                {
                    //first select distinct beginday
                    DataView dvScheduleBeginDay = new DataView(dt);
                    DataTable dtBeginDay = dvScheduleBeginDay.ToTable(true, "BeginDay");

                    //clone raw datatable
                    DataTable dtClone = dt.Copy();

                    //second --> select table schedule by day
                    //list scheduleinfo detail
                    List<ScheduleInfoDetail> lstScheduleInfoDetail = null;
                    //schedule info
                    ScheduleInfo objScheduleInfo = null;
                    for (int k = 0; k < dtBeginDay.Rows.Count; k++)
                    {
                        //get schedules for each day
                        DataRow[] drScheduleInfo = dtClone.Select(string.Format("BeginDay = '{0}'", dtBeginDay.Rows[k]["BeginDay"]));

                        //new object schedule
                        objScheduleInfo = new ScheduleInfo();
                        DateTime dayBegin = Convert.ToDateTime(drScheduleInfo[0]["BeginDay"]);
                        objScheduleInfo.Ngay = dayBegin.ToString("dd/MM/yyyy");

                        //process each schedule on that day
                        //prepare list schedule info
                        lstScheduleInfoDetail = new List<ScheduleInfoDetail>();
                        for (int i = 0; i < drScheduleInfo.Length; i++)
                        {
                            //get end day                        
                            DateTime dayEnd = Convert.ToDateTime(drScheduleInfo[i]["EndDay"]);
                            //process when day begin less than day end
                            if (dayBegin < dayEnd)
                            {
                                //add to dtBeginDay if nesscessary
                                DataRow[] tempEndDate = dtBeginDay.Select(string.Format("BeginDay = '{0}'", dtToDate));
                                if (tempEndDate == null || tempEndDate.Length == 0)
                                {
                                    DataRow drBeginDay = dtBeginDay.NewRow();
                                    drBeginDay["BeginDay"] = dtToDate;
                                    dtBeginDay.Rows.Add(drBeginDay);
                                }
                                //int dateCounter = 1;
                                //for (DateTime objDateTime = dayBegin.AddDays(1); objDateTime <= dayEnd; objDateTime += TimeSpan.FromDays(1))
                                //{

                                //}
                                DataRow drSchedule = dtClone.NewRow();
                                //add data
                                drSchedule["Descriptions"] = drScheduleInfo[i]["Descriptions"];
                                drSchedule["BeginDay"] = dayBegin.AddDays(1);
                                drSchedule["EndDay"] = dayEnd;
                                drSchedule["BeginDate"] = Convert.ToDateTime(drScheduleInfo[i]["BeginDate"]).AddDays(1);
                                //dateCounter++;
                                drSchedule["EndDate"] = Convert.ToDateTime(drScheduleInfo[i]["EndDate"]);
                                drSchedule["ListMangerName"] = drScheduleInfo[i]["ListMangerName"];
                                drSchedule["ToAddress"] = drScheduleInfo[i]["ToAddress"];
                                dtClone.Rows.Add(drSchedule);
                            }
                            //add schedule detail
                            ScheduleInfoDetail objScheduleInfoDetail = new ScheduleInfoDetail();
                            objScheduleInfoDetail.STT = Convert.ToString(i + 1);
                            objScheduleInfoDetail.ThoiGianRange = string.Format("{0} - {1}", Convert.ToDateTime(drScheduleInfo[i]["BeginDate"]).ToString("hh:mm tt"),
                                Convert.ToDateTime(drScheduleInfo[i]["EndDate"]).ToString("hh:mm tt"));
                            objScheduleInfoDetail.LanhDao = string.Format(Convert.ToString(drScheduleInfo[i]["ListMangerName"]));
                            objScheduleInfoDetail.NoiDung = string.Format(Convert.ToString(drScheduleInfo[i]["Descriptions"]));
                            objScheduleInfoDetail.DiaDiem = string.Format(Convert.ToString(drScheduleInfo[i]["ToAddress"]));
                            lstScheduleInfoDetail.Add(objScheduleInfoDetail);
                        }
                        //add to list
                        objScheduleInfo.ListScheduleDetail = lstScheduleInfoDetail;
                        lstScheduleInfo.Add(objScheduleInfo);
                    }
                }
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("ScheduleBL", "ProcessScheduleData", ex.Message);
            }
            return lstScheduleInfo;
        }
        /// <summary>
        /// get manager
        /// </summary>
        /// <returns></returns>
        public DataTable GetManager()
        {
            try
            {
                return objScheduleDA.GetManager();
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
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

                return objScheduleDA.GetByManagerType(managerType, fromDate, toDate);
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
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

                return objScheduleDA.GetScheduleForManager(currentDate, userID);
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        public List<GroupedLichCongTacET> GetScheduleForManager_ServiceMobile(DateTime? currentDate, string userID)
        {
            try
            {
                List<GroupedLichCongTacET> lstGroup = new List<GroupedLichCongTacET>();
                List<LichCongTacDetailET> lstLichCT = new List<LichCongTacDetailET>();
                DataTable dt = objScheduleDA.GetScheduleForManager_ServiceMobile(currentDate, userID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lstLichCT.Add(setPropertiesMobile(dt.Rows[i]));
                }
                List<int> lstManarer = lstLichCT.Select(p => p.ManagerID).Distinct().ToList();
                foreach (int item in lstManarer)
                {
                    List<LichCongTacDetailET> lstLichCTByManager = lstLichCT.Where(p => p.ManagerID == item).ToList();
                    if (lstLichCTByManager!=null&&lstLichCTByManager.Count>0)
                    {
                        lstGroup.Add(new GroupedLichCongTacET { Name = lstLichCTByManager.FirstOrDefault().Name, ManagerID = item, lstLichCongTac = lstLichCTByManager });
                    }
                }
                return lstGroup;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        private LichCongTacDetailET setPropertiesMobile(DataRow oReader)
        {
            try
            {
                LichCongTacDetailET objCMS_NewsET = new LichCongTacDetailET();
                if (oReader["Name"] != DBNull.Value)
                    objCMS_NewsET.Name = Convert.ToString(oReader["Name"]);
                if (oReader["ManagerID"] != DBNull.Value)
                    objCMS_NewsET.ManagerID = Convert.ToInt32(oReader["ManagerID"]);
                if (oReader["Title"] != DBNull.Value)
                    objCMS_NewsET.Title = Convert.ToString(oReader["Title"]);
                if (oReader["MTime"] != DBNull.Value)
                    objCMS_NewsET.MTime = Convert.ToString(oReader["MTime"]);
                if (oReader["ToAddress"] != DBNull.Value)
                    objCMS_NewsET.ToAddress = Convert.ToString(oReader["ToAddress"]);
                return objCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", "setProperties", ex.Message);
                throw ex;
            }
        }

    }
}

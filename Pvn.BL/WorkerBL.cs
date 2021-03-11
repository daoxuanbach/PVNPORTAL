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
    public class WorkerBL
    {
        #region Constructors
        WorkerDA objPVNWorkerBLDA;
        public WorkerBL()
        {
            objPVNWorkerBLDA = new WorkerDA();
        }



        #endregion Constructors


        /// <summary>
        /// Get Worker
        /// </summary>
        /// <param name="WorkerDate"></param>
        /// <returns></returns>
        public DataTable GetBirthdayAnnouncement(int companyID)
        {
            try
            {
                DataTable dt = objPVNWorkerBLDA.GetBirthdayAnnouncement(companyID);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Get worker by condition
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public DataSet GetSearchPaging(int companyID, short companyLevel)
        {
            try
            {
                DataSet dt = objPVNWorkerBLDA.GetSearchPaging(companyID, companyLevel);
                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        
        /// <summary>
        /// Get worker by condition
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public DataTable GetSearchByKeyword(string keyword)
        {
            try
            {
                DataTable dt = objPVNWorkerBLDA.GetSearchByKeyword(keyword);
                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        public List<WorkerDetailET> GetListSearchByKeywordMobile(int CompanyID, string keyword)
        {
            try
            {
                List<WorkerDetailET> lst = new List<WorkerDetailET>();
                DataTable dt = objPVNWorkerBLDA.GetSearchByKeywordMobile(CompanyID, keyword);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(setPropertiesMobile(dt.Rows[i]));
                }
                return lst;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        
        /// <summary>
        /// Get worker Service Mobile
        /// </summary>
        /// <param name="companyID"></param>
        /// <param name="workerName"></param>
        /// <returns></returns>
        public List<WorkerDetailET> GetSearchPagingServiceMobile(int companyID, short companyLevel)
        {
            try
            {
                List<WorkerDetailET> lst = new List<WorkerDetailET>();
                DataTable dt = objPVNWorkerBLDA.GetSearchPagingServiceMobile(companyID, companyLevel);             
                 for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(setPropertiesMobile(dt.Rows[i]));
                }
                return lst;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        public List<WorkerDetailET> GetListSearchByKeyword(string keyword)
        {
            try
            {
                List<WorkerDetailET> lst = new List<WorkerDetailET>();
                DataTable dt = objPVNWorkerBLDA.GetSearchByKeyword(keyword);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(setProperties(dt.Rows[i]));
                }
                return lst;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }
        private WorkerDetailET setProperties(DataRow oReader)
        {
            try
            {
                WorkerDetailET objCMS_NewsET = new WorkerDetailET();
                if (oReader["HoTen"] != DBNull.Value)
                    objCMS_NewsET.HoTen = Convert.ToString(oReader["HoTen"]);
                if (oReader["GioiTinh"] != DBNull.Value)
                    objCMS_NewsET.GioiTinh = Convert.ToString(oReader["GioiTinh"]);
                if (oReader["Contact"] != DBNull.Value)
                {
                    objCMS_NewsET.Contact = Convert.ToString(oReader["Contact"]);
                }

                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_NewsET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader.Table.Columns.Contains("DepartmentName") && oReader["DepartmentName"] != DBNull.Value)
                    objCMS_NewsET.DepartmentName = Convert.ToString(oReader["DepartmentName"]);
                return objCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        private WorkerDetailET setPropertiesMobile(DataRow oReader)
        {
            try
            {
                WorkerDetailET objCMS_NewsET = new WorkerDetailET();
                if (oReader["HoTen"] != DBNull.Value)
                    objCMS_NewsET.HoTen = Convert.ToString(oReader["HoTen"]);
                if (oReader["GioiTinh"] != DBNull.Value)
                    objCMS_NewsET.GioiTinh = Convert.ToString(oReader["GioiTinh"]);
                if (oReader["WorkerContact"] != DBNull.Value)
                {
                    string contact = Convert.ToString(oReader["WorkerContact"]);
                    List<string> listStrLineElements = contact.Split(new char[] { '$' }, StringSplitOptions.RemoveEmptyEntries).ToList();
                    List<ContactET> lstContact = new List<ContactET>();
                    foreach (string itemContact in listStrLineElements)
                    {
                        if (itemContact.Contains("Máy di động"))
                        {
                            objCMS_NewsET.SDTLienHe = itemContact.Substring(itemContact.IndexOf("#") + 1);
                        }
                        lstContact.Add(new ContactET { NoiDung = itemContact.Replace("#", ": ") });
                       
                    }
                    objCMS_NewsET.LstContact = lstContact;
                }
                if (oReader["ImageURL"] != DBNull.Value)
                    objCMS_NewsET.ImageURL = Convert.ToString(oReader["ImageURL"]);
                if (oReader.Table.Columns.Contains("DepartmentName") && oReader["DepartmentName"] != DBNull.Value)
                    objCMS_NewsET.DepartmentName = Convert.ToString(oReader["DepartmentName"]);
                if (oReader.Table.Columns.Contains("JobTitle") && oReader["JobTitle"] != DBNull.Value)
                    objCMS_NewsET.JobTitle = Convert.ToString(oReader["JobTitle"]);
                return objCMS_NewsET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", "setProperties", ex.Message);
                throw ex;
            }
        }
        /// <summary>
        /// Get list manager for displaying on chart
        /// </summary>
        /// <returns></returns>
        public DataSet GetListManagerForChart()
        {
            try
            {
                DataSet dt = objPVNWorkerBLDA.GetListManagerForChart();
                return dt;
            }
            catch (Exception ex)
            {
                // CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Get manager by ID
        /// </summary>
        /// <param name="managerID"></param>
        /// <returns></returns>
        public DataTable GetManagerByID(int managerID)
        {
            try
            {
                DataTable dt = objPVNWorkerBLDA.GetManagerByID(managerID);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

    }
}

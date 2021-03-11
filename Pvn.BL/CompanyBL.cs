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
    public class CompanyBL
    {
        CompanyDA objDA;
        public CompanyBL()
        {
            objDA = new CompanyDA();
        }
        /// <summary>
        /// Get Company by level
        /// </summary>
        /// <param name="CompanyDate"></param>
        /// <returns></returns>
        public DataTable GetCompanyByLevel(short companyLevel)
        {
            try
            {
                DataTable dt = objDA.GetCompanyByLevel(companyLevel);
                return dt;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }
        }

        /// <summary>
        /// Get company by level and parent
        /// </summary>
        /// <param name="companyLevel"></param>
        /// <param name="_parentID"></param>
        /// <returns></returns>
        public DataTable GetAllCompanyByLevelAndParent(int? companyLevel, int? _parentID)
        {
            DataTable dt;
            try
            {
                return dt = objDA.GetAllCompanyByLevelAndParent(companyLevel, _parentID);
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }

        }

        public List<CMS_CompanyET> GetAllLstCompanyByLevelAndParent(int? companyLevel, int? _parentID)
        {
            DataTable dt;
             List<CMS_CompanyET> lst = new List<CMS_CompanyET>();
            try
            {
                 dt = objDA.GetAllCompanyByLevelAndParent(companyLevel, _parentID);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    lst.Add(setProperties(dt.Rows[i]));
                }
                return lst;
            }
            catch (Exception ex)
            {
                //CommonLib.Common.Info.Instance.WriteToLog(ex);
                return null;
            }

        }
        private CMS_CompanyET setProperties(DataRow oReader)
        {
            try
            {
                CMS_CompanyET objET = new CMS_CompanyET();
                if (oReader["CompanyName"] != DBNull.Value)
                    objET.CompanyName = Convert.ToString(oReader["CompanyName"]);
                if (oReader["CompanyID"] != DBNull.Value)
                    objET.CompanyID = Convert.ToInt32(oReader["CompanyID"]);
                return objET;
            }
            catch (Exception ex)
            {
                Pvn.Utils.LogFile.WriteLogFile("CMS_NewsDA", "setProperties", ex.Message);
                throw ex;
            }
        }
    }
}

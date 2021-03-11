using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;
using Pvn.Entity;
using Pvn.DA;
using System.Data;
using Pvn.Utils;
namespace Pvn.BL
{
    public class NewsInfoBL
    {
        #region Biến + thuộc tính
        NewsInfoDA objDA;
        public NewsInfoBL()
        {
            objDA = new NewsInfoDA();
        }
        #endregion
      
        public DataTable GetNewsInfoType()
        {
            return objDA.GetNewsInfoType();
        }

        public DataTable GetNewsInfoByType(int infoTypeID)
        {
            return objDA.GetNewsInfoByType(infoTypeID);
        }
    }
}


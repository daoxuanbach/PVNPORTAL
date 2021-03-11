using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Utils
{
  public  class formatUtils
    {
      public static DateTime? FormatDateTime(string dateString)
      {
          try
          {
              return DateTime.ParseExact(dateString, "dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture); 
          }
          catch (FormatException)
          {
              return null;
          } 
      }
      public static DateTime? FormatDate(string dateString)
      {
          try
          {
              return DateTime.ParseExact(dateString, "dd/MM/yyyy", CultureInfo.InvariantCulture);
          }
          catch (FormatException)
          {
              return null;
          }
      }

      public static string formatDateToString(DateTime? dateTime)
      {
          try
          {
                if (dateTime!=null)
                {
                    DateTime dt = Convert.ToDateTime(dateTime);
                    return dt.ToString("dd/MM/yyyy h:mm tt", CultureInfo.InvariantCulture);
                }
                return "";

          }
          catch (Exception)
          {
              return null;
          }
      }
    }
     
}

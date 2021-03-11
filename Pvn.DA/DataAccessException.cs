using System;
using System.Collections.Generic;
using System.Web;

namespace Pvn.DA
{
    public class DataAccessException : Exception
    {
        public DataAccessException(string message)
            : base(message)
        {
            
        }
    }
}

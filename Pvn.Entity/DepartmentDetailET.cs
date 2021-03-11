using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
   public class DepartmentDetailET
    {
        public string DepartmentName { get; set; }
        public List<PhoneDetailET> ListPhoneDetail { get; set; }
    }
}

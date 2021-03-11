using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class MeetingMobileET
    {
        public int RoomID { get; set; }
        public string RoomName { get; set; }
        public string RoomAddress { get; set; }
        public string Title { get; set; }
        public DateTime MeetingDate { get; set; }
        public string MTime { get; set; }
    }
}

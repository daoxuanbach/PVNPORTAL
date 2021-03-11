using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Entity
{
    public class Sys_FileBinary
    {
       
        public virtual string CreatedBy { get; set; }
        public virtual DateTime? CreatedDate { get; set; }
        public virtual byte[] FileAttach { get; set; }
        public virtual Guid FileBinaryID { get; set; }
        public virtual string FileDescription { get; set; }
        public virtual string FileName { get; set; }
        public virtual string FileSize { get; set; }
        public virtual string ModifiedBy { get; set; }
        public virtual DateTime? ModifiedDate { get; set; }
    }
}

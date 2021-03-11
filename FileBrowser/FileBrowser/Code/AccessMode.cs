using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FileBrowser.FileBrowser.Code
{
    class AccessMode
    {
        public static AccessMode DenyAll { get; set; }

        public static AccessMode ReadOnly { get; set; }

        public static AccessMode Write { get; set; }

        public static AccessMode Delete { get; set; }

        public static AccessMode Default { get; set; }
    }
}

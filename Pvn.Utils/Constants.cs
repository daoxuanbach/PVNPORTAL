using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pvn.Utils
{
    public static class Constants
    {
        public static int ROW_PAGE = 20;
        public static int PAGE_STEP = 3;
        public const string COMMAR = ",";
        public class Language
        {
            public const string ENGLISH = "en-US";
            public const string VIETNAMESE = "vi-VN";
        }
        public class ObjectType
        {
            public const string Link = "Link";
            public const string Category = "CategoryID";
            public const string News = "NewsID";
        }
    }
}

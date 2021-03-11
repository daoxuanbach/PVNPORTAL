using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pvn.Web.Codes
{
    public class RenderNewsContent
    {
        public const string codeSignBegin = "$$code:";
        public const string codeSignEnd = "$";
        public const char codespr = ';';
        public const char codeop = '=';

        abstract class CodeProcessorBase
        {
            public abstract string Code
            {
                get;
            }

            public abstract void AnalyzingParameter(string param);
            public abstract string Process(string contentBase, ref int codeIndex);

            public abstract CodeProcessorBase Clone();
        }

        class BackgroundProcessor : CodeProcessorBase
        {
            public const string _code = "bk";
            private const string _renderTemp = @"<script>
	var elements = document.getElementsByClassName('news-content col-xs-12');
	for (var i = 0; i < elements.length; i++) {{
		elements[i].style.backgroundColor = '{0}';
	}}
</script>";
            public override string Code
            {
                get { return _code; }
            }

            public string BKColor
            {
                get;
                private set;
            }
            public override void AnalyzingParameter(string param)
            {
                BKColor = param;
            }
            public override string Process(string contentBase, ref int codeIndex)
            {
                string script = string.Format(_renderTemp, BKColor);
                return string.Format("{0}{1}", script, contentBase);
            }

            public override CodeProcessorBase Clone()
            {
                return new BackgroundProcessor();
            }
        }

        private static Dictionary<string, CodeProcessorBase> codeProcessorList = new Dictionary<string, CodeProcessorBase>(StringComparer.InvariantCultureIgnoreCase);
        static RenderNewsContent()
        {
            codeProcessorList.Add(BackgroundProcessor._code, new BackgroundProcessor());
        }

        public static string ProcessRender(string orgContent)
        {
            if (string.IsNullOrEmpty(orgContent)) return orgContent;
            int idx = orgContent.IndexOf(codeSignBegin);
            if (idx < 0) return orgContent;
            int idx1 = orgContent.IndexOf(codeSignEnd, idx + codeSignBegin.Length);
            if (idx1 < 0) idx1 = orgContent.Length;
            int idx2 = idx + codeSignBegin.Length;
            string codeinfo = orgContent.Substring(idx2, idx1 - idx2);
            orgContent = orgContent.Substring(0, idx) + (idx1 < orgContent.Length ? orgContent.Substring(idx1 + 1) : string.Empty);
            string[] parts = codeinfo.Split(codespr);
            foreach (string item in parts)
            {
                if (string.IsNullOrEmpty(item)) continue;
                idx1 = item.IndexOf(codeop);
                string code = idx1 < 0 ? item : item.Substring(0, idx1);
                string pr = idx1 < 0 ? string.Empty : item.Substring(idx1 + 1);
                CodeProcessorBase processor;
                if (codeProcessorList.TryGetValue(code, out processor))
                {
                    processor = processor.Clone();
                    processor.AnalyzingParameter(pr);
                    orgContent = processor.Process(orgContent, ref idx);
                }
            }
            return orgContent;
        }
    }
}
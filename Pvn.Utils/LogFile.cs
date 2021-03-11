using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Pvn.Utils
{
    public class LogFile
    {
        private const string FILE_NAME = "PaicLogTextFile.txt";
        private static string ConfigFilePath
        {
            get { return (HttpContext.Current.Server.MapPath("/") + FILE_NAME); }
        }
        public static void WriteLogFile(string fileName, string methodName, string message)
        {
            FileStream fs = null;
            if (!File.Exists(ConfigFilePath))
            {
                using (fs = File.Create(ConfigFilePath))
                {
                }
            }
            try
            {
                if (!string.IsNullOrEmpty(message))
                {
                   // using (FileStream file = new FileStream(ConfigFilePath, FileMode.OpenOrCreate, FileAccess.Write))
                    using (FileStream file = new FileStream(ConfigFilePath, FileMode.Append, FileAccess.Write))
                    {
                        StreamWriter streamWriter =  new StreamWriter(file);
                        streamWriter.WriteLine((((System.DateTime.Now + " - ") + fileName + " - ") + methodName + " - ") + message );
                        //streamWriter.WriteLine("\n");
                        streamWriter.Close();
                    }
                }
            }
            catch (Exception ex)
            {
                WriteLogFile("Pvn.Utils.LogFile", "WriteLogFile", ex.Message);
            }
        }
    }
}

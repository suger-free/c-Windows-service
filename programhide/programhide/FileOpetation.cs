using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace programhide
{
    class FileOpetation
    {
        /// <summary>  
        /// 保存至本地文件  
        /// </summary>  
        /// <param name="ETMID"></param>  
        /// <param name="content"></param>  
        public static void SaveRecord(string content)
        {
            if (string.IsNullOrEmpty(content))
            {
                return;
            }


            FileStream fileStream = null;


            StreamWriter streamWriter = null;


            try
            {
                string path = Path.Combine(System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase, string.Format("{0:yyyyMMdd}", DateTime.Now));


                using (fileStream = new FileStream(path, FileMode.Append, FileAccess.Write))
                {
                    using (streamWriter = new StreamWriter(fileStream))
                    {
                        streamWriter.Write(content);


                        if (streamWriter != null)
                        {
                            streamWriter.Close();
                        }
                    }


                    if (fileStream != null)
                    {
                        fileStream.Close();
                    }
                }
            }
            catch { }
        }
    }
}

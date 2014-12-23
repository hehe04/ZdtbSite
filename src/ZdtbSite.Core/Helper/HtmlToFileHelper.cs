using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ZdtbSite.Core.Helper
{
    public static class HtmlToFileHelper
    {
        /// <summary>
        /// HTML转换PDF
        /// </summary>
        /// <param name="url">需要转换html的url</param>
        /// <returns>PDF文件路径</returns>
        public static string HtmlToPDF(string url)
        {
            string fileName = Guid.NewGuid().ToString();
            string outputPath = HttpContext.Current.Server.MapPath("/Content/OutPutFile/");
            string savepath = string.Format(outputPath + "\\" + fileName + ".pdf");//最终保存
            try
            {
                if (!string.IsNullOrEmpty(url) || !string.IsNullOrEmpty(savepath))
                {
                    Process p = new Process();
                    string resource = HttpContext.Current.Server.MapPath("/Content/Resoure");
                    string dllstr = string.Format(resource + "\\wkhtmltopdf.exe");
                    if (System.IO.File.Exists(dllstr))
                    {
                        p = System.Diagnostics.Process.Start(dllstr, url + " " + outputPath + fileName + ".pdf");
                        p.WaitForExit();
                    }
                }
                else savepath = null;
            }
            catch (Exception ex)
            {
                savepath = null;
                throw new Exception(ex.ToString());
            }
            return savepath;
        }
    }
}

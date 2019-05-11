using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Hosting;

namespace MyFramework.Business.Functions.FileUpload
{
    public static class DeleteImage
    {
        public static void DeleteImagePath(string path)
        {
            if (path != null)
            {
                var fullpathoffile = HostingEnvironment.MapPath(path) ?? "";
                if (File.Exists(fullpathoffile))
                {
                    File.Delete(fullpathoffile);
                }
            }
        }
    }
}

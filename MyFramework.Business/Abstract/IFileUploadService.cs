using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using MyFramework.Entities.ComplexType;

namespace MyFramework.Business.Abstract
{
   public interface IFileUploadService
   {
        string FileSave(HttpPostedFileBase file, string isim);
        string ImageSave(HttpPostedFileBase file, string isim);
        ImageDetail ThumbImageSave(HttpPostedFileBase file, string isim, int height = 100, int witdh = 100);
        string Thumbnail(HttpPostedFileBase file, string name, int height, int witdh);
    }
}

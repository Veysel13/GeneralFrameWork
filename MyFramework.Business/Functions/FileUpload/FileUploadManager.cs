using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Hosting;
using MyFramework.Business.Abstract;
using MyFramework.Entities.ComplexType;

namespace MyFramework.Business.Functions.FileUpload
{
    public class FileUploadManager : IFileUploadService
    {
        public string FileSave(HttpPostedFileBase file, string isim)
        {
            string extension = file.ContentType.Split('/')[1];
            string filename = $"{isim}_{Guid.NewGuid()}";
            string path = $"/File/";
            file.SaveAs(HostingEnvironment.MapPath($"{path}{filename}.{extension}") ?? throw new InvalidOperationException());

            return $"{path}{filename}.{extension}";
        }
        public string ImageSave(HttpPostedFileBase file, string isim)
        {
            string extension = file.ContentType.Split('/')[1];
            string filename = $"{isim}_{Guid.NewGuid()}";
            string path = $"/Medya/";
            file.SaveAs(HostingEnvironment.MapPath($"{path}{filename}.{extension}") ?? throw new InvalidOperationException());
            return $"{path}{filename}.{extension}";
        }

        public ImageDetail ThumbImageSave(HttpPostedFileBase file, string isim, int height = 100, int witdh = 100)
        {
            string extension = file.ContentType.Split('/')[1];
            string filename = $"{isim}_{Guid.NewGuid()}";
            string path = $"/Medya/";
            file.SaveAs(HostingEnvironment.MapPath($"{path}{filename}.{extension}") ?? throw new InvalidOperationException());

            string thumpImage = Thumbnail(file, $"{filename}.{extension}", height, witdh);
            var imageDetail = new ImageDetail
            {
                ThumpImage = thumpImage,
                Image = $"{path}{filename}.{extension}"
            };
            return imageDetail;
        }

        public string Thumbnail(HttpPostedFileBase file, string name, int height, int witdh)
        {
            int Genislik = witdh; //Thumbnail'in genişliği
            int Yukseklik = height; //Thumbnail'in yüksekliği
            Bitmap Thumbnail = new Bitmap(Genislik, Yukseklik);
            Bitmap OrjinalResim = new Bitmap(file.InputStream);
            Graphics Kanvas = Graphics.FromImage(Thumbnail);
            Kanvas.DrawImage(OrjinalResim, new Rectangle(0, 0, Genislik, Yukseklik), 0, 0, OrjinalResim.Width, OrjinalResim.Height, GraphicsUnit.Pixel);
            string path = $"/Medya/Thump/";
            Thumbnail.Save(HostingEnvironment.MapPath($"{path}{name}") ?? throw new InvalidOperationException(), System.Drawing.Imaging.ImageFormat.Jpeg);
            return $"{path}{name}";
        }
    }
}

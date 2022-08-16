using Core.Utilities.Helpers.FileHelper.Core.Utilities.Helpers.FileHelper;
using ImageMagick;
using Microsoft.AspNetCore.Http;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Core.Utilities.Helpers.FileHelper
{
    // Projeme yükleyeceğim dosyalarla ilgili yükleme,silme,güncelleme işlemlerini bu class!ımda yapıyorum.
    //İşlemin nasıl gerçekleştiğini anlamak için yazdığım yorum satırlarını okumaya En alttaki *Upload* metodunundan başlayabilirsiniz.
    public class FileHeplerManager : IFileHelper
    {
        public void Delete(string filePath)//Burada ki string filePath, 'CarImageManager'dan gelen dosyamın kaydedildiği adres ve adı 
        {
            if (File.Exists(filePath))//if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
        }

        public string Update(IFormFile file, string filePath, string root)//Dosya güncellemek için ise gelen parametreye baktığımızda Güncellenecek yeni dosya, Eski dosyamızın kayıt dizini, ve yeni bir kayıt dizini
        {
            if (File.Exists(filePath))// Tekrar if kontrolü ile parametrede gelen adreste öyle bir dosya var mı diye kontrol ediliyor.
            {
                File.Delete(filePath);//Eğer dosya var ise dosya bulunduğu yerden siliniyor.
            }
            return Upload(file, root);// Eski dosya silindikten sonra yerine geçecek yeni dosyaiçin alttaki *Upload* metoduna yeni dosya ve kayıt edileceği adres parametre olarak döndürülüyor.
        }

        public string Upload(IFormFile file, string root)
        {
            if (file.Length > 0)//file.Length=>Dosya uzunluğunu bayt olarak alır. burada Dosya gönderil mi gönderilmemiş diye test işlemi yapıldı.
            {
                if (!Directory.Exists(root))//Directory=>System.IO'nın bir class'ı. burada ki işlem tam olarak şu. Bu Upload metodumun parametresi olan string root CarManager'dan gelmekte
                {                           //CarImageManager içerisine girdiğinizde buraya parametre olarak *PathConstants.ImagesPath* böyle bir şey gönderilidğini görürsünüz. PathConstants clası içerisine girdiğinizde string bir ifadeyle bir dizin adresi var
                                            //O adres bizim Yükleyeceğimiz dosyaların kayıt edileceği adres burada *Check if a directory Exists* ifadesi şunu belirtiyor dosyanın kaydedileceği adres dizini var mı? varsa if yapısının kod bloğundan ayrılır eğer yoksa içinde ki kodda dosyaların kayıt edilecek dizini oluşturur
                    Directory.CreateDirectory(root);
                }
                string extension = Path.GetExtension(file.FileName);//Path.GetExtension(file.FileName)=>> Seçmiş olduğumuz dosyanın uzantısını elde ediyoruz.
                string guid = GuidHelper.GuidHelperManager.CreateGuid();//Core.Utilities.Helpers.GuidHelper klasürünün içinde ki GuidManager klasörüne giderseniz burada satırda ne yaptığımızı anlayacaksınız
                string filePath = guid + extension;//Dosyanın oluşturduğum adını ve uzantısını yan yana getiriyorum. Mesela metin dosyası ise .txt gibi bu projemizde resim yükyeceğimiz için .jpg olacak uzantılar 
                using (var image=Image.Load(file.OpenReadStream()))
                {
                    //string newSize = ImageRezise(image, 800,100 );
                    //string[] sizearray = newSize.Split(',');
                   
                    //image.Mutate(x => x.Resize(Convert.ToInt32(sizearray[1]), Convert.ToInt32(sizearray[0])));
                    image.Save(root + filePath);
                }
                return filePath;


            }
           
            return null;
        }
        public string ImageRezise(Image img, int MaxHeight, int MaxWidth)
        {
            if (img.Width > MaxWidth || img.Height> MaxHeight)
            {
                double widthratio = (double)img.Width / (double)MaxWidth;
                double heightratio = (double)img.Height /(double) MaxHeight;
                double ratio = Math.Max(widthratio, heightratio);
                int newWidth = (int)(img.Width / ratio);
                int newHeight = (int)(img.Height / ratio);
                return newWidth.ToString() + " ," + newHeight.ToString();
            }
            else
            {
                return img.Height.ToString() + " ," + img.Width.ToString();
            }
        }
    }
}

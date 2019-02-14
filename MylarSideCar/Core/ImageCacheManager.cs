using System;
using System.Drawing;
using System.IO;
using System.Net;
using System.Windows.Forms;

namespace MylarSideCar.Core
{
    ///<summary>
    ///
    ///</summary>
    public class ImageCacheManager
    {
 
        public static Image GetImage(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                return null;
            }
            Uri u = new Uri(url);
            string filename = System.IO.Path.GetFileName(u.LocalPath);
            string path =   Path.GetDirectoryName(Application.ExecutablePath) + "\\imageCache\\";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path =  path + filename;
            if (File.Exists(path))
            {
                return Image.FromFile(path);
            }
            

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Referer = "http://stackoverflow.com";
            request.UserAgent = "Mozilla/5.0";
            using (var response = request.GetResponse())
            {
             
                Stream res=  response.GetResponseStream();
                var image =  Image.FromStream(res);
                image.Save(path);
                return image;
            }
 
        }
 
    

    }
}

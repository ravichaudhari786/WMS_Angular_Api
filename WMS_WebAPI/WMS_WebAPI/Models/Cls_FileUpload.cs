using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using WMS_WebAPI.Controllers;

namespace WMS_WebAPI.Models
{
    public class Cls_FileUpload
    {
        public  string info(FileInputData obj)
        {
            string[] s = obj.base64.ToString().Split(',');
            byte[] imageBytes = Convert.FromBase64String(s[1]);

            string path = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"].ToString() + obj.name;
            File.WriteAllBytes(path, imageBytes);
            //return true;
            path = System.Configuration.ConfigurationManager.AppSettings["GetUploadFilePath"].ToString() + obj.name;
            return path;
        }

        public System.Drawing.Image Base64ToImage(FileInputData obj)
        {
            string[] s = obj.base64.ToString().Split(',');
            byte[] imageBytes = Convert.FromBase64String(s[1]);
            MemoryStream ms = new MemoryStream(imageBytes, 0, imageBytes.Length);
            ms.Write(imageBytes, 0, imageBytes.Length);
            System.Drawing.Image image = System.Drawing.Image.FromStream(ms, true);
            return image;
        }
    }

    public class FileInputData
    {
        public string base64 { get; set; }


        public string name { get; set; }

        public Nullable<int> size { get; set; }

        public string type { get; set; }

    }

    public  class FileRes
    {
        public string FileName { get; set; }
        public string FilePath { get; set; }
    }
}
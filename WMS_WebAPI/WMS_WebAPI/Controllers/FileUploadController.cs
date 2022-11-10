using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WMS_WebAPI.Models;
using System.Data;

namespace WMS_WebAPI.Controllers
{
   

    public class FileUploadController : ApiController
    {
        [HttpPost]
        [Route("api/FileUpload/FileUplaodInfo")]
        public IHttpActionResult FileUplaodInfo(FileInputData obj)
        {
           

            Cls_FileUpload obj1 = new Cls_FileUpload();
            // obj1.info(obj);


            string path = System.Configuration.ConfigurationManager.AppSettings["FileUploadPath"].ToString() + obj.name;
            obj1.Base64ToImage(obj).Save(path);
            FileRes fro = new FileRes();
            fro.FileName = obj.name;
            fro.FilePath = path;

            return Ok(fro);
        }
       
    }
   
}
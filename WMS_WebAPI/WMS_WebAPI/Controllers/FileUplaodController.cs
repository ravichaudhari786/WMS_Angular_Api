using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;

namespace WMS_WebAPI.Controllers
{
    
    public class FileUplaodController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        [Route("api/FileUplaod/Upload")]

        //public Task<Microsoft.AspNetCore.Mvc.IActionResult> Upload(HttpPostedFileBase file)
        //{
        //    //......
        //    return "";
        //}
        public void Upload(HttpPostedFileBase file)
        {
            //......
           
                string hhh = "";
        }


    }
}
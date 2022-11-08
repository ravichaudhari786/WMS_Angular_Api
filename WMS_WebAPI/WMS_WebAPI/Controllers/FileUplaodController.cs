using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WMS_WebAPI.Controllers
{
    
    public class FileUplaodController : ApiController
    {
        // GET api/<controller>
        [HttpPost]
        [Route("api/FileUplaod/Upload")]
        
        public Task<IActionResult> Upload(HttpPostedFileBase file)
        {
            //......
        }

        [HttpPost]
        [Route("api/FileUplaod/Upload1")]

        public Task<IActionResult> Upload1()
        {
            //......
        }
    }
}
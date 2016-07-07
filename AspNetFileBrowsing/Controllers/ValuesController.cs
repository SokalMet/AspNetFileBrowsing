using AspNetFileBrowsing.Controllers.Code;
using AspNetFileBrowsing.Models;
using AspNetFileBrowsing.Models.File;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AspNetFileBrowsing.Controllers
{  
    public class ValuesController : ApiController
    {
        FileHelper file = new FileHelper();   
        // GET api/values
        public FolderDataModel Get()
        {            
            return file.GetFolderData();
        }

        // GET api/values/5
        public FolderDataModel Get(string currentPath, string folderName, bool toUpper)
        {
            return file.GetFolderData(currentPath, folderName, toUpper);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}

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

        // GET api/values/
        public FolderDataModel Get(string currentPath, string folderName)
        {
            return file.GetFolderData(currentPath, folderName);
        }

        // GET api/values/
        public FolderDataModel Get(string currentPath, bool toUpper)
        {
            return file.GetFolderData(currentPath, "", toUpper);
        }
    }
}

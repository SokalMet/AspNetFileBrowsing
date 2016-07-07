using AspNetFileBrowsing.Controllers.Code;
using AspNetFileBrowsing.Models.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Web;
using System.Web.Http;

namespace AspNetFileBrowsing.Controllers
{
    public class FileController : ApiController
    {
       FileHelper file = new FileHelper();
        public FolderDataModel Get()
        {
            return file.GetFolderData();
        }
    }
}

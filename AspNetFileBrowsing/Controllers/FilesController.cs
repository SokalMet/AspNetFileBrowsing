using AspNetFileBrowsing.Code;
using AspNetFileBrowsing.Models.File;
using System.Web.Http;

namespace AspNetFileBrowsing.Controllers
{
    public class FilesController : ApiController
    { 
        public FolderDataModel Get(string currentPath="", string folderName="", bool toUpper=false)
        {
            return FileHelper.GetFolderData(currentPath, folderName, toUpper);
        }        
    }
}

using AspNetFileBrowsing.Models.File;
using System;
using System.IO;
using System.Web;
using System.Web.Http;

namespace AspNetFileBrowsing.Controllers
{
    public class FileController : ApiController
    {
        public FolderDataModel GetFolderData(string currentPath = "", string folderName = "", bool toUpper = false)
        {
            var path = ComputePath(currentPath, folderName, toUpper);
            return GetFolderDataByPath(path);
        }

        private static string ComputePath(string basePath, string folderName, bool toUpper)
        {
            var path = string.IsNullOrEmpty(basePath) 
                ? HttpContext.Current.Server.MapPath("~/") 
                : basePath;
            
            if (!string.IsNullOrEmpty(folderName))
                path = Path.Combine(basePath, folderName);

            if (toUpper)
                path = Directory.GetParent(path.TrimEnd('\\').TrimEnd('/')).FullName;

            return path;
        }

        private static FolderDataModel GetFolderDataByPath(string path)
        {
            var model = new FolderDataModel
            {
                CurrentPath = path,
                Status = ResponseStatus.Success
            };

            //TODO: check if the path is valid
            //if(NOT_VALID){model.Status = ResponseStatus.Failed; model.ErrorMessage = "Path is not valid: " + path;}
            //else{

            try
            {
                //TODO: get all files and folders names, filter files by size and get count of each group; fill the model
            }
            catch (Exception ex)
            {
                model.Status = ResponseStatus.Failed;
                model.ErrorMessage = "Message: " + ex.Message + (ex.InnerException != null ? "Inner exception message: " + ex.InnerException.Message : "");
            }
            //}

            return model;
        }
    }
}

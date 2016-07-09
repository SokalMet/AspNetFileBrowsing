using AspNetFileBrowsing.Models.File;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace AspNetFileBrowsing.Code
{
    public static class FileHelper
    {
        public static FolderDataModel GetFolderData(string currentPath = "", string folderName = "", bool toUpper = false)
        {
            var path = ComputePath(currentPath, folderName, toUpper);
            return GetFolderDataByPath(path);
        }

        public static string ComputePath(string basePath, string folderName, bool toUpper)
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

        public static FolderDataModel GetFolderDataByPath(string path)
        {
            var model = new FolderDataModel
            {
                CurrentPath = path,
                Status = ResponseStatus.Success
            };

            //checking - if the path is valid

            if (!Directory.Exists(path))
            {
                model.Status = ResponseStatus.Failed;
                model.ErrorMessage = "Path is not valid: " + path;
            }
            else
            {
                try
                {
                    //TODO: get all files and folders names, filter files by size and get count of each group; fill the model
                    var tempDir = new DirectoryInfo(path);
                    model.LessThan10Mb = tempDir.EnumerateFiles("*", SearchOption.AllDirectories).Count(file => file.Length/1024/1024 < 10)  ;
                    model.From10MbTo50Mb= tempDir.EnumerateFiles("*", SearchOption.AllDirectories).Count(file => file.Length / 1024/1024 >= 10 && file.Length / 1024/1024 <= 50);
                    model.MoreThan50Mb = tempDir.EnumerateFiles("*", SearchOption.AllDirectories).Count(file => file.Length / 1024 /1024 > 50);

                    model.Folders = Directory.GetDirectories(path, "*", SearchOption.TopDirectoryOnly).Select(x => x.Split('\\').Last()).ToList();
                    model.Files = Directory.GetFiles(path, "*", SearchOption.TopDirectoryOnly).Select(x => x.Split('\\').Last()).ToList();


                }
                catch (Exception ex)
                {
                    model.Status = ResponseStatus.Failed;
                    model.ErrorMessage = "Message: " + ex.Message + (ex.InnerException != null ? "Inner exception message: " + ex.InnerException.Message : "");
                }
            }

            return model;
        }
    }
}
using System.Collections.Generic;

namespace AspNetFileBrowsing.Models.File
{
    public class FolderDataModel
    {
        public string CurrentPath { get; set; }
        public bool CanGoUpper { get; set; }

        public int LessThan10Mb { get; set; }
        public int From10MbTo50Mb { get; set; }
        public int MoreThan50Mb { get; set; }

        public List<string> Folders { get; set; }
        public List<string> Files { get; set; }

        public ResponseStatus Status { get; set; }
        public string ErrorMessage { get; set; }
    }

    public enum ResponseStatus
    {
        Success,
        Failed
    }
}
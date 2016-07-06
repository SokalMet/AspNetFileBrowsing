using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspNetFileBrowsing.Models
{
    public class BrowserModel
    {
        public string CurrentPosition { get; set; }
        public bool BrowseUp { get; set; }
        public int LessTen { get; set; }
        public int TenToFifty { get; set; }
        public int MoreHundred { get; set; }
    }
}
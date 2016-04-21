using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utube.Models
{
    public class PageInfo
    {
        public int totalResults { get; set; }
        public int resultsPerPage { get; set; }
    }

    public class Item
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public string id { get; set; }
    }

    public class YoutubeSearch
    {
        public string kind { get; set; }
        public string etag { get; set; }
        public PageInfo pageInfo { get; set; }
        public List<Item> items { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolioWebsite.DAL.Entities
{
    public class BlogPost
    {
        public int BlogPostID { get; set; }
        public string Head { get; set; }
        public string Date { get; set; }
        public string Description { get; set; }
        public string Url { get; set; }
        public string UrlTitle { get; set; }
    }
}

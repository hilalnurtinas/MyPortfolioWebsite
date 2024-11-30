using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolioWebsite.DAL.Entities
{
    public class Reference
    {
        public int ReferenceID { get; set; }
        public string ReferenceName { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }

    }
}
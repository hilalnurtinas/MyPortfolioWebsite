﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolioWebsite.DAL.Entities
{
    public class SocialMedia
    {
        public int SocialMediaID { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string Icon {  get; set; }
        

    }
}
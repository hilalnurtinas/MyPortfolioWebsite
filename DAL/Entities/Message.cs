using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyPortfolioWebsite.DAL.Entities
{
    public class Message
    {
        public int MessageID{ get; set; } 
        public string SenderName { get; set; }
        public string Subject { get; set; }
        public string SenderEmail { get; set; }
        public string Detail { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsRead  { get; set; }
    }
}
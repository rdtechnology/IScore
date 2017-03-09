using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Iscore.WebSite.Models
{
    public class AdminModels
    {
    }

    public class BrandModel
    {
        public int? Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}
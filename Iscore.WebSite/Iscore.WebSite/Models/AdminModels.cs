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

    public class SizeModel
    {
        public int? Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class ColorModel
    {
        public int? Id { get; set; }
        public string code { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }

    public class CategoryModel
    {
        public int? Id { get; set; }
        public int? parentCatId { get; set; }
        public int? position { get; set; }
        public bool isParent { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }


}
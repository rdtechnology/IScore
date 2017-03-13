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

    public class UserModel {
        public int? Id { get; set; }
        public string name { get; set; }
        public string firstname { get; set; }
        public string middlename { get; set; }
        public string lastname { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string landline { get; set; }
        public string mobile { get; set; }
        public string fax { get; set; }
        public string role { get; set; }
        public bool isActive { get; set; }
        public UserLoginModel userlogin { get; set; }
        public List<AddressModel> address { get; set; }
    }

    public class UserLoginModel {
        public int? Id { get; set; }
        public string username { get; set; }
        public string password { get; set; }
        public bool canlogin { get; set; }
        public int? retryattempt { get; set; }
    }

    public class AddressModel {
        public int? Id { get; set; }
        public int? userId { get; set; }
        public string streetnumber { get; set; }
        public string streetaddress { get; set; }
        public string suburb { get; set; }
        public string city { get; set; }
        public string country { get; set; }
        public string postcode { get; set; }
        public string type { get; set; }

    }

}
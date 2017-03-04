using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Iscore.DataBase;

namespace Iscore.WebSite.Models
{
    public class SiteUtil
    {
        public static IscoreEntities NewDb
        {
            get
            {
                var db = new IscoreEntities();
                return db;
            }
        }

        public static User CurrentUser
        {
            get
            {
                if (!HttpContext.Current.Request.IsAuthenticated && HttpContext.Current.Session["CurrentUser"] == null)
                {
                    return null;
                }

                if (HttpContext.Current.Session["CurrentUser"] == null)
                {
                    //AccountController.ResetCurrentUserSession();
                }

                return (User)HttpContext.Current.Session["CurrentUser"];
            }

            set { HttpContext.Current.Session["CurrentUser"] = value; }
        }
    }
}
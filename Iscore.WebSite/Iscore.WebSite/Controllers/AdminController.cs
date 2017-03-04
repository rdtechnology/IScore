using Iscore.WebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Iscore.WebSite.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        #region LookUp
        public ActionResult LookUp()
        {

            return View();
        }

        [HttpGet]
        public JsonResult GetLookUps()
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var lookup = db.LookUps.Where(x => x.IsActive.Value).ToList();

                    return Json(lookup, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }

        [HttpPost]
        public JsonResult AddEditLookUps(int id, string code, object temp)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var lookup = db.LookUps.Where(x => x.IsActive.Value).ToList();

                    return Json(new { Success = true });
                }
            }
            catch (Exception e)
            {

                throw;
            }
        }
        #endregion
    }

    
}
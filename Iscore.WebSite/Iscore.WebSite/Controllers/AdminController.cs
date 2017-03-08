using Iscore.DataBase;
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
                    var lookup = db.LookUps.Where(x => x.IsActive.Value).OrderBy(x => x.EntityName).Select(x => new { Id = x.Id, EntityName = x.EntityName, Code = x.Code, Description = x.Description }).ToList();

                    return Json(new { data = lookup }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        [HttpPost]
        public JsonResult AddEditLookUps(int id, string code, string entityName, string description)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    // add new lookup
                    if (id == 0)
                    {
                        var newLookup = new LookUp()
                        {
                            Code = code,
                            EntityName = entityName,
                            Description = description,
                            CreatedBy = "Admin",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Admin",
                            UpdatedOn = DateTime.Now,
                            IsActive = true
                        };
                        db.LookUps.Add(newLookup);
                    }
                    // edit lookup
                    else
                    {
                        var lookup = db.LookUps.Where(x => x.IsActive.Value && x.Id == id).FirstOrDefault();
                        lookup.Code = code;
                        lookup.EntityName = entityName;
                        lookup.Description = description;
                        lookup.UpdatedBy = "Admin";
                        lookup.UpdatedOn = DateTime.Now;
                        lookup.IsActive = true;

                    }

                    db.SaveChanges();
                    return Json(new { Success = true });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, ErrorMessage = e.Message });
            }
        }

        [HttpPost]
        public JsonResult DisableLookUp(int id)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var lookup = db.LookUps.Where(x => x.IsActive.Value && x.Id == id).FirstOrDefault();

                    lookup.UpdatedBy = "Admin";
                    lookup.UpdatedOn = DateTime.Now;
                    lookup.IsActive = false;
                    
                    //db.SaveChanges();
                    return Json(new { Success = true });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, ErrorMessage = e.Message });
            }
        }
        #endregion

        public ActionResult Brand()
        {
            return View();
        }

        public JsonResult GetAllBrands()
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    //var lookup = db.LookUps.Where(x => x.IsActive.Value).OrderBy(x => x.EntityName).Select(x => new { Id = x.Id, EntityName = x.EntityName, Code = x.Code, Description = x.Description }).ToList();

                    return Json(new { data = "" }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

    }


}
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

        #region LookUp functions
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

        #region Brand functions
        public ActionResult Brand()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllBrands(string condition)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var brands = db.Brands.OrderByDescending(x => x.IsActive).ToList();

                    return Json(new { data = brands }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        [HttpPost]
        public JsonResult AddEditBrand(int id, BrandModel brand)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    if (brand.Id == 0)
                    {
                        var newBrand = new Brand
                        {
                            Code = brand.code,
                            Name = brand.name,
                            Description = brand.description,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Admin",
                            UpdatedOn = DateTime.Now
                        };
                        db.Brands.Add(newBrand);
                    }
                    else
                    {
                        var oldBrands = db.Brands.Where(x => x.Id == brand.Id).FirstOrDefault();
                        oldBrands.Code = brand.code;
                        oldBrands.Description = brand.description;
                        oldBrands.Name = brand.name;
                        oldBrands.IsActive = true;
                        oldBrands.UpdatedBy = "Admin";
                        oldBrands.UpdatedOn = DateTime.Now;
                    }

                    db.SaveChanges();
                    return Json(new { Success = true });
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, ErrorMessage = e.Message });
                throw;
            }
        }

        [HttpPost]
        public JsonResult DisableBrand(int id)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var brand = db.Brands.Where(x => x.IsActive.Value && x.Id == id).FirstOrDefault();

                    if (brand != null)
                    {
                        brand.UpdatedBy = "Admin";
                        brand.UpdatedOn = DateTime.Now;
                        brand.IsActive = false;

                        db.SaveChanges();
                        return Json(new { Success = true });
                    }
                    else
                    {
                        return Json(new { Success = false, ErrorMessage = "Brand can not Disable. There are some products still using current Brand." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, ErrorMessage = e.Message });
            }
        } 
        #endregion
    }


}
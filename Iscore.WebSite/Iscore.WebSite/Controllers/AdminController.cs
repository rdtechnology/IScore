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
        public JsonResult GetAllBrands()
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

        #region Size functions
        public ActionResult Size()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllSize()
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var brands = db.Sizes.OrderByDescending(x => x.IsActive).ToList();

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
        public JsonResult AddEditSize(int id, SizeModel size)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    if (size.Id == 0)
                    {
                        var newSize = new Size
                        {
                            Code = size.code,
                            Name = size.name,
                            Description = size.description,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Admin",
                            UpdatedOn = DateTime.Now
                        };
                        db.Sizes.Add(newSize);
                    }
                    else
                    {
                        var oldSize = db.Sizes.Where(x => x.Id == size.Id).FirstOrDefault();
                        oldSize.Code = size.code;
                        oldSize.Description = size.description;
                        oldSize.Name = size.name;
                        oldSize.IsActive = true;
                        oldSize.UpdatedBy = "Admin";
                        oldSize.UpdatedOn = DateTime.Now;
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
        public JsonResult DisableSize(int id)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var size = db.Sizes.Where(x => x.IsActive.Value && x.Id == id).FirstOrDefault();

                    if (size != null)
                    {
                        size.UpdatedBy = "Admin";
                        size.UpdatedOn = DateTime.Now;
                        size.IsActive = false;

                        db.SaveChanges();
                        return Json(new { Success = true });
                    }
                    else
                    {
                        return Json(new { Success = false, ErrorMessage = "Size can not Disable. There are some products still using current Size." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, ErrorMessage = e.Message });
            }
        }
        #endregion

        #region Color functions
        public ActionResult Color()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllColor()
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var brands = db.Colors.OrderByDescending(x => x.IsActive).ToList();

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
        public JsonResult AddEditColor(int id, ColorModel color)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    if (color.Id == 0)
                    {
                        var newColor = new Color
                        {
                            Code = color.code,
                            Name = color.name,
                            Description = color.description,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Admin",
                            UpdatedOn = DateTime.Now
                        };
                        db.Colors.Add(newColor);
                    }
                    else
                    {
                        var oldColor = db.Colors.Where(x => x.Id == color.Id).FirstOrDefault();
                        oldColor.Code = color.code;
                        oldColor.Description = color.description;
                        oldColor.Name = color.name;
                        oldColor.IsActive = true;
                        oldColor.UpdatedBy = "Admin";
                        oldColor.UpdatedOn = DateTime.Now;
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
        public JsonResult DisableColor(int id)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var color = db.Colors.Where(x => x.IsActive.Value && x.Id == id).FirstOrDefault();

                    if (color != null)
                    {
                        color.UpdatedBy = "Admin";
                        color.UpdatedOn = DateTime.Now;
                        color.IsActive = false;

                        db.SaveChanges();
                        return Json(new { Success = true });
                    }
                    else
                    {
                        return Json(new { Success = false, ErrorMessage = "Color can not Disable. There are some products still using current Color." });
                    }
                }
            }
            catch (Exception e)
            {
                return Json(new { Success = false, ErrorMessage = e.Message });
            }
        }
        #endregion

        #region Category functions
        public ActionResult Category()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetAllCategory()
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var category = db.Categories.OrderByDescending(x => x.IsActive).Select(x => new {
                        Id = x.Id,
                        ParentCategoryId = x.ParentCategoryId,
                        ParentCategory = x.Category2.Name,
                        Name = x.Name,
                        Description = x.Description,
                        Position = x.Position,
                        IsActive = x.IsActive,
                        IsParent = x.IsParent,
                    }).ToList();

                    return Json(new { data = category }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        public JsonResult GetAllActiveCategory()
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var category = db.Categories.Where(x => x.IsActive.Value).Select(x => new {
                        Id = x.Id,
                        ParentCategoryId = x.ParentCategoryId,
                        Name = x.Name,
                        Description = x.Description,
                        Position = x.Position,
                        IsParent = x.IsParent,
                    }).ToList();

                    return Json(new { data = category }, JsonRequestBehavior.AllowGet);
                }
            }
            catch (Exception e)
            {
                return null;
                throw;
            }
        }

        [HttpPost]
        public JsonResult AddEditCategory(int id, CategoryModel category)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    if (category.Id == 0)
                    {
                        var newCategory = new Category
                        {
                            IsParent = category.isParent,
                            ParentCategoryId = category.parentCatId,
                            Name = category.name,
                            Description = category.description,
                            IsActive = true,
                            CreatedBy = "Admin",
                            CreatedOn = DateTime.Now,
                            UpdatedBy = "Admin",
                            UpdatedOn = DateTime.Now
                        };
                        db.Categories.Add(newCategory);
                    }
                    else
                    {
                        var oldCategory = db.Categories.Where(x => x.Id == category.Id).FirstOrDefault();
                        oldCategory.ParentCategoryId = category.parentCatId;
                        oldCategory.IsParent = category.isParent;
                        oldCategory.Description = category.description;
                        oldCategory.Name = category.name;
                        oldCategory.IsActive = true;
                        oldCategory.UpdatedBy = "Admin";
                        oldCategory.UpdatedOn = DateTime.Now;
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
        public JsonResult DisableCategory(int id)
        {
            try
            {
                using (var db = SiteUtil.NewDb)
                {
                    var category = db.Categories.Where(x => x.IsActive.Value && x.Id == id).FirstOrDefault();

                    if (category != null)
                    {
                        category.UpdatedBy = "Admin";
                        category.UpdatedOn = DateTime.Now;
                        category.IsActive = false;

                        db.SaveChanges();
                        return Json(new { Success = true });
                    }
                    else
                    {
                        return Json(new { Success = false, ErrorMessage = "Category can not Disable. There are some products still using current Category." });
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
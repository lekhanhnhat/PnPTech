using Models.DAO;
using Models.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using System.Configuration;

namespace PNPGEAR.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        // GET: Admin/Product
        public ActionResult Index(string searchString, int page = 1, int pageSize = 10)
        {
            var dao = new ProductDao();

            var model = dao.ListAllPaging(searchString, page, pageSize);
            ViewBag.SeachString = searchString;
            return View(model);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product product,HttpPostedFileBase ImageFile)
        {
            if (ModelState.IsValid)
            {
                
                string filename = Path.GetFileNameWithoutExtension(product.ImageFile.FileName);
                string extension = Path.GetExtension(product.ImageFile.FileName);
                filename = filename + DateTime.Now.ToString("yymmssff") + extension;
                product.ProductImage = "~/Data/" + filename;
                filename = Path.Combine(Server.MapPath("~/Data/"), filename);
                product.ImageFile.SaveAs(filename);
                var dao = new ProductDao();
                long id = dao.Insert(product);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Them san pham khong thanh cong");
                }
            }
            return View("Index");
        }
        public ActionResult Details(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        public ActionResult Edit(int id)
        {
            var product = new ProductDao().ViewDetail(id);
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                var dao = new ProductDao();
                var result = dao.Update(product);
                if (result)
                {
                    return RedirectToAction("Index", "Product");
                }
                else
                {
                    ModelState.AddModelError("", "Cap nhat san pham khong thanh cong");
                }
            }
            return View("Index");
        }
    }
}
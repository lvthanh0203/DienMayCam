using DienMayCam.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DienMayCam.Models;
using PagedList;

namespace DienMayCam.Areas.Admin.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities1 = new WebsiteBanHangEntities();
        // GET: Admin/Product
        public ActionResult Index(string SearchString, string curentFilter, int? page)
        {
            var lstProduct = new List<Product>();
            if (SearchString != null) 
            {
                page = 1;
            }
            else
            {
                SearchString = curentFilter;
            }
            if (!string.IsNullOrEmpty(SearchString))
            {
                 lstProduct = objWebsiteBanHangEntities1.Product.Where(n => n.Name.Contains(SearchString)).ToList();
                
            }
            else
            {
                lstProduct = objWebsiteBanHangEntities1.Product.ToList();
            }
            ViewBag.currentFilter = SearchString;
            int pageSize = 4;
            int pageNumber = (page ?? 1);
            lstProduct = lstProduct.OrderByDescending(n => n.Id).ToList();
            
            
            return View(lstProduct.ToPagedList(pageNumber,pageSize));
        }
        public ActionResult Details(int Id)
        {
            var objProduct = objWebsiteBanHangEntities1.Product.Where(n=>n.Id==Id).FirstOrDefault();
            return View(objProduct);
        }
        [HttpGet]
        public ActionResult Create()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Create(Product objProduct)
        {
            try 
            {
            
                if (objProduct.ImageUpload != null)
                {
                    string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                    string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                    fileName = fileName  /*+ "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))*/ + extension;
                    objProduct.Avatar = fileName;
                    objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
                }
                objWebsiteBanHangEntities1.Product.Add(objProduct);
                objWebsiteBanHangEntities1.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int Id)
        {

            var objProduct = objWebsiteBanHangEntities1.Product.Where(n => n.Id == Id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Delete(Product objPro)
        {

            var objProduct = objWebsiteBanHangEntities1.Product.Where(n => n.Id == objPro.Id).FirstOrDefault();
            objWebsiteBanHangEntities1.Product.Remove(objProduct);
            objWebsiteBanHangEntities1.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int Id)
        {

            var objProduct = objWebsiteBanHangEntities1.Product.Where(n => n.Id == Id).FirstOrDefault();

            return View(objProduct);
        }
        [HttpPost]
        public ActionResult Edit(int Id, Product objProduct)
        {
            if (objProduct.ImageUpload != null)
            {
                string fileName = Path.GetFileNameWithoutExtension(objProduct.ImageUpload.FileName);
                string extension = Path.GetExtension(objProduct.ImageUpload.FileName);
                fileName = fileName  /*+ "_" + long.Parse(DateTime.Now.ToString("yyyyMMddhhmmss"))*/ + extension;
                objProduct.Avatar = fileName;
                objProduct.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/Content/images/"), fileName));
            }
            objWebsiteBanHangEntities1.Entry(objProduct).State = EntityState.Modified;
            objWebsiteBanHangEntities1.SaveChanges();

            return RedirectToAction("Index");
        }
    }
}
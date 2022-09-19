using DienMayCam.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DienMayCam.Controllers
{
    public class ProductController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities1 = new WebsiteBanHangEntities();

        // GET: Product
        public ActionResult Detail(int Id)
        {
            var objProduct = objWebsiteBanHangEntities1.Product.Where(n => n.Id == Id).FirstOrDefault();
            return View(objProduct);
        }
    }
}
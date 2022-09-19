using DienMayCam.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DienMayCam.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        WebsiteBanHangEntities objWebsiteBanHangEntities1 = new WebsiteBanHangEntities();
        // GET: Admin/Home
        public ActionResult Index()
        {
            if (Session["idUser"] != null)
            {
                var lstProduct = objWebsiteBanHangEntities1.Product.ToList();
                return View(lstProduct);
            }
            else
            return View("Login");
        }
    }
}
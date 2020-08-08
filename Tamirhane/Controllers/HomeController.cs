using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamirhane.Data;

namespace Tamirhane.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {

            //using (var ctx = new DataContext())
            //{
            //    var stud = new Musteri() { Isim = "Ali" };

            //    ctx.Musteris.Add(stud);
            //    ctx.SaveChanges();
            //}

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}
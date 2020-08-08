using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamirhane.Data;
using Tamirhane.Models;

namespace Tamirhane.Controllers
{
    public class AracController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Arac_Read([DataSourceRequest] DataSourceRequest request)
        {
            var ctx = new DataContext();

            var data = ctx.Aracs.ToList();

            var total = ctx.Aracs.Count();

            var result = new DataSourceResult()
            {
                Data = data,
                Total = total
            };

            return Json(result);
        }



        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Arac_Create([DataSourceRequest] DataSourceRequest request, AracModel arac)
        {
            if (arac != null && ModelState.IsValid)
            {

                using (var ctx = new DataContext())
                {
                    Arac row = new Arac()
                    {
                          Marka = arac.Marka,
                          Model = arac.Model,
                          ModelYili = arac.ModelYili,
                          Plaka = arac.Plaka
                    };

                    ctx.Aracs.Add(row);
                    ctx.SaveChanges();
                }

            }

            return Json(new[] { arac }.ToDataSourceResult(request, ModelState));
        }



        public JsonResult AracList_Get(string text)
        {

            using (var ctx = new DataContext())
            {
                var aracList = ctx.Aracs.Where(x => x.Plaka.Contains(text));

                var aracs = aracList.Select(arac => new AracViewModel
                {
                    Id = arac.Id,
                    Plaka = arac.Plaka 
                });


                return Json(aracs.ToList(), JsonRequestBehavior.AllowGet);
            }

        }
    }
}
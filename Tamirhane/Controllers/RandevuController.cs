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
    public class RandevuController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult New()
        {
            return View();
        }

        [HttpPost]
        public virtual ActionResult Edit(RandevuModel randevu)
        {

            if (randevu != null && ModelState.IsValid)
            {

                using (var ctx = new DataContext())
                {
                    Randevu row = new Randevu()
                    {
                        AracId = randevu.AracId,
                        MusteriId = randevu.MusteriId,
                        RandevuTarihi = randevu.RandevuTarihi,
                    };

                    ctx.Randevus.Add(row);
                    ctx.SaveChanges();
                }

            }

            return View("Index");
        }

        public ActionResult Randevu_Read([DataSourceRequest] DataSourceRequest request)
        {
            var ctx = new DataContext();

            var data = ctx.Randevus.ToList();

            var total = ctx.Randevus.Count();

            var result = new DataSourceResult()
            {
                Data = data,
                Total = total
            };

            return Json(result);
        }
    }
}
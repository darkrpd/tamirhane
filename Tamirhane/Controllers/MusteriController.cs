using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamirhane.Data;
using Tamirhane.Models;

namespace Tamirhane.Controllers
{

    public class MusteriController : Controller
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
        public virtual ActionResult Edit(MusteriModel musteri)
        {

            if (musteri != null && ModelState.IsValid)
            {

                using (var ctx = new DataContext())
                {
                    var aracs = ctx.Aracs.Where(x => musteri.Aracs.Contains(x.Id.ToString())).ToList();

                    Musteri row = new Musteri()
                    {
                        Email = musteri.Email,
                        Isim = musteri.Isim,
                        Soyisim = musteri.Soyisim,
                        Telefon = musteri.Telefon,
                        Aracs = aracs
                    };

                    ctx.Musteris.Add(row);
                    ctx.SaveChanges();
                }

            }

            return View("Index");
        }

        public ActionResult Musteri_Read([DataSourceRequest] DataSourceRequest request)
        {
            var ctx = new DataContext();

            var data = ctx.Musteris.ToList();

            var total = ctx.Musteris.Count();

            //var dataContext = new SampleEntities();

            // Convert to view model to avoid JSON serialization problems due to circular references.
            //IQueryable<OrderViewModel> orders = dataContext.Orders.Select(o => new OrderViewModel
            //{
            //    OrderID = o.OrderID,
            //    ShipCity = o.ShipCity,
            //    ShipCountry = o.ShipCountry,
            //    ShipName = o.ShipName
            //});

            //orders = orders.ApplyOrdersFiltering(request.Filters);

            //var total = orders.Count();

            //orders = orders.ApplyOrdersSorting(request.Groups, request.Sorts);

            //if (!request.Sorts.Any() && !request.Groups.Any())
            //{
            //    // Entity Framework doesn't support paging on unsorted data.
            //    orders = orders.OrderBy(o => o.OrderID);
            //}

            //orders = orders.ApplyOrdersPaging(request.Page, request.PageSize);

            //IEnumerable data = orders.ApplyOrdersGrouping(request.Groups);

            var result = new DataSourceResult()
            {
                Data = data,
                Total = total
            };

            return Json(result);
        }


        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Musteri_Create([DataSourceRequest] DataSourceRequest request, MusteriModel musteri)
        {
            if (musteri != null && ModelState.IsValid)
            {

                using (var ctx = new DataContext())
                {
                    Musteri row = new Musteri()
                    {
                        Email = musteri.Email,
                        Isim = musteri.Isim,
                        Soyisim = musteri.Soyisim,
                        Telefon = musteri.Telefon
                    };

                    ctx.Musteris.Add(row);
                    ctx.SaveChanges();
                }

            }

            return Json(new[] { musteri }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Musteri_Update([DataSourceRequest] DataSourceRequest request, MusteriModel musteri)
        {
            if (musteri != null && ModelState.IsValid)
            {
                using (var ctx = new DataContext())
                {

                }
            }

            return Json(new[] { musteri }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Musteri_Destroy([DataSourceRequest] DataSourceRequest request, MusteriModel musteri)
        {
            if (musteri != null)
            {
                using (var ctx = new DataContext())
                {

                }
            }

            return Json(new[] { musteri }.ToDataSourceResult(request, ModelState));
        }

    }
} 
using Kendo.Mvc.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Tamirhane.Data;

namespace Tamirhane.Controllers
{
    public class IsEmriController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult IsEmri_Read([DataSourceRequest] DataSourceRequest request)
        {
            var ctx = new DataContext();

            var data = ctx.IsEmris.ToList();

            var total = ctx.IsEmris.Count();

            var result = new DataSourceResult()
            {
                Data = data,
                Total = total
            };

            return Json(result);
        }
    }
}
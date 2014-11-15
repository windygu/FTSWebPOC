using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Scatter_ChartsController : Controller
    {
        public ActionResult Date_Axis()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _StockData()
        {
            return Json(ChartDataRepository.StockData());
        }
    }
}
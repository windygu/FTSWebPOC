using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class FinancialController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _BoeingStockData()
        {
            var db = new SampleEntities();

            return Json(
                from s in db.Stocks
                where s.Symbol == "BA"
                select new StockDataPoint
                {
                    Date = s.Date,
                    Open = s.Open,
                    High = s.High,
                    Low = s.Low,
                    Close = s.Close,
                    Volume = s.Volume
                }
            );
        }
    }
}
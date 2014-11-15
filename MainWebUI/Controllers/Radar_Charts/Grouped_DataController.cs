using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Radar_ChartsController : Controller
    {
        public ActionResult Grouped_Data()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _WindData()
        {
            return Json(ChartDataRepository.WindData());
        }
    }
}
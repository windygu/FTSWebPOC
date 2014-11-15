using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Scatter_ChartsController : Controller
    {
        public ActionResult Multiple_Axes()
        {
            return View(ChartDataRepository.EngineData());
        }
    }
}
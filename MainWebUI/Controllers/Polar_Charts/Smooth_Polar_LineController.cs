using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Polar_ChartsController : Controller
    {
        public ActionResult Smooth_Polar_Line()
        {
            return View(ChartDataRepository.SunPosition());
        }
    }
}
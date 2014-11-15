using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;
using System.Collections.Generic;

namespace FTS.MainWebUI.Controllers
{
    public partial class Funnel_ChartsController : Controller
    {
        public ActionResult Remote_Data_Binding()
        {   
            return View();
        }

        [HttpPost]
        public ActionResult SpainElectricityProduction()
        {
            return Json(ChartDataRepository.SpainElectricityProduction());
        }
    }
}
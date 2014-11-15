using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Line_ChartsController : Controller
    {
        public ActionResult Date_Axis()
        {
            return View(ChartDataRepository.DatePoints());
        }
    }
}
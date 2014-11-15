using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Step_Line_ChartsController : Controller
    {
        public ActionResult Notes()
        {
            return View(ChartDataRepository.GrandSlam());
        }
    }
}
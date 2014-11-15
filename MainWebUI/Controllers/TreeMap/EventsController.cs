using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class TreeMapController : Controller
    {
        public ActionResult Events()
        {
            return View();
        }

        public ActionResult _PopulationUSA()
        {
            return Json(TreeMapDataRepository.PopulationUSAData(), JsonRequestBehavior.AllowGet);
        }
    }
}
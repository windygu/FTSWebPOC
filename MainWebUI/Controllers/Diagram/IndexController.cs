using FTS.MainWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FTS.MainWebUI.Controllers
{
    public partial class DiagramController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult _OrgChart()
        {
            return Json(DiagramDataRepository.OrgChart(), JsonRequestBehavior.AllowGet);
        }
    }
}

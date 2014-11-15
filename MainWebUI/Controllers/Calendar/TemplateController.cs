using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FTS.MainWebUI.Controllers
{
    public partial class CalendarController : Controller
    {
        public ActionResult Template()
        {
            return View();
        }
    }
}
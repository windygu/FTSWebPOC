﻿using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Range_Bar_ChartsController : Controller
    {
        public ActionResult Remote_Data_Binding()
        {
            return View();
        }

        [HttpPost]
        public ActionResult _DownloadSpeeds()
        {
            return Json(ChartDataRepository.DownloadSpeeds());
        }
    }
}

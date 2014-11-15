﻿using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class SparklinesController : Controller
    {
        public ActionResult Local_Data_Binding()
        {
            return View(ChartDataRepository.CompensationData());
        }
    }
}
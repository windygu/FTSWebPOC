﻿using System;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class Donut_ChartsController : Controller
    {
        public ActionResult Local_Data_Binding()
        {
            return View(ChartDataRepository.SpainElectricityBreakdown());
        }
    }
}
﻿using System.Collections.Generic;
using System.Web.Mvc;
using FTS.MainWebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System.Linq;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {
        public ActionResult Filter_Menu_Customization()
        {            
            return View();
        }

        public ActionResult FilterMenuCustomization_Read([DataSourceRequest] DataSourceRequest request)
        {
            return Json(GetEmployees().ToDataSourceResult(request));
        }

        public ActionResult FilterMenuCustomization_Cities()
        {
            var db = new SampleEntities();
            return Json(db.Employees.Select(e => e.City).Distinct(), JsonRequestBehavior.AllowGet);
        }

        public ActionResult FilterMenuCustomization_Titles()
        {
            var db = new SampleEntities();
            return Json(db.Employees.Select(e => e.Title).Distinct(), JsonRequestBehavior.AllowGet);
        } 
    }
}

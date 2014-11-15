﻿using System.Web.Mvc;

namespace FTS.MainWebUI.Controllers
{
    public partial class PivotGridController
    {
        public ActionResult Local_Flat_Data_Binding()
        {
            var model = productService.Read();

            return View(model);
        }
    }
}

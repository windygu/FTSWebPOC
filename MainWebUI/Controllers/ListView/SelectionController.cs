using System.Collections.Generic;
using System.Data.Linq;
using System.Linq;
using System.Web.Mvc;
using FTS.MainWebUI.Models;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using System;

namespace FTS.MainWebUI.Controllers
{
    public partial class ListViewController : Controller
    {
        public ActionResult Selection()
        {
            return View(GetProducts());
        }        
    }
}
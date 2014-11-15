using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {       
        public ActionResult ServerHierarchy()
        {
            return View(new SampleEntities().Employees);
        }
    }
}
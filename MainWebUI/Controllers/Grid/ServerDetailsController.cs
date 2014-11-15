using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {        
        public ActionResult ServerDetails()
        {
            return View(new SampleEntities().Employees);
        }
    }
}
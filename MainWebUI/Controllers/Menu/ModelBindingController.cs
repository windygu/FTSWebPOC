using FTS.MainWebUI.Models;
using System.Web.Mvc;
using System.Linq;

namespace FTS.MainWebUI.Controllers
{
    public partial class MenuController : Controller
    {
        public ActionResult ModelBinding()
        {
            SampleEntities northwind = new SampleEntities();
            return View(northwind.Categories);
        }
    }
}

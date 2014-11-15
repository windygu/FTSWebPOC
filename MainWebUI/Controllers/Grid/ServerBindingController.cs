using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {
        public ActionResult ServerBinding()
        {
            return View(new SampleEntities().Products);
        }
    }
}

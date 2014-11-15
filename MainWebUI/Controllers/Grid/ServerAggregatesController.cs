using System.Web.Mvc;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {
        public ActionResult ServerAggregates()
        {
            return View(new SampleEntities().Products);
        }       
    }
}

using System.Web.Mvc;
using System.Linq;
using FTS.MainWebUI.Models;

namespace FTS.MainWebUI.Controllers
{
    public partial class GridController : Controller
    {
        public ActionResult ServerRowTemplate()
        {
            return View(new SampleEntities().Customers);
        }
    }
}

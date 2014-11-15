namespace FTS.MainWebUI.Controllers
{
    using System.Web.Mvc;
    using Kendo.Mvc.UI;
    using Kendo.Mvc.Extensions;
    using FTS.MainWebUI.Models.Scheduler;

    public partial class SchedulerController
    {
        public ActionResult Api()
        {
            return View();
        }
    }
}

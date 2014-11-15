using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using FTS.BaseBusiness.Systems;

namespace FTS.InvesterInfoWeb
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801

    public class MvcApplication : System.Web.HttpApplication
    {

        private FTSMainWeb _ftsMainWeb;
        public FTSMainWeb FTSMain
        {
            get
            {
                if (_ftsMainWeb == null)
                {
                    _ftsMainWeb = new FTSMainWeb();
                    _ftsMainWeb.RunWebPOC();
                }
                return _ftsMainWeb;
            }
        }

        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
            
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        protected void Application_Start()
        {
            Application[StaticConst.FTS_MAIN] = FTSMain;
            AreaRegistration.RegisterAllAreas();
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
    }
}
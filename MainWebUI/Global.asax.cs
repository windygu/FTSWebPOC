using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.SessionState;
using FTS.BaseBusiness.Systems;
using Microsoft.Ajax.Utilities;

namespace FTS.MainWebUI
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
                   // _ftsMainWeb.RunWeb();
                }
                return _ftsMainWeb;
            }
        }
        
        protected void Application_Start()
        {
            Application[StaticWeb.FTS_MAIN] = FTSMain;

            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            ModelBinderConfig.RegisterModelBinders(ModelBinders.Binders);
            ViewEngineConfig.RegisterViewEngines(ViewEngines.Engines);
            


        }

    }
}
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace FTS.MainWebUI
{
    public static class StaticMain
    {
        public static FTSMainWeb FTSMain()
        {
            return (FTSMainWeb) HttpContext.Current.Application[StaticWeb.FTS_MAIN];
        } 
    }
}
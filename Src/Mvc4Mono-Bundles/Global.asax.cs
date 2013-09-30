using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace WebApplication4
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AreaRegistration.RegisterAllAreas();
            this.RegisterFilters(GlobalFilters.Filters);
            this.RegisterRoutes(RouteTable.Routes);
            this.RegisterBundles(BundleTable.Bundles);
        }

        private void RegisterFilters(GlobalFilterCollection filters)
        { 
            GlobalFilters.Filters.Add(new HandleErrorAttribute());
        }

        private void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
               name: "Default",
               url: "{controller}/{action}/{id}",
               defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }

        private void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js").IncludeDirectory("~/Content/js/", "*.js", true));

            bundles.Add(new StyleBundle("~/css").IncludeDirectory("~/Content/css/", "*.css", true));
        }
    }
}
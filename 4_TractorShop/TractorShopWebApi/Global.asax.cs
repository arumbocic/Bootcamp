using Autofac;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TractorShop.Repository;
using TractorShop.Repository.Common;
using TractorShop.Service;
using TractorShop.Service.Common;
using System.Web;

namespace TractorShopWebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            IocConfig.Configure();
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


        }
    }
}

using Autofac;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using TractorShop.Repository;
using TractorShop.Repository.Common;
using TractorShop.Service;
using TractorShop.Service.Common;

namespace TractorShopWebApi
{
    public class WebApiApplication : HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public IContainer Configure()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<TractorModelRepository>().As<ITractorModelRepository>();
            builder.RegisterType<TractorModelService>().As<ITractorModelService>();

            return builder.Build();
        }

    }
}

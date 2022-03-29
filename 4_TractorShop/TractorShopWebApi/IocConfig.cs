using Autofac;
using Autofac.Integration.WebApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using TractorShop.Repository;
using TractorShop.Repository.Common;
using TractorShop.Service;
using TractorShop.Service.Common;

namespace TractorShopWebApi
{
    public class IocConfig
    {
        public static void Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            builder.RegisterType<CustomerRepository>().As<ICustomerRepository>();
            builder.RegisterType<CustomerService>().As<ICustomerService>();
            builder.RegisterType<TractorModelRepository>().As<ITractorModelRepository>();
            builder.RegisterType<TractorModelService>().As<ITractorModelService>();

            var container = builder.Build();
            var resolver = new AutofacWebApiDependencyResolver(container);
            GlobalConfiguration.Configuration.DependencyResolver = resolver;
        }
    }
}
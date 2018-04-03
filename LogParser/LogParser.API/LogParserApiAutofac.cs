using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Autofac;
using Autofac.Integration.WebApi;

namespace LogParser
{
    class LogParserApiAutofac
    {
        public static void Configure(HttpConfiguration config)
        {
            var builder = new ContainerBuilder();

            Autofac.Autofac.RegisterTypes(builder);

            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());

            var container = builder.Build();

            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}

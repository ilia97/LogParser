using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser
{
    class LogParserAutofac
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();

            Autofac.Autofac.RegisterTypes(builder);

            return builder.Build();
        }
    }
}

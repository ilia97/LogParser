using Autofac;
using LogParser.Core.Services;
using LogParser.Core.Services.Interfaces;
using LogParser.DataAccess;
using LogParser.DataAccess.Repository;
using LogParser.DataAccess.UnitOfWork;
using LogParser.LocationDefiner;

namespace LogParser.Autofac
{
    public class Autofac
    {
        public static void RegisterTypes(ContainerBuilder builder)
        {
            builder.RegisterType<LogParserContext>().AsSelf().InstancePerLifetimeScope();

            builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            
            builder.RegisterType<IpApiLocationDefiner>().As<ILocationDefiner>().InstancePerLifetimeScope();

            builder.RegisterType<LogService>().As<ILogService>().InstancePerLifetimeScope();
            builder.RegisterType<ParserService>().As<IParserService>().InstancePerLifetimeScope();
        }
    }
}

using AutoMapper;
using LogParser.Core.Models;
using LogParser.DataAccess.Entities;

namespace LogParser.AutoMapper
{
    public class AutoMapper
    {
        public static void MapTypes(IMapperConfigurationExpression config)
        {
            config.CreateMap<RequestEntity, Request>().PreserveReferences();
            config.CreateMap<Request, RequestEntity>().PreserveReferences();

            config.CreateMap<ServerEntity, Server>().PreserveReferences();
            config.CreateMap<Server, ServerEntity>().PreserveReferences();

            config.CreateMap<RequestParameterEntity, RequestParameter>().PreserveReferences();
            config.CreateMap<RequestParameter, RequestParameterEntity>().PreserveReferences();
        }
    }
}

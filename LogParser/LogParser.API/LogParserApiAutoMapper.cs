using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using LogParser.API.ViewModels.Log;
using LogParser.Core.Models;

namespace LogParser
{
    class LogParserApiAutoMapper
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<KeyValuePair<string, int>, HostsViewModel>()
                    .ForMember("IpAddress", opt => opt.MapFrom(c => c.Key))
                    .ForMember("RequestsCount", opt => opt.MapFrom(c => c.Value));

                cfg.CreateMap<KeyValuePair<string, int>, RoutesViewModel>()
                    .ForMember("Route", opt => opt.MapFrom(c => c.Key))
                    .ForMember("RequestsCount", opt => opt.MapFrom(c => c.Value));

                cfg.CreateMap<Request, LogsViewModel>()
                    .ForMember("IpAddress", opt => opt.MapFrom(c => c.Server.IpAddress))
                    .ForMember("Geolocation", opt => opt.MapFrom(c => c.Server.Geolocation))
                    .ForMember("RequestParameters", opt => opt.MapFrom(c => c.RequestParameters.ToDictionary(x => x.ParameterName, x => x.ParameterValue)));

                AutoMapper.AutoMapper.MapTypes(cfg);
            });
        }
    }
}

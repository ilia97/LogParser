using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;
using AutoMapper;
using LogParser.API.ViewModels.Log;
using LogParser.Core.Models;
using LogParser.Core.Services.Interfaces;

namespace LogParser.API.Controllers
{
    public class LogsController : ApiController
    {
        private readonly ILogService _logService;

        public LogsController(ILogService logService)
        {
            _logService = logService;
        }

        [Route("hosts")]
        public async Task<IList<HostsViewModel>> GetHosts(int n = 10, DateTime? start = null, DateTime? end = null)
        {
            var hosts = await _logService.GetHosts(n, start, end);

            var viewModel = Mapper.Map<IDictionary<string, int>, IList<HostsViewModel>>(hosts);

            return viewModel;
        }

        [Route("routes")]
        public async Task<IList<RoutesViewModel>> GetRoutes(int n = 10, DateTime? start = null, DateTime? end = null)
        {
            var routes = await _logService.GetRoutes(n, start, end);

            var viewModel = Mapper.Map<IDictionary<string, int>, IList<RoutesViewModel>>(routes);

            return viewModel;
        }

        [Route("logs")]
        public async Task<IList<LogsViewModel>> GetLogs(int offset = 0, int limit = 10, DateTime? start = null, DateTime? end = null)
        {
            var logs = await _logService.GetRequests(offset, limit, start, end);

            var viewModel = Mapper.Map<IList<Request>, IList<LogsViewModel>>(logs);

            return viewModel;
        }
    }
}

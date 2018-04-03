using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LogParser.Core.Models;
using LogParser.Core.Services.Interfaces;
using LogParser.DataAccess.Entities;
using LogParser.DataAccess.UnitOfWork;

namespace LogParser.Core.Services
{
    public class LogService : ILogService
    {
        private readonly IUnitOfWork _unitOfWork;

        public LogService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Dictionary<string, int>> GetHosts(int n, DateTime? start, DateTime? end)
        {
            return (await _unitOfWork.RequestRepository
                .Get(x => x.Date >= (start ?? DateTime.MinValue) &&
                        x.Date <= (end ?? DateTime.MaxValue)))
                .GroupBy(x => x.ServerIpAddress)
                .OrderByDescending(x => x.Count())
                .Take(n)
                .ToDictionary(x => x.Key, x => x.Count());
        }

        public async Task<IList<Request>> GetRequests(int offset, int limit, DateTime? start, DateTime? end)
        {
            var requests = (await _unitOfWork.RequestRepository
                .Get(x => x.Date >= (start ?? DateTime.MinValue) &&
                        x.Date <= (end ?? DateTime.MaxValue)))
                .OrderBy(x => x.Date)
                .Skip(offset)
                .Take(limit)
                .ToList();

            return Mapper.Map<IList<RequestEntity>, IList<Request>>(requests);
        }

        public async Task<Dictionary<string, int>> GetRoutes(int n, DateTime? start, DateTime? end)
        {
            return (await _unitOfWork.RequestRepository
                .Get(x => x.Date >= (start ?? DateTime.MinValue) &&
                        x.Date <= (end ?? DateTime.MaxValue)))
                .GroupBy(x => x.ServerIpAddress + x.Url)
                .OrderByDescending(x => x.Count())
                .Take(n)
                .ToDictionary(x => x.Key, x => x.Count());
        }
    }
}

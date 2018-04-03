using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using LogParser.Core.Models;

namespace LogParser.Core.Services.Interfaces
{
    public interface ILogService
    {
        Task<Dictionary<string, int>> GetHosts(int n, DateTime? start, DateTime? end);

        Task<Dictionary<string, int>> GetRoutes(int n, DateTime? start, DateTime? end);

        Task<IList<Request>> GetRequests(int offset, int limit, DateTime? start, DateTime? end);
    }
}

using System.Threading.Tasks;

namespace LogParser.Core.Services.Interfaces
{
    public interface IParserService
    {
        Task ParseLogs(string logs);
    }
}

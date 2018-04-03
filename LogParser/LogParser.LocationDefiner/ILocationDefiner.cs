using System.Threading.Tasks;

namespace LogParser.LocationDefiner
{
    public interface ILocationDefiner
    {
        Task<string> Define(string ipAddress);
    }
}

using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace LogParser.LocationDefiner
{
    public class IpApiLocationDefiner : ILocationDefiner
    {
        public async Task<string> Define(string ipAddress)
        {
            using (var client = new HttpClient())
            {
                var responseString = await client.GetStringAsync($"http://ip-api.com/json/{ipAddress}");

                var json = JsonConvert.DeserializeObject<dynamic>(responseString);

                if ((string)json.status == "success")
                {
                    return (string)json.country;
                }

                return null;
            }
        }
    }
}
